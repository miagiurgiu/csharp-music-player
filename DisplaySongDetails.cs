using System;
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
    public partial class DisplaySongDetails : Form
    {
        Song song;
        Service service;
        public DisplaySongDetails(Song song, Service service)
        {
            this.song = song;
            this.service = service;
            InitializeComponent();
            displaySong();
           
        }

        public void displaySong()
        {
            Artist artist = service.getArtistById(song.IdArtist);

            nameLabel.Text = song.Title;
            nameLabel.Font = new Font("Candara", 18, FontStyle.Bold);
            nameLabel.Left = (this.ClientSize.Width - nameLabel.Width) / 2;

            artistLabel.Font = new Font("Candara", 12, FontStyle.Regular);
            artistLabel.Text = "Artist: " + artist.Name;

            durationLabel.Font = new Font("Candara", 12, FontStyle.Regular);
            durationLabel.Text = "Duration: " + song.Duration;

            albumLabel.Font = new Font("Candara", 12, FontStyle.Regular);
            //albumLabel.Text = "Release Date: " + song.ReleaseDate;
            DateTime releaseDate = DateTime.Parse(song.ReleaseDate);
            albumLabel.Text = "Release Year: " + releaseDate.Year;

            genreLabel.Font = new Font("Candara", 12, FontStyle.Regular);
            genreLabel.Text = "Genre: " + song.Genre;

            studioLabel.Font = new Font("Candara", 12, FontStyle.Regular);
            studioLabel.Text = "Studio: " + song.Studio;

            infoLabel.Font = new Font("Candara", 12, FontStyle.Italic);
            infoLabel.Text = "Info: " + song.Info;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
