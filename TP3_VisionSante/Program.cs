namespace Tp3_VisionSante;

internal static class Program
{
    static Citoyen cit = new();
    
    private static void Main(string[] args)
    {
        Utilitaires.EnTete();
        
        Utilitaires.ChargerFichier<Professionnel>(
            "/home/voktex/RiderProjects/TP3-VisionSant-POO/TP3_VisionSante/donnees/population.txt", 
            new Professionnel(),
            ';',
            "poputation");
        return;
        
        Menu menu = new Menu("Profils offerts");

        menu.AjouterOption(new MenuItem('C', "Profil citoyen", ProfilCitoyen));
        menu.AjouterOption(new MenuItem('P', "Profil professionnel de la santé", ProfilProfessionnelSante));

        menu.SaisirOption();
    
    }

    private static void ProfilCitoyen()
    {
        Utilitaires.EnTete();
        cit.AfficherSommaire();
    }

    private static void ProfilProfessionnelSante()
    {
        Utilitaires.EnTete();
        Professionnel ps = new();
        ps.AfficherSommaire();
    }
}
