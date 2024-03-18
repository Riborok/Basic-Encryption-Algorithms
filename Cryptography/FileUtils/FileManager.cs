using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Cryptography.FileUtils {
    public class FileManager {
        public const string SavedSrc = @"../../Resources/saved.png";
        public const string NotSavedSrc = @"../../Resources/notsaved.png";
        
        private string _path = string.Empty;
        private readonly Control _fileName;
        private readonly Control _tbText;
        private readonly IFileService _fileService;
        private readonly FileDialogService _dialogService;
        private readonly Button _butSave;
        
        public FileManager(Control fileName, Control tbText, Button butSave, IFileService fileService, string filter) {
            _fileName = fileName;
            _tbText = tbText;
            _butSave = butSave;
            _fileService = fileService;
            _dialogService = new FileDialogService(filter);
        }

        public void Create() {
            string? path = _dialogService.ShowSaveDialog();
            if (path != null) {
                _fileService.CreateFile(path);
                UpdatePath(path);
            }
        }

        public void Open() {
            string? path = _dialogService.ShowOpenDialog();
            if (path != null) {
                _tbText.Text = _fileService.ReadFile(path);
                UpdatePath(path);
            }
        }

        public void SaveAs() {
            string? path = _dialogService.ShowSaveDialog();
            if (path != null) {
                _fileService.SaveFile(path, _tbText.Text);
                UpdatePath(path);
            }
        }
        
        private void UpdatePath(string path) {
            _path = path;
            _fileName.Text = Path.GetFileName(_path);
            _butSave.Image = Image.FromFile(SavedSrc);
        }

        public void Save() {
            if (_path == string.Empty)
                OfferToCreateOrOpenFile();
            if (_path != string.Empty) {
                _fileService.SaveFile(_path, _tbText.Text);
                _butSave.Image = Image.FromFile(SavedSrc);
            }
        }
        
        private void OfferToCreateOrOpenFile() {
            DialogResult dialogResult = FileDialogService.ShowWarningDialog(
                @"Do you want to create a file?"
            );
            if (dialogResult == DialogResult.Yes)
                Create();
            else if (dialogResult == DialogResult.No)
                Open();
        }
    }
}