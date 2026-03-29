using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Media;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicPlayer.Properties;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {
        Service service;
        private SoundPlayer _soundPlayer;
        private Timer _myTimer;
        private int _timeElapsed; // in secunde
        private int _songDurationSeconds = 0;

        public Form1(Service service)
        {
            this.service = service;
            InitializeComponent();
            _myTimer = new Timer();
            _myTimer.Interval = 1000;
            _myTimer.Tick += new EventHandler(TimerEventProcessor);
            setFirstSong();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            artistLabel.Text = "";
            artistLabel.Visible = false;
        }

        private void setFirstSong() { }

        public void playSelectedSong(int songId)
        {
            service.playSongFromCurrentList(songId); // doar setează currentSongIndex

            Song selectedSong = service.currentSong();

            if (selectedSong == null || !File.Exists(selectedSong.Path))
            {
                MessageBox.Show("Melodia nu există sau fișierul nu a fost găsit.");
                return;
            }

            Artist artist = service.getArtistById(selectedSong.IdArtist);

            if (TimeSpan.TryParse(selectedSong.Duration, out TimeSpan duration))
                _songDurationSeconds = (int)duration.TotalSeconds;
            else
                _songDurationSeconds = 15;

            _timeElapsed = 0;
            timeLabel.Text = "00:00";

            playButton.Image = Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\pause.jpeg");
            title.Text = selectedSong.Title;
            artistLabel.Text = artist?.Name ?? "Artist necunoscut";
            artistLabel.Visible = true;
            help.Text = "true";

            _soundPlayer = new SoundPlayer(selectedSong.Path);
            _soundPlayer.Play();

            _myTimer.Stop();
            if (_songDurationSeconds > 0)
                _myTimer.Start();
        }


        public void playSelectedPlaylist(int playlistId)
        {
            service.playSelectedPlaylist(playlistId);
            Song selectedSong = service.currentSong();
            if (selectedSong == null || !File.Exists(selectedSong.Path)) return;

            if (TimeSpan.TryParse(selectedSong.Duration, out TimeSpan duration))
                _songDurationSeconds = (int)duration.TotalSeconds;
            else
                _songDurationSeconds = 15;

            _timeElapsed = 0;
            timeLabel.Text = "00:00";

            Artist artist = service.getArtistById(selectedSong.IdArtist);

            playButton.Image = Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\pause.jpeg");
            title.Text = selectedSong.Title;
            artistLabel.Text = artist?.Name ?? "Artist necunoscut";
            artistLabel.Visible = true;
            help.Text = "true";

            _soundPlayer = new SoundPlayer(selectedSong.Path);
            _soundPlayer.Play();

            _myTimer.Stop();
            if (_songDurationSeconds > 0)
                _myTimer.Start();
        }

        public void playCurrentSong()
        {
            Song selectedSong = service.currentSong();
            if (selectedSong == null || !File.Exists(selectedSong.Path)) return;

            if (TimeSpan.TryParse(selectedSong.Duration, out TimeSpan duration))
                _songDurationSeconds = (int)duration.TotalSeconds;
            else
                _songDurationSeconds = 15;

            _timeElapsed = 0;
            timeLabel.Text = "00:00";

            Artist artist = service.getArtistById(selectedSong.IdArtist);

            playButton.Image = Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\pause.jpeg");
            title.Text = selectedSong.Title;
            artistLabel.Text = artist?.Name ?? "Artist necunoscut";
            artistLabel.Visible = true;
            help.Text = "true";

            _soundPlayer = new SoundPlayer(selectedSong.Path);
            _soundPlayer.Play();

            _myTimer.Stop();
            if (_songDurationSeconds > 0)
                _myTimer.Start();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Song currentSong = service.currentSong();
            if (currentSong == null || !File.Exists(currentSong.Path)) return;

            if (title.Text == "")
            {
                playSelectedSong(currentSong.IdSong);
            }
            else if (help.Text == "false")
            {
                playButton.Image = Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\pause.jpeg");
                _soundPlayer.Play();
                _myTimer.Start();
                _timeElapsed = 0;
                help.Text = "true";
            }
            else
            {
                playButton.Image = Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\play.jpeg");
                _soundPlayer.Stop();
                _myTimer.Stop();
                _timeElapsed = 0;
                help.Text = "false";
            }
        }

        private void TimerEventProcessor(Object myObject, EventArgs myEventArgs)
        {
            if (_songDurationSeconds <= 0) return;
            _timeElapsed++;
            string minutes = (_timeElapsed / 60).ToString("D2");
            string seconds = (_timeElapsed % 60).ToString("D2");
            timeLabel.Text = $"{minutes}:{seconds}";

            if (_timeElapsed >= _songDurationSeconds)
            {
                _myTimer.Stop();
                _soundPlayer.Stop();

                Song next = service.nextSong();
                if (next != null && File.Exists(next.Path))
                {
                    playSelectedSong(next.IdSong);
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            service.nextSong();
            playCurrentSong();
        }


        private void previousButton_Click(object sender, EventArgs e)
        {
            service.previousSong();
            playCurrentSong();
        }


        private void displayPlaylists_Click(object sender, EventArgs e)
        {
            DisplayPlaylistForm displayPlaylistForm = new DisplayPlaylistForm(service, this);
            displayPlaylistForm.Show();
        }

        private void displaySongs_Click(object sender, EventArgs e)
        {
            DisplaySongsForm displaySongsForm = new DisplaySongsForm(service, this);
            displaySongsForm.Show();
        }

        private void deleteSongs_Click(object sender, EventArgs e)
        {
            DeleteSongsForm deleteSongsForm = new DeleteSongsForm(service);
            deleteSongsForm.Show();
        }

        private void addPlaylistButton_Click(object sender, EventArgs e)
        {
            AddPlaylistForm form = new AddPlaylistForm(service);
            form.Show();
        }
    }
}
