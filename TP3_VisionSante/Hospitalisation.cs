// ----------------------
// Hospitalisation.cs
// Ubert Guertin
// TP3 Vision Sant�
// 2025-04-17
// ----------------------

namespace TP3_VisionSante
{
    /// <summary>
    /// Repr�sente une hospitalisation dans le syst�me de sant�.
    /// H�rite de la classe <see cref="Intervention"/> et impl�mente l'interface <see cref="Utilitaires.MethodeAfficherObligatoire"/>.
    /// </summary>
    internal class Hospitalisation : Intervention, Utilitaires.MethodeAfficherObligatoire
    {
        /// <summary>
        /// Obtient ou d�finit la date de fin de l'hospitalisation.
        /// </summary>
        private string DateFin { get; set; }

        /// <summary>
        /// Obtient ou d�finit le num�ro de la chambre attribu�e pendant l'hospitalisation.
        /// </summary>
        private int Chambre { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Hospitalisation"/>.
        /// </summary>
        /// <param name="nas">Le num�ro d�assurance sociale du patient.</param>
        /// <param name="codePS">Le code du professionnel de la sant� responsable.</param>
        /// <param name="etablissement">Le nom de l��tablissement o� a lieu l�hospitalisation.</param>
        /// <param name="date">La date de d�but de l�hospitalisation.</param>
        /// <param name="dateFin">La date de fin de l�hospitalisation.</param>
        /// <param name="chambre">Le num�ro de chambre attribu� pendant l�hospitalisation.</param>
        public Hospitalisation(int nas, string codePS, string etablissement, string date, List<Citoyen> patients, string dateFin, int chambre)
            : base(nas, codePS, etablissement, date, patients)
        {
            DateFin = dateFin;
            Chambre = chambre;
        }

        /// <summary>
        /// Affiche les d�tails de l�hospitalisation dans un format tabulaire.
        /// </summary>
        public override void Afficher()
        {
            Console.WriteLine($"{Etablissement,-30}{Date,-12}{CodePS,-8}{Chambre,-8}{DateFin,-12}");
        }
    }
}

