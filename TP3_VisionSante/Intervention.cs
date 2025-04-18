// ----------------------
// Intervention.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------

namespace TP3_VisionSante;

internal abstract class Intervention : Utilitaires.MethodeAfficherObligatoire
{
    public int NAS { get; set; }
    public string CodePS { get; set; }
    public string Etablissement { get; set; }
    public DateTime Date { get; set; }

    public string DateStr { get; set; }

    public string PatientNom { get; set; }
    private List<Citoyen> Patients;

    public Intervention(int nas, string codePS, string etablissement, string date, List<Citoyen> patients)
    {
        NAS = nas;
        CodePS = codePS;
        Etablissement = etablissement;
        DateStr = date;
        Patients = patients;
        
        RecupererNomPatient();
        RecupererFormatDate();
    }

    public virtual void Afficher()
    {
        Console.WriteLine($"{NAS} {CodePS} {Etablissement} {DateStr}");
    }

    public void AfficherProfessionnel(List<Citoyen> patients)
    {
        foreach (Citoyen patient in patients)
        {
            if (patient.NAS == NAS)
            {
                Console.WriteLine($"{patient.Nom,-30}{NAS,-10}{DateStr,-12}{Etablissement,-20}");
            }
        }
    }
    
    private void RecupererFormatDate()
    {
        string[] d = DateStr.Split("-");
        Date = new DateTime(int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]));
    }

    private void RecupererNomPatient()
    {
        foreach (Citoyen patient in Patients)
        {
            if (patient.NAS == NAS)
            {
                PatientNom = patient.Nom;
                break;
            }
        }
    }
}