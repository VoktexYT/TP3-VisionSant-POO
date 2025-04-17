// ----------------------
// Maladie.cs
// Ubert Guertin
// TP3 Vision Santé
// 2025-04-17
// ----------------------

namespace TP3_VisionSante
{
    /// <summary>
    /// Représente une maladie déclarée pour un citoyen dans le système de santé.
    /// Hérite de la classe <see cref="Problemes"/>.
    /// </summary>
    internal class Maladie : Problemes
    {
        /// <summary>
        /// Obtient ou définit le stade de la maladie.
        /// Représente la gravité ou l'avancement de la maladie.
        /// </summary>
        int Stade { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Maladie"/>.
        /// </summary>
        /// <param name="nas">Le numéro d'assurance sociale du citoyen.</param>
        /// <param name="type">Le type de maladie (ex. : cancer, grippe).</param>
        /// <param name="dateDebut">La date de début de la maladie.</param>
        /// <param name="dateFin">La date de fin de la maladie (ou prévue).</param>
        /// <param name="description">Une description détaillée de la maladie.</param>
        /// <param name="stade">Le stade ou niveau de gravité de la maladie.</param>
        public Maladie(int nas, string type, string dateDebut, string dateFin, string description, int stade)
            : base(nas, type, dateDebut, dateFin, description)
        {
            Stade = stade;
        }

        /// <summary>
        /// Affiche les détails de la maladie dans un format tabulaire.
        /// </summary>
        public override void Afficher()
        {
            Console.WriteLine($"{Type,-20}{Stade,-10}{DateDebut,-15}{DateFin,-15}{Description,-20}");
        }
    }
}


