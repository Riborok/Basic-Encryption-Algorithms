using System;
using System.IO;
using System.Windows.Forms;

namespace Cryptography.Managers {
    public class FileManager {
        private string _path = string.Empty;
        private TextBox _tbFileName;
        private TextBox _tbText;
        public bool IsSaved { get; set; }
        
        public FileManager(TextBox tbFileName, TextBox tbText) {
            IsSaved = true;
            _tbFileName = tbFileName;
            _tbText = tbText;
        }

        public DialogResult WarnIfNotSaved() {
            DialogResult result = DialogResult.None;
            
            if (!IsSaved) {
                 result = MessageBox.Show(
                    $@"The {_tbFileName.Tag} file is not saved. Do you want to save it?",
                    @"Warning",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes) {
                    Save();
                }
            }
            
            return result;
        }
        
        public void Create() {
            if (WarnIfNotSaved() == DialogResult.Cancel)
                return;
            
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            
            saveFileDialog.Title = @"Create file";
            saveFileDialog.Filter = @"Text files (*.txt)|*.txt"; 
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                _path = saveFileDialog.FileName;
                _tbFileName.Text = Path.GetFileName(_path);

                try {
                    using (File.Create(_path)) {
                        IsSaved = true;
                    }
                } catch {
                    throw new FileNotFoundException("The file could not be created!");
                }
            }
        }

        public void Open() {
            if (WarnIfNotSaved() == DialogResult.Cancel)
                return;
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Title = @"Open file";
            openFileDialog.Filter = @"Text files (*.txt)|*.txt"; 
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                _path = openFileDialog.FileName;
                IsSaved = true;

                try {
                    _tbFileName.Text = Path.GetFileName(_path);
                    _tbText.Text = File.ReadAllText(_path);
                } catch {
                    throw new AggregateException("Path of opened file not found.");
                }
            }
        }
        
        public void Save() {
            if (string.IsNullOrEmpty(_path)) {
                Create();
            } else {
                try {
                    File.WriteAllText(_path, _tbText.Text);
                    IsSaved = true;
                }
                catch {
                    throw new FileNotFoundException("The file could not be saved!");
                }
            }
        }
    }
}