namespace Tp3_VisionSante;

public class Blessure
{
	private int NAS { get; set; }
	string Type { get; set; }
	string DateDebut { get; set; }
	string Description { get; set; }
	
	public Blessure(int nas, string type, string dateDebut, string description)
	{
		NAS = nas;
		Type = type;
		DateDebut = dateDebut;
		Description = description;
	}
}