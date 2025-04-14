namespace Tp3_VisionSante;

internal class Hospitalisation
{
	public int NAS {get; set;}
	public string CodePS {get; set;}
	private string Etablissement {get; set;}
	private string Date {get; set;}
	
	private string DateFin {get; set;}
	
	private int Chambre {get; set;}
	
	public Hospitalisation(int nas, string codePS, string etablissement, string date, string dateFin, int chambre)
	{
		NAS = nas;
		CodePS = codePS;
		Etablissement = etablissement;
		Date = date;
		DateFin = dateFin;
		Chambre = chambre;
	}

	public void Afficher()
	{
		Console.WriteLine($"{Etablissement,-30}{Date,-12}{CodePS,-8}{Chambre,-8}{DateFin,-12}");
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