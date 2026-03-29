using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Playlist
    {
        private int idPlaylist;
        private string name;
        private string description;
        private int idUser;
        public int IdPlaylist
        { get { return idPlaylist; } set { idPlaylist = value; } }

        public string Name
        { get { return name; } set { name = value; } }

        public string Description
        { get { return description; } set { description = value; } }

        public int IdUser
        { get {return idUser; } set { idUser = value; } }
        public Playlist(int idPlaylist, string name, string description, int idUser)
        {
            this.idPlaylist = idPlaylist;
            this.name = name;
            this.description = description;
            this.idUser = idUser;
        }
        public Playlist(string name, string description, int idUser)
        {
            this.name = name;
            this.description = description;
            this.idUser = idUser;
        }

        public Playlist()
        { }

    }
}
