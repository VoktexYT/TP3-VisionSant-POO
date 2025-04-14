namespace Tp3_VisionSante;

internal class RendezVous
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
		Console.WriteLine($"{Etablissement,-30}{Date,-12}{NAS,8}");
	}

	public void AfficherProfessionnel(List<Citoyen> patients)
	{
		foreach (Citoyen patient in patients)
		{
			if (patient.NAS == NAS)
			{
				Console.WriteLine($"{patient.Nom,-30}{NAS,-10}{Date,-12}{Etablissement,-20}");
			}
		}
	}

}