namespace MusicPlayer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //private System.Windows.Forms.Button addPlaylistButton;

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
            this.label5 = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Label();
            this.displaySongs = new System.Windows.Forms.Button();
            this.deleteSongs = new System.Windows.Forms.Button();
            this.displayPlaylists = new System.Windows.Forms.Button();
            this.timeLabel = new System.Windows.Forms.Label();
            this.addPlaylistButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Candara", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(64, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 44);
            this.label5.TabIndex = 4;
            this.label5.Text = "NOW PLAYING:";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Candara", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.title.ForeColor = System.Drawing.Color.DarkCyan;
            this.title.Location = new System.Drawing.Point(345, 114);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(0, 39);
            this.title.TabIndex = 5;
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.BackColor = System.Drawing.Color.Transparent;
            this.artistLabel.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.artistLabel.Location = new System.Drawing.Point(347, 153);
            this.artistLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(70, 29);
            this.artistLabel.TabIndex = 6;
            this.artistLabel.Text = "Artist";
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.Transparent;
            this.playButton.Image = ((System.Drawing.Image)(resources.GetObject("playButton.Image")));
            this.playButton.Location = new System.Drawing.Point(904, 103);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(60, 60);
            this.playButton.TabIndex = 7;
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.BackColor = System.Drawing.Color.Transparent;
            this.previousButton.Image = ((System.Drawing.Image)(resources.GetObject("previousButton.Image")));
            this.previousButton.Location = new System.Drawing.Point(827, 103);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(60, 60);
            this.previousButton.TabIndex = 10;
            this.previousButton.UseVisualStyleBackColor = false;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.Transparent;
            this.nextButton.Image = ((System.Drawing.Image)(resources.GetObject("nextButton.Image")));
            this.nextButton.Location = new System.Drawing.Point(989, 103);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(60, 60);
            this.nextButton.TabIndex = 11;
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Transparent;
            this.help.Location = new System.Drawing.Point(168, 160);
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(96, 32);
            this.help.TabIndex = 12;
            this.help.Text = "label6";
            this.help.Visible = false;
            //this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // displaySongs
            // 
            this.displaySongs.Font = new System.Drawing.Font("Candara", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.displaySongs.Location = new System.Drawing.Point(69, 264);
            this.displaySongs.Name = "displaySongs";
            this.displaySongs.Size = new System.Drawing.Size(284, 46);
            this.displaySongs.TabIndex = 13;
            this.displaySongs.Text = "Display all songs";
            this.displaySongs.UseVisualStyleBackColor = true;
            this.displaySongs.Click += new System.EventHandler(this.displaySongs_Click);
            // 
            // deleteSongs
            // 
            this.deleteSongs.Font = new System.Drawing.Font("Candara", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteSongs.Location = new System.Drawing.Point(69, 345);
            this.deleteSongs.Name = "deleteSongs";
            this.deleteSongs.Size = new System.Drawing.Size(284, 46);
            this.deleteSongs.TabIndex = 14;
            this.deleteSongs.Text = "Delete songs";
            this.deleteSongs.UseVisualStyleBackColor = true;
            this.deleteSongs.Click += new System.EventHandler(this.deleteSongs_Click);
            // 
            // displayPlaylists
            // 
            this.displayPlaylists.Font = new System.Drawing.Font("Candara", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.displayPlaylists.Location = new System.Drawing.Point(69, 421);
            this.displayPlaylists.Name = "displayPlaylists";
            this.displayPlaylists.Size = new System.Drawing.Size(284, 45);
            this.displayPlaylists.TabIndex = 15;
            this.displayPlaylists.Text = "Display all playlists";
            this.displayPlaylists.UseVisualStyleBackColor = true;
            this.displayPlaylists.Click += new System.EventHandler(this.displayPlaylists_Click);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Candara", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.timeLabel.Location = new System.Drawing.Point(691, 109);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(130, 54);
            this.timeLabel.TabIndex = 16;
            this.timeLabel.Text = "00:00";
            // 
            // addPlaylistButton
            //
            this.addPlaylistButton.Font = new System.Drawing.Font("Candara", 14F);
            this.addPlaylistButton.Location = new System.Drawing.Point(69, 490);
            this.addPlaylistButton.Name = "addPlaylistButton";
            this.addPlaylistButton.Size = new System.Drawing.Size(284, 45);
            this.addPlaylistButton.TabIndex = 17;
            this.addPlaylistButton.Text = "Add new playlist";
            this.addPlaylistButton.UseVisualStyleBackColor = true;
            this.addPlaylistButton.Click += new System.EventHandler(this.addPlaylistButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1081, 540);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.displayPlaylists);
            this.Controls.Add(this.deleteSongs);
            this.Controls.Add(this.displaySongs);
            this.Controls.Add(this.help);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.title);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.addPlaylistButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();


            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.descriptionTextBox = new System.Windows.Forms.TextBox();


        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label help;
        private System.Windows.Forms.Button displaySongs;
        private System.Windows.Forms.Button deleteSongs;
        private System.Windows.Forms.Button displayPlaylists;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Button addPlaylistButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox descriptionTextBox;
    }
}
