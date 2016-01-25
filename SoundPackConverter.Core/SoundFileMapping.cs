using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundPackConverter.Core
{
    /// <summary>
    /// Represents a mapping of dota sound effect file names to a league of legends sound cue.
    /// </summary>
    public class SoundFileMapping
    {
        public SoundEffectType EffectType { get; set; }
        public List<string> DotaNames { get; set; } = new List<string>();
    }
}
