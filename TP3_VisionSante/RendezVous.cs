namespace Tp3_VisionSante;

public class RendezVous
{
	int NAS {get; set;}
	string CodePS {get; set;}
	string Etablissement {get; set;}
	string Date {get; set;}
	public RendezVous(int nas, string codePS, string etablissement, string date)
	{
		NAS = nas;
		CodePS = codePS;
		Etablissement = etablissement;
		Date = date;
	}
}