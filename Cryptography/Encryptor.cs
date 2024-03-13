using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cryptography.Managers;

namespace Cryptography
{
    public partial class Encryptor : Form
    {
        private FileManager textFileManager;
        private FileManager ciphertextFileManager;
        
        public Encryptor()
        {
            InitializeComponent();
            
            textFileManager = new FileManager(tbInitTextFileName, tbInitText);
            ciphertextFileManager = new FileManager(tbCiphertextFileName, tbCiphertext);
        }

        private void butNewInitText_Click(object sender, EventArgs e) {
            textFileManager.Create();
        }

        private void butNewCiphertext_Click(object sender, EventArgs e) {
            ciphertextFileManager.Create();
        }

        private void butOpenInitText_Click(object sender, EventArgs e) {
            textFileManager.Open();
        }
        
        private void butOpenCiphertext_Click(object sender, EventArgs e) {
            ciphertextFileManager.Open();
        }

        private void butSaveInitText_Click(object sender, EventArgs e) {
            textFileManager.Save();
        }

        private void butSaveCiphertext_Click(object sender, EventArgs e) {
            ciphertextFileManager.Save();
        }

        private void tbInitText_TextChanged(object sender, EventArgs e) {
            textFileManager.IsSaved = false;
        }
        
        private void tbCiphertext_TextChanged(object sender, EventArgs e) {
            ciphertextFileManager.IsSaved = false;
        }

        private void Encryptor_FormClosing(object sender, FormClosingEventArgs e) {
            textFileManager.WarnIfNotSaved();
            ciphertextFileManager.WarnIfNotSaved();
        }
    }
}