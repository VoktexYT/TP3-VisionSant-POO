// ----------------------
// Hospitalisation.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------

namespace TP3_VisionSante
{
    /// <summary>
    /// Représente une hospitalisation dans le système de santé.
    /// Hérite de la classe <see cref="Intervention"/> et implémente l'interface <see cref="Utilitaires.MethodeAfficherObligatoire"/>.
    /// </summary>
    internal class Hospitalisation : Intervention, Utilitaires.MethodeAfficherObligatoire
    {
        /// <summary>
        /// Obtient ou définit la date de fin de l'hospitalisation.
        /// </summary>
        private string DateFin { get; set; }

        /// <summary>
        /// Obtient ou définit le numéro de la chambre attribuée pendant l'hospitalisation.
        /// </summary>
        private int Chambre { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Hospitalisation"/>.
        /// </summary>
        /// <param name="nas">Le numéro d’assurance sociale du patient.</param>
        /// <param name="codePS">Le code du professionnel de la santé responsable.</param>
        /// <param name="etablissement">Le nom de l’établissement où a lieu l’hospitalisation.</param>
        /// <param name="date">La date de début de l’hospitalisation.</param>
        /// <param name="dateFin">La date de fin de l’hospitalisation.</param>
        /// <param name="chambre">Le numéro de chambre attribué pendant l’hospitalisation.</param>
        public Hospitalisation(int nas, string codePS, string etablissement, string date, string dateFin, int chambre)
            : base(nas, codePS, etablissement, date)
        {
            DateFin = dateFin;
            Chambre = chambre;
        }

        /// <summary>
        /// Affiche les détails de l’hospitalisation dans un format tabulaire.
        /// </summary>
        public override void Afficher()
        {
            Console.WriteLine($"{Etablissement,-30}{Date,-12}{CodePS,-8}{Chambre,-8}{DateFin,-12}");
        }
    }
}

