namespace TP3_VisionSante;
internal class Citoyen
{
    public int? NAS { get; set; }
    public string Nom { get; set; }
    protected string DateNaissance { get; set; }
    
    public List<Blessure> Blessures { get; set; } = new List<Blessure>();
    public List<Maladie> Maladies { get; set; } = new List<Maladie>();
    
    public List<Hospitalisation> Hospitalisations { get; set; } = new List<Hospitalisation>();

    public List<RendezVous> RendezVous_ { get; set; } = new List<RendezVous>();

    public Citoyen(int nas, string nom, string dateNaissance)
    {
        NAS = nas;
        Nom = nom;
        DateNaissance = dateNaissance;
    }

    public void AfficherCaracteristiques()
    {
        Console.WriteLine($"{Nom,-30}{NAS,5}{DateNaissance,12}{Hospitalisations.Count+RendezVous_.Count,5}");
    }

    public DateTime RecupererDateNaissance()
    {
        string[] dn = DateNaissance.Split("-");
        return new DateTime(int.Parse(dn[0]), int.Parse(dn[1]), int.Parse(dn[2]));
    }
    
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

    public void AfficherBlessures()
    {
        Utilitaires.AfficherTableau<Blessure>(
            "Blessures",
            Nom,
            $"{"Type",-20}{"Début",-15}{"Guérison",-15}{"Description",-20}",
            Blessures);
    }
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
    public void AfficherTousProblemes()
    {
        AfficherBlessures();
        AfficherMaladies();
    }

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
    public void AfficherToutesRessources()
    {
        AfficherRendezVous();
        AfficherHospitalisations();
    }
}
