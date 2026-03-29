namespace MusicPlayer
{
    partial class DisplaySongDetails
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DisplaySongDetails));
            this.nameLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.albumLabel = new System.Windows.Forms.Label();
            this.genreLabel = new System.Windows.Forms.Label();
            this.studioLabel = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Bold);
            this.nameLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.nameLabel.Location = new System.Drawing.Point(300, 30);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(180, 37);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Song Name";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.BackColor = System.Drawing.Color.Transparent;
            this.artistLabel.Font = new System.Drawing.Font("Candara", 12F);
            this.artistLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.artistLabel.Location = new System.Drawing.Point(50, 100);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(63, 24);
            this.artistLabel.TabIndex = 1;
            this.artistLabel.Text = "Artist:";
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.BackColor = System.Drawing.Color.Transparent;
            this.durationLabel.Font = new System.Drawing.Font("Candara", 12F);
            this.durationLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.durationLabel.Location = new System.Drawing.Point(50, 140);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(85, 24);
            this.durationLabel.TabIndex = 2;
            this.durationLabel.Text = "Duration:";
            // 
            // albumLabel
            // 
            this.albumLabel.AutoSize = true;
            this.albumLabel.BackColor = System.Drawing.Color.Transparent;
            this.albumLabel.Font = new System.Drawing.Font("Candara", 12F);
            this.albumLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.albumLabel.Location = new System.Drawing.Point(50, 180);
            this.albumLabel.Name = "albumLabel";
            this.albumLabel.Size = new System.Drawing.Size(120, 24);
            this.albumLabel.TabIndex = 3;
            this.albumLabel.Text = "Release Date:";
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.BackColor = System.Drawing.Color.Transparent;
            this.genreLabel.Font = new System.Drawing.Font("Candara", 12F);
            this.genreLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.genreLabel.Location = new System.Drawing.Point(50, 220);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(66, 24);
            this.genreLabel.TabIndex = 4;
            this.genreLabel.Text = "Genre:";
            // 
            // studioLabel
            // 
            this.studioLabel.AutoSize = true;
            this.studioLabel.BackColor = System.Drawing.Color.Transparent;
            this.studioLabel.Font = new System.Drawing.Font("Candara", 12F);
            this.studioLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.studioLabel.Location = new System.Drawing.Point(50, 260);
            this.studioLabel.Name = "studioLabel";
            this.studioLabel.Size = new System.Drawing.Size(70, 24);
            this.studioLabel.TabIndex = 5;
            this.studioLabel.Text = "Studio:";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.BackColor = System.Drawing.Color.Transparent;
            this.infoLabel.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Italic);
            this.infoLabel.ForeColor = System.Drawing.Color.DarkCyan;
            this.infoLabel.Location = new System.Drawing.Point(50, 300);
            this.infoLabel.MaximumSize = new System.Drawing.Size(700, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(47, 24);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "Info:";
            // 
            // DisplaySongDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.studioLabel);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.albumLabel);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "DisplaySongDetails";
            this.Text = "Song Details";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label albumLabel;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label studioLabel;
        private System.Windows.Forms.Label infoLabel;
    }
}
