// ----------------------
// Utilitaires.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------


namespace TP3_VisionSante
{
    /// <summary>
    /// Fournit des méthodes utilitaires pour l'affichage, la gestion de l'écran et le chargement de fichiers.
    /// </summary>
    internal static class Utilitaires
    {
        private const int _TAILLE_TITRE = 33;

        /// <summary>
        /// Interface imposant l'implémentation de la méthode <see cref="Afficher"/>.
        /// Doit être implémentée par toute classe nécessitant une sortie à l'écran via la méthode <c>Afficher()</c>.
        /// </summary>
        public interface MethodeAfficherObligatoire
        {
            /// <summary>
            /// Méthode d'affichage obligatoire.
            /// Doit afficher les informations pertinentes de l'objet implémentant cette interface.
            /// </summary>
            public void Afficher();
        }

        /// <summary>
        /// Affiche l’en-tête principal du programme dans la console, incluant les informations de l’auteur.
        /// </summary>
        public static void AfficherEnTete()
        {
            ViderEcran();
            string separateur = "o" + new string('-', _TAILLE_TITRE - 2) + "o";

            Console.WriteLine(separateur);
            Console.WriteLine($"|{"  Ubert Guertin",-(_TAILLE_TITRE - 2)}|");
            Console.WriteLine($"|{"  Présente",-(_TAILLE_TITRE - 2)}|");
            Console.WriteLine($"|{"  VISION SANTÉ",-(_TAILLE_TITRE - 2)}|");
            Console.WriteLine(separateur);
        }

        /// <summary>
        /// Affiche un message de pause à l’utilisateur et attend une saisie clavier.
        /// </summary>
        /// <param name="msg">Message facultatif à afficher avant la pause.</param>
        public static void Pause(string msg = "")
        {
            Console.WriteLine("\n\n" + msg);
            Console.Write("Appuyez sur une touche...");
            Console.ReadLine();
        }

        /// <summary>
        /// Efface complètement la console.
        /// </summary>
        public static void ViderEcran()
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J"); // Efface l'historique pour certains terminaux
        }

        /// <summary>
        /// Affiche un titre centré avec ou sans nettoyage de l'écran.
        /// </summary>
        /// <param name="t">Le texte du titre à afficher.</param>
        /// <param name="cls">Indique si l’écran doit être vidé avant l’affichage.</param>
        public static void AfficherTitre(string t, bool cls = true)
        {
            if (cls)
            {
                ViderEcran();
                AfficherEnTete();
            }
            Console.WriteLine($"\n{t,20}");
        }

        /// <summary>
        /// Lit une touche du clavier et retourne son caractère correspondant.
        /// </summary>
        /// <returns>Le caractère correspondant à la touche pressée.</returns>
        public static char GetClefClavier()
        {
            ConsoleKeyInfo cle = Console.ReadKey();
            return cle.KeyChar;
        }

        /// <summary>
        /// Affiche dynamiquement un tableau générique d'objets, en invoquant la méthode <c>Afficher()</c> de chaque élément.
        /// </summary>
        /// <typeparam name="T">Le type d’objet contenu dans la liste.</typeparam>
        /// <param name="typeEnTete">Le titre du type d'éléments.</param>
        /// <param name="nomEnTete">Le nom associé au tableau (ex. nom du citoyen).</param>
        /// <param name="structureEnTete">Structure tabulaire en première ligne (colonnes).</param>
        /// <param name="tableau">La liste des objets à afficher.</param>
        public static void AfficherTableau<T>(string typeEnTete, string nomEnTete, string structureEnTete, List<T> tableau)
        {
            Console.WriteLine($"\n\n{typeEnTete} de {nomEnTete}:\n");
            Console.WriteLine(structureEnTete);
            Console.WriteLine(new string('-', structureEnTete.Length));

            foreach (T t in tableau)
            {
                var methode = t.GetType().GetMethod("Afficher");

                if (methode != null)
                {
                    methode.Invoke(t, null);
                }
            }
        }

        /// <summary>
        /// Charge un fichier texte en mémoire et retourne chaque ligne comme une liste de chaînes, séparées par un caractère donné.
        /// </summary>
        /// <param name="chemin">Chemin absolu ou relatif du fichier.</param>
        /// <param name="separateur">Caractère utilisé pour séparer les champs.</param>
        /// <param name="nomFichier">Nom du fichier à utiliser pour l'affichage en mode debug (facultatif).</param>
        /// <returns>Une liste de lignes, chaque ligne étant une liste de champs séparés.</returns>
        public static List<List<string>> ChargerFichier(string chemin, char separateur, string nomFichier = "")
        {
            List<List<string>> tousLesDonnees = new List<List<string>>();

            bool debug = nomFichier != "";
            int nbrDonnees = 0;

            _AfficherDebug($"Vérification du fichier '{nomFichier}'", debug);
            if (File.Exists(chemin))
            {
                _AfficherDebug($"Ouverture du fichier '{nomFichier}'", debug);
                StreamReader fichier = new StreamReader(chemin);

                _AfficherDebug($"Lecture du fichier '{nomFichier}'", debug);
                while (fichier.Peek() >= 1)
                {
                    string? ligne = fichier.ReadLine();

                    if (ligne != null)
                    {
                        tousLesDonnees.Add(
                            ligne.Split(separateur).ToList()
                        );
                    }

                    nbrDonnees++;
                }

                _AfficherDebug($"{nbrDonnees} donnée(s) chargée(s) du fichier '{nomFichier}'", debug);
                _AfficherDebug($"Fermeture du fichier '{nomFichier}'", debug);
                fichier.Close();

                return tousLesDonnees;
            }

            Console.WriteLine($"ERREUR: Le chemin '{chemin}' est invalide. Fermeture du programme...");
            Environment.Exit(0);
            return tousLesDonnees;
        }

        /// <summary>
        /// Affiche un message de débogage si le mode debug est activé.
        /// </summary>
        /// <param name="msg">Le message à afficher.</param>
        /// <param name="debug">Détermine si le message doit être affiché.</param>
        private static void _AfficherDebug(string msg, bool debug)
        {
            if (debug)
            {
                Console.WriteLine(msg);
            }
        }
    }
}
