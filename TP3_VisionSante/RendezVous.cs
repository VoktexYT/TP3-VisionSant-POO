namespace Tp3_VisionSante;

internal class RendezVous : Intervention
{

    public RendezVous(int nas, string codePS, string etablissement, string date) : base(nas, codePS, etablissement, date) {}

    public override void Afficher()
    {
        Console.WriteLine($"{Etablissement,-30}{Date,-12}{NAS,8}");
    }
}