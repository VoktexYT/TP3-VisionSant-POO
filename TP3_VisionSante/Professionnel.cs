// ----------------------
// Professionnel.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------

namespace TP3_VisionSante;

internal class Professionnel : Citoyen
{
    public string? CodePS { get; set; }
    private string? TitreProfessionnel { get; set; }

    public List<Citoyen> Patients { get; set; } = new List<Citoyen>();

    public List<Intervention> Interventions { get; set; } = new List<Intervention> { };

    public Professionnel(int nas, string nom, string dateNaissance, string codePS, string titreProfessionnel) : base(nas, nom, dateNaissance)
    {
        CodePS = codePS;
        TitreProfessionnel = titreProfessionnel;
    }

    public override void AfficherSommaire()
    {
        Utilitaires.ViderEcran();
        Utilitaires.AfficherEnTete();

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
    }

    private void AfficherPatients()
    {
        AfficherOptionTri();
        SaisirOptionTri();

        Utilitaires.ViderEcran();

        Utilitaires.AfficherEnTete();
        Console.WriteLine($"Patients de {Nom}");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("{0,-30}{1,5}{2,12}{3,5}", "Nom", "NAS", "Naissance", " Nb Interv");
        Console.WriteLine("_________________________________________________________________________________");

        foreach (Citoyen patient in Patients)
        {
            patient.AfficherCaracteristiques();
        }
    }

    private void AfficherInterventions()
    {
        Utilitaires.AfficherEnTete();
        AfficherOptionTriIntervention();
        SaisirOptionTriIntervention();
        Utilitaires.ViderEcran();

        Utilitaires.AfficherEnTete();

        Console.WriteLine($"Interventions de {Nom}");
        Console.WriteLine("-----------------------------------------------------");
        Console.WriteLine("{0,-30}{1,-10}{2,-12}{3,-20}", "Patient", "NAS", "  Date", "Établissement");
        Console.WriteLine("________________________________________________________________________________");

        foreach (Intervention intervention in Interventions)
        {
            intervention.AfficherProfessionnel(Patients);
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
                Patients.Sort(TrierCroissantPatientsNas); break;
            case 'A':
                Patients.Sort(TrierDecroissantPatientsNas); break;
            case 'o':
                Patients.Sort(TrierCroissantPatientsNom); break;
            case 'O':
                Patients.Sort(TrierDecroissantPatientsNom); break;
            case 's':
            case 'S':
                Patients.Sort(TrierCroissantPatientsNaissance); break;
        }
    }

    private void SaisirOptionTriIntervention()
    {
        ConsoleKeyInfo keyInfo;
        AfficherOptionTriIntervention();
        keyInfo = Console.ReadKey(true);

        Interventions.Clear();
        Interventions.AddRange(RendezVous_);
        Interventions.AddRange(Hospitalisations);


        switch (keyInfo.KeyChar)
        {
            case 'd':
                Interventions.Sort(TrierCroissantInterventionDate); break;
            case 'D':
                Interventions.Sort(TrierDecroissantInterventionDate); break;
            case 'e':
                Interventions.Sort(TrierCroissantInterventionEtablissement); break;
            case 'E':
                Interventions.Sort(TrierDecroissantInterventionEtablissement); break;
            case 'a':
                Interventions.Sort(TrierCroissantInterventionNas); break;
            case 'A':
                Interventions.Sort(TrierDecroissantInterventionNas); break;
            case 'n':
                Interventions.Sort(TrierCroissantInterventionNom); break;
            case 'N':
                Interventions.Sort(TrierDecroissantInterventionNom); break;
            case 's':
            case 'S':
                Interventions.Sort(TrierDecroissantInterventionNas); break;
        }
    }

    private void AfficherOptionTri()
    {
        Utilitaires.AfficherEnTete();
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
        Utilitaires.AfficherEnTete();
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

    private int TrierCroissantInterventionNom(Intervention int1, Intervention int2)
    {
        return string.Compare(int1.PatientNom, int2.PatientNom);
    }
    
    private int TrierDecroissantInterventionNom(Intervention int1, Intervention int2)
    {
        return string.Compare(int2.PatientNom, int1.PatientNom);
    }

    private int TrierCroissantInterventionDate(Intervention int1, Intervention int2)
    {
        return DateTime.Compare(int1.Date, int2.Date);
    }

    private int TrierDecroissantInterventionDate(Intervention int1, Intervention int2)
    {
        return DateTime.Compare(int2.Date, int1.Date);
    }

    private int TrierCroissantInterventionEtablissement(Intervention int1, Intervention int2)
    {
        return string.Compare(int1.Etablissement, int2.Etablissement);
    }

    private int TrierDecroissantInterventionEtablissement(Intervention int1, Intervention int2)
    {
        return string.Compare(int2.Etablissement, int1.Etablissement);
    }

    private int TrierCroissantInterventionNas(Intervention int1, Intervention int2)
    {
        return int1.NAS > int2.NAS ? 1 : int1.NAS < int2.NAS ? -1 : 0;
    }

    private int TrierDecroissantInterventionNas(Intervention int1, Intervention int2)
    {
        return int1.NAS > int2.NAS ? -1 : int1.NAS < int2.NAS ? 1 : 0;
    }

    private int TrierCroissantPatientsNaissance(Citoyen patient1, Citoyen patient2)
    {
        return DateTime.Compare(patient1.RecupererDateNaissance(), patient2.RecupererDateNaissance());
    }
    private int TrierDecroissantPatientsNaissance(Citoyen patient1, Citoyen patient2)
    {
        return DateTime.Compare(patient2.RecupererDateNaissance(), patient1.RecupererDateNaissance());
    }

    private int TrierCroissantPatientsNas(Citoyen patient1, Citoyen patient2)
    {
        return patient1.NAS > patient2.NAS ? 1 : patient1.NAS < patient2.NAS ? -1 : 0;
    }
    private int TrierDecroissantPatientsNas(Citoyen patient1, Citoyen patient2)
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