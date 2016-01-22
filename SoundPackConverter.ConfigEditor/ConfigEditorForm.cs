using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json;
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
            PopulateEffectTypeTreeview();
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

        private void ButtonAddNewName_Click(object sender, EventArgs e)
        {
            var enteredText = TextBoxEnteredNames.Text;
            var enteredLines = enteredText.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            ListBoxSoundName.Items.AddRange(enteredLines);
            TextBoxEnteredNames.Clear();
            AddFileToSelectedSoundEffect(enteredLines);
        }

        private void ButtonDeleteName_Click(object sender, EventArgs e)
        {
            var indices = ListBoxSoundName.SelectedIndices;
            var orderedIndices = indices.Cast<int>().OrderByDescending(x => x);
            foreach (int selectedIndex in orderedIndices)
            {
                RemoveFileFromSelectedSoundEffect(ListBoxSoundName.Items[selectedIndex].ToString());
                ListBoxSoundName.Items.RemoveAt(selectedIndex);
            }
        }

        private void PopulateEffectTypeTreeview()
        {
            List<TreeNode> nodes = JsonConvert.DeserializeObject<List<TreeNode>>(File.ReadAllText("config.json"), new SoundMappingTreeConverter());
            TreeViewEffectName.Nodes.AddRange(nodes.ToArray());
        }

        private void PopulateSoundNameListbox()
        {
            ListBoxSoundName.Items.Clear();
            ListBoxSoundName.Items.AddRange(GetFilesForSelectedSoundEffect().ToArray());
        }

        private void TreeViewEffectName_AfterSelect(object sender, TreeViewEventArgs e)
        {
            PopulateSoundNameListbox();
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
            string[] names = extractedNames.ToArray();
            ListBoxSoundName.Items.AddRange(names);
            AddFileToSelectedSoundEffect(names);
        }

        private SoundEffectType? GetSelectedSoundEffectType()
        {
            var selectedText = TreeViewEffectName.SelectedNode.Text;
            SoundEffectType selectedType;
            if (Enum.TryParse(selectedText, out selectedType))
            {
                return selectedType;
            }
            return null;
        }

        private List<string> GetFilesForSelectedSoundEffect()
        {
            var selected = GetSelectedSoundEffectType();
            if (selected.HasValue)
                return _config.DotaFileMappings[selected.Value];
            return new List<string>();
        }

        private void AddFileToSelectedSoundEffect(string file)
        {
            SoundEffectType? effect = GetSelectedSoundEffectType();
            if (effect.HasValue)
                AddFileToSoundEffect(effect.Value, file);
        }

        private void AddFileToSelectedSoundEffect(IEnumerable<string> files)
        {
            SoundEffectType? effect = GetSelectedSoundEffectType();
            if (effect.HasValue)
                AddFileToSoundEffect(effect.Value, files);
        }

        private void RemoveFileFromSelectedSoundEffect(string file)
        {
            SoundEffectType? effect = GetSelectedSoundEffectType();
            if (effect.HasValue)
                RemoveFileFromSoundEffect(effect.Value, file);
        }

        private void AddFileToSoundEffect(SoundEffectType effect, string file)
        {
            _config.DotaFileMappings[effect].Add(file);
        }

        private void AddFileToSoundEffect(SoundEffectType effect, IEnumerable<string> files)
        {
            _config.DotaFileMappings[effect].AddRange(files);
        }

        private void RemoveFileFromSoundEffect(SoundEffectType effect, string file)
        {
            if (_config.DotaFileMappings[effect].Contains(file))
            {
                _config.DotaFileMappings[effect].Remove(file);
            }
        }
    }
}
