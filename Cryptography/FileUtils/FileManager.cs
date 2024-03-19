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
                _fileService.CreateFile(path);
                UpdatePath(path);
            }
        }

        public void Open() {
            if (TryOpenWithoutReading())
                _tbText.Text = _fileService.ReadFile(_path);
        }

        private bool TryOpenWithoutReading() {
            string? path = _dialogService.ShowOpenDialog();
            if (path != null)
                UpdatePath(path);
            return path != null;
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
        }

        public void Save() {
            if (_path == string.Empty)
                OfferToCreateOrOpenFile(); // can update _path
            if (_path != string.Empty)
                _fileService.SaveFile(_path, _tbText.Text);
        }
        
        private void OfferToCreateOrOpenFile() {
            DialogResult dialogResult = FileDialogService.ShowWarningDialog(@"Do you want to save an to existing file?");
            if (dialogResult == DialogResult.Yes)
                TryOpenWithoutReading();
            else if (dialogResult == DialogResult.No)
                Create();
        }
    }
}