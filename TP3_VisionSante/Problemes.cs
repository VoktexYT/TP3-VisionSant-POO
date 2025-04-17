// ----------------------
// Probleme.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------

namespace TP3_VisionSante;


internal abstract class Problemes : Utilitaires.MethodeAfficherObligatoire
{
    public int NAS { get; set; }
    public string Type { get; set; }
    public string DateDebut { get; set; }
    public string DateFin { get; set; }
    public string Description { get; set; }

    public Problemes(int nas, string type, string dateDebut, string dateFin, string description)
    {
        NAS = nas;
        Type = type;
        DateDebut = dateDebut;
        DateFin = dateFin;
        Description = description;
    }

    public virtual void Afficher()
    {
        Console.WriteLine($"{NAS} {Type} {DateDebut} {DateFin} {Description}");
    }
}
