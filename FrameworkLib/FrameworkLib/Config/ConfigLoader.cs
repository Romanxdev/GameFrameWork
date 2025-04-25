using System.IO;
using System.Xml.Serialization;

namespace FrameworkLib.Config
{
    /// <summary>
    /// Responsible for loading the game configuration from an XML file..
    /// </summary>
    public static class ConfigLoader
    {
        /// <summary>
        /// Loads GameConfig from the given XML file path.
        /// </summary>
        /// <param name="path">The file path to the XML configuration file.</param>
        /// <returns>A GameConfig object with the loaded data.</returns>
        public static GameConfig Load(string path)
        {
         
            var serializer = new XmlSerializer(typeof(GameConfig));

            
            using var stream = File.OpenRead(path);

           
            return (GameConfig)serializer.Deserialize(stream);
        }
    }
}
