namespace Tp3_VisionSante;
internal class Citoyen
{
    private string? NAS { get; set; }

    public Citoyen()
    {
        NAS = "";
    }
    
    public void AfficherSommaire()
    {
        Console.Write("NAS du citoyen désiré:");
        NAS = Console.ReadLine();

        Console.WriteLine("\n------------------------------------------------------------------");
        Console.WriteLine("Nom: \t\tPascale Bisonnette");
        Console.WriteLine("Né le:\t\t1968-07-25");
        Console.WriteLine("NAS:\t\t" + NAS);
        Console.WriteLine("\n------------------------------------------------------------------");

        Console.WriteLine("Historique");
        Console.WriteLine("\t8 problèmes");
        Console.WriteLine("\t9 ressources utilisées");
        Console.WriteLine("\n");

        Menu menuCitoyen = new Menu("Consulter problèmes ou ressources?", false);
        menuCitoyen.AjouterOption(new MenuItem('P', "Problèmes", AfficherSommaireProblemes));
        menuCitoyen.AjouterOption(new MenuItem('R', "Ressources", AfficherSommaireRessources));
        menuCitoyen.SaisirOption();
    }

    public void AfficherSommaireProblemes()
    {
        Utilitaires.EnTete();
        Console.WriteLine("Problèmes médicaux de Pascale Bisonnette\n----------------------------------------\n");
        Console.WriteLine("\t4 maladies");
        Console.WriteLine("\t3 blessures");

        Console.WriteLine("\n");

        Menu menuProb = new Menu("Consulter blessures ou maladies?", false);
        menuProb.AjouterOption(new MenuItem('B', "Blessures", AfficherBlessures));
        menuProb.AjouterOption(new MenuItem('M', "Maladies", AfficherMaladies));
        menuProb.AjouterOption(new MenuItem('T', "Tous problèmes", AfficherTousProblemes));
      
        menuProb.SaisirOption();
       
    }


    public void AfficherSommaireRessources()
    {
        Utilitaires.EnTete();
        Console.WriteLine("Ressources utilisées par Pascale Bisonnette\n----------------------------------------\n");
        Console.WriteLine("\t3 rendez-vous");
        Console.WriteLine("\t2 hospitalisations");

        Console.WriteLine("\n");

        Menu menuRess = new Menu("Consulter Rendez-Vous ou Hospitalisations?", false);
        menuRess.AjouterOption(new MenuItem('R', "Rendez-vous", AfficherRendezVous));
        menuRess.AjouterOption(new MenuItem('H', "Hospitalisation", AfficherHospitalisations));
        menuRess.AjouterOption(new MenuItem('T', "Toutes les ressources", AfficherToutesRessources));
        menuRess.SaisirOption();
    }

    public void AfficherBlessures()
    {
        Utilitaires.EnTete();
        Console.WriteLine("Blessures de Pascale Bisonnette:\n");
        Console.WriteLine("Type            Début      Guérison   Description ");
        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("{0,-13} {1,11} {2,11} {3,-30}", "Fracture", "2020-03-24", "2020-03-26", "Fracture ouverte du tibia");
        Console.WriteLine("{0,-13} {1,11} {2,11} {3,-30}", "Brûlure", "2019-06-21", "2019-08-31", "Brûlure 2ième degr au visage");
        Console.WriteLine("{0,-13} {1,11} {2,11} {3,-30}", "Contusion", "2017-12-24", "2018-02-11", "Hématome majeur suite à un accident d'auto");
        Console.WriteLine("{0,-13} {1,11} {2,11} {3,-30}", "Intoxication", "2007-03-02", "2007-03-21", "Perte de vision suite à surdose d'alcool");
       
        Utilitaires.Pause();
    }
    public void AfficherMaladies()
    {
        Utilitaires.EnTete();
        Console.WriteLine("Maladies de Pascale Bisonnette:\n");
        Console.WriteLine("Pathologie             Stade  Début    Guérison   Commentaire ");
        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("{0,-22} {1,3} {2,11} {3,11} {4,-30}", "Schlérose en plaques", "3", "1998-01-24", "", "État chronique mais stable");
        Console.WriteLine("{0,-22} {1,3} {2,11} {3,11} {4,-30}", "Cancer de la prostate", "1", "2008-01-24", "2013-01-31", "Aucune récidive après plus de 5 ans");
        Console.WriteLine("{0,-22} {1,3} {2,11} {3,11} {4,-30}", "Gonorrhée", "1", "1998-01-24", "1998-02-14", "Guérison après antibiotiques");

        Utilitaires.Pause();
    }
    public void AfficherTousProblemes()
    {
        Utilitaires.EnTete();
        Console.WriteLine("Problèmes médicaux de Pascale Bisonnette:\n");
        
        Console.WriteLine("Blessures:");
        Console.WriteLine("Type            Début      Guérison   Description ");
        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("{0,-13} {1,11} {2,11} {3,-30}", "Fracture", "2020-03-24", "2020-03-26", "Fracture ouverte du tibia");
        Console.WriteLine("{0,-13} {1,11} {2,11} {3,-30}", "Brûlure", "2019-06-21", "2019-08-31", "Brûlure 2ième degr au visage");
        Console.WriteLine("{0,-13} {1,11} {2,11} {3,-30}", "Contusion", "2017-12-24", "2018-02-11", "Hématome majeur suite à un accident d'auto");
        Console.WriteLine("{0,-13} {1,11} {2,11} {3,-30}", "Intoxication", "2007-03-02", "2007-03-21", "Perte de vision suite à surdose d'alcool");
        Console.WriteLine( );
        Console.WriteLine("Maladies:");
        Console.WriteLine("Pathologie             Stade  Début    Guérison   Commentaire ");
        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("{0,-22} {1,3} {2,11} {3,11} {4,-30}", "Schlérose en plaques", "3", "1998-01-24", "", "État chronique mais stable");
        Console.WriteLine("{0,-22} {1,3} {2,11} {3,11} {4,-30}", "Cancer de la prostate", "1", "2008-01-24", "2013-01-31", "Aucune récidive après plus de 5 ans");
        Console.WriteLine("{0,-22} {1,3} {2,11} {3,11} {4,-30}", "Gonorrhée", "1", "1998-01-24", "1998-02-14", "Guérison après antibiotiques");
        Utilitaires.Pause();
    }

    public void AfficherRendezVous()
    {
        Utilitaires.EnTete();
        Console.WriteLine("Rendez-vous de Pascale Bisonnette:\n");
        Console.WriteLine("{0,-22} {1,-12} {2,8}", "Établissement", "  Date", "Code PS");
        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("{0,-22} {1,12} {2,8}", "CLSC Rosemère", "2022-02-13", "NC-103");
        Console.WriteLine("{0,-22} {1,12} {2,8}", "Clinique MTS", "2012-02-13", "MG-803");
        Console.WriteLine("{0,-22} {1,12} {2,8}", "CH St-Jérôme", "2017-02-13", "UR-504");

        Utilitaires.Pause();
    }
    public void AfficherHospitalisations()
    {
        Utilitaires.EnTete();
        Console.WriteLine("Hospitalisations  de Pascale Bisonnette:\n");
        Console.WriteLine("{0,-22} {1,-12} {2,8} {3,-8} {4,-12}", "Établissement", "  Arrivée", "Code PS", "Chambre", "  Départ");
        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("{0,-22} {1,12} {2,8} {3,-8} {4,12}", "CUSM", "2022-02-03", "NC-103", "233", "");
        Console.WriteLine("{0,-22} {1,12} {2,8} {3,-8} {4,12}", "CH Hotel Dieu", "1995-12-03", "MG-512", "D-1233", "1996-02-03");
        Utilitaires.Pause();

    }
    public void AfficherToutesRessources()
    {
        Utilitaires.EnTete();
        Console.WriteLine("Ressources utilisées par Pascale Bisonnette:\n");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("Rendez-vous:");
        Console.WriteLine("{0,-22} {1,-12} {2,8}", "Établissement", "  Date", "Code PS");
        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("{0,-22} {1,12} {2,8}", "CLSC Rosemère", "2022-02-13", "NC-103");
        Console.WriteLine("{0,-22} {1,12} {2,8}", "Clinique MTS", "2012-02-13", "MG-803");
        Console.WriteLine("{0,-22} {1,12} {2,8}", "CH St-Jérôme", "2017-02-13", "UR-504");
        Console.WriteLine();
        Console.WriteLine("Hospitalisations:");
        Console.WriteLine("{0,-22} {1,-12} {2,8} {3,-8} {4,-12}", "Établissement", "  Arrivée", "Code PS" , "Chambre", "  Départ");
        Console.WriteLine("_________________________________________________________________");
        Console.WriteLine("{0,-22} {1,12} {2,8} {3,-8} {4,12}", "CUSM", "2022-02-03", "NC-103", "233", "");
        Console.WriteLine("{0,-22} {1,12} {2,8} {3,-8} {4,12}", "CH Hotel Dieu", "1995-12-03", "MG-512", "D-1233", "1996-02-03");
        Utilitaires.Pause();
    }
}
