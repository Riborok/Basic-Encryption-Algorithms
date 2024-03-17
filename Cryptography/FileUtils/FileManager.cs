using System;
using System.IO;
using System.Windows.Forms;

namespace Cryptography.FileUtils {
    public class FileManager {
        private string _path = string.Empty;
        private readonly Control _fileName;
        private readonly Control _tbText;
        private readonly IFileService _fileService;
        private readonly FileDialogService _dialogService;
        
        public FileManager(Control fileName, Control tbText, IFileService fileService, string filter) {
            _fileName = fileName;
            _tbText = tbText;
            _fileService = fileService;
            _dialogService = new FileDialogService(filter);
        }

        public void Create() {
            string? path = _dialogService.ShowSaveDialog();
            if (path != null) {
                _path = path;

                _fileService.CreateFile(_path);
                _fileName.Text = Path.GetFileName(_path);
            }
        }

        public void Open() {
            string? path = _dialogService.ShowOpenDialog();
            if (path != null) {
                _path = path;

                _tbText.Text = _fileService.ReadFile(_path);
                _fileName.Text = Path.GetFileName(_path);
            }
        }

        public void Save() {
            if (_path == string.Empty)
                OfferToCreateOrOpenFile();
            if (_path != string.Empty) {
                _fileService.SaveFile(_path, _tbText.Text);
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