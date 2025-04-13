namespace Tp3_VisionSante;

public class Maladie
{
	public int NAS { get; set; }
	string Patoligie { get; set; }
	string DateDebut { get; set; }
	string DateFin { get; set; }
	string Description { get; set; }
	
	int Stade { get; set; }
	
	public Maladie(int nas, string patoligie, string dateDebut, string dateFin, string description, int stade)
	{
		NAS = nas;
		Patoligie = patoligie;
		DateDebut = dateDebut;
		DateFin = dateFin;
		Description = description;
		Stade = stade;
	}

	public void Afficher()
	{
		Console.WriteLine($"{Patoligie,-20}{Stade,-10}{DateDebut,-15}{DateFin,-15}{Description,-20}");
	}
}