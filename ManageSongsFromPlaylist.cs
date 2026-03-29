/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class ManageSongsFromPlaylist : Form
    {
        Service service;
        string playlistId;

        public ManageSongsFromPlaylist(Service service, string playlistId)
        {
            InitializeComponent();
            this.service = service;
            this.playlistId = playlistId;
            displaySongs();
            panel1.BackColor = ColorTranslator.FromHtml("#a8e1de");
        }
        private void displaySongs()
        {
            Song[] songs = service.getAllSongs();
            for (int i = 0; i < service.getAllSongsCount(); i++)
            {
                Label songLabel = new Label();
                songLabel.Text = songs[i].Title;
                songLabel.AutoSize = true;
                songLabel.Margin = new Padding(3, 6, 3, 6);
                songLabel.Font = new Font("Candara", 12, FontStyle.Regular); //SCHIMBAM FONTUL LA LABEL-URI!!!
                tableLayoutPanel1.Controls.Add(songLabel);
                if (songs[i].isInPlaylist(playlistId))
                {
                    // Cream buttonul de  "-" 
                    Button deleteButton = new Button();
                    deleteButton.Image = new Bitmap(Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\minus.png"), new Size(25, 25));
                    deleteButton.Tag = songs[i].IdSong;
                    deleteButton.AutoSize = true;
                    deleteButton.Margin = new Padding(3, 6, 3, 6); 
                    deleteButton.Click += new EventHandler(deleteSong_Click);
                    tableLayoutPanel1.Controls.Add(deleteButton);
                }
                else
                {
                    // Cream buttonul de "+" 
                    Button addButton = new Button();
                    addButton.Image = new Bitmap(Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\plus.png"), new Size(25, 25));
                    addButton.Tag = songs[i].IdSong;
                    addButton.AutoSize = true;
                    addButton.Margin = new Padding(3, 6, 3, 6);
                    addButton.Click += new EventHandler(addSong_Click);
                    tableLayoutPanel1.Controls.Add(addButton);
                }
            }
        }
        private void addSongToPlaylist(object sender, EventArgs e)
        {

        }

        private void addSong_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int songId = (int)clickedButton.Tag;
                service.addSongToPlaylist(songId, int.Parse(playlistId));
                tableLayoutPanel1.Controls.Clear();
                displaySongs();
            }
        }
        private void deleteSong_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int songId = (int)clickedButton.Tag;
                service.deleteSongFromPlaylist(songId, playlistId);
                tableLayoutPanel1.Controls.Clear();
                displaySongs();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class ManageSongsFromPlaylist : Form
    {
        private Service service;
        private int playlistId;

        public ManageSongsFromPlaylist(Service service, string playlistId)
        {
            InitializeComponent();
            this.service = service;
            this.playlistId = int.Parse(playlistId); // conversie din string
            displaySongs();
            panel1.BackColor = ColorTranslator.FromHtml("#a8e1de");
        }

        private void displaySongs()
        {
            tableLayoutPanel1.Controls.Clear();

            // Ia toate melodiile și cele din playlistul activ
            Song[] allSongs = service.getAllSongs();
            Song[] songsInPlaylist = service.getSongsFromPlaylist(playlistId);

            foreach (Song song in allSongs)
            {
                Label songLabel = new Label();
                songLabel.Text = song.Title;
                songLabel.AutoSize = true;
                songLabel.Margin = new Padding(3, 6, 3, 6);
                songLabel.Font = new Font("Candara", 12, FontStyle.Regular);
                tableLayoutPanel1.Controls.Add(songLabel);

                bool isInPlaylist = songsInPlaylist.Any(s => s.IdSong == song.IdSong);

                if (isInPlaylist)
                {
                    // buton de ștergere (-)
                    Button deleteButton = new Button();
                    deleteButton.Image = new Bitmap(
                        Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\minus.png"),
                        new Size(25, 25));
                    deleteButton.Tag = song.IdSong;
                    deleteButton.AutoSize = true;
                    deleteButton.Margin = new Padding(3, 6, 3, 6);
                    deleteButton.Click += new EventHandler(deleteSong_Click);
                    tableLayoutPanel1.Controls.Add(deleteButton);
                }
                else
                {
                    // buton de adăugare (+)
                    Button addButton = new Button();
                    addButton.Image = new Bitmap(
                        Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\plus.png"),
                        new Size(25, 25));
                    addButton.Tag = song.IdSong;
                    addButton.AutoSize = true;
                    addButton.Margin = new Padding(3, 6, 3, 6);
                    addButton.Click += new EventHandler(addSong_Click);
                    tableLayoutPanel1.Controls.Add(addButton);
                }
            }
        }

        private void addSong_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int songId = (int)clickedButton.Tag;
                service.addSongToPlaylist(songId, playlistId);
                displaySongs(); // reafișează după modificare
            }
        }

        private void deleteSong_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int songId = (int)clickedButton.Tag;
                service.deleteSongFromPlaylist(songId, playlistId);
                displaySongs(); // reafișează după modificare
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // gol — e gestionat de designer
        }
    }
}
