// ----------------------
// Citoyen.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------


namespace TP3_VisionSante;

/// <summary>
/// Représente un citoyen avec des informations personnelles et un historique médical.
/// </summary>
internal class Citoyen
{
    public int? NAS { get; set; }
    public string Nom { get; set; }
    protected string DateNaissance { get; set; }
    
    public List<Blessure> Blessures { get; set; } = new List<Blessure>();
    public List<Maladie> Maladies { get; set; } = new List<Maladie>();
    
    public List<Hospitalisation> Hospitalisations { get; set; } = new List<Hospitalisation>();

    public List<RendezVous> RendezVous_ { get; set; } = new List<RendezVous>();

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Citoyen"/>.
    /// </summary>
    /// <param name="nas">Numéro d'assurance sociale du citoyen.</param>
    /// <param name="nom">Nom du citoyen.</param>
    /// <param name="dateNaissance">Date de naissance (format "yyyy-MM-dd").</param>
    public Citoyen(int nas, string nom, string dateNaissance)
    {
        NAS = nas;
        Nom = nom;
        DateNaissance = dateNaissance;
    }

    /// <summary>
    /// Affiche un résumé des caractéristiques du citoyen.
    /// </summary>
    public void AfficherCaracteristiques()
    {
        Console.WriteLine($"{Nom,-30}{NAS,5}{DateNaissance,12}{Hospitalisations.Count+RendezVous_.Count,5}");
    }

    /// <summary>
    /// Retourne la date de naissance du citoyen en tant qu'objet <see cref="DateTime"/>.
    /// </summary>
    /// <returns>Date de naissance en tant que DateTime.</returns>
    public DateTime RecupererDateNaissance()
    {
        string[] dn = DateNaissance.Split("-");
        return new DateTime(int.Parse(dn[0]), int.Parse(dn[1]), int.Parse(dn[2]));
    }

    /// <summary>
    /// Affiche un sommaire complet du citoyen, incluant ses problèmes et ses ressources médicales.
    /// </summary>
    public virtual void AfficherSommaire()
    {
        Utilitaires.AfficherEnTete();
        
        Console.WriteLine("\n------------------------------------------------------------------");
        Console.WriteLine($"Nom: \t\t{Nom}");
        Console.WriteLine($"Né le:\t\t{DateNaissance}");
        Console.WriteLine($"NAS:\t\t{NAS}");
        Console.WriteLine("\n------------------------------------------------------------------");

        Console.WriteLine("Historique");
        Console.WriteLine($"\t{Blessures.Count + Maladies.Count} problèmes");
        Console.WriteLine($"\t{Hospitalisations.Count + RendezVous_.Count} ressources utilisées");
        Console.WriteLine("\n");
        
        Menu menuCitoyen = new Menu("Consulter problèmes ou ressources?", false);
        menuCitoyen.AjouterOption(new MenuItem('P', "Problèmes", AfficherSommaireProblemes));
        menuCitoyen.AjouterOption(new MenuItem('R', "Ressources", AfficherSommaireRessources));
        menuCitoyen.SaisirOption();
    }

    /// <summary>
    /// Affiche un sommaire des problèmes médicaux du citoyen (blessures et maladies).
    /// </summary>
    public void AfficherSommaireProblemes()
    {
        Utilitaires.AfficherEnTete();
        Console.WriteLine($"\n\nProblèmes médicaux de {Nom}\n----------------------------------------\n");
        Console.WriteLine($"\t{Maladies.Count} maladies");
        Console.WriteLine($"\t{Blessures.Count} blessures");

        Console.WriteLine("\n");

        Menu menuProb = new Menu("Consulter blessures ou maladies?", false);
        menuProb.AjouterOption(new MenuItem('B', "Blessures", AfficherBlessures));
        menuProb.AjouterOption(new MenuItem('M', "Maladies", AfficherMaladies));
        menuProb.AjouterOption(new MenuItem('T', "Tous problèmes", AfficherTousProblemes));
      
        menuProb.SaisirOption();
        Utilitaires.Pause();
        Utilitaires.ViderEcran();
    }

    /// <summary>
    /// Affiche un sommaire des ressources médicales utilisées (rendez-vous et hospitalisations).
    /// </summary>
    public void AfficherSommaireRessources()
    {
        Utilitaires.AfficherEnTete();
        Console.WriteLine($"\n\nRessources utilisées par {Nom}\n----------------------------------------\n");
        Console.WriteLine($"\t{RendezVous_.Count} rendez-vous");
        Console.WriteLine($"\t{Hospitalisations.Count} hospitalisations");

        Console.WriteLine("\n");

        Menu menuRess = new Menu("Consulter Rendez-Vous ou Hospitalisations?", false);
        menuRess.AjouterOption(new MenuItem('R', "Rendez-vous", AfficherRendezVous));
        menuRess.AjouterOption(new MenuItem('H', "Hospitalisation", AfficherHospitalisations));
        menuRess.AjouterOption(new MenuItem('T', "Toutes les ressources", AfficherToutesRessources));
        menuRess.SaisirOption();
        Utilitaires.Pause();
        Utilitaires.ViderEcran();
    }

    /// <summary>
    /// Affiche la liste des blessures du citoyen.
    /// </summary>
    public void AfficherBlessures()
    {
        Utilitaires.AfficherTableau<Blessure>(
            "Blessures",
            Nom,
            $"{"Type",-20}{"Début",-15}{"Guérison",-15}{"Description",-20}",
            Blessures);
    }


    /// <summary>
    /// Affiche la liste des maladies du citoyen.
    /// </summary>
    public void AfficherMaladies()
    {
        Console.WriteLine($"\n\nMaladies de {Nom}:\n");
        Console.WriteLine($"{"Pathologie",-20}{"Stade",-10}{"Début",-15}{"Guérison",-15}{"Commentaire",-20}");
        Console.WriteLine("_________________________________________________________________");

        foreach (Maladie maladie in Maladies)
        {
            maladie.Afficher();
        }
    }

    /// <summary>
    /// Affiche toutes les maladies et blessures du citoyen.
    /// </summary>
    public void AfficherTousProblemes()
    {
        AfficherBlessures();
        AfficherMaladies();
    }

    /// <summary>
    /// Affiche la liste des rendez-vous du citoyen.
    /// </summary>
    public void AfficherRendezVous()
    {
        Console.WriteLine($"\n\nRendez-vous de {Nom}:\n");
        Console.WriteLine($"{"Établissement",-25}{"Date",-12}{"Code PS",8}");
        Console.WriteLine("_________________________________________________________________");

        foreach (RendezVous rendezVous in RendezVous_)
        {
            rendezVous.Afficher();
        }
    }

    /// <summary>
    /// Affiche la liste des hospitalisations du citoyen.
    /// </summary>
    public void AfficherHospitalisations()
    {
        Console.WriteLine($"\n\nHospitalisations de {Nom}:\n");
        Console.WriteLine($"{"Établissement",-30}{"Arrivée",-12}{"Code PS",-8}{"Chambre",-8}{"Départ",-12}");
        Console.WriteLine("_________________________________________________________________");

        foreach (Hospitalisation hospitalisation in Hospitalisations)
        {
            hospitalisation.Afficher();
        }
    }


    /// <summary>
    /// Affiche toutes les ressources médicales utilisées par le citoyen (rendez-vous et hospitalisations).
    /// </summary>
    public void AfficherToutesRessources()
    {
        AfficherRendezVous();
        AfficherHospitalisations();
    }
}
