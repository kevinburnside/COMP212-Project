namespace COMP212_FinalProject
{
    partial class FrmSubstitutionCompression
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
        private void InitializeComponent()
        {
            this.lblBrowse = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.compressionGroupBox = new System.Windows.Forms.GroupBox();
            this.compressionTextBox = new System.Windows.Forms.TextBox();
            this.clearTextBox = new System.Windows.Forms.TextBox();
            this.cipheredTextBox = new System.Windows.Forms.TextBox();
            this.compressionLabel = new System.Windows.Forms.Label();
            this.clearLabel = new System.Windows.Forms.Label();
            this.cipheredLabel = new System.Windows.Forms.Label();
            this.compressionGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBrowse
            // 
            this.lblBrowse.AutoSize = true;
            this.lblBrowse.Location = new System.Drawing.Point(22, 28);
            this.lblBrowse.Name = "lblBrowse";
            this.lblBrowse.Size = new System.Drawing.Size(174, 13);
            this.lblBrowse.TabIndex = 0;
            this.lblBrowse.Text = "Select the file you would like to run:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(202, 25);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(196, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(419, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(512, 23);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 3;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(607, 23);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 4;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(697, 23);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // compressionGroupBox
            // 
            this.compressionGroupBox.Controls.Add(this.compressionTextBox);
            this.compressionGroupBox.Controls.Add(this.clearTextBox);
            this.compressionGroupBox.Controls.Add(this.cipheredTextBox);
            this.compressionGroupBox.Controls.Add(this.compressionLabel);
            this.compressionGroupBox.Controls.Add(this.clearLabel);
            this.compressionGroupBox.Controls.Add(this.cipheredLabel);
            this.compressionGroupBox.Location = new System.Drawing.Point(568, 133);
            this.compressionGroupBox.Name = "compressionGroupBox";
            this.compressionGroupBox.Size = new System.Drawing.Size(255, 112);
            this.compressionGroupBox.TabIndex = 7;
            this.compressionGroupBox.TabStop = false;
            this.compressionGroupBox.Text = "Compression Ratio";
            // 
            // compressionTextBox
            // 
            this.compressionTextBox.Location = new System.Drawing.Point(111, 69);
            this.compressionTextBox.Name = "compressionTextBox";
            this.compressionTextBox.Size = new System.Drawing.Size(138, 20);
            this.compressionTextBox.TabIndex = 5;
            // 
            // clearTextBox
            // 
            this.clearTextBox.Location = new System.Drawing.Point(111, 47);
            this.clearTextBox.Name = "clearTextBox";
            this.clearTextBox.Size = new System.Drawing.Size(138, 20);
            this.clearTextBox.TabIndex = 4;
            // 
            // cipheredTextBox
            // 
            this.cipheredTextBox.Location = new System.Drawing.Point(111, 25);
            this.cipheredTextBox.Name = "cipheredTextBox";
            this.cipheredTextBox.Size = new System.Drawing.Size(138, 20);
            this.cipheredTextBox.TabIndex = 3;
            // 
            // compressionLabel
            // 
            this.compressionLabel.AutoSize = true;
            this.compressionLabel.Location = new System.Drawing.Point(6, 69);
            this.compressionLabel.Name = "compressionLabel";
            this.compressionLabel.Size = new System.Drawing.Size(98, 13);
            this.compressionLabel.TabIndex = 2;
            this.compressionLabel.Text = "Compression Ratio:";
            // 
            // clearLabel
            // 
            this.clearLabel.AutoSize = true;
            this.clearLabel.Location = new System.Drawing.Point(6, 47);
            this.clearLabel.Name = "clearLabel";
            this.clearLabel.Size = new System.Drawing.Size(80, 13);
            this.clearLabel.TabIndex = 1;
            this.clearLabel.Text = "Size clear Text:";
            // 
            // cipheredLabel
            // 
            this.cipheredLabel.AutoSize = true;
            this.cipheredLabel.Location = new System.Drawing.Point(6, 25);
            this.cipheredLabel.Name = "cipheredLabel";
            this.cipheredLabel.Size = new System.Drawing.Size(98, 13);
            this.cipheredLabel.TabIndex = 0;
            this.cipheredLabel.Text = "Size ciphered Text:";
            // 
            // FrmSubstitutionCompression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 651);
            this.Controls.Add(this.compressionGroupBox);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblBrowse);
            this.Name = "FrmSubstitutionCompression";
            this.Text = "Substitution Compression";
            this.compressionGroupBox.ResumeLayout(false);
            this.compressionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBrowse;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox compressionGroupBox;
        private System.Windows.Forms.TextBox compressionTextBox;
        private System.Windows.Forms.TextBox clearTextBox;
        private System.Windows.Forms.TextBox cipheredTextBox;
        private System.Windows.Forms.Label compressionLabel;
        private System.Windows.Forms.Label clearLabel;
        private System.Windows.Forms.Label cipheredLabel;
    }
}

