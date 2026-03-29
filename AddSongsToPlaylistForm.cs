using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class AddSongsToPlaylistForm : Form
    {
        private Service service;
        private int playlistId;
        private TextBox urlTextBox;
        private Button addUrlButton;

        public AddSongsToPlaylistForm(Service service, int playlistId)
        {
            this.service = service;
            this.playlistId = playlistId;
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(168, 225, 222);

            // Label
            Label label = new Label();
            label.Text = "Introdu calea fișierului .wav:";
            label.Location = new Point(10, 10);
            label.Width = 200;

            // TextBox
            urlTextBox = new TextBox();
            urlTextBox.Width = 250;
            urlTextBox.Location = new Point(10, 35);
            urlTextBox.Text = "C:\\cale\\fisier.wav";

            // Buton
            addUrlButton = new Button();
            addUrlButton.Text = "Adaugă melodie nouă";
            addUrlButton.Location = new Point(270, 33);
            addUrlButton.Click += AddNewSongFromUrl;

            // Adaugă pe form (nu doar pe panel1!)
            this.Controls.Add(label);
            this.Controls.Add(urlTextBox);
            this.Controls.Add(addUrlButton);

            displaySongs();
        }


        private void displaySongs()
        {
            Song[] songs = service.getAllSongs();
            int songCount = service.getAllSongsCount();

            for (int i = 0; i < songCount; i++)
            {
                Panel songPanel = new Panel();
                songPanel.Width = 300;
                songPanel.Height = 40;

                Label label = new Label();
                label.Text = songs[i].Title;
                label.Width = 200;
                label.Location = new Point(0, 10);

                Button addButton = new Button();
                addButton.Text = "+";
                addButton.Width = 30;
                addButton.Height = 25;
                addButton.Tag = songs[i].IdSong;
                addButton.Location = new Point(220, 5);
                addButton.Click += AddSongToPlaylist;

                songPanel.Controls.Add(label);
                songPanel.Controls.Add(addButton);
                flowLayoutPanel1.Controls.Add(songPanel);
            }
        }

        private void AddSongToPlaylist(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int songId = (int)btn.Tag;

            try
            {
                service.addSongToPlaylist(songId, playlistId);
                MessageBox.Show("Melodie adăugată în playlist!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }
        private void doneButton_Click(object sender, EventArgs e)
        {
            this.Close(); // Închide formularul
        }
        private void AddNewSongFromUrl(object sender, EventArgs e)
        {
            string path = urlTextBox.Text;

            if (!File.Exists(path))
            {
                MessageBox.Show("Fișierul nu există.");
                return;
            }

            string title = Path.GetFileNameWithoutExtension(path); // numele fișierului
            Song newSong = new Song(
                0,                  // idSong (va fi generat de DB)
                title,
                "00:30",            // durata implicită
                "2020",             // dată fictivă
                "Unknown",          // gen
                "Studio",           // studio
                "Adăugată manual",  // info
                path,
                1                   // idArtist (un artist existent — ai grijă să fie valid)
            );

            try
            {
                service.addSong(newSong);
                MessageBox.Show("Melodie adăugată!");
                flowLayoutPanel1.Controls.Clear(); // curăță lista
                displaySongs(); // reafișează toate
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare: " + ex.Message);
            }
        }

    }
}
