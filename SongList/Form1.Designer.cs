using System.Data.SqlClient;
using System.Windows.Forms;

namespace SongList
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ArtistSearchBox = new System.Windows.Forms.TextBox();
            this.SearchArtistButton = new System.Windows.Forms.Button();
            this.ClearArtistButton = new System.Windows.Forms.Button();
            this.ArtstAlbumSearchListView = new System.Windows.Forms.ListView();
            this.SongListView = new System.Windows.Forms.ListView();
            this.AlbumTrackListView = new System.Windows.Forms.ListView();
            this.ReturnArtistButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.artistSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.songListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InstructionLabel2 = new System.Windows.Forms.Label();
            this.InstructionLabel1 = new System.Windows.Forms.Label();
            this.InstructionLabel3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.PoweredByLabel = new System.Windows.Forms.Label();
            this.ViewSongListButton = new System.Windows.Forms.Button();
            this.ViiewTrackListButton = new System.Windows.Forms.Button();
            this.ExportButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // ArtistSearchBox
            // 
            this.ArtistSearchBox.Location = new System.Drawing.Point(80, 185);
            this.ArtistSearchBox.Name = "ArtistSearchBox";
            this.ArtistSearchBox.Size = new System.Drawing.Size(180, 20);
            this.ArtistSearchBox.TabIndex = 1;
            this.ArtistSearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchEnterKeyPress);
            // 
            // SearchArtistButton
            // 
            this.SearchArtistButton.Location = new System.Drawing.Point(265, 185);
            this.SearchArtistButton.Name = "SearchArtistButton";
            this.SearchArtistButton.Size = new System.Drawing.Size(50, 20);
            this.SearchArtistButton.TabIndex = 2;
            this.SearchArtistButton.Text = "Search";
            this.SearchArtistButton.UseVisualStyleBackColor = true;
            this.SearchArtistButton.Click += new System.EventHandler(this.SearchButton);
            // 
            // ClearArtistButton
            // 
            this.ClearArtistButton.Location = new System.Drawing.Point(320, 185);
            this.ClearArtistButton.Name = "ClearArtistButton";
            this.ClearArtistButton.Size = new System.Drawing.Size(50, 20);
            this.ClearArtistButton.TabIndex = 4;
            this.ClearArtistButton.Text = "Clear";
            this.ClearArtistButton.UseVisualStyleBackColor = true;
            this.ClearArtistButton.Click += new System.EventHandler(this.ClearSelectionButton);
            // 
            // ArtstAlbumSearchListView
            // 
            this.ArtstAlbumSearchListView.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArtstAlbumSearchListView.FullRowSelect = true;
            this.ArtstAlbumSearchListView.Location = new System.Drawing.Point(10, 210);
            this.ArtstAlbumSearchListView.Name = "ArtstAlbumSearchListView";
            this.ArtstAlbumSearchListView.Size = new System.Drawing.Size(870, 235);
            this.ArtstAlbumSearchListView.TabIndex = 5;
            this.ArtstAlbumSearchListView.UseCompatibleStateImageBehavior = false;
            this.ArtstAlbumSearchListView.View = System.Windows.Forms.View.Details;
            this.ArtstAlbumSearchListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.AlbumSort);
            this.ArtstAlbumSearchListView.Click += new System.EventHandler(this.AlbumSelected);
            // 
            // SongListView
            // 
            this.SongListView.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongListView.FullRowSelect = true;
            this.SongListView.Location = new System.Drawing.Point(10, 210);
            this.SongListView.Name = "SongListView";
            this.SongListView.Size = new System.Drawing.Size(870, 235);
            this.SongListView.TabIndex = 5;
            this.SongListView.UseCompatibleStateImageBehavior = false;
            this.SongListView.View = System.Windows.Forms.View.Details;
            this.SongListView.Click += new System.EventHandler(this.DeleteFromTrackList);
            // 
            // AlbumTrackListView
            // 
            this.AlbumTrackListView.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlbumTrackListView.FullRowSelect = true;
            this.AlbumTrackListView.GridLines = true;
            this.AlbumTrackListView.Location = new System.Drawing.Point(10, 210);
            this.AlbumTrackListView.Name = "AlbumTrackListView";
            this.AlbumTrackListView.Size = new System.Drawing.Size(870, 235);
            this.AlbumTrackListView.TabIndex = 11;
            this.AlbumTrackListView.UseCompatibleStateImageBehavior = false;
            this.AlbumTrackListView.View = System.Windows.Forms.View.Details;
            this.AlbumTrackListView.Click += new System.EventHandler(this.SongSelection_click);
            // 
            // ReturnArtistButton
            // 
            this.ReturnArtistButton.Location = new System.Drawing.Point(375, 185);
            this.ReturnArtistButton.Name = "ReturnArtistButton";
            this.ReturnArtistButton.Size = new System.Drawing.Size(135, 20);
            this.ReturnArtistButton.TabIndex = 7;
            this.ReturnArtistButton.Text = "Back To Album Search";
            this.ReturnArtistButton.UseVisualStyleBackColor = true;
            this.ReturnArtistButton.Click += new System.EventHandler(this.ReturnToSearchButtonClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.artistSearchToolStripMenuItem,
            this.trackListToolStripMenuItem,
            this.songListToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // artistSearchToolStripMenuItem
            // 
            this.artistSearchToolStripMenuItem.Name = "artistSearchToolStripMenuItem";
            this.artistSearchToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.artistSearchToolStripMenuItem.Text = "Album Search";
            this.artistSearchToolStripMenuItem.Click += new System.EventHandler(this.ShowAlbumSearch);
            // 
            // trackListToolStripMenuItem
            // 
            this.trackListToolStripMenuItem.Name = "trackListToolStripMenuItem";
            this.trackListToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.trackListToolStripMenuItem.Text = "Track List";
            this.trackListToolStripMenuItem.Click += new System.EventHandler(this.ShowTrackListSearch);
            // 
            // songListToolStripMenuItem
            // 
            this.songListToolStripMenuItem.Name = "songListToolStripMenuItem";
            this.songListToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.songListToolStripMenuItem.Text = "Song List";
            this.songListToolStripMenuItem.Click += new System.EventHandler(this.ViewSongListButton_Click);
            // 
            // InstructionLabel2
            // 
            this.InstructionLabel2.AutoSize = true;
            this.InstructionLabel2.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionLabel2.ForeColor = System.Drawing.Color.Lime;
            this.InstructionLabel2.Location = new System.Drawing.Point(275, 150);
            this.InstructionLabel2.Name = "InstructionLabel2";
            this.InstructionLabel2.Size = new System.Drawing.Size(376, 20);
            this.InstructionLabel2.TabIndex = 10;
            this.InstructionLabel2.Text = "Start by searching for an Artist/Band below.";
            // 
            // InstructionLabel1
            // 
            this.InstructionLabel1.AutoSize = true;
            this.InstructionLabel1.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionLabel1.ForeColor = System.Drawing.Color.Lime;
            this.InstructionLabel1.Location = new System.Drawing.Point(250, 130);
            this.InstructionLabel1.Name = "InstructionLabel1";
            this.InstructionLabel1.Size = new System.Drawing.Size(406, 20);
            this.InstructionLabel1.TabIndex = 10;
            this.InstructionLabel1.Text = "Build a list of songs and save it as an Excel file.";
            // 
            // InstructionLabel3
            // 
            this.InstructionLabel3.AutoSize = true;
            this.InstructionLabel3.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstructionLabel3.ForeColor = System.Drawing.Color.Lime;
            this.InstructionLabel3.Location = new System.Drawing.Point(250, 459);
            this.InstructionLabel3.Name = "InstructionLabel3";
            this.InstructionLabel3.Size = new System.Drawing.Size(14, 20);
            this.InstructionLabel3.TabIndex = 13;
            this.InstructionLabel3.Text = " ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(350, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(210, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(350, 510);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(210, 30);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // PoweredByLabel
            // 
            this.PoweredByLabel.AutoSize = true;
            this.PoweredByLabel.Font = new System.Drawing.Font("Century", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PoweredByLabel.ForeColor = System.Drawing.Color.Lime;
            this.PoweredByLabel.Location = new System.Drawing.Point(407, 487);
            this.PoweredByLabel.Name = "PoweredByLabel";
            this.PoweredByLabel.Size = new System.Drawing.Size(103, 20);
            this.PoweredByLabel.TabIndex = 16;
            this.PoweredByLabel.Text = "Powered by";
            // 
            // ViewSongListButton
            // 
            this.ViewSongListButton.Location = new System.Drawing.Point(635, 185);
            this.ViewSongListButton.Name = "ViewSongListButton";
            this.ViewSongListButton.Size = new System.Drawing.Size(90, 20);
            this.ViewSongListButton.TabIndex = 17;
            this.ViewSongListButton.Text = "View Song List";
            this.ViewSongListButton.UseVisualStyleBackColor = true;
            this.ViewSongListButton.Click += new System.EventHandler(this.ViewSongListButton_Click);
            // 
            // ViiewTrackListButton
            // 
            this.ViiewTrackListButton.Location = new System.Drawing.Point(515, 185);
            this.ViiewTrackListButton.Name = "ViiewTrackListButton";
            this.ViiewTrackListButton.Size = new System.Drawing.Size(115, 20);
            this.ViiewTrackListButton.TabIndex = 18;
            this.ViiewTrackListButton.Text = "Back To Track List";
            this.ViiewTrackListButton.UseVisualStyleBackColor = true;
            this.ViiewTrackListButton.Click += new System.EventHandler(this.ViewTrackListButton_Click);
            // 
            // ExportButton
            // 
            this.ExportButton.Location = new System.Drawing.Point(730, 185);
            this.ExportButton.Name = "ExportButton";
            this.ExportButton.Size = new System.Drawing.Size(75, 20);
            this.ExportButton.TabIndex = 19;
            this.ExportButton.Text = "Export";
            this.ExportButton.UseVisualStyleBackColor = true;
            this.ExportButton.Click += new System.EventHandler(this.ExportToExcel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Developed by Sean Leonard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Email: sdvpl2011@gmail.com";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(894, 551);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ExportButton);
            this.Controls.Add(this.ViiewTrackListButton);
            this.Controls.Add(this.ViewSongListButton);
            this.Controls.Add(this.PoweredByLabel);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.InstructionLabel3);
            this.Controls.Add(this.InstructionLabel1);
            this.Controls.Add(this.InstructionLabel2);
            this.Controls.Add(this.ReturnArtistButton);
            this.Controls.Add(this.ArtstAlbumSearchListView);
            this.Controls.Add(this.SongListView);
            this.Controls.Add(this.AlbumTrackListView);
            this.Controls.Add(this.ClearArtistButton);
            this.Controls.Add(this.SearchArtistButton);
            this.Controls.Add(this.ArtistSearchBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "SonglistBuilder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private void Form1_Load(object sender, System.EventArgs e)
        {
            // ArtstAlbumSearchListView Columns
            ColumnHeader ArtistColumn, header1, header2;
            ArtistColumn = new ColumnHeader();
            header1 = new ColumnHeader();
            header2 = new ColumnHeader();

            ArtistColumn.Text = "Artist/Band";
            ArtistColumn.TextAlign = HorizontalAlignment.Left;
            ArtistColumn.Width = 250;

            header1.Text = "Release";
            header1.TextAlign = HorizontalAlignment.Left;
            header1.Width = 250;

            header2.TextAlign = HorizontalAlignment.Left;
            header2.Text = "Release Date";
            header2.Width = 250;

            ArtstAlbumSearchListView.Columns.Add(ArtistColumn);
            ArtstAlbumSearchListView.Columns.Add(header1);
            ArtstAlbumSearchListView.Columns.Add(header2);
            ArtstAlbumSearchListView.View = View.Details;
            AlbumTrackListView.Hide();



            //SongListView Columns
            ColumnHeader header3, header4, header34;
            header3 = new ColumnHeader();
            header4 = new ColumnHeader();
            header34 = new ColumnHeader();

            header3.Text = "Artist/Band ";
            header3.TextAlign = HorizontalAlignment.Left;
            header3.Width = 250;

            header4.TextAlign = HorizontalAlignment.Left;
            header4.Text = "Album Title";
            header4.Width = 250;

            header34.TextAlign = HorizontalAlignment.Left;
            header34.Text = "Track Name";
            header34.Width = 250;

            SongListView.Columns.Add(header3);
            SongListView.Columns.Add(header4);
            SongListView.Columns.Add(header34);
            SongListView.View = View.Details;



            //AlbumTrackListView Columns
            ColumnHeader column0 = new ColumnHeader();
            column0.Text = "Artist/Band";
            column0.Width = 250;
            column0.TextAlign = HorizontalAlignment.Left;

            ColumnHeader column1 = new ColumnHeader();
            column1.Text = "Album Title";
            column1.Width = 250;
            column1.TextAlign = HorizontalAlignment.Left;

            ColumnHeader column2 = new ColumnHeader();
            column2.Text = "Track Name";
            column2.Width = 250;
            column2.TextAlign = HorizontalAlignment.Left;

            AlbumTrackListView.Columns.Add(column0);
            AlbumTrackListView.Columns.Add(column1);
            AlbumTrackListView.Columns.Add(column2);
            AlbumTrackListView.View = View.Details;
        }

        private TextBox ArtistSearchBox;
        private Button SearchArtistButton;
        private Button ClearArtistButton;
        private Button ReturnArtistButton;

        private ListView ArtstAlbumSearchListView;
        private ListView AlbumTrackListView;
        private ListView SongListView;
        //private ListView LearntSongListView;
        private MenuStrip menuStrip1;

        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem artistSearchToolStripMenuItem;
        private ToolStripMenuItem songListToolStripMenuItem;

        private Label InstructionLabel3;
        private Label InstructionLabel2;
        private Label InstructionLabel1;
        private ToolStripMenuItem trackListToolStripMenuItem;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label PoweredByLabel;
        private Button ViewSongListButton;
        private Button ViiewTrackListButton;
        private Button ExportButton;
        private Label label1;
        private Label label2;
    }

        
    
}

