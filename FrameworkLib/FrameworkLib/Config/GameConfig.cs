using System.Xml.Serialization;

namespace FrameworkLib.Config
{
    /// <summary>
    /// Represents the overall configuration for the game, loaded from an XML file.
    /// </summary>
    [XmlRoot("GameConfig")]
    public class GameConfig
    {
        /// <summary>
        /// Contains configuration related to the world size.
        /// </summary>
        public WorldConfig World { get; set; }

        /// <summary>
        /// Specifies the difficulty level of the game (e.g., Novice, Normal, Trained).
        /// </summary>
        public string GameLevel { get; set; }
    }

    /// <summary>
    /// Represents configuration details for the game world.
    /// </summary>
    public class WorldConfig
    {
        /// <summary>
        /// The maximum horizontal size of the world (X-axis).
        /// </summary>
        public int MaxX { get; set; }

        /// <summary>
        /// The maximum vertical size of the world (Y-axis).
        /// </summary>
        public int MaxY { get; set; }
    }
}
