namespace Tp3_VisionSante;

internal static class Program
{
    private static List<Citoyen> _citoyens = new List<Citoyen>();
    private static List<Professionnel> _professionnels = new List<Professionnel>();
    
    private static List<Blessure> _blessures = new List<Blessure>();
    private static List<Maladie> _maladies = new List<Maladie>();

    private static List<RendezVous> _rendezVous = new List<RendezVous>();
    private static List<Hospitalisation> _hospitalisation = new List<Hospitalisation>();
    
    private static void Main(string[] args)
    {
        Console.WriteLine("Chargement de la base de données...");
        
        _RepartirPopulation();
        _RepartirProbleme();
        _RepartirUtilisations();
        
        Utilitaires.ViderEcran();
        
        Utilitaires.EnTete();
        
        Menu menu = new Menu("Profils offerts");
        menu.AjouterOption(new MenuItem('C', "Profil citoyen", ProfilCitoyen));
        menu.AjouterOption(new MenuItem('P', "Profil professionnel de la santé", ProfilProfessionnelSante));

        menu.SaisirOption();
    }

    private static void _RepartirUtilisations()
    {
        List<List<string>> listeUtilisations = Utilitaires.ChargerFichier(
            "/home/voktex/RiderProjects/TP3-VisionSant-POO/TP3_VisionSante/donnees/utilisations.txt",
            ';'
        );

        foreach (List<string> utilisation in listeUtilisations)
        {
            int NAS = int.Parse(utilisation[0]);
            string codePS = utilisation[1];
            string etablissement = utilisation[2];
            string date = utilisation[3];
            
            if (utilisation.Count == 4)
            {
                RendezVous rendezVous = new RendezVous(NAS, codePS, etablissement, date);
                _rendezVous.Add(rendezVous);
            }
            
            else if (utilisation.Count == 6)
            {
                string dateFin = utilisation[4];
                int chambre = int.Parse(utilisation[5]);
                
                Hospitalisation hospitalisation = new Hospitalisation(NAS, codePS, etablissement, date, dateFin, chambre);
                _hospitalisation.Add(hospitalisation);
            }
        }
    }

    private static void _RepartirProbleme()
    {
        List<List<string>> listeProblemes = Utilitaires.ChargerFichier(
            "/home/voktex/RiderProjects/TP3-VisionSant-POO/TP3_VisionSante/donnees/problemes.txt",
            ';'
        );

        foreach (List<string> probleme in listeProblemes)
        {
            int NAS = int.Parse(probleme[0]);
            string typeOuPatologie = probleme[1];
            string dateDebut = probleme[2];

            if (probleme.Count == 5)
            {
                string description = probleme[3];
                Blessure blessure = new Blessure(NAS, typeOuPatologie, dateDebut, description);
                _blessures.Add(blessure);
            }
            
            else if (probleme.Count == 6)
            {
                string dateFin = probleme[3];
                string description = probleme[4];
                int stade = int.Parse(probleme[5]);
                
                Maladie maladie = new Maladie(NAS, typeOuPatologie, dateDebut, dateFin, description, stade);
                _maladies.Add(maladie);
            }
        }
    }
    
    private static void _RepartirPopulation()
    {
        List<List<string>> listePopulation = Utilitaires.ChargerFichier(
            "/home/voktex/RiderProjects/TP3-VisionSant-POO/TP3_VisionSante/donnees/population.txt",
            ';'
        );

        foreach (List<string> population in listePopulation)
        {
            int NAS = int.Parse(population[0]);
            string nom = population[1];
            string dateNaissance = population[2];
            
            if (population.Count == 3)
            {
                Citoyen citoyen = new Citoyen(NAS, nom, dateNaissance);
                _citoyens.Add(citoyen);
            }
            
            else if (population.Count == 5)
            {
                string codePS = population[3];
                string titreProfessionnel = population[4];

                Professionnel professionnel = new Professionnel(NAS, nom, dateNaissance, codePS, titreProfessionnel);
                _professionnels.Add(professionnel);
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
