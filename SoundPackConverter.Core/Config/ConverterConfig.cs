using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SoundPackConverter.Core.Config
{
    public class ConverterConfig
    {
        /// <summary>
        /// A list of <see cref="SoundEffectType"/> in an order representing the order of the effect types in the LoL WPK archive.
        /// </summary>
        public List<SoundEffectType> LeagueFileOrder { get; set; }

        /// <summary>
        /// A dictionary taking <see cref="SoundEffectType"/> as the key mapping to a list of file names.
        /// Dota file names have the announcer pack then the sound effect in the same name. 
        /// The file names in this mapping are compared to the extracted Dota files via an endswith comparison.
        /// Some of the announcer files have announcer specific prefixes but sound effect generic suffixes.
        /// </summary>
        public Dictionary<SoundEffectType, List<string>>  DotaFileMappings { get; set; }

        public ConverterConfig()
        {
            LeagueFileOrder = new List<SoundEffectType>();
            DotaFileMappings = new Dictionary<SoundEffectType, List<string>>();
            foreach (var type in typeof(SoundEffectType).GetEnumValues())
            {
                DotaFileMappings.Add((SoundEffectType)type, new List<string>());
            }
        }

        /// <summary>
		/// Reads a configuration file from a given path
		/// </summary>
		/// <param name="path">string path</param>
		/// <returns>ConverterConfig object</returns>
		public static ConverterConfig Read(string path)
        {
            if (!File.Exists(path))
                return new ConverterConfig();
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return Read(fs);
            }
        }

        /// <summary>
        /// Reads the configuration file from a stream
        /// </summary>
        /// <param name="stream">stream</param>
        /// <returns>ConverterConfig object</returns>
        public static ConverterConfig Read(Stream stream)
        {
            using (var sr = new StreamReader(stream))
            {
                var cf = JsonConvert.DeserializeObject<ConverterConfig>(sr.ReadToEnd());
                return cf;
            }
        }

        /// <summary>
        /// Writes the configuration to a given path
        /// </summary>
        /// <param name="path">string path - Location to put the config file</param>
        public void Write(string path)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                Write(fs);
            }
        }

        /// <summary>
        /// Writes the configuration to a stream
        /// </summary>
        /// <param name="stream">stream</param>
        public void Write(Stream stream)
        {
            var str = JsonConvert.SerializeObject(this, Formatting.Indented);
            using (var sw = new StreamWriter(stream))
            {
                sw.Write(str);
            }
        }
    }
}