// ----------------------
// RendezVous.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------

namespace TP3_VisionSante
{
    /// <summary>
    /// Représente un rendez-vous médical entre un citoyen et un professionnel de la santé.
    /// Hérite de la classe <see cref="Intervention"/>.
    /// </summary>
    internal class RendezVous : Intervention
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="RendezVous"/>.
        /// </summary>
        /// <param name="nas">Le numéro d’assurance sociale du citoyen.</param>
        /// <param name="codePS">Le code du professionnel de la santé responsable du rendez-vous.</param>
        /// <param name="etablissement">Le nom de l’établissement où se déroule le rendez-vous.</param>
        /// <param name="date">La date du rendez-vous.</param>
        public RendezVous(int nas, string codePS, string etablissement, string date)
            : base(nas, codePS, etablissement, date)
        { }

        /// <summary>
        /// Affiche les détails du rendez-vous sous forme tabulaire dans la console.
        /// </summary>
        public override void Afficher()
        {
            Console.WriteLine($"{Etablissement,-30}{Date,-12}{NAS,8}");
        }
    }
}


