namespace DavidKeeton.MovieLib.Windows
{
    partial class AboutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this._labelProjectName = new System.Windows.Forms.Label();
            this._labelVersion = new System.Windows.Forms.Label();
            this._labelCopyright = new System.Windows.Forms.Label();
            this._labelName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this._labelProjectName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this._labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this._labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this._labelName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.okButton, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(12, 11);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(556, 326);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("logoPictureBox.Image")));
            this.logoPictureBox.Location = new System.Drawing.Point(4, 4);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(175, 318);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // _labelProjectName
            // 
            this._labelProjectName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelProjectName.Location = new System.Drawing.Point(191, 0);
            this._labelProjectName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this._labelProjectName.MaximumSize = new System.Drawing.Size(0, 21);
            this._labelProjectName.Name = "_labelProjectName";
            this._labelProjectName.Size = new System.Drawing.Size(361, 21);
            this._labelProjectName.TabIndex = 19;
            this._labelProjectName.Text = "Product Name";
            this._labelProjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelVersion
            // 
            this._labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelVersion.Location = new System.Drawing.Point(191, 32);
            this._labelVersion.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this._labelVersion.MaximumSize = new System.Drawing.Size(0, 21);
            this._labelVersion.Name = "_labelVersion";
            this._labelVersion.Size = new System.Drawing.Size(361, 21);
            this._labelVersion.TabIndex = 0;
            this._labelVersion.Text = "Version";
            this._labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelCopyright
            // 
            this._labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelCopyright.Location = new System.Drawing.Point(191, 64);
            this._labelCopyright.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this._labelCopyright.MaximumSize = new System.Drawing.Size(0, 21);
            this._labelCopyright.Name = "_labelCopyright";
            this._labelCopyright.Size = new System.Drawing.Size(361, 21);
            this._labelCopyright.TabIndex = 21;
            this._labelCopyright.Text = "Copyright";
            this._labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _labelName
            // 
            this._labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelName.Location = new System.Drawing.Point(191, 96);
            this._labelName.Margin = new System.Windows.Forms.Padding(8, 0, 4, 0);
            this._labelName.MaximumSize = new System.Drawing.Size(0, 21);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(361, 21);
            this._labelName.TabIndex = 22;
            this._labelName.Text = "Company Name";
            this._labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(191, 132);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(361, 155);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "Description";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.okButton.Location = new System.Drawing.Point(452, 295);
            this.okButton.Margin = new System.Windows.Forms.Padding(4);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(100, 27);
            this.okButton.TabIndex = 24;
            this.okButton.Text = "&OK";
            // 
            // AboutForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 348);
            this.Controls.Add(this.tableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Padding = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About MovieLib.Windows";
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label _labelProjectName;
        private System.Windows.Forms.Label _labelVersion;
        private System.Windows.Forms.Label _labelCopyright;
        private System.Windows.Forms.Label _labelName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button okButton;
    }
}
