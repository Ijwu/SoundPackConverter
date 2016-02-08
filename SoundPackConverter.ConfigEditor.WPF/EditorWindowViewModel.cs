using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using CommonMvvm;
using Newtonsoft.Json;
using SoundPackConverter.Core;
using SoundPackConverter.Core.Config;

namespace SoundPackConverter.ConfigEditor.WPF
{
    public class EditorWindowViewModel : ViewModelBase
    {
        public List<Node> EffectNames { get; set; }

        public List<string> SoundNames
        {
            get
            {
                SoundEffectType effect;
                bool success = Enum.TryParse(((Node)SelectedItem).Value, false, out effect);
                if (success)
                {
                    return _config.DotaFileMappings[effect];
                }
                return new List<string>();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public object SelectedItem { get; set; }

        public ICommand OnAddName => new CommandBase<int>(OnAddNameAction);

        private void OnAddNameAction(int obj)
        {
            MessageBox.Show(SoundNames[0]);
        }

        private ConverterConfig _config = new ConverterConfig();

        public EditorWindowViewModel()
        {
            EffectNames = JsonConvert.DeserializeObject<List<Node>>(File.ReadAllText("config.json"), new SoundMappingTreeConverter());
        }
    }
}