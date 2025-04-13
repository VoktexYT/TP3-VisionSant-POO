namespace Tp3_VisionSante;

public class Blessure
{
	public int NAS { get; set; }
	public string Type { get; set; }
	public string DateDebut { get; set; }
	public string DateFin { get; set; }
	public string Description { get; set; }
	
	public Blessure(int nas, string type, string dateDebut, string dateFin, string description)
	{
		NAS = nas;
		Type = type;
		DateDebut = dateDebut;
		DateFin = dateFin;
		Description = description;
	}

	public void Afficher()
	{
		Console.WriteLine($"{Type,-20}{DateDebut,-15}{DateFin,-15}{Description,-20}");
	}
}