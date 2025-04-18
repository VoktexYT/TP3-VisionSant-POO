// ----------------------
// Program.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------

namespace TP3_VisionSante
{
    /// <summary>
    /// Classe principale du programme VisionSanté.
    /// Gère le cycle de vie principal de l'application et le chargement des données.
    /// </summary>
    internal static class Program
    {
        // Données principales du système
        private static readonly List<Citoyen> _citoyens = new();
        private static readonly List<Professionnel> _professionnels = new();
        private static readonly List<Blessure> _blessures = new();
        private static readonly List<Maladie> _maladies = new();
        private static readonly List<RendezVous> _rendezVous = new();
        private static readonly List<Hospitalisation> _hospitalisation = new();

        // Tailles des lignes attendues dans les fichiers
        private const int _TAILLE_LIGNE_CITOYEN = 3;
        private const int _TAILLE_LIGNE_PROFESSIONNEL = 5;
        private const int _TAILLE_LIGNE_BLESSURE = 5;
        private const int _TAILLE_LIGNE_MALADIE = 6;
        private const int _TAILLE_LIGNE_RENDEZ_VOUS = 4;
        private const int _TAILLE_LIGNE_HOSPITALISATION = 6;

        // Chemins vers les fichiers de données
        // private const string _CHEMIN_FICHIER_POPULATION =
        //     "C:\\Users\\Ubert Guertin\\Desktop\\TP3-VisionSant-POO\\TP3_VisionSante\\donnees\\population.txt";
        //
        // private const string _CHEMIN_FICHIER_PROBLEMES =
        //     "C:\\Users\\Ubert Guertin\\Desktop\\TP3-VisionSant-POO\\TP3_VisionSante\\donnees\\problemes.txt";
        //
        // private const string _CHEMIN_FICHIER_UTILISATIONS =
        //     "C:\\Users\\Ubert Guertin\\Desktop\\TP3-VisionSant-POO\\TP3_VisionSante\\donnees\\utilisations.txt";
        
        private const string _CHEMIN_FICHIER_POPULATION =
            "/home/voktex/RiderProjects/TP3-VisionSant-POO/TP3_VisionSante/donnees/population.txt";

        private const string _CHEMIN_FICHIER_PROBLEMES =
            "/home/voktex/RiderProjects/TP3-VisionSant-POO/TP3_VisionSante/donnees/problemes.txt";

        private const string _CHEMIN_FICHIER_UTILISATIONS =
            "/home/voktex/RiderProjects/TP3-VisionSant-POO/TP3_VisionSante/donnees/utilisations.txt";

        private const char _SEPARATEUR_FICHIER_DONNEES = ';';

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// Charge les données et affiche le menu principal.
        /// </summary>
        /// <param name="args">Arguments de la ligne de commande (non utilisés).</param>
        private static void Main(string[] args)
        {
            MettreAJourDonnees();
            AfficherMenuIntroduction();
        }

        /// <summary>
        /// Affiche le menu principal permettant de naviguer dans les profils.
        /// </summary>
        private static void AfficherMenuIntroduction()
        {
            Utilitaires.AfficherEnTete();

            Menu menu = new Menu("Profils offerts");
            menu.AjouterOption(new MenuItem('C', "Profil citoyen", _ProfilCitoyen));
            menu.AjouterOption(new MenuItem('P', "Profil professionnel de la santé", _ProfilProfessionnelSante));
            menu.AjouterOption(new MenuItem('A', "Afficher professionnels de la santé", AfficherProfessionnel));
            menu.AjouterOption(new MenuItem('B', "Afficher citoyens", AfficherCitoyen));

            menu.SaisirOption();
        }

        /// <summary>
        /// Met à jour l'ensemble des données à partir des fichiers.
        /// </summary>
        private static void MettreAJourDonnees()
        {
            Console.WriteLine("Chargement de la base de données POPULATION");
            _RepartirPopulation();

            Console.WriteLine("Chargement de la base de données PROBLEME");
            _RepartirProbleme();

            Console.WriteLine("Chargement de la base de données UTILISATION");
            _RepartirUtilisations();

            Console.WriteLine("Mise à jour du dossier santé de chaque patient");
            _RepartirProblemePatient();

            Console.WriteLine("Mise a jour du dossier ressource de chaque patient");
            _RepartirUtilisationPatient();

            Console.WriteLine("Mise à jour du dossier professionnel de chaque professionnel");
            _RepartirPatientAvecProfessionnel();

            Console.WriteLine("Mise à jour du dossier intervention de chaque professionnel");
            _RepartirInterventionAvecProfessionnel();

            Utilitaires.ViderEcran();
        }

        /// <summary>
        /// Affiche les codes PS de tous les professionnels.
        /// </summary>
        private static void AfficherProfessionnel()
        {
            foreach (var professionnel in _professionnels)
            {
                Console.Write($"[{professionnel.CodePS}] ");
            }

            Utilitaires.Pause();
        }

        /// <summary>
        /// Affiche les NAS de tous les citoyens.
        /// </summary>
        private static void AfficherCitoyen()
        {
            foreach (var citoyen in _citoyens)
            {
                Console.Write($"[{citoyen.NAS,-4}] ");
            }

            Utilitaires.Pause();
        }

        /// <summary>
        /// Associe chaque patient à son ou ses professionnels de la santé via les rendez-vous.
        /// </summary>
        private static void _RepartirPatientAvecProfessionnel()
        {
            var citoyensParNAS = _citoyens.ToDictionary(c => c.NAS);
            var professionnelsParCode = _professionnels.ToDictionary(p => p.CodePS);

            foreach (RendezVous rv in _rendezVous)
            {
                if (citoyensParNAS.TryGetValue(rv.NAS, out var citoyen)
                    && professionnelsParCode.TryGetValue(rv.CodePS, out var professionnel))
                {
                    professionnel.Patients.Add(citoyen);
                }
            }
        }

        /// <summary>
        /// Associe les interventions (rendez-vous, hospitalisations) aux professionnels concernés.
        /// </summary>
        private static void _RepartirInterventionAvecProfessionnel()
        {
            var rendezVousParCodePS = _rendezVous
                .GroupBy(rv => rv.CodePS)
                .ToDictionary(g => g.Key, g => g.ToList());

            var hospitalisationParCodePS = _hospitalisation
                .GroupBy(h => h.CodePS)
                .ToDictionary(h => h.Key, g => g.ToList());

            foreach (Professionnel professionnel in _professionnels)
            {
                if (hospitalisationParCodePS.TryGetValue(professionnel.CodePS, out var hosp))
                {
                    professionnel.Hospitalisations.AddRange(hosp);
                }

                if (rendezVousParCodePS.TryGetValue(professionnel.CodePS, out var rvs))
                {
                    professionnel.RendezVous_.AddRange(rvs);
                }
            }
        }

        /// <summary>
        /// Associe les utilisations des ressources (rendez-vous, hospitalisations) à chaque citoyen.
        /// </summary>
        private static void _RepartirUtilisationPatient()
        {
            var hospitalisationsParNAS = _hospitalisation
                .GroupBy(h => h.NAS)
                .ToDictionary(g => g.Key, g => g.ToList());

            var rendezVousParNAS = _rendezVous
                .GroupBy(r => r.NAS)
                .ToDictionary(g => g.Key, g => g.ToList());

            foreach (Citoyen c in _citoyens)
            {
                int nas = c.NAS ?? -1;

                if (nas != -1)
                {
                    if (hospitalisationsParNAS.TryGetValue(nas, out var hosp))
                    {
                        c.Hospitalisations.AddRange(hosp);
                    }

                    if (rendezVousParNAS.TryGetValue(nas, out var rvs))
                    {
                        c.RendezVous_.AddRange(rvs);
                    }
                }
            }
        }

        /// <summary>
        /// Associe les problèmes de santé (blessures, maladies) à chaque citoyen.
        /// </summary>
        private static void _RepartirProblemePatient()
        {
            var blessuresParNas = _blessures.GroupBy(b => b.NAS).ToDictionary(g => g.Key, g => g.ToList());
            var maladiesParNas = _maladies.GroupBy(m => m.NAS).ToDictionary(g => g.Key, g => g.ToList());

            foreach (Citoyen c in _citoyens)
            {
                int nas = c.NAS ?? -1;

                if (nas != -1)
                {
                    if (blessuresParNas.TryGetValue(nas, out var bls))
                    {
                        c.Blessures.AddRange(bls);
                    }

                    if (maladiesParNas.TryGetValue(nas, out var mls))
                    {
                        c.Maladies.AddRange(mls);
                    }
                }
            }
        }

        /// <summary>
        /// Lit les données d'utilisation depuis un fichier et crée les objets correspondants (rendez-vous ou hospitalisations).
        /// </summary>
        private static void _RepartirUtilisations()
        {
            List<List<string>> listeUtilisations = Utilitaires.ChargerFichier(_CHEMIN_FICHIER_UTILISATIONS, _SEPARATEUR_FICHIER_DONNEES);
            int barProgression = 0;
            int tailleBarProgression = 10;
            
            
            (int, int) positionCurseurInitial = Console.GetCursorPosition();
            
            // 2/34 = ?/10
            // 
            //
            
            foreach (List<string> utilisation in listeUtilisations)
            {
                Console.SetCursorPosition(positionCurseurInitial.Item1, positionCurseurInitial.Item2);
                Console.WriteLine("          ");
                Console.SetCursorPosition(positionCurseurInitial.Item1, positionCurseurInitial.Item2);
                Console.WriteLine($"{barProgression * 100 / listeUtilisations.Count} %");

                (int nas, string codePS, string etablissement, string date) =
                (int.Parse(utilisation[0]), utilisation[1], utilisation[2], utilisation[3]);

                switch (utilisation.Count)
                {
                    case _TAILLE_LIGNE_RENDEZ_VOUS:
                        RendezVous rendezVous = new RendezVous(nas, codePS, etablissement, date, _citoyens);
                        _rendezVous.Add(rendezVous);
                        break;

                    case _TAILLE_LIGNE_HOSPITALISATION:
                        (string dateFin, int noChambre) = (utilisation[4], int.Parse(utilisation[5]));
                        Hospitalisation hospitalisation = new Hospitalisation(nas, codePS, etablissement, date, _citoyens, dateFin, noChambre);
                        _hospitalisation.Add(hospitalisation);
                        break;
                }

                barProgression++;
            }
        }

        /// <summary>
        /// Lit les problèmes de santé depuis un fichier et crée les objets correspondants (blessures ou maladies).
        /// </summary>
        private static void _RepartirProbleme()
        {
            List<List<string>> listeProblemes = Utilitaires.ChargerFichier(_CHEMIN_FICHIER_PROBLEMES, _SEPARATEUR_FICHIER_DONNEES);

            foreach (List<string> probleme in listeProblemes)
            {
                if (probleme.Count != _TAILLE_LIGNE_MALADIE && probleme.Count != _TAILLE_LIGNE_BLESSURE) continue;

                (int nas, string type, string dateDebut, string dateFin, string description) =
                    (int.Parse(probleme[0]), probleme[1], probleme[2], probleme[3], probleme[4]);

                switch (probleme.Count)
                {
                    case _TAILLE_LIGNE_BLESSURE:
                        _blessures.Add(new Blessure(nas, type, dateDebut, dateFin, description));
                        break;

                    case _TAILLE_LIGNE_MALADIE:
                        int stade = int.Parse(probleme[5]);
                        _maladies.Add(new Maladie(nas, type, dateDebut, dateFin, description, stade));
                        break;
                }
            }
        }

        /// <summary>
        /// Lit les données de la population et crée des objets Citoyen ou Professionnel.
        /// </summary>
        private static void _RepartirPopulation()
        {
            List<List<string>> listePopulation = Utilitaires.ChargerFichier(_CHEMIN_FICHIER_POPULATION, _SEPARATEUR_FICHIER_DONNEES);

            foreach (List<string> population in listePopulation)
            {
                (int nas, string nom, string dateNaissance) =
                (int.Parse(population[0]), population[1], population[2]);

                switch (population.Count)
                {
                    case _TAILLE_LIGNE_CITOYEN:
                        Citoyen citoyen = new Citoyen(nas, population[1], dateNaissance);
                        _citoyens.Add(citoyen);
                        break;

                    case _TAILLE_LIGNE_PROFESSIONNEL:
                        (string codePS, string titreProfessionnel) = (population[3], population[4]);
                        Professionnel professionnel = new Professionnel(nas, nom, dateNaissance, codePS, titreProfessionnel);
                        _professionnels.Add(professionnel);
                        break;
                }
            }
        }

        /// <summary>
        /// Affiche le profil détaillé d’un citoyen selon son NAS.
        /// </summary>
        private static void _ProfilCitoyen()
        {
            Utilitaires.AfficherEnTete();

            Console.Write("NAS du citoyen désiré: ");
            string? nasStr = Console.ReadLine();

            if (nasStr is string)
            {
                int NAS = int.Parse(nasStr);

                foreach (Citoyen citoyen in _citoyens)
                {
                    if (citoyen.NAS == NAS)
                    {
                        citoyen.AfficherSommaire();
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Affiche le profil détaillé d’un professionnel de la santé selon son code PS.
        /// </summary>
        private static void _ProfilProfessionnelSante()
        {
            Utilitaires.AfficherEnTete();

            Console.Write("Code PS du professionnel désiré: ");
            string? codePsStr = Console.ReadLine();

            if (codePsStr is string)
            {
                foreach (Professionnel professionnel in _professionnels)
                {
                    if (professionnel.CodePS == codePsStr)
                    {
                        professionnel.AfficherSommaire();
                        break;
                    }
                }
            }

            Utilitaires.Pause();
        }
    }
}
