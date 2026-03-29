using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class DeleteSongsForm : Form
    {
        Service service;

        public DeleteSongsForm(Service service)
        {
            this.service = service;
            InitializeComponent();
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
                songLabel.Font = new Font("Candara", 12);
                songLabel.AutoSize = true;
                songLabel.Margin = new Padding(3, 6, 3, 6);

                Button deleteButton = new Button();
                deleteButton.Image = Image.FromFile("C:\\Users\\Maria\\Desktop\\FinalMusicPlayer\\MusicPlayer\\Images\\trash.png");
                deleteButton.Tag = songs[i].IdSong;
                deleteButton.AutoSize = true;
                deleteButton.Margin = new Padding(3, 3, 3, 3);
                deleteButton.Click += new EventHandler(DeleteSong_Click);

                tableLayoutPanel1.Controls.Add(songLabel);
                tableLayoutPanel1.Controls.Add(deleteButton);
            }
        }
     
        private void DeleteSong_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = Int32.Parse(button.Tag.ToString());
            service.deleteSong(id);

            int index = tableLayoutPanel1.Controls.IndexOf(button);
            if (index > 0)
            {
                tableLayoutPanel1.Controls.RemoveAt(index);
                tableLayoutPanel1.Controls.RemoveAt(index - 1);
            }
        }

        private void DeleteSongsForm_Load(object sender, EventArgs e)
        {


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
