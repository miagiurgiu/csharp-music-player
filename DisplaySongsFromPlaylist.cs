using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class DisplaySongsFromPlaylist : Form
    {
        private Service service;
        private int playlistId;
        private Form1 mainForm;
        //private Label playlistLabel;


        public DisplaySongsFromPlaylist(Service service, int playlistId, Form1 mainForm)
        {
            InitializeComponent();
            Playlist playlist = service.getAllPlaylists().FirstOrDefault(p => p.IdPlaylist == playlistId);
            if (playlist != null)
            {
                playlistLabel.Text = playlist.Name;
                playlistLabel.Font = new Font("Candara", 18, FontStyle.Bold);
                playlistLabel.ForeColor = Color.DarkCyan;
                playlistLabel.BackColor = Color.Transparent; // dacă fundalul permite
                playlistLabel.TextAlign = ContentAlignment.MiddleCenter;
                playlistLabel.Left = (this.ClientSize.Width - playlistLabel.Width) / 2;
                //playlistLabel.Location = new Point(30, 10); // mai la stânga și sus
                //playlistLabel.Size = new Size(500, 40);     // lățime și înălțime personalizate
               // playlistLabel.AutoSize = false;             // activăm controlul mărimii

            }
            this.service = service;
            this.playlistId = playlistId;
            this.mainForm = mainForm;
            SetupLayout();
            DisplaySongs();
        }

        private void SetupLayout()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 0;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
        }

        private void DisplaySongs()
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = 0;

            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));

            Song[] allSongs = service.getAllSongs();
            Song[] songsInPlaylist = service.getSongsFromPlaylist(playlistId);

            foreach (Song song in allSongs)
            {
                bool isInPlaylist = songsInPlaylist.Any(s => s.IdSong == song.IdSong);

                Label songLabel = new Label();
                songLabel.Text = song.Title;
                songLabel.AutoSize = true;
                songLabel.Font = new Font("Candara", 12, FontStyle.Regular);
                songLabel.Margin = new Padding(3, 6, 3, 6);
                songLabel.Tag = song.IdSong;
                songLabel.Cursor = Cursors.Hand;
                songLabel.Click += (s, e) =>
                {
                    int id = (int)((Label)s).Tag;
                    mainForm.playSelectedSong(id);
                };

                if (isInPlaylist)
                {
                    songLabel.ForeColor = System.Drawing.Color.DarkCyan;
                }

                Button actionButton = new Button();
                actionButton.Tag = song.IdSong;
                actionButton.Size = new Size(30, 30);
                actionButton.Margin = new Padding(3, 6, 3, 6);

                if (isInPlaylist)
                {
                    actionButton.Image = new Bitmap(
                        new Bitmap("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\minus.png"),
                        new Size(25, 25));
                    actionButton.Click += DeleteSong_Click;
                }
                else
                {
                    actionButton.Image = new Bitmap(
                        new Bitmap("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\plus.png"),
                        new Size(25, 25));
                    actionButton.Click += AddSong_Click;
                }

                int rowIndex = tableLayoutPanel1.RowCount++;
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                tableLayoutPanel1.Controls.Add(songLabel, 0, rowIndex);
                tableLayoutPanel1.Controls.Add(actionButton, 1, rowIndex);

                if (isInPlaylist)
                {
                    CheckBox inPlaylistCheck = new CheckBox();
                    inPlaylistCheck.Checked = true;
                    inPlaylistCheck.Enabled = false;
                    inPlaylistCheck.AutoSize = true;
                    inPlaylistCheck.Margin = new Padding(3, 6, 3, 6);
                    tableLayoutPanel1.Controls.Add(inPlaylistCheck, 2, rowIndex);
                }
            }
        }

        private void AddSong_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int songId = (int)clickedButton.Tag;
                service.addSongToPlaylist(songId, playlistId);
                DisplaySongs();
            }
        }

        private void DeleteSong_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int songId = (int)clickedButton.Tag;
                service.deleteSongFromPlaylist(songId, playlistId);
                DisplaySongs();
            }
        }

        private void DisplaySongsFromPlaylist_Load(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void DisplaySongsFromPlaylist_Load_1(object sender, EventArgs e)
        {

        }
    }
}

