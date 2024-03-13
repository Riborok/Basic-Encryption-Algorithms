namespace Cryptography
{
    partial class Encryptor
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
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Encryptor));
            this.tbInitText = new System.Windows.Forms.TextBox();
            this.lbKey = new System.Windows.Forms.Label();
            this.butEncrypt = new System.Windows.Forms.Button();
            this.lbErrors = new System.Windows.Forms.Label();
            this.tbErrors = new System.Windows.Forms.TextBox();
            this.lbEnryptMethod = new System.Windows.Forms.Label();
            this.lbInitText = new System.Windows.Forms.Label();
            this.lbCipherText = new System.Windows.Forms.Label();
            this.cbEncryptMethod = new System.Windows.Forms.ComboBox();
            this.tbKey = new System.Windows.Forms.TextBox();
            this.tbCiphertext = new System.Windows.Forms.TextBox();
            this.butOpenInitText = new System.Windows.Forms.Button();
            this.butSaveInitText = new System.Windows.Forms.Button();
            this.butSaveCiphertext = new System.Windows.Forms.Button();
            this.butOpenCiphertext = new System.Windows.Forms.Button();
            this.butDecrypt = new System.Windows.Forms.Button();
            this.butNewInitText = new System.Windows.Forms.Button();
            this.butNewCiphertext = new System.Windows.Forms.Button();
            this.tbInitTextFileName = new System.Windows.Forms.TextBox();
            this.tbCiphertextFileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbInitText
            // 
            this.tbInitText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInitText.Location = new System.Drawing.Point(12, 45);
            this.tbInitText.Multiline = true;
            this.tbInitText.Name = "tbInitText";
            this.tbInitText.Size = new System.Drawing.Size(300, 105);
            this.tbInitText.TabIndex = 1;
            this.tbInitText.TextChanged += new System.EventHandler(this.tbInitText_TextChanged);
            // 
            // lbKey
            // 
            this.lbKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbKey.Location = new System.Drawing.Point(360, 81);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(300, 33);
            this.lbKey.TabIndex = 6;
            this.lbKey.Text = "Ключ:";
            this.lbKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butEncrypt
            // 
            this.butEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEncrypt.Location = new System.Drawing.Point(12, 379);
            this.butEncrypt.Name = "butEncrypt";
            this.butEncrypt.Size = new System.Drawing.Size(300, 31);
            this.butEncrypt.TabIndex = 7;
            this.butEncrypt.Text = "Шифровать";
            this.butEncrypt.UseVisualStyleBackColor = true;
            // 
            // lbErrors
            // 
            this.lbErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbErrors.Location = new System.Drawing.Point(12, 297);
            this.lbErrors.Name = "lbErrors";
            this.lbErrors.Size = new System.Drawing.Size(300, 33);
            this.lbErrors.TabIndex = 8;
            this.lbErrors.Text = "Ошибки:";
            this.lbErrors.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbErrors
            // 
            this.tbErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbErrors.Location = new System.Drawing.Point(12, 333);
            this.tbErrors.Name = "tbErrors";
            this.tbErrors.ReadOnly = true;
            this.tbErrors.Size = new System.Drawing.Size(300, 22);
            this.tbErrors.TabIndex = 9;
            // 
            // lbEnryptMethod
            // 
            this.lbEnryptMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbEnryptMethod.Location = new System.Drawing.Point(360, 9);
            this.lbEnryptMethod.Name = "lbEnryptMethod";
            this.lbEnryptMethod.Size = new System.Drawing.Size(300, 33);
            this.lbEnryptMethod.TabIndex = 10;
            this.lbEnryptMethod.Text = "Метод:";
            this.lbEnryptMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbInitText
            // 
            this.lbInitText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInitText.Location = new System.Drawing.Point(12, 9);
            this.lbInitText.Name = "lbInitText";
            this.lbInitText.Size = new System.Drawing.Size(300, 33);
            this.lbInitText.TabIndex = 11;
            this.lbInitText.Text = "Исходный текст:";
            this.lbInitText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCipherText
            // 
            this.lbCipherText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCipherText.Location = new System.Drawing.Point(12, 153);
            this.lbCipherText.Name = "lbCipherText";
            this.lbCipherText.Size = new System.Drawing.Size(300, 33);
            this.lbCipherText.TabIndex = 13;
            this.lbCipherText.Text = "Шифротекст:";
            this.lbCipherText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbEncryptMethod
            // 
            this.cbEncryptMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncryptMethod.FormattingEnabled = true;
            this.cbEncryptMethod.Items.AddRange(new object[] { "Метод Децимации", "Метод Плейфера (С использованием 4 таблиц)", "Вращающийся квадрат", "Метод Вижнера (Обычный ключ)", "Метод Вижнера (Прогрессивный ключ)", "Метод Вижнера (Саморегенерирующийся ключ)" });
            this.cbEncryptMethod.Location = new System.Drawing.Point(360, 45);
            this.cbEncryptMethod.Name = "cbEncryptMethod";
            this.cbEncryptMethod.Size = new System.Drawing.Size(300, 21);
            this.cbEncryptMethod.TabIndex = 14;
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKey.Location = new System.Drawing.Point(360, 117);
            this.tbKey.Multiline = true;
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(300, 33);
            this.tbKey.TabIndex = 15;
            // 
            // tbCiphertext
            // 
            this.tbCiphertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCiphertext.Location = new System.Drawing.Point(12, 189);
            this.tbCiphertext.Multiline = true;
            this.tbCiphertext.Name = "tbCiphertext";
            this.tbCiphertext.Size = new System.Drawing.Size(300, 105);
            this.tbCiphertext.TabIndex = 16;
            this.tbCiphertext.TextChanged += new System.EventHandler(this.tbCiphertext_TextChanged);
            // 
            // butOpenInitText
            // 
            this.butOpenInitText.Image = global::Cryptography.Properties.Resources.folder;
            this.butOpenInitText.Location = new System.Drawing.Point(256, 17);
            this.butOpenInitText.Name = "butOpenInitText";
            this.butOpenInitText.Size = new System.Drawing.Size(25, 25);
            this.butOpenInitText.TabIndex = 17;
            this.butOpenInitText.UseVisualStyleBackColor = true;
            this.butOpenInitText.Click += new System.EventHandler(this.butOpenInitText_Click);
            // 
            // butSaveInitText
            // 
            this.butSaveInitText.Image = ((System.Drawing.Image)(resources.GetObject("butSaveInitText.Image")));
            this.butSaveInitText.Location = new System.Drawing.Point(287, 17);
            this.butSaveInitText.Name = "butSaveInitText";
            this.butSaveInitText.Size = new System.Drawing.Size(25, 25);
            this.butSaveInitText.TabIndex = 18;
            this.butSaveInitText.UseVisualStyleBackColor = true;
            this.butSaveInitText.Click += new System.EventHandler(this.butSaveInitText_Click);
            // 
            // butSaveCiphertext
            // 
            this.butSaveCiphertext.Image = global::Cryptography.Properties.Resources.save;
            this.butSaveCiphertext.Location = new System.Drawing.Point(287, 161);
            this.butSaveCiphertext.Name = "butSaveCiphertext";
            this.butSaveCiphertext.Size = new System.Drawing.Size(25, 25);
            this.butSaveCiphertext.TabIndex = 20;
            this.butSaveCiphertext.UseVisualStyleBackColor = true;
            this.butSaveCiphertext.Click += new System.EventHandler(this.butSaveCiphertext_Click);
            // 
            // butOpenCiphertext
            // 
            this.butOpenCiphertext.Image = global::Cryptography.Properties.Resources.folder;
            this.butOpenCiphertext.Location = new System.Drawing.Point(256, 161);
            this.butOpenCiphertext.Name = "butOpenCiphertext";
            this.butOpenCiphertext.Size = new System.Drawing.Size(25, 25);
            this.butOpenCiphertext.TabIndex = 19;
            this.butOpenCiphertext.UseVisualStyleBackColor = true;
            this.butOpenCiphertext.Click += new System.EventHandler(this.butOpenCiphertext_Click);
            // 
            // butDecrypt
            // 
            this.butDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butDecrypt.Location = new System.Drawing.Point(360, 379);
            this.butDecrypt.Name = "butDecrypt";
            this.butDecrypt.Size = new System.Drawing.Size(300, 31);
            this.butDecrypt.TabIndex = 21;
            this.butDecrypt.Text = "Дешифровать";
            this.butDecrypt.UseVisualStyleBackColor = true;
            // 
            // butNewInitText
            // 
            this.butNewInitText.Image = global::Cryptography.Properties.Resources._new;
            this.butNewInitText.Location = new System.Drawing.Point(225, 17);
            this.butNewInitText.Name = "butNewInitText";
            this.butNewInitText.Size = new System.Drawing.Size(25, 25);
            this.butNewInitText.TabIndex = 22;
            this.butNewInitText.UseVisualStyleBackColor = true;
            this.butNewInitText.Click += new System.EventHandler(this.butNewInitText_Click);
            // 
            // butNewCiphertext
            // 
            this.butNewCiphertext.Image = global::Cryptography.Properties.Resources._new;
            this.butNewCiphertext.Location = new System.Drawing.Point(225, 161);
            this.butNewCiphertext.Name = "butNewCiphertext";
            this.butNewCiphertext.Size = new System.Drawing.Size(25, 25);
            this.butNewCiphertext.TabIndex = 23;
            this.butNewCiphertext.UseVisualStyleBackColor = true;
            this.butNewCiphertext.Click += new System.EventHandler(this.butNewCiphertext_Click);
            // 
            // tbInitTextFileName
            // 
            this.tbInitTextFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInitTextFileName.Location = new System.Drawing.Point(135, 14);
            this.tbInitTextFileName.Name = "tbInitTextFileName";
            this.tbInitTextFileName.ReadOnly = true;
            this.tbInitTextFileName.Size = new System.Drawing.Size(84, 22);
            this.tbInitTextFileName.TabIndex = 24;
            // 
            // tbCiphertextFileName
            // 
            this.tbCiphertextFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCiphertextFileName.Location = new System.Drawing.Point(135, 158);
            this.tbCiphertextFileName.Name = "tbCiphertextFileName";
            this.tbCiphertextFileName.ReadOnly = true;
            this.tbCiphertextFileName.Size = new System.Drawing.Size(84, 22);
            this.tbCiphertextFileName.TabIndex = 25;
            // 
            // Encryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(672, 422);
            this.Controls.Add(this.tbCiphertextFileName);
            this.Controls.Add(this.tbInitTextFileName);
            this.Controls.Add(this.butNewCiphertext);
            this.Controls.Add(this.butNewInitText);
            this.Controls.Add(this.butDecrypt);
            this.Controls.Add(this.butSaveCiphertext);
            this.Controls.Add(this.butOpenCiphertext);
            this.Controls.Add(this.butSaveInitText);
            this.Controls.Add(this.butOpenInitText);
            this.Controls.Add(this.tbCiphertext);
            this.Controls.Add(this.tbKey);
            this.Controls.Add(this.cbEncryptMethod);
            this.Controls.Add(this.lbCipherText);
            this.Controls.Add(this.lbInitText);
            this.Controls.Add(this.lbEnryptMethod);
            this.Controls.Add(this.tbErrors);
            this.Controls.Add(this.lbErrors);
            this.Controls.Add(this.butEncrypt);
            this.Controls.Add(this.lbKey);
            this.Controls.Add(this.tbInitText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Encryptor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Encryptor_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox tbCiphertextFileName;

        private System.Windows.Forms.TextBox tbInitTextFileName;

        private System.Windows.Forms.Button butNewInitText;
        private System.Windows.Forms.Button butNewCiphertext;

        private System.Windows.Forms.Button butDecrypt;

        private System.Windows.Forms.Button butSaveCiphertext;
        private System.Windows.Forms.Button butOpenCiphertext;

        private System.Windows.Forms.Button butSaveInitText;

        private System.Windows.Forms.Button butOpenInitText;

        private System.Windows.Forms.TextBox tbKey;

        private System.Windows.Forms.ComboBox cbEncryptMethod;

        private System.Windows.Forms.Label lbEnryptMethod;
        private System.Windows.Forms.Label lbInitText;
        private System.Windows.Forms.Label lbCipherText;

        private System.Windows.Forms.Label lbErrors;
        private System.Windows.Forms.TextBox tbErrors;

        private System.Windows.Forms.Button butEncrypt;

        private System.Windows.Forms.Label lbKey;

        private System.Windows.Forms.TextBox tbInitText;

        private System.Windows.Forms.TextBox tbCiphertext;

        #endregion
    }
}