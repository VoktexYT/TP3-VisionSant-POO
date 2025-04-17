// ----------------------
// Maladie.cs
// Ubert Guertin
// TP3 Vision Sant�
// 2025-04-17
// ----------------------

namespace TP3_VisionSante
{
    /// <summary>
    /// Repr�sente une maladie d�clar�e pour un citoyen dans le syst�me de sant�.
    /// H�rite de la classe <see cref="Problemes"/>.
    /// </summary>
    internal class Maladie : Problemes
    {
        /// <summary>
        /// Obtient ou d�finit le stade de la maladie.
        /// Repr�sente la gravit� ou l'avancement de la maladie.
        /// </summary>
        int Stade { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Maladie"/>.
        /// </summary>
        /// <param name="nas">Le num�ro d'assurance sociale du citoyen.</param>
        /// <param name="type">Le type de maladie (ex. : cancer, grippe).</param>
        /// <param name="dateDebut">La date de d�but de la maladie.</param>
        /// <param name="dateFin">La date de fin de la maladie (ou pr�vue).</param>
        /// <param name="description">Une description d�taill�e de la maladie.</param>
        /// <param name="stade">Le stade ou niveau de gravit� de la maladie.</param>
        public Maladie(int nas, string type, string dateDebut, string dateFin, string description, int stade)
            : base(nas, type, dateDebut, dateFin, description)
        {
            Stade = stade;
        }

        /// <summary>
        /// Affiche les d�tails de la maladie dans un format tabulaire.
        /// </summary>
        public override void Afficher()
        {
            Console.WriteLine($"{Type,-20}{Stade,-10}{DateDebut,-15}{DateFin,-15}{Description,-20}");
        }
    }
}


