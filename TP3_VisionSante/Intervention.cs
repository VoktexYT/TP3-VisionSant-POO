namespace Tp3_VisionSante;

internal abstract class Intervention
{
    public int NAS { get; set; }
    public string CodePS { get; set; }
    public string Etablissement { get; set; }
    public DateTime Date { get; set; }

    public string DateStr { get; set; }

    public Intervention(int nas, string codePS, string etablissement, string date)
    {
        NAS = nas;
        CodePS = codePS;
        Etablissement = etablissement;
        DateStr = date;

        string[] d = date.Split("-");
        Date = new DateTime(int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]));
    }

    public extern virtual void Afficher();

    public string RecupererPatientNom(List<Citoyen> patients)
    {
        foreach (Citoyen patient in patients)
        {
            if (patient.NAS == NAS)
            {
                return patient.Nom;
            }
        }

        return "";
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
}