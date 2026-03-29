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
    public partial class DisplaySongsForm : Form
    {
        private Service service;
        private Form mainForm;

        public DisplaySongsForm(Service service, Form mainForm)
        {
            this.mainForm = mainForm;
            this.service = service;
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(168, 225, 222);
            displaySongs();
        }

        private void displaySongs()
        {
            Song[] songs = service.getAllSongs();
            int songCount = service.getAllSongsCount();

            for (int i = 0; i < songCount; i++)
            {
                //if (songs[i] == null) continue; // prevenim exceptii NullReference

                Button button = new System.Windows.Forms.Button();
                button.Text = songs[i].Title;
                button.Tag = songs[i].IdSong;
                button.Font = new Font("Candara", 12);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.MouseDownBackColor = Color.Transparent;
                button.FlatAppearance.MouseOverBackColor = Color.Transparent;
                button.Width = 250;
                button.Height = TextRenderer.MeasureText(button.Text, button.Font).Height + 20;
                button.Click += new EventHandler(PlaySong);

                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void PlaySong(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                int songId = (int)clickedButton.Tag;
                service.playSelectedSong(songId);
                MessageBox.Show("Melodia a fost pornită.");
            }
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Nu face nimic momentan
        }

        private void DisplaySongsForm_Load(object sender, EventArgs e)
        {
            // Nu face nimic momentan
        }
    }

}
*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class DisplaySongsForm : Form
    {
        private Service service;
        private Form1 mainForm;

        public DisplaySongsForm(Service service, Form1 mainForm)
        {
            this.mainForm = mainForm;
            this.service = service;
            InitializeComponent();
            panel1.BackColor = Color.FromArgb(168, 225, 222);
            displaySongs();
        }

        private void displaySongs()
        {
            Song[] songs = service.getAllSongs();
            int songCount = service.getAllSongsCount();

            for (int i = 0; i < songCount; i++)
            {
                Button button = new Button();
                button.Text = songs[i].Title;
                button.Tag = songs[i].IdSong;
                button.Font = new Font("Candara", 12);
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.MouseDownBackColor = Color.Transparent;
                button.FlatAppearance.MouseOverBackColor = Color.Transparent;
                button.Width = 250;
                button.Height = TextRenderer.MeasureText(button.Text, button.Font).Height + 20;
                //button.Click += (sender, e) => mainForm.PlaySong((Song)((Button)sender).Tag);
                button.Click += (sender, e) =>
                {
                    Button b = (Button)sender;
                    int songId = (int)b.Tag;
                    mainForm.playSelectedSong(songId);
                };
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Nu face nimic momentan
        }

        private void DisplaySongsForm_Load(object sender, EventArgs e)
        {
            // Nu face nimic momentan
        }
    }
}
