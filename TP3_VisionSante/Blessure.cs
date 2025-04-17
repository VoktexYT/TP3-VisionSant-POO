// ----------------------
// Blessure.cs
// Ubert Guertin
// TP3 Vision Sant�
// 2025-04-17
// ----------------------


namespace TP3_VisionSante
{
    /// <summary>
    /// Repr�sente une blessure subie par un citoyen, avec ses d�tails.
    /// H�rite de la classe <see cref="Problemes"/>.
    /// </summary>
    internal class Blessure : Problemes
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="Blessure"/>.
        /// </summary>
        /// <param name="nas">Le num�ro d�assurance sociale du citoyen concern�.</param>
        /// <param name="type">Le type de blessure (ex. fracture, coupure, etc.).</param>
        /// <param name="dateDebut">La date de d�but du probl�me de sant�.</param>
        /// <param name="dateFin">La date de fin du probl�me de sant�.</param>
        /// <param name="description">Une description plus d�taill�e de la blessure.</param>
        public Blessure(int nas, string type, string dateDebut, string dateFin, string description)
            : base(nas, type, dateDebut, dateFin, description)
        { }

        /// <summary>
        /// Affiche les d�tails de la blessure dans un format tabulaire.
        /// </summary>
        public override void Afficher()
        {
            Console.WriteLine($"{Type,-20}{DateDebut,-15}{DateFin,-15}{Description,-20}");
        }
    }
}
