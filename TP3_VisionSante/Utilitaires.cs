namespace Tp3_VisionSante;

internal static class Utilitaires
{
    private const int TAILLE_TITRE = 33; 

    public static void EnTete()
    {
        string separateur = "o" + new string('-', TAILLE_TITRE - 2) + "o";

        Console.WriteLine(separateur);
        Console.WriteLine($"|{"  Ubert Guertin",-(TAILLE_TITRE - 2)}|");
        Console.WriteLine($"|{"  Présente",-(TAILLE_TITRE - 2)}|");
        Console.WriteLine($"|{"  VISION SANTÉ",-(TAILLE_TITRE - 2)}|");
        Console.WriteLine(separateur);
    }

    public static void Pause(string msg="")
    {
        Console.WriteLine("\n\n" + msg);
        Console.Write("Appuyez sur une touche...");
        Console.ReadLine();
    }

    public static void ViderEcran()
    {
        Console.Clear();
        Console.WriteLine("\x1b[3J");
    }
    public static void Titre(string t, bool cls=true)
    {
        string separateur = new string('-', t.Length);

        if (cls)
        {
            ViderEcran();
            EnTete();
        }

        Console.WriteLine(separateur);
        Console.WriteLine(t);
        Console.WriteLine(separateur);
    }

    public static char GetClefClavier()
    {
        ConsoleKeyInfo cle = Console.ReadKey();
        return cle.KeyChar;
    }

    private static void AfficherDebug(string msg, bool debug)
    {
        if (debug)
        {
            Console.WriteLine(msg);
        }
    }
    
    public static List<T> ChargerFichier<T>(string chemin, T typeValeur, char separateur, string nomFichier = "")
    {
        List<T> tousLesDonnees = new List<T>();
        bool debug = nomFichier != "";
        int nbrDonnees = 0;

        AfficherDebug($"Vérification du fichier '{nomFichier}'", debug);
        if (File.Exists(chemin))
        {
            AfficherDebug($"Ouverture du fichier '{nomFichier}'", debug);
            StreamReader fichier = new StreamReader(chemin);
            
            AfficherDebug($"Lecture du fichier '{nomFichier}'", debug);
            while (fichier.Peek() >= 1)
            {
                fichier.ReadLine();
                nbrDonnees++;
            }
            AfficherDebug($"{nbrDonnees} donnée(s) chargée(s) du fichier '{nomFichier}'", debug);
            
            AfficherDebug($"Fermeture du fichier '{nomFichier}'", debug);
            fichier.Close();
            
            return tousLesDonnees;
        }

        throw new FileNotFoundException($"Le fichier {nomFichier} a rencontré une exception de type 404");
    }

}
