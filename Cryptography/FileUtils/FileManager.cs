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
        
        private bool _hasWarn = false;
        public bool IsSaved { get; set; }
        
        public FileManager(Control fileName, Control tbText, IFileService fileService, string filter) {
            _fileName = fileName;
            _tbText = tbText;
            _fileService = fileService;
            _dialogService = new FileDialogService(filter);
            IsSaved = true;
        }

        public bool WarnIfNotSaved() {
            if (!IsSaved && !_hasWarn) {
                DialogResult dialogResult = FileDialogService.ShowWarningDialog(
                    $@"The file {_fileName.Text} is not saved. Do you want to save it?"
                );

                if (dialogResult == DialogResult.Yes) {
                    _hasWarn = true;
                    Save();
                    _hasWarn = false;
                }

                return dialogResult == DialogResult.Cancel;
            }
            return false;
        }

        public void Create() {
            WarnIfNotSaved();

            string? path = _dialogService.ShowSaveDialog();
            if (path != null) {
                _path = path;
                IsSaved = true;

                _fileService.CreateFile(_path);
                _fileName.Text = Path.GetFileName(_path);
            }
        }

        public void Open() {
            WarnIfNotSaved();

            string? path = _dialogService.ShowOpenDialog();
            if (path != null) {
                _path = path;
                IsSaved = true;

                _tbText.Text = _fileService.ReadFile(_path);
                _fileName.Text = Path.GetFileName(_path);
            }
        }

        public void Save() {
            if (_path == string.Empty)
                OfferToCreateOrOpenFile();
            if (_path != string.Empty) {
                IsSaved = true;
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