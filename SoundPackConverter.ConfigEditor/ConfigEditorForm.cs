using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using SoundPackConverter.ConfigEditor.Properties;
using SoundPackConverter.Core;
using SoundPackConverter.Core.Config;

namespace SoundPackConverter.ConfigEditor
{
    public partial class ConfigEditorForm : Form
    {
        private ConverterConfig _config = new ConverterConfig();
        private readonly Regex FileNameRegex = new Regex("^(ann)?(ouncer)?_?(?<FileSubstring>.*).(vsnd_c|mp3)");

        public ConfigEditorForm()
        {
            InitializeComponent();
            PopulateEffectTypeListbox();
            ListBoxEffectType.SelectedIndex = 0;
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel.Text = Resources.ToolStripStatusLoading;
            var readFileDialog = new OpenFileDialog();
            readFileDialog.Filter = "JSON Files|*.json";
            readFileDialog.ShowDialog();

            var filePath = readFileDialog.FileName;

            if (string.IsNullOrWhiteSpace(filePath))
                return;

            try
            {
                _config = ConverterConfig.Read(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.ErrorBoxFileLoadingMessage, Resources.ToolStripStatusError, MessageBoxButtons.OK);
                File.WriteAllText("log.txt", ex.ToString());
                ToolStripStatusLabel.Text = Resources.ToolStripStatusError;
                return;
            }

            ToolStripStatusLabel.Text = Resources.ToolStripStatusDone;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            ToolStripStatusLabel.Text = Resources.ToolStripStatusSaving;
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files|*.json";
            saveFileDialog.ShowDialog();

            var filePath = saveFileDialog.FileName;

            if (string.IsNullOrWhiteSpace(filePath))
                return;

            try
            {
                _config.Write(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Resources.ErrorBoxSaveFileMessage, Resources.ToolStripStatusError, MessageBoxButtons.OK);
                File.WriteAllText("log.txt", ex.ToString());
                ToolStripStatusLabel.Text = Resources.ToolStripStatusError;
                return;
            }

            ToolStripStatusLabel.Text = Resources.ToolStripStatusDone;
        }

        private void ListBoxEffectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateSoundNameListbox();
        }

        private void ButtonAddNewName_Click(object sender, EventArgs e)
        {
            var enteredText = TextBoxEnteredNames.Text;
            var enteredLines = enteredText.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            ListBoxSoundName.Items.AddRange(enteredLines);
            _config.DotaFileMappings[(SoundEffectType)ListBoxEffectType.SelectedItem].AddRange(enteredLines);
            TextBoxEnteredNames.Clear();
        }

        private void ButtonDeleteName_Click(object sender, EventArgs e)
        {
            var indices = ListBoxSoundName.SelectedIndices;
            var orderedIndices = indices.Cast<int>().OrderByDescending(x => x);
            foreach (int selectedIndex in orderedIndices)
            {
                ListBoxSoundName.Items.RemoveAt(selectedIndex);
                _config.DotaFileMappings[(SoundEffectType)ListBoxEffectType.SelectedItem].RemoveAt(selectedIndex);
            }
        }

        private void PopulateEffectTypeListbox()
        {
            var objectCollection = new ListBox.ObjectCollection(ListBoxEffectType);
            var enumValues = Enum.GetValues(typeof (SoundEffectType));
            var sortedEnumValues = enumValues.OfType<SoundEffectType>().OrderBy(x => (int) x);
            foreach (var type in sortedEnumValues)
            {
                objectCollection.Add(type);
            }
            ListBoxEffectType.Items.AddRange(objectCollection);
        }

        private void PopulateSoundNameListbox()
        {
            ListBoxSoundName.Items.Clear();
            var itemsArray = _config.DotaFileMappings[(SoundEffectType) ListBoxEffectType.SelectedItem].ToArray();
            itemsArray = itemsArray.OrderBy(x => x).ToArray();
            ListBoxSoundName.Items.AddRange(itemsArray);
        }

        private void TextBoxEnteredNames_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void TextBoxEnteredNames_DragDrop(object sender, DragEventArgs e)
        {
            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
            var fileNames = filePaths.Select(x => Path.GetFileName(x));
            var extractedNames = fileNames.Select(x => FileNameRegex.Match(x).Groups["FileSubstring"].Value).Where(x => !string.IsNullOrWhiteSpace(x));
            ListBoxSoundName.Items.AddRange(extractedNames.ToArray());
            _config.DotaFileMappings[(SoundEffectType)ListBoxEffectType.SelectedItem].AddRange(extractedNames.ToList());
        }
    }
}
