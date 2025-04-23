// ----------------------
// Menu.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------

namespace TP3_VisionSante;

/// <summary>
/// Représente un menu interactif avec plusieurs options sélectionnables.
/// </summary>
internal class Menu
{
    public string Nom {  get; set; }    
    public List<MenuItem> Items { get; set; }
    bool _top = true;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Menu"/>.
    /// </summary>
    /// <param name="nom">Titre du menu à afficher.</param>
    /// <param name="top">Détermine si le menu reste actif après une exécution (true = oui).</param>
    public Menu(string nom, bool top=true)
    {
        Nom = nom;
        Items = new List<MenuItem>();
        _top = top;
    }


    /// <summary>
    /// Ajoute une option (élément) au menu.
    /// </summary>
    /// <param name="o">Objet de type <see cref="MenuItem"/> représentant une option du menu.</param>
    public void AjouterOption(MenuItem o)
    {
        Items.Add(o);   
    }


    /// <summary>
    /// Affiche les options du menu dans la console.
    /// </summary>
    void Afficher()
    {
        Utilitaires.AfficherTitre(Nom, _top);
        
        foreach(MenuItem mi in Items)
        {
            Console.WriteLine("\t" + mi.Cle + ": " + mi.Nom);
        }
        Console.WriteLine("\n\nEsc pour quitter...");
    }

    /// <summary>
    /// Permet à l'utilisateur de sélectionner une option parmi les éléments du menu
    /// en appuyant sur une touche correspondante. Exécute l'action liée à l'option.
    /// </summary>
    public void SaisirOption()
    {
        ConsoleKeyInfo cle;
        Afficher();
        while ((cle = Console.ReadKey(true)).Key != ConsoleKey.Escape)
        {
            foreach (MenuItem mi in Items)
            {
                if ((char)cle.Key == mi.Cle)
                {
                    if (_top)
                        Utilitaires.ViderEcran();
                    mi.Execution();
                    if (_top)
                      Afficher();
                }
            }
            if (!_top)
                break;
        }
    }
}
