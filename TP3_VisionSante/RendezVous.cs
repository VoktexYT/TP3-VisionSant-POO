// ----------------------
// RendezVous.cs
// Ubert Guertin
// TP3 Vision Sant�
// 2025-04-17
// ----------------------

namespace TP3_VisionSante
{
    /// <summary>
    /// Repr�sente un rendez-vous m�dical entre un citoyen et un professionnel de la sant�.
    /// H�rite de la classe <see cref="Intervention"/>.
    /// </summary>
    internal class RendezVous : Intervention
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RendezVous"/>.
        /// </summary>
        /// <param name="nas">Le num�ro d�assurance sociale du citoyen.</param>
        /// <param name="codePS">Le code du professionnel de la sant� responsable du rendez-vous.</param>
        /// <param name="etablissement">Le nom de l��tablissement o� se d�roule le rendez-vous.</param>
        /// <param name="date">La date du rendez-vous.</param>
        public RendezVous(int nas, string codePS, string etablissement, string date, List<Citoyen> patients)
            : base(nas, codePS, etablissement, date, patients)
        { }

        /// <summary>
        /// Affiche les d�tails du rendez-vous sous forme tabulaire dans la console.
        /// </summary>
        public override void Afficher()
        {
            Console.WriteLine($"{Etablissement,-30}{Date,-12}{NAS,8}");
        }
    }
}


