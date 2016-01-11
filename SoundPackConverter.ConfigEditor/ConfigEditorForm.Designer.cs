namespace SoundPackConverter.ConfigEditor
{
    partial class ConfigEditorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListBoxEffectType = new System.Windows.Forms.ListBox();
            this.ListBoxSoundName = new System.Windows.Forms.ListBox();
            this.GroupBoxSoundNameEditing = new System.Windows.Forms.GroupBox();
            this.TextBoxEnteredNames = new System.Windows.Forms.TextBox();
            this.ButtonDeleteName = new System.Windows.Forms.Button();
            this.ButtonAddNewName = new System.Windows.Forms.Button();
            this.GroupBoxSaveLoadMenu = new System.Windows.Forms.GroupBox();
            this.ButtonLoad = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.GroupBoxSoundNameEditing.SuspendLayout();
            this.GroupBoxSaveLoadMenu.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxEffectType
            // 
            this.ListBoxEffectType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ListBoxEffectType.FormattingEnabled = true;
            this.ListBoxEffectType.Location = new System.Drawing.Point(12, 12);
            this.ListBoxEffectType.Name = "ListBoxEffectType";
            this.ListBoxEffectType.Size = new System.Drawing.Size(179, 316);
            this.ListBoxEffectType.TabIndex = 0;
            this.ListBoxEffectType.SelectedIndexChanged += new System.EventHandler(this.ListBoxEffectType_SelectedIndexChanged);
            // 
            // ListBoxSoundName
            // 
            this.ListBoxSoundName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListBoxSoundName.FormattingEnabled = true;
            this.ListBoxSoundName.Location = new System.Drawing.Point(443, 12);
            this.ListBoxSoundName.Name = "ListBoxSoundName";
            this.ListBoxSoundName.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ListBoxSoundName.Size = new System.Drawing.Size(179, 316);
            this.ListBoxSoundName.TabIndex = 1;
            // 
            // GroupBoxSoundNameEditing
            // 
            this.GroupBoxSoundNameEditing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxSoundNameEditing.Controls.Add(this.TextBoxEnteredNames);
            this.GroupBoxSoundNameEditing.Controls.Add(this.ButtonDeleteName);
            this.GroupBoxSoundNameEditing.Controls.Add(this.ButtonAddNewName);
            this.GroupBoxSoundNameEditing.Location = new System.Drawing.Point(197, 83);
            this.GroupBoxSoundNameEditing.Name = "GroupBoxSoundNameEditing";
            this.GroupBoxSoundNameEditing.Size = new System.Drawing.Size(240, 255);
            this.GroupBoxSoundNameEditing.TabIndex = 2;
            this.GroupBoxSoundNameEditing.TabStop = false;
            this.GroupBoxSoundNameEditing.Text = "Edit";
            // 
            // TextBoxEnteredNames
            // 
            this.TextBoxEnteredNames.AllowDrop = true;
            this.TextBoxEnteredNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxEnteredNames.Location = new System.Drawing.Point(6, 19);
            this.TextBoxEnteredNames.Multiline = true;
            this.TextBoxEnteredNames.Name = "TextBoxEnteredNames";
            this.TextBoxEnteredNames.Size = new System.Drawing.Size(225, 182);
            this.TextBoxEnteredNames.TabIndex = 4;
            this.TextBoxEnteredNames.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxEnteredNames_DragDrop);
            this.TextBoxEnteredNames.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxEnteredNames_DragEnter);
            // 
            // ButtonDeleteName
            // 
            this.ButtonDeleteName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDeleteName.Location = new System.Drawing.Point(135, 207);
            this.ButtonDeleteName.Name = "ButtonDeleteName";
            this.ButtonDeleteName.Size = new System.Drawing.Size(99, 42);
            this.ButtonDeleteName.TabIndex = 3;
            this.ButtonDeleteName.Text = "Delete Name";
            this.ButtonDeleteName.UseVisualStyleBackColor = true;
            this.ButtonDeleteName.Click += new System.EventHandler(this.ButtonDeleteName_Click);
            // 
            // ButtonAddNewName
            // 
            this.ButtonAddNewName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAddNewName.Location = new System.Drawing.Point(6, 207);
            this.ButtonAddNewName.Name = "ButtonAddNewName";
            this.ButtonAddNewName.Size = new System.Drawing.Size(99, 42);
            this.ButtonAddNewName.TabIndex = 2;
            this.ButtonAddNewName.Text = "Add Name";
            this.ButtonAddNewName.UseVisualStyleBackColor = true;
            this.ButtonAddNewName.Click += new System.EventHandler(this.ButtonAddNewName_Click);
            // 
            // GroupBoxSaveLoadMenu
            // 
            this.GroupBoxSaveLoadMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxSaveLoadMenu.Controls.Add(this.ButtonLoad);
            this.GroupBoxSaveLoadMenu.Controls.Add(this.ButtonSave);
            this.GroupBoxSaveLoadMenu.Location = new System.Drawing.Point(197, 12);
            this.GroupBoxSaveLoadMenu.Name = "GroupBoxSaveLoadMenu";
            this.GroupBoxSaveLoadMenu.Size = new System.Drawing.Size(237, 68);
            this.GroupBoxSaveLoadMenu.TabIndex = 3;
            this.GroupBoxSaveLoadMenu.TabStop = false;
            this.GroupBoxSaveLoadMenu.Text = "Save/Load";
            // 
            // ButtonLoad
            // 
            this.ButtonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonLoad.Location = new System.Drawing.Point(132, 20);
            this.ButtonLoad.Name = "ButtonLoad";
            this.ButtonLoad.Size = new System.Drawing.Size(99, 42);
            this.ButtonLoad.TabIndex = 1;
            this.ButtonLoad.Text = "Load";
            this.ButtonLoad.UseVisualStyleBackColor = true;
            this.ButtonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSave.Location = new System.Drawing.Point(6, 20);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(99, 42);
            this.ButtonSave.TabIndex = 0;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel});
            this.StatusStrip.Location = new System.Drawing.Point(0, 339);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(634, 22);
            this.StatusStrip.TabIndex = 4;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            this.ToolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // ConfigEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.GroupBoxSaveLoadMenu);
            this.Controls.Add(this.GroupBoxSoundNameEditing);
            this.Controls.Add(this.ListBoxSoundName);
            this.Controls.Add(this.ListBoxEffectType);
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "ConfigEditorForm";
            this.Text = "Sound Pack Converter Config Editor";
            this.GroupBoxSoundNameEditing.ResumeLayout(false);
            this.GroupBoxSoundNameEditing.PerformLayout();
            this.GroupBoxSaveLoadMenu.ResumeLayout(false);
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListBoxEffectType;
        private System.Windows.Forms.ListBox ListBoxSoundName;
        private System.Windows.Forms.GroupBox GroupBoxSoundNameEditing;
        private System.Windows.Forms.TextBox TextBoxEnteredNames;
        private System.Windows.Forms.Button ButtonDeleteName;
        private System.Windows.Forms.Button ButtonAddNewName;
        private System.Windows.Forms.GroupBox GroupBoxSaveLoadMenu;
        private System.Windows.Forms.Button ButtonLoad;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
    }
}

