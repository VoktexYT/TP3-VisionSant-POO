namespace Tp3_VisionSante;

internal class Professionnel
{
    private int? NAS { get; set; }
    private string? Nom { get; set; }
    private string? DateNaissance { get; set; }
    public string? CodePS { get; set; }
    private string? TitreProfessionnel { get; set; }
    
    public List<Citoyen> Patients { get; set; } = new List<Citoyen>();
    public List<RendezVous> RendezVous_ { get; set; } = new List<RendezVous>();
    public List<Hospitalisation> Hospitalisations { get; set; } = new List<Hospitalisation>();

    public Professionnel(int nas, string nom, string dateNaissance, string codePS, string titreProfessionnel)
    {
        NAS = nas;
        Nom = nom;
        DateNaissance = dateNaissance;
        CodePS = codePS;
        TitreProfessionnel = titreProfessionnel;
    }
    
    public void AfficherSommaire()
    {
        Utilitaires.ViderEcran();
        Utilitaires.EnTete();
        
        Console.WriteLine("\n------------------------------------------------------------------");
        Console.WriteLine($"Nom: \t\t{Nom}, {TitreProfessionnel}");
        Console.WriteLine($"Né le:\t\t{DateNaissance}");
        Console.WriteLine("Code PS:\t{0}", CodePS);
        Console.WriteLine("\n------------------------------------------------------------------");

        Console.WriteLine("Historique");
        Console.WriteLine($"\t\t{Patients.Count} patients");
        Console.WriteLine($"\t\t{RendezVous_.Count + Hospitalisations.Count} interventions");
        Console.WriteLine("\n");

        Menu menuPs = new Menu($"Consulter patients ou interventions de {Nom}?", false);
        menuPs.AjouterOption(new MenuItem('P', "Patients", AfficherPatients));
        menuPs.AjouterOption(new MenuItem('I', "Interventions", AfficherInterventions));
        menuPs.SaisirOption();
        
        Utilitaires.Pause();
    }

    private void AfficherPatients()
    {
        AfficherOptionTri();
        SaisirOptionTri();
        
        Utilitaires.ViderEcran();

        Utilitaires.EnTete();
        Console.WriteLine($"Patients de {Nom}");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("{0,-30}{1,5}{2,12}{3,5}", "Nom", "NAS", "Naissance", " Nb Interv");
        Console.WriteLine("_________________________________________________________________________________");

        foreach (Citoyen patient in Patients)
        {
            patient.AfficherCaracteristiques(10);
        }
    }

    private void AfficherInterventions()
    {
        Utilitaires.EnTete();
        AfficherOptionTriIntervention();
        SaisirOptionTriIntervention();
        Utilitaires.ViderEcran();

        Utilitaires.EnTete();

        Console.WriteLine($"Interventions de {Nom}");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("{0,-30}{1,-10}{2,-12}{3,-20}", "Patient", "NAS", "  Date", "Établissement");
        Console.WriteLine("________________________________________________________________________________");

        foreach (RendezVous rendezVous in RendezVous_)
        {
            rendezVous.AfficherProfessionnel(Patients);
        }

        foreach (Hospitalisation hospitalisation in Hospitalisations) 
        {
            hospitalisation.AfficherProfessionnel(Patients);    
        }
    }


    private void SaisirOptionTri()
    {
        ConsoleKeyInfo keyInfo;
        AfficherOptionTri();
        string optionTri = "";
        keyInfo = Console.ReadKey(true);
        
        switch (keyInfo.KeyChar)
        {
            case 'n':
                Patients.Sort(TrierCroissantPatientsNaissance);
                break;
            case 'N':
                Patients.Sort(TrierDecroissantPatientsNaissance);
                break;
            case 'a':
                Patients.Sort(TrierCroissantPatientsNAS); break;
            case 'A':
                Patients.Sort(TrierDecroissantPatientsNAS); break;
            case 'o':
                Patients.Sort(TrierCroissantPatientsNom); break;
            case 'O':
                Patients.Sort(TrierDecroissantPatientsNom); break;
            case 's':
            case 'S':
                Patients.Sort(TrierCroissantPatientsNaissance); break;
        }
    }

    private string SaisirOptionTriIntervention()
    {
        ConsoleKeyInfo keyInfo;
        AfficherOptionTriIntervention();
        string optionTri = "";
        keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key.ToString())
        {
            case "d":
            case "D":
            case "e":
            case "E":
            case "n":
            case "N":
            case "s":
            case "S":
                optionTri = "N";
                return optionTri;
            default:
                return "quitter";
        }
    }

    private void AfficherOptionTri()
    {
        Utilitaires.EnTete();
        Console.WriteLine($"\t\t\tPatients de {Nom} triés par\n");
        Console.WriteLine("\t\t\tn-naissance .:");
        Console.WriteLine("\t\t\tN-Naissance :.");
        Console.WriteLine("\t\t\ta-nAS .:");
        Console.WriteLine("\t\t\tA-NAS :.");
        Console.WriteLine("\t\t\to-nom .:");
        Console.WriteLine("\t\t\tO-Nom :.");
        Console.WriteLine("\t\t\ts-sans tri");
    }

    private void AfficherOptionTriIntervention()
    {
        Utilitaires.EnTete();
        Console.WriteLine($"\t\tInterventions de {Nom} triées par\n");
        Console.WriteLine("\t\td-date .:");
        Console.WriteLine("\t\tD-Date :.");
        Console.WriteLine("\t\te-établissement .:");
        Console.WriteLine("\t\tE-Établissement :.");
        Console.WriteLine("\t\ta-nas .:");
        Console.WriteLine("\t\tA-Nas :.");
        Console.WriteLine("\t\tn-nom .:");
        Console.WriteLine("\t\tN-Nom :.");
        Console.WriteLine("\t\ts-sans tri");
    }

    private int TrierCroissantPatientsNaissance(Citoyen patient1, Citoyen patient2)
    {
         return DateTime.Compare(patient1.RecupererDateNaissance(), patient2.RecupererDateNaissance());
    }
    private int TrierDecroissantPatientsNaissance(Citoyen patient1, Citoyen patient2)
    {
        return DateTime.Compare(patient2.RecupererDateNaissance(), patient1.RecupererDateNaissance());
    }
    
    private int TrierCroissantPatientsNAS(Citoyen patient1, Citoyen patient2)
    {
        return patient1.NAS > patient2.NAS ? 1 : patient1.NAS < patient2.NAS ? -1 : 0;
    }
    private int TrierDecroissantPatientsNAS(Citoyen patient1, Citoyen patient2)
    {
        return patient1.NAS > patient2.NAS ? -1 : patient1.NAS < patient2.NAS ? 1 : 0;
    }
    private int TrierCroissantPatientsNom(Citoyen patient1, Citoyen patient2)
    {
        return string.Compare(patient1.Nom, patient2.Nom);
    }
    private int TrierDecroissantPatientsNom(Citoyen patient1, Citoyen patient2)
    {
        return string.Compare(patient2.Nom, patient1.Nom);
    }
}
