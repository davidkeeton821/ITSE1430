namespace DavidKeeton.MovieLib.Windows
{
    partial class MovieDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._chkIsOwned = new System.Windows.Forms.CheckBox();
            this._textTitle = new System.Windows.Forms.TextBox();
            this._textDescription = new System.Windows.Forms.TextBox();
            this._textLength = new System.Windows.Forms.TextBox();
            this._buttonSave = new System.Windows.Forms.Button();
            this._buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "minutes";
            // 
            // _chkIsOwned
            // 
            this._chkIsOwned.AutoSize = true;
            this._chkIsOwned.Location = new System.Drawing.Point(97, 185);
            this._chkIsOwned.Name = "_chkIsOwned";
            this._chkIsOwned.Size = new System.Drawing.Size(74, 21);
            this._chkIsOwned.TabIndex = 3;
            this._chkIsOwned.Text = "Owned";
            this._chkIsOwned.UseVisualStyleBackColor = true;
            // 
            // _textTitle
            // 
            this._textTitle.Location = new System.Drawing.Point(97, 37);
            this._textTitle.Name = "_textTitle";
            this._textTitle.Size = new System.Drawing.Size(375, 22);
            this._textTitle.TabIndex = 0;
            // 
            // _textDescription
            // 
            this._textDescription.Location = new System.Drawing.Point(97, 65);
            this._textDescription.Multiline = true;
            this._textDescription.Name = "_textDescription";
            this._textDescription.Size = new System.Drawing.Size(375, 79);
            this._textDescription.TabIndex = 1;
            // 
            // _textLength
            // 
            this._textLength.Location = new System.Drawing.Point(97, 157);
            this._textLength.Name = "_textLength";
            this._textLength.Size = new System.Drawing.Size(63, 22);
            this._textLength.TabIndex = 2;
            // 
            // _buttonSave
            // 
            this._buttonSave.Location = new System.Drawing.Point(334, 259);
            this._buttonSave.Name = "_buttonSave";
            this._buttonSave.Size = new System.Drawing.Size(75, 23);
            this._buttonSave.TabIndex = 4;
            this._buttonSave.Text = "Save";
            this._buttonSave.UseVisualStyleBackColor = true;
            this._buttonSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _buttonCancel
            // 
            this._buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._buttonCancel.Location = new System.Drawing.Point(415, 259);
            this._buttonCancel.Name = "_buttonCancel";
            this._buttonCancel.Size = new System.Drawing.Size(75, 23);
            this._buttonCancel.TabIndex = 5;
            this._buttonCancel.Text = "Cancel";
            this._buttonCancel.UseVisualStyleBackColor = true;
            // 
            // MovieDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._buttonCancel;
            this.ClientSize = new System.Drawing.Size(509, 312);
            this.Controls.Add(this._buttonCancel);
            this.Controls.Add(this._buttonSave);
            this.Controls.Add(this._textLength);
            this.Controls.Add(this._textDescription);
            this.Controls.Add(this._textTitle);
            this.Controls.Add(this._chkIsOwned);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MovieDetailForm";
            this.Text = "Movie Details";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox _chkIsOwned;
        private System.Windows.Forms.TextBox _textTitle;
        private System.Windows.Forms.TextBox _textDescription;
        private System.Windows.Forms.TextBox _textLength;
        private System.Windows.Forms.Button _buttonSave;
        private System.Windows.Forms.Button _buttonCancel;
    }
}