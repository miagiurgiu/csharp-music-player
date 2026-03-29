using System;
using System.Linq;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class AddPlaylistForm : Form
    {
        private Service service;

        public AddPlaylistForm(Service service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            
            string name = nameTextBox.Text.Trim();
            string description = descriptionTextBox.Text.Trim();
            int idUser = 1;

            // fără verificări
            int newPlaylistId = service.AddPlaylist(name, description, idUser);


            // deschide direct formularul cu melodiile
            AddSongsToPlaylistForm form = new AddSongsToPlaylistForm(service, newPlaylistId);
            form.Show();

            this.Close();

        }

    }
}
