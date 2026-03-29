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
    public partial class DisplayPlaylistForm : Form
    {
        Service service;
        Form1 mainForm;
        public DisplayPlaylistForm(Service service, Form1 mainForm)
        {
            this.service = service;
            InitializeComponent();
            setPlaylists();
            this.mainForm = mainForm;
            flowLayoutPanel1.AutoScroll = true;
        }
        private void setPlaylists()
        {
            Playlist[] playlists = service.getAllPlaylists();

            for (int i = 0; i < playlists.Length; i++)
            {
                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.FlowDirection = FlowDirection.LeftToRight;
                panel.WrapContents = false;
                panel.Width = 450;
                panel.Height = 40;
                panel.Padding = new Padding(5);
                panel.Margin = new Padding(5);

                // 📌 Numele playlistului - clickabil
                Label nameLabel = new Label();
                nameLabel.Text = playlists[i].Name;
                nameLabel.Tag = playlists[i].IdPlaylist;
                nameLabel.Font = new Font("Candara", 12);
                nameLabel.Width = 300;
                nameLabel.Height = 30;
                nameLabel.TextAlign = ContentAlignment.MiddleLeft;
                nameLabel.Cursor = Cursors.Hand;
                nameLabel.Click += (s, e) =>
                {
                    int id = (int)((Label)s).Tag;

                    Song[] playlistSongs = service.getSongsFromPlaylist(id);

                    if (playlistSongs.Length == 0)
                    {
                        MessageBox.Show("Acest playlist nu conține nicio melodie.");
                        return;
                    }
                    service.setPlayingSongs(playlistSongs);
                    service.playSongFromCurrentList(playlistSongs[0].IdSong); // NU pierzi playlistul
                    mainForm.playCurrentSong(); // o metodă nouă în Form1 dacă vrei să refolosești redarea

                    // Încarcă DOAR melodiile din playlist
                    //service.setPlayingSongs(playlistSongs);

                    // Pornește redarea de la prima melodie din playlist
                    // mainForm.playSelectedSong(playlistSongs[0].IdSong);

                    // Deschide fereastra cu lista de melodii din acest playlist
                    DisplaySongsFromPlaylist form = new DisplaySongsFromPlaylist(service, id, mainForm);
                    form.Show();
                };

                // ❌ Buton "Șterge"
                Button deleteButton = new Button();
                deleteButton.Text = "Șterge";
                deleteButton.Tag = playlists[i].IdPlaylist;
                deleteButton.Font = new Font("Candara", 10);
                deleteButton.Width = 80;
                deleteButton.Height = 30;
                deleteButton.Click += (s, e) =>
                {
                    int id = (int)((Button)s).Tag;
                    service.deletePlaylist(id);
                    MessageBox.Show("Playlist șters!");
                    flowLayoutPanel1.Controls.Clear();
                    setPlaylists();
                    // sau: RefreshPlaylists(); dacă vrei să nu închizi fereastra
                };

                panel.Controls.Add(nameLabel);
                panel.Controls.Add(deleteButton);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }
        private void PlayPlaylist(object sender, EventArgs e)
        {
            Button selectedPlaylist = (Button)sender;
            int playlistId = (int)selectedPlaylist.Tag;

            mainForm.playSelectedPlaylist(playlistId);

            // Trimitem ca string doar dacă constructorul DisplaySongsFromPlaylist cere un string
            DisplaySongsFromPlaylist displaySongsFromPlaylist = new DisplaySongsFromPlaylist(service, playlistId,mainForm);
            displaySongsFromPlaylist.Show();
        }

        private void DisplayPlaylistForm_Load(object sender, EventArgs e)
        {
            
        }

        private void addSong_Click(object sender, EventArgs e)
        {

        }
    }
}
