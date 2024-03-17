using System.IO;

namespace Cryptography.FileUtils {
	public interface IFileService {
		void CreateFile(string path);
		string ReadFile(string path);
		void SaveFile(string path, string content);
	}

	public class TextFileService : IFileService {
		public void CreateFile(string path) {
			try {
				File.Create(path).Dispose();
			} catch {
				throw new IOException("The file could not be created!");
			}
		}

		public string ReadFile(string path) {
			try {
				return File.ReadAllText(path);
			} catch {
				throw new IOException("The file could not be read!");
			}
		}

		public void SaveFile(string path, string content) {
			try {
				File.WriteAllText(path, content);
			} catch {
				throw new IOException("The file could not be saved!");
			}
		}
	}
}