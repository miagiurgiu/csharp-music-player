using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Artist
    {
        private int idArtist;//numarul melodiei (cnp al melodiei)
        private string name;
        private string nationality;
        private string birthdate;
        private string style;
        //private string path;

        public int IdArtist
        { get { return idArtist; } set { idArtist = value; } }

        public string Name
        { get { return name; } set { name = value; } }

        public string Nationality
        { get { return nationality; } set { nationality = value; } }

        public string Birthdate
        { get { return birthdate; } set { birthdate = value; } }

        public string Style
        { get { return style; } set { style = value; } }

        //constructor:
        public Artist(int idArtist, string name, string nationality, string birthdate, string style)
        {
            this.idArtist=idArtist;
            this.name=name;
            this.nationality=nationality;   
            this.birthdate=birthdate;
            this.style=style;
        }
    }
}
