using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Documents;
using CommonMvvm;
using Newtonsoft.Json;
using SoundPackConverter.Core.Config;

namespace SoundPackConverter.ConfigEditor.WPF
{
    public class EditorWindowViewModel : ViewModelBase
    {
        public List<Node> EffectNames { get; set; } 
        public List<string> SoundNames { get; set; }

        public Node SelectedNode { get; set; }

        private ConverterConfig _config = new ConverterConfig();

        public EditorWindowViewModel()
        {
            EffectNames = JsonConvert.DeserializeObject<List<Node>>(File.ReadAllText("config.json"), new SoundMappingTreeConverter());
        }
    }
}