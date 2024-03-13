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

        public void WarnIfNotSaved() {
            if (!IsSaved) {
                DialogResult result = MessageBox.Show(
                    $@"The file ${_tbFileName.Text} is not saved. Do you want to save it?",
                    @"Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes) {
                    Save();
                }
            }
        }
        
        public void Create() {
            WarnIfNotSaved();
            
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
            WarnIfNotSaved();
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.Title = @"Open file";
            openFileDialog.Filter = @"Text files (*.txt)|*.txt"; 
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                _path = openFileDialog.FileName;
                _tbFileName.Text = Path.GetFileName(_path);
                IsSaved = true;
                _tbText.Text = File.ReadAllText(_path);
            }
        }
        
        public void Save() {
            if (string.IsNullOrEmpty(_path)) {
                Create();
            }

            if (!string.IsNullOrEmpty(_path)) {
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