namespace Tp3_VisionSante;

internal class Menu
{
    public string Nom {  get; set; }    
    public List<MenuItem> Items { get; set; }
    bool _top = true;

    public Menu(string nom, bool top=true)
    {
        Nom = nom;
        Items = new List<MenuItem>();
        _top = top;
    }   

    public void AjouterOption(MenuItem o)
    {
        Items.Add(o);   
    }

    void Afficher()
    {
        
        Utilitaires.Titre(Nom, _top);
        
        foreach(MenuItem mi in Items)
        {
            Console.WriteLine("\t" + mi.Cle + ": " + mi.Nom);
        }
        Console.WriteLine("\n\nEsc pour quitter...");
    }

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
