using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song
    {
        private int idSong;
        private string title;
        private string duration;
        private string releaseDate;
        private string genre;
        private string studio;
        private string info;
        private string path;
        private int idArtist;

        public int IdSong
        { get { return idSong; } set { idSong = value; } }

        public string Title
        { get { return title; } set { title = value; } }

        public string Duration
        { get { return duration; } set { duration = value; } }

        public string ReleaseDate
        { get { return releaseDate; } set { releaseDate = value; } }

        public string Genre
        { get { return genre; } set { genre = value; } }
        public string Studio 
        { get { return studio; }  set { studio = value; } }

        public string Info
        { get { return info; } set { info = value; } }

        public string Path
        { get { return path; } set { path = value; } }

        public int IdArtist
        { get { return idArtist; } set { idArtist = value; } }
        
        public Song(int idSong, string title, string duration, string releaseDate,
        string genre, string studio, string info, string path, int idArtist)
        {
            this.idSong = idSong;   
            this.title = title;
            this.duration = duration;
            this.releaseDate = releaseDate;
            this.genre = genre; 
            this.studio = studio;
            this.info = info;
            this.path = path;
            this.idArtist = idArtist;

        }
        public Song()
        { }
    }
}
