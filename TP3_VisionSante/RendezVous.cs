namespace Tp3_VisionSante;

public class RendezVous
{
	public int NAS {get; set;}
	public string CodePS {get; set;}
	private string Etablissement {get; set;}
	private string Date {get; set;}
	public RendezVous(int nas, string codePS, string etablissement, string date)
	{
		NAS = nas;
		CodePS = codePS;
		Etablissement = etablissement;
		Date = date;
	}

	public void Afficher()
	{
		Console.WriteLine($"{Etablissement,-25}{Date,-12}{CodePS,8}");
	}
}