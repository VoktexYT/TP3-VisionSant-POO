using System.Runtime.InteropServices.JavaScript;

namespace Tp3_VisionSante;

internal static class Program
{
    private static List<Citoyen> _citoyens = new List<Citoyen>();
    private static List<Professionnel> _professionnels = new List<Professionnel>();
    
    private static List<Blessure> _blessures = new List<Blessure>();
    private static List<Maladie> _maladies = new List<Maladie>();

    private static List<RendezVous> _rendezVous = new List<RendezVous>();
    private static List<Hospitalisation> _hospitalisation = new List<Hospitalisation>();

    private const int TAILLE_LIGNE_CITOYEN = 3;
    private const int TAILLE_LIGNE_PROFESSIONNEL = 5;
    
    private const int TAILLE_LIGNE_BLESSURE = 5;
    private const int TAILLE_LIGNE_MALADIE = 6;
    
    private const int TAILLE_LIGNE_RENDEZ_VOUS = 4;
    private const int TAILLE_LIGNE_HOSPITALISATION = 6;
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Chargement de la base de données POPULATION");
        _RepartirPopulation();

        Console.WriteLine("Chargement de la base de données PROBLEME");
        _RepartirProbleme();
        
        Console.WriteLine("Chargement de la base de données UTILISATION");
        _RepartirUtilisations();

        Console.WriteLine("Mise a jour du dosser santé de chaque patient");
        _RepartirProblemePatient();
        
        Console.WriteLine("Mise a jour du dosser ressource de chaque patient");
        _RepartirUtilisationPatient();
        
        Console.WriteLine("Mise a jour du dosser professionnel de chaque professionnel");
        _RepartirPatientAvecProfessionnel();
        
        Console.WriteLine("Mise a jour du dosser intervention de chaque professionnel");
        _RepartirInterventionAvecProfessionnel();
        
        
        Utilitaires.ViderEcran();

        // PHY101
        ProfilProfessionnelSante();

        return;

        Utilitaires.EnTete();
        
        Menu menu = new Menu("Profils offerts");
        menu.AjouterOption(new MenuItem('C', "Profil citoyen", ProfilCitoyen));
        menu.AjouterOption(new MenuItem('P', "Profil professionnel de la santé", ProfilProfessionnelSante));
        menu.AjouterOption(new MenuItem('A', "Afficher professionnels de la santé", AfficherProfessionnel));
        menu.AjouterOption(new MenuItem('B', "Afficher citoyens", AfficherCitoyen));

        menu.SaisirOption();
    }

    private static void AfficherProfessionnel()
    {
        foreach (var professionnel in _professionnels)
        {
            Console.Write($"[{professionnel.CodePS}] ");
        }
        
        Utilitaires.Pause();
    }
    
    private static void AfficherCitoyen()
    {
        foreach (var citoyen in _citoyens)
        {
            Console.Write($"[{citoyen.NAS,-4}] ");
        }
        Utilitaires.Pause();
    }

    private static void _RepartirPatientAvecProfessionnel()
    {
        var citoyensParNAS = 
            _citoyens.ToDictionary(c => c.NAS);
        
        var professionnelsParCode = 
            _professionnels.ToDictionary(p => p.CodePS);

        foreach (RendezVous rv in _rendezVous)
        {
            if (citoyensParNAS.TryGetValue(rv.NAS, out var citoyen) 
                && professionnelsParCode.TryGetValue(rv.CodePS, out var professionnel))
            {
                professionnel.Patients.Add(citoyen);
            }
        }
    }
    private static void _RepartirInterventionAvecProfessionnel()
    {
        var rendezVousParCodePS = 
            _rendezVous
                .GroupBy(rv => rv.CodePS)
                .ToDictionary(g => g.Key, g => g.ToList());
        
        var hospitalisationParCodePS = 
            _hospitalisation
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

    private static void _RepartirUtilisationPatient()
    {
        var hospitalisationsParNAS = 
            _hospitalisation
                .GroupBy(h => h.NAS)
                .ToDictionary(g => g.Key, g => g.ToList());
        
        var rendezVousParNAS = 
            _rendezVous
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

    private static void _RepartirProblemePatient()
    {
        var blessuresParNas = 
            _blessures
                .GroupBy(b => b.NAS)
                .ToDictionary(g => g.Key, g => g.ToList());
        
        var maladiesParNas = 
            _maladies
                .GroupBy(m => m.NAS)
                .ToDictionary(g => g.Key, g => g.ToList());

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

    private static void _RepartirUtilisations()
    {
        List<List<string>> listeUtilisations = Utilitaires.ChargerFichier(
            "C:\\Users\\Ubert Guertin\\Downloads\\TP3-VisionSant-POO-main\\TP3_VisionSante\\donnees\\utilisations.txt",
            ';'
        );

        foreach (List<string> utilisation in listeUtilisations)
        {
            int NAS = int.Parse(utilisation[0]);
            string codePS = utilisation[1];
            string etablissement = utilisation[2];
            string date = utilisation[3];

            switch (utilisation.Count)
            {
                case TAILLE_LIGNE_RENDEZ_VOUS:
                    RendezVous rendezVous = new RendezVous(NAS, codePS, etablissement, date);
                    _rendezVous.Add(rendezVous);
                    break;
                
                case TAILLE_LIGNE_HOSPITALISATION:
                    string dateFin = utilisation[4];
                    int chambre = int.Parse(utilisation[5]);
                    Hospitalisation hospitalisation = new Hospitalisation(NAS, codePS, etablissement, date, dateFin, chambre);
                    _hospitalisation.Add(hospitalisation);
                    break;
            }
        }
    }

    private static void _RepartirProbleme()
    {
        List<List<string>> listeProblemes = Utilitaires.ChargerFichier(
            "C:\\Users\\Ubert Guertin\\Downloads\\TP3-VisionSant-POO-main\\TP3_VisionSante\\donnees\\problemes.txt",
            ';'
        );

        foreach (List<string> probleme in listeProblemes)
        {
            if (probleme.Count != TAILLE_LIGNE_MALADIE && probleme.Count != TAILLE_LIGNE_BLESSURE) continue;
            
            int nas = int.Parse(probleme[0]);
            string typeOuPatologie = probleme[1];
            string dateDebut = probleme[2];
            string dateFin = probleme[3];
            string description = probleme[4];

            switch (probleme.Count)
            {
                case TAILLE_LIGNE_BLESSURE:
                    _blessures.Add(new Blessure(nas, typeOuPatologie, dateDebut, dateFin, description));
                    break;
                
                case TAILLE_LIGNE_MALADIE:
                    int stade = int.Parse(probleme[5]);
                    _maladies.Add(new Maladie(nas, typeOuPatologie, dateDebut, dateFin, description, stade));
                    break;
            }
        }
    }
    
    private static void _RepartirPopulation()
    {
        List<List<string>> listePopulation = Utilitaires.ChargerFichier(
            "C:\\Users\\Ubert Guertin\\Downloads\\TP3-VisionSant-POO-main\\TP3_VisionSante\\donnees\\population.txt",
            ';'
        );

        foreach (List<string> population in listePopulation)
        {
            int nas = int.Parse(population[0]); 
            string nom = population[1];
            string dateNaissance = population[2];
            
            switch (population.Count)
            {
                case TAILLE_LIGNE_CITOYEN:
                    Citoyen citoyen = new Citoyen(nas, population[1], dateNaissance);
                    _citoyens.Add(citoyen);
                    break;
                
                case TAILLE_LIGNE_PROFESSIONNEL:
                    string codePS = population[3];
                    string titreProfessionnel = population[4];

                    Professionnel professionnel = new Professionnel(nas, nom, dateNaissance, codePS, titreProfessionnel);
                    _professionnels.Add(professionnel);
                    break;
            }
        }
    }

    private static void ProfilCitoyen()
    {
        Utilitaires.EnTete();
        
        Console.Write("NAS du citoyen désiré: ");
        int NAS = int.Parse(Console.ReadLine());

        foreach (Citoyen citoyen in _citoyens)
        {
            if (citoyen.NAS == NAS)
            {
                citoyen.AfficherSommaire();
                break;
            }
        }
    }

    private static void ProfilProfessionnelSante()
    {
        Utilitaires.EnTete();
        
        Console.Write("Code PS du professionnel désiré: ");
        string codePS = Console.ReadLine();
        //string codePS = ""


        foreach (Professionnel professionnel in _professionnels)
        {
            if (professionnel.CodePS == codePS)
            {
                professionnel.AfficherSommaire();
                break;
            }
        }
        
        Utilitaires.Pause();
    }
}
