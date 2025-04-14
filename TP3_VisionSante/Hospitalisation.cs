namespace Tp3_VisionSante;

internal class Hospitalisation : Intervention
{
    private string DateFin { get; set; }
    private int Chambre { get; set; }

    public Hospitalisation(int nas, string codePS, string etablissement, string date, string dateFin, int chambre) : base(nas, codePS, etablissement, date)
    {
        DateFin = dateFin;
        Chambre = chambre;
    }

    public override void Afficher()
    {
        Console.WriteLine($"{Etablissement,-30}{Date,-12}{CodePS,-8}{Chambre,-8}{DateFin,-12}");
    }
}