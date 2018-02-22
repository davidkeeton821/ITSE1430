namespace DavidKeeton.MovieLib.Windows
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._miFile = new System.Windows.Forms.ToolStripMenuItem();
            this._miMovies = new System.Windows.Forms.ToolStripMenuItem();
            this._miHelp = new System.Windows.Forms.ToolStripMenuItem();
            this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this._miMoviesAdd = new System.Windows.Forms.ToolStripMenuItem();
            this._miMoviesEdit = new System.Windows.Forms.ToolStripMenuItem();
            this._miMoviesDelete = new System.Windows.Forms.ToolStripMenuItem();
            this._miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFile,
            this._miMovies,
            this._miHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(682, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _miFile
            // 
            this._miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFileExit});
            this._miFile.Name = "_miFile";
            this._miFile.Size = new System.Drawing.Size(44, 24);
            this._miFile.Text = "&File";
            // 
            // _miMovies
            // 
            this._miMovies.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miMoviesAdd,
            this._miMoviesEdit,
            this._miMoviesDelete});
            this._miMovies.Name = "_miMovies";
            this._miMovies.Size = new System.Drawing.Size(68, 24);
            this._miMovies.Text = "&Movies";
            // 
            // _miHelp
            // 
            this._miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout});
            this._miHelp.Name = "_miHelp";
            this._miHelp.Size = new System.Drawing.Size(53, 24);
            this._miHelp.Text = "&Help";
            // 
            // _miHelpAbout
            // 
            this._miHelpAbout.Name = "_miHelpAbout";
            this._miHelpAbout.Size = new System.Drawing.Size(181, 26);
            this._miHelpAbout.Text = "A&bout";
            this._miHelpAbout.Click += new System.EventHandler(this.OnHelpAbout);
            // 
            // _miMoviesAdd
            // 
            this._miMoviesAdd.Name = "_miMoviesAdd";
            this._miMoviesAdd.Size = new System.Drawing.Size(181, 26);
            this._miMoviesAdd.Text = "&Add";
            this._miMoviesAdd.Click += new System.EventHandler(this.OnMoviesAdd);
            // 
            // _miMoviesEdit
            // 
            this._miMoviesEdit.Name = "_miMoviesEdit";
            this._miMoviesEdit.Size = new System.Drawing.Size(181, 26);
            this._miMoviesEdit.Text = "&Edit";
            this._miMoviesEdit.Click += new System.EventHandler(this.OnMoviesEdit);
            // 
            // _miMoviesDelete
            // 
            this._miMoviesDelete.Name = "_miMoviesDelete";
            this._miMoviesDelete.Size = new System.Drawing.Size(181, 26);
            this._miMoviesDelete.Text = "&Delete";
            this._miMoviesDelete.Click += new System.EventHandler(this.OnMoviesDelete);
            // 
            // _miFileExit
            // 
            this._miFileExit.Name = "_miFileExit";
            this._miFileExit.Size = new System.Drawing.Size(181, 26);
            this._miFileExit.Text = "E&xit";
            this._miFileExit.Click += new System.EventHandler(this.OnFileExit);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 353);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Movie Library";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem _miFile;
        private System.Windows.Forms.ToolStripMenuItem _miFileExit;
        private System.Windows.Forms.ToolStripMenuItem _miMovies;
        private System.Windows.Forms.ToolStripMenuItem _miMoviesAdd;
        private System.Windows.Forms.ToolStripMenuItem _miMoviesEdit;
        private System.Windows.Forms.ToolStripMenuItem _miMoviesDelete;
        private System.Windows.Forms.ToolStripMenuItem _miHelp;
        private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
    }
}

