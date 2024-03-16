using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cryptography.En_Decryption;
using Cryptography.En_Decryption.Decimation;
using Cryptography.En_Decryption.Playfair;
using Cryptography.En_Decryption.Transposition;
using Cryptography.En_Decryption.Vigener;
using Cryptography.Managers;

namespace Cryptography {
    public partial class Encryptor : Form {
        private FileManager textFileManager;
        private FileManager ciphertextFileManager;

        public Encryptor() {
            InitializeComponent();

            textFileManager = new FileManager(tbInitTextFileName, tbInitText);
            ciphertextFileManager = new FileManager(tbCiphertextFileName, tbCiphertext);
            
            dgvKey.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 0, 0, 0);
        }

        /// <exception cref="ArgumentException">
        /// Thrown when the tag property of the key input control is not an integer.
        /// </exception>
        private void ShowInputKeyComponents(int mask) {
            tbKey1.Visible = HasFlag(mask, InputMask.Tb1);
            tbKey2.Visible = HasFlag(mask, InputMask.Tb2);
            tbKey3.Visible = HasFlag(mask, InputMask.Tb3);
            tbKey4.Visible = HasFlag(mask, InputMask.Tb4);
            dgvKey.Visible = HasFlag(mask, InputMask.Dvg);
            lbSize.Visible = HasFlag(mask, InputMask.LbSize);
            nudSize.Visible = HasFlag(mask, InputMask.NudSize);
        }

        private void butNewInitText_Click(object sender, EventArgs e) {
            try {
                textFileManager.Create();
            } catch (ArgumentException exception) {
                tbErrors.Text = exception.Message;
            }
        }

        private void butNewCiphertext_Click(object sender, EventArgs e) {
            try {
                ciphertextFileManager.Create();
            } catch (ArgumentException exception) {
                tbErrors.Text = exception.Message;
            }
        }

        private void butOpenInitText_Click(object sender, EventArgs e) {
            try {
                textFileManager.Open();
            } catch (ArgumentException exception) {
                tbErrors.Text = exception.Message;
            }
        }

        private void butOpenCiphertext_Click(object sender, EventArgs e) {
            try {
                ciphertextFileManager.Open();
            } catch (ArgumentException exception) {
                tbErrors.Text = exception.Message;
            }
        }

        private void butSaveInitText_Click(object sender, EventArgs e) {
            try {
                textFileManager.Save();
            } catch (ArgumentException exception) {
                tbErrors.Text = exception.Message;
            }
        }

        private void butSaveCiphertext_Click(object sender, EventArgs e) {
            try {
                ciphertextFileManager.Save();
            } catch (ArgumentException exception) {
                tbErrors.Text = exception.Message;
            }
        }

        private void tbInitText_TextChanged(object sender, EventArgs e) {
            textFileManager.IsSaved = false;
        }

        private void tbCiphertext_TextChanged(object sender, EventArgs e) {
            ciphertextFileManager.IsSaved = false;
        }

        private void Encryptor_FormClosing(object sender, FormClosingEventArgs e) {
            if (textFileManager.WarnIfNotSaved() == DialogResult.Cancel) {
                e.Cancel = true;
                return;
            }

            if (ciphertextFileManager.WarnIfNotSaved() == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void cbEncryptMethod_SelectedIndexChanged(object sender, EventArgs e) {
            cbLanguage.Enabled = true;
            cbLanguage.SelectedIndex = 0;
            
            switch (cbEncryptMethod.SelectedIndex) {
                case 1:
                    ShowInputKeyComponents(CreateMask(InputMask.Tb1, InputMask.Tb2));
                    break;
                case 2:
                    ShowInputKeyComponents(CreateMask(InputMask.Dvg, InputMask.LbSize, InputMask.NudSize));
                    break;
                case 6:
                    ShowInputKeyComponents(CreateMask(InputMask.Tb1, InputMask.Tb2, InputMask.Tb3, InputMask.Tb4));
                    cbLanguage.Enabled = false;
                    break;
                default:
                    ShowInputKeyComponents(CreateMask(InputMask.Tb1));
                    break;
            }
        }

        private static string CombineStrings(string str1, string str2, string str3, string str4, string separator) {
            return string.Join(separator, new[] { str1, str2, str3, str4 });
        }

        private (Cipher cipher, IEnumerable<string> keys) GetCipher() {
            Alphabet textAlphabet;
            if (cbLanguage.SelectedIndex == 0) {
                textAlphabet =  Alphabets.EnAlphabet; 
            } else if (cbLanguage.SelectedIndex == 1) {
                textAlphabet = Alphabets.RuAlphabet;
            } else {
                throw new ArgumentException("Language is not selected.");  
            }

            switch (cbEncryptMethod.SelectedIndex) {
                case 0:
                    return (new DecimationCipher(textAlphabet, Alphabets.DigitAlphabet), new[] { tbKey1.Text });
                case 1:
                    return (new TranspositionCipher(textAlphabet, textAlphabet), new[] { tbKey1.Text });
                case 2:
                // var transpositionCipher = new TranspositionCipher(textAlphabet, textAlphabet);
                // tbCiphertext.Text = transpositionCipher.Encrypt(tbInitText.Text, new [] {tbKey1.Text});
                // break;
                case 3:
                    return (new VigenerCipher(new DirectKeyFactory(textAlphabet)), new[] { tbKey1.Text });
                case 4:
                    return (new VigenerCipher(new ProgressiveKeyFactory(textAlphabet)), new[] { tbKey1.Text });
                case 5:
                    return (new VigenerCipher(new SelfGeneratingKeyFactory(textAlphabet)), new[] { tbKey1.Text });
                case 6:
                    const char delimiter = ' ';
                    return (new PlayfairCipher(new PlayfairEnQuadraticKeyFactory(delimiter)), new[] {
                        CombineStrings(
                            tbKey1.Text, tbKey2.Text,
                            tbKey3.Text, tbKey4.Text, delimiter.ToString()
                        )
                    });
                default:
                    throw new ArgumentException("Encryption method is not selected.");
            }
        }
        
        private void butEncrypt_Click(object sender, EventArgs e) {
            tbErrors.Text = string.Empty;
            
            try {
                var (cipher, keys) = GetCipher();
                tbCiphertext.Text = cipher.Encrypt(tbInitText.Text, keys);
            }
            catch (ArgumentException exception) {
                tbErrors.Text = exception.Message;
            }
        }
        
        private void butDecrypt_Click(object sender, EventArgs e) {
            tbErrors.Text = string.Empty;
            
            try {
                var (cipher, keys) = GetCipher();
                tbInitText.Text = cipher.Decrypt(tbCiphertext.Text, keys);
            }
            catch (ArgumentException exception) {
                tbErrors.Text = exception.Message;
            }
        }

        [Flags]
        private enum InputMask {
            Tb1     = 1 << 0,
            Tb2     = 1 << 1,
            Tb3     = 1 << 2,
            Tb4     = 1 << 3,
            Dvg     = 1 << 4,
            LbSize  = 1 << 5,
            NudSize = 1 << 6,
        }
        
        private static bool HasFlag(int mask, InputMask flag) => (mask & (int)flag) != 0;
        
        private static int CreateMask(params InputMask[] flags) {
            int result = 0;
            foreach (var flag in flags)
                result |= (int)flag;
            
            return result;
        }

        private void dgvKey_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            DataGridViewCell cell = dgvKey.Rows[e.RowIndex].Cells[e.ColumnIndex];
            
            if (cell.Style.BackColor == Color.Aquamarine) {
                cell.Style.BackColor = Color.White;
            } else {
                cell.Style.BackColor = Color.Aquamarine;
            }
            
            dgvKey.ClearSelection();
        }

        private void nudSize_ValueChanged(object sender, EventArgs e) {
            int newSize = (int)nudSize.Value;
            dgvKey.RowCount = newSize;
            dgvKey.ColumnCount = newSize;
            
            foreach (DataGridViewColumn column in dgvKey.Columns)
            {
                column.Width = dgvKey.RowTemplate.Height;
            }
        }
    }
}