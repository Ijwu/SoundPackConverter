using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundPackConverter.Core
{
    public class SoundFileMapping
    {
        public SoundEffectType EffectType { get; set; }
        public List<string> DotaNames { get; set; } = new List<string>();
        public List<string> LeagueNames { get; set; } = new List<string>();
    }
}
