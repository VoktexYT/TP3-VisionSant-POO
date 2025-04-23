// ----------------------
// Intervention.cs
// Ubert Guertin
// TP3 Vision Sant�
// 2025-04-17
// ----------------------

namespace TP3_VisionSante;

/// <summary>
/// Classe abstraite repr�sentant une intervention m�dicale.
/// Elle impl�mente une m�thode obligatoire d'affichage via l'interface <see cref="Utilitaires.MethodeAfficherObligatoire"/>.
/// </summary>
internal abstract class Intervention : Utilitaires.MethodeAfficherObligatoire
{
    public int NAS { get; set; }
    public string CodePS { get; set; }
    public string Etablissement { get; set; }
    public DateTime Date { get; set; }

    public string DateStr { get; set; }

    public string PatientNom { get; set; }
    private List<Citoyen> Patients;

    /// <summary>
    /// Initialise une nouvelle instance de la classe <see cref="Intervention"/>.
    /// </summary>
    /// <param name="nas">Num�ro d'assurance sociale du patient.</param>
    /// <param name="codePS">Code du professionnel de sant�.</param>
    /// <param name="etablissement">�tablissement o� a eu lieu l'intervention.</param>
    /// <param name="date">Date de l'intervention (format texte "yyyy-MM-dd").</param>
    /// <param name="patients">Liste des citoyens utilis�e pour retrouver les noms des patients.</param>
    public Intervention(int nas, string codePS, string etablissement, string date, List<Citoyen> patients)
    {
        NAS = nas;
        CodePS = codePS;
        Etablissement = etablissement;
        DateStr = date;
        Patients = patients;
        
        RecupererNomPatient();
        RecupererFormatDate();
    }

    /// <summary>
    /// M�thode virtuelle d'affichage de base pour l'intervention.
    /// Peut �tre red�finie dans les classes d�riv�es.
    /// </summary>
    public virtual void Afficher()
    {
        Console.WriteLine($"{NAS} {CodePS} {Etablissement} {DateStr}");
    }

    /// <summary>
    /// Affiche les d�tails de l'intervention en incluant les informations du patient,
    /// � partir de la liste fournie.
    /// </summary>
    /// <param name="patients">Liste de patients � utiliser pour trouver le nom correspondant au NAS.</param>
    public void AfficherProfessionnel(List<Citoyen> patients)
    {
        foreach (Citoyen patient in patients)
        {
            if (patient.NAS == NAS)
            {
                Console.WriteLine($"{patient.Nom,-30}{NAS,-10}{DateStr,-12}{Etablissement,-20}");
            }
        }
    }

    /// <summary>
    /// Convertit la cha�ne de date (<see cref="DateStr"/>) en un objet <see cref="DateTime"/>
    /// et l�assigne � la propri�t� <see cref="Date"/>.
    /// </summary>
    private void RecupererFormatDate()
    {
        string[] d = DateStr.Split("-");
        Date = new DateTime(int.Parse(d[0]), int.Parse(d[1]), int.Parse(d[2]));
    }

    /// <summary>
    /// Recherche dans la liste de patients celui correspondant au NAS,
    /// et enregistre son nom dans <see cref="PatientNom"/>.
    /// </summary>
    private void RecupererNomPatient()
    {
        foreach (Citoyen patient in Patients)
        {
            if (patient.NAS == NAS)
            {
                PatientNom = patient.Nom;
                break;
            }
        }
    }
}