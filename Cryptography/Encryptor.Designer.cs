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
            this.tbKey1 = new System.Windows.Forms.TextBox();
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
            this.tbKey4 = new System.Windows.Forms.TextBox();
            this.tbKey2 = new System.Windows.Forms.TextBox();
            this.tbKey3 = new System.Windows.Forms.TextBox();
            this.dgvKey = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.lbSize = new System.Windows.Forms.Label();
            this.nudSize = new System.Windows.Forms.NumericUpDown();
            this.butSaveAsInitText = new System.Windows.Forms.Button();
            this.butSaveAsCiphertext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tbInitText
            // 
            this.tbInitText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInitText.Location = new System.Drawing.Point(12, 45);
            this.tbInitText.Multiline = true;
            this.tbInitText.Name = "tbInitText";
            this.tbInitText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbInitText.Size = new System.Drawing.Size(300, 105);
            this.tbInitText.TabIndex = 1;
            // 
            // lbKey
            // 
            this.lbKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbKey.Location = new System.Drawing.Point(360, 153);
            this.lbKey.Name = "lbKey";
            this.lbKey.Size = new System.Drawing.Size(300, 33);
            this.lbKey.TabIndex = 6;
            this.lbKey.Text = "Key:";
            this.lbKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // butEncrypt
            // 
            this.butEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.butEncrypt.Location = new System.Drawing.Point(12, 379);
            this.butEncrypt.Name = "butEncrypt";
            this.butEncrypt.Size = new System.Drawing.Size(300, 31);
            this.butEncrypt.TabIndex = 7;
            this.butEncrypt.Text = "Encrypt";
            this.butEncrypt.UseVisualStyleBackColor = true;
            this.butEncrypt.Click += new System.EventHandler(this.butEncrypt_Click);
            // 
            // lbErrors
            // 
            this.lbErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbErrors.Location = new System.Drawing.Point(12, 297);
            this.lbErrors.Name = "lbErrors";
            this.lbErrors.Size = new System.Drawing.Size(300, 33);
            this.lbErrors.TabIndex = 8;
            this.lbErrors.Text = "Errors:";
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
            this.lbEnryptMethod.Text = "Method:";
            this.lbEnryptMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbInitText
            // 
            this.lbInitText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbInitText.Location = new System.Drawing.Point(12, 9);
            this.lbInitText.Name = "lbInitText";
            this.lbInitText.Size = new System.Drawing.Size(300, 33);
            this.lbInitText.TabIndex = 11;
            this.lbInitText.Text = "Initial text:";
            this.lbInitText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbCipherText
            // 
            this.lbCipherText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCipherText.Location = new System.Drawing.Point(12, 153);
            this.lbCipherText.Name = "lbCipherText";
            this.lbCipherText.Size = new System.Drawing.Size(300, 33);
            this.lbCipherText.TabIndex = 13;
            this.lbCipherText.Text = "Ciphertext:";
            this.lbCipherText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbEncryptMethod
            // 
            this.cbEncryptMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncryptMethod.FormattingEnabled = true;
            this.cbEncryptMethod.Items.AddRange(new object[] { "Decimation Method", "Transposition Method", "Rotating grid", "Vigener Method (Direct key)", "Vigener Method (Progressive key)", "Vigener Method (Autokey)", "Playfair Method (Using 4 tables)" });
            this.cbEncryptMethod.Location = new System.Drawing.Point(360, 45);
            this.cbEncryptMethod.Name = "cbEncryptMethod";
            this.cbEncryptMethod.Size = new System.Drawing.Size(300, 21);
            this.cbEncryptMethod.TabIndex = 14;
            this.cbEncryptMethod.SelectedIndexChanged += new System.EventHandler(this.cbEncryptMethod_SelectedIndexChanged);
            // 
            // tbKey1
            // 
            this.tbKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKey1.Location = new System.Drawing.Point(360, 189);
            this.tbKey1.Multiline = true;
            this.tbKey1.Name = "tbKey1";
            this.tbKey1.Size = new System.Drawing.Size(300, 21);
            this.tbKey1.TabIndex = 15;
            this.tbKey1.Tag = "";
            // 
            // tbCiphertext
            // 
            this.tbCiphertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCiphertext.Location = new System.Drawing.Point(12, 189);
            this.tbCiphertext.Multiline = true;
            this.tbCiphertext.Name = "tbCiphertext";
            this.tbCiphertext.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbCiphertext.Size = new System.Drawing.Size(300, 105);
            this.tbCiphertext.TabIndex = 16;
            // 
            // butOpenInitText
            // 
            this.butOpenInitText.Image = global::Cryptography.Properties.Resources.folder;
            this.butOpenInitText.Location = new System.Drawing.Point(222, 17);
            this.butOpenInitText.Name = "butOpenInitText";
            this.butOpenInitText.Size = new System.Drawing.Size(25, 25);
            this.butOpenInitText.TabIndex = 17;
            this.butOpenInitText.UseVisualStyleBackColor = true;
            this.butOpenInitText.Click += new System.EventHandler(this.butOpenInitText_Click);
            // 
            // butSaveInitText
            // 
            this.butSaveInitText.Image = global::Cryptography.Properties.Resources.save;
            this.butSaveInitText.Location = new System.Drawing.Point(253, 17);
            this.butSaveInitText.Name = "butSaveInitText";
            this.butSaveInitText.Size = new System.Drawing.Size(25, 25);
            this.butSaveInitText.TabIndex = 18;
            this.butSaveInitText.UseVisualStyleBackColor = true;
            this.butSaveInitText.Click += new System.EventHandler(this.butSaveInitText_Click);
            // 
            // butSaveCiphertext
            // 
            this.butSaveCiphertext.Image = global::Cryptography.Properties.Resources.save;
            this.butSaveCiphertext.Location = new System.Drawing.Point(253, 161);
            this.butSaveCiphertext.Name = "butSaveCiphertext";
            this.butSaveCiphertext.Size = new System.Drawing.Size(25, 25);
            this.butSaveCiphertext.TabIndex = 20;
            this.butSaveCiphertext.UseVisualStyleBackColor = true;
            this.butSaveCiphertext.Click += new System.EventHandler(this.butSaveCiphertext_Click);
            // 
            // butOpenCiphertext
            // 
            this.butOpenCiphertext.Image = global::Cryptography.Properties.Resources.folder;
            this.butOpenCiphertext.Location = new System.Drawing.Point(222, 161);
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
            this.butDecrypt.Text = "Decrypt";
            this.butDecrypt.UseVisualStyleBackColor = true;
            this.butDecrypt.Click += new System.EventHandler(this.butDecrypt_Click);
            // 
            // butNewInitText
            // 
            this.butNewInitText.Image = global::Cryptography.Properties.Resources._new;
            this.butNewInitText.Location = new System.Drawing.Point(191, 17);
            this.butNewInitText.Name = "butNewInitText";
            this.butNewInitText.Size = new System.Drawing.Size(25, 25);
            this.butNewInitText.TabIndex = 22;
            this.butNewInitText.UseVisualStyleBackColor = true;
            this.butNewInitText.Click += new System.EventHandler(this.butNewInitText_Click);
            // 
            // butNewCiphertext
            // 
            this.butNewCiphertext.Image = global::Cryptography.Properties.Resources._new;
            this.butNewCiphertext.Location = new System.Drawing.Point(191, 161);
            this.butNewCiphertext.Name = "butNewCiphertext";
            this.butNewCiphertext.Size = new System.Drawing.Size(25, 25);
            this.butNewCiphertext.TabIndex = 23;
            this.butNewCiphertext.UseVisualStyleBackColor = true;
            this.butNewCiphertext.Click += new System.EventHandler(this.butNewCiphertext_Click);
            // 
            // tbInitTextFileName
            // 
            this.tbInitTextFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbInitTextFileName.Location = new System.Drawing.Point(83, 14);
            this.tbInitTextFileName.Name = "tbInitTextFileName";
            this.tbInitTextFileName.ReadOnly = true;
            this.tbInitTextFileName.Size = new System.Drawing.Size(102, 22);
            this.tbInitTextFileName.TabIndex = 24;
            this.tbInitTextFileName.Tag = "Enryption";
            // 
            // tbCiphertextFileName
            // 
            this.tbCiphertextFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCiphertextFileName.Location = new System.Drawing.Point(83, 158);
            this.tbCiphertextFileName.Name = "tbCiphertextFileName";
            this.tbCiphertextFileName.ReadOnly = true;
            this.tbCiphertextFileName.Size = new System.Drawing.Size(102, 22);
            this.tbCiphertextFileName.TabIndex = 25;
            this.tbCiphertextFileName.Tag = "Decryption";
            // 
            // tbKey4
            // 
            this.tbKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKey4.Location = new System.Drawing.Point(360, 273);
            this.tbKey4.Multiline = true;
            this.tbKey4.Name = "tbKey4";
            this.tbKey4.Size = new System.Drawing.Size(300, 21);
            this.tbKey4.TabIndex = 26;
            this.tbKey4.Tag = "";
            this.tbKey4.Visible = false;
            // 
            // tbKey2
            // 
            this.tbKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKey2.Location = new System.Drawing.Point(360, 216);
            this.tbKey2.Multiline = true;
            this.tbKey2.Name = "tbKey2";
            this.tbKey2.Size = new System.Drawing.Size(300, 21);
            this.tbKey2.TabIndex = 27;
            this.tbKey2.Tag = "";
            this.tbKey2.Visible = false;
            // 
            // tbKey3
            // 
            this.tbKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbKey3.Location = new System.Drawing.Point(360, 243);
            this.tbKey3.Multiline = true;
            this.tbKey3.Name = "tbKey3";
            this.tbKey3.Size = new System.Drawing.Size(300, 21);
            this.tbKey3.TabIndex = 28;
            this.tbKey3.Tag = "";
            this.tbKey3.Visible = false;
            // 
            // dgvKey
            // 
            this.dgvKey.AllowUserToAddRows = false;
            this.dgvKey.AllowUserToDeleteRows = false;
            this.dgvKey.AllowUserToResizeColumns = false;
            this.dgvKey.AllowUserToResizeRows = false;
            this.dgvKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKey.ColumnHeadersVisible = false;
            this.dgvKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column1 });
            this.dgvKey.GridColor = System.Drawing.Color.Black;
            this.dgvKey.Location = new System.Drawing.Point(427, 189);
            this.dgvKey.Name = "dgvKey";
            this.dgvKey.ReadOnly = true;
            this.dgvKey.RowHeadersVisible = false;
            this.dgvKey.RowTemplate.Height = 20;
            this.dgvKey.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKey.Size = new System.Drawing.Size(165, 163);
            this.dgvKey.TabIndex = 29;
            this.dgvKey.Tag = "";
            this.dgvKey.Visible = false;
            this.dgvKey.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvKey_CellMouseClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 20;
            // 
            // lbLanguage
            // 
            this.lbLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLanguage.Location = new System.Drawing.Point(360, 93);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(74, 33);
            this.lbLanguage.TabIndex = 30;
            this.lbLanguage.Text = "Language:";
            this.lbLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Items.AddRange(new object[] { "En", "Ru" });
            this.cbLanguage.Location = new System.Drawing.Point(360, 129);
            this.cbLanguage.Name = "cbLanguage";
            this.cbLanguage.Size = new System.Drawing.Size(74, 21);
            this.cbLanguage.TabIndex = 31;
            // 
            // lbSize
            // 
            this.lbSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSize.Location = new System.Drawing.Point(518, 93);
            this.lbSize.Name = "lbSize";
            this.lbSize.Size = new System.Drawing.Size(74, 33);
            this.lbSize.TabIndex = 32;
            this.lbSize.Text = "Size:";
            this.lbSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbSize.Visible = false;
            // 
            // nudSize
            // 
            this.nudSize.Location = new System.Drawing.Point(518, 129);
            this.nudSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSize.Name = "nudSize";
            this.nudSize.Size = new System.Drawing.Size(50, 20);
            this.nudSize.TabIndex = 33;
            this.nudSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSize.Visible = false;
            this.nudSize.ValueChanged += new System.EventHandler(this.nudSize_ValueChanged);
            // 
            // butSaveAsInitText
            // 
            this.butSaveAsInitText.Image = ((System.Drawing.Image)(resources.GetObject("butSaveAsInitText.Image")));
            this.butSaveAsInitText.Location = new System.Drawing.Point(284, 17);
            this.butSaveAsInitText.Name = "butSaveAsInitText";
            this.butSaveAsInitText.Size = new System.Drawing.Size(25, 25);
            this.butSaveAsInitText.TabIndex = 34;
            this.butSaveAsInitText.UseVisualStyleBackColor = true;
            this.butSaveAsInitText.Click += new System.EventHandler(this.butSaveAsInitText_Click);
            // 
            // butSaveAsCiphertext
            // 
            this.butSaveAsCiphertext.Image = ((System.Drawing.Image)(resources.GetObject("butSaveAsCiphertext.Image")));
            this.butSaveAsCiphertext.Location = new System.Drawing.Point(284, 161);
            this.butSaveAsCiphertext.Name = "butSaveAsCiphertext";
            this.butSaveAsCiphertext.Size = new System.Drawing.Size(25, 25);
            this.butSaveAsCiphertext.TabIndex = 35;
            this.butSaveAsCiphertext.UseVisualStyleBackColor = true;
            this.butSaveAsCiphertext.Click += new System.EventHandler(this.butSaveAsCiphertext_Click);
            // 
            // Encryptor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(672, 422);
            this.Controls.Add(this.butSaveAsCiphertext);
            this.Controls.Add(this.butSaveAsInitText);
            this.Controls.Add(this.nudSize);
            this.Controls.Add(this.lbSize);
            this.Controls.Add(this.cbLanguage);
            this.Controls.Add(this.lbLanguage);
            this.Controls.Add(this.dgvKey);
            this.Controls.Add(this.tbKey3);
            this.Controls.Add(this.tbKey2);
            this.Controls.Add(this.tbKey4);
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
            this.Controls.Add(this.tbKey1);
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
            this.Text = "Cryptography";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button butSaveAsCiphertext;

        private System.Windows.Forms.Button butSaveAsInitText;

        private System.Windows.Forms.NumericUpDown nudSize;

        private System.Windows.Forms.Label lbSize;

        private System.Windows.Forms.Label lbLanguage;
        private System.Windows.Forms.ComboBox cbLanguage;

        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

        private System.Windows.Forms.DataGridView dgvKey;

        private System.Windows.Forms.TextBox tbKey4;
        private System.Windows.Forms.TextBox tbKey2;
        private System.Windows.Forms.TextBox tbKey3;

        private System.Windows.Forms.TextBox tbCiphertextFileName;

        private System.Windows.Forms.TextBox tbInitTextFileName;

        private System.Windows.Forms.Button butNewInitText;
        private System.Windows.Forms.Button butNewCiphertext;

        private System.Windows.Forms.Button butDecrypt;

        private System.Windows.Forms.Button butSaveCiphertext;
        private System.Windows.Forms.Button butOpenCiphertext;

        private System.Windows.Forms.Button butSaveInitText;

        private System.Windows.Forms.Button butOpenInitText;

        private System.Windows.Forms.TextBox tbKey1;

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