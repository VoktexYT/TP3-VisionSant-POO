namespace Tp3_VisionSante;

public class Hospitalisation
{
	int NAS {get; set;}
	string CodePS {get; set;}
	string Etablissement {get; set;}
	string Date {get; set;}
	
	string DateFin {get; set;}
	
	int Chambre {get; set;}
	
	public Hospitalisation(int nas, string codePS, string etablissement, string date, string dateFin, int chambre)
	{
		NAS = nas;
		CodePS = codePS;
		Etablissement = etablissement;
		Date = date;
		DateFin = dateFin;
		Chambre = chambre;
	}
}