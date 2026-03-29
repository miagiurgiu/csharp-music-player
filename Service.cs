using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Service
    {
        public Repository repository;
        private Song[] playingSongs = new Song[100];
        private Artist[] artists = new Artist[100];
        int numberOfPlayingSongs = 0;
        int currentSongIndex = 0;
        int numberOfArtists = 0;
        public Song song;

        public Service(Repository repository)
        {
            this.repository = repository;
            playingSongs = repository.getAllSongs();
            numberOfPlayingSongs = playingSongs.Length;
            currentSongIndex = 0;
        }

        //functiile de ADD
        public void addSong(Song song)
        {
            repository.addSong(song);
        }
        public void addSongToPlaylist(int idSong, int idPlaylist)
        {
            Song song = repository.getSong(idSong);
            Playlist playlist = repository.getPlaylist(idPlaylist);
            repository.addSongToPlaylist(song, playlist);
        }
        public int AddPlaylist(string name, string description, int idUser)
        {
            Playlist playlist = new Playlist(name, description, idUser);
            return repository.addPlaylist(playlist);
        }


        //functiile de DELETE
        public void deleteSong(int idSong)
        {
            repository.deleteSong(idSong);
        }
        public void deleteAllSongs()
        {
            repository.deleteAllSongs();
        }
        public void deleteSongFromPlaylist(int idSong, int idPlaylist)
        {
            Song song = repository.getSong(idSong);
            Playlist playlist = repository.getPlaylist(idPlaylist);
            repository.removeSongFromPlaylist(song, playlist);
        }
        public void deletePlaylist(int idPlaylist)
        {
            repository.deletePlaylist(idPlaylist);
        }

        //functiile de GET
        public Song getSongById(int idSong)
        {
            return repository.getSong(idSong);
        }

        public Artist getArtistById(int idArtist)
        {
            return repository.getArtist(idArtist);
        }

        public int getSongCount()
        {
            return numberOfPlayingSongs;
        }
        public Song[] getAllSongs()
        {
            return repository.getAllSongs();
        }

        public int getAllSongsCount()
        {
            return repository.getNumberOfSongs();
        }
        public Song[] getPlayingSongs()
        {
            return playingSongs;
        }
        public Playlist[] getAllPlaylists()
        {
            return repository.getAllPlaylists();
        }

        public int getAllPlaylistsCount()
        {
            return repository.getAllPlaylistsCount();
        }
        public Song[] getSongsFromPlaylist(int playlistId)
        {
            return repository.getSongsFromPlaylist(playlistId);
        }
       
        public string getArtistNameForSong(Song song)
        {
            if (song == null)
                return "Unknown Song";

            Artist artist = getArtistById(song.IdArtist);
            return artist != null ? artist.Name : "Unknown Artist";
        }
        public (Song, Artist) getSongWithArtist(int idSong)
        {
            return repository.getSongWithArtist(idSong);
        }

        //functiile de PLAY
        public void playSelectedSong(int idSong)
        {
            Song selectedSong = repository.getSong(idSong);
            playingSongs[0] = selectedSong;
            currentSongIndex = 0;
            (Song song, Artist artist) = getSongWithArtist(idSong);
            DisplaySongDetails detailsForm = new DisplaySongDetails(song, this);
            detailsForm.Show();
            numberOfPlayingSongs = 1;
        }
        public void playSongFromCurrentList(int idSong)
        {
            for (int i = 0; i < numberOfPlayingSongs; i++)
            {
                if (playingSongs[i].IdSong == idSong)
                {
                    currentSongIndex = i;
                    return;
                }
            }
        }

        public void playSelectedPlaylist(int idPlaylist)
        {
            playingSongs = repository.getSongsFromPlaylist(idPlaylist);
            numberOfPlayingSongs = playingSongs.Length;
            currentSongIndex = 0;
        }

        //functiile de SET

        public void setPlayingSongs(Song[] selectedSongs)
        {
            this.playingSongs = selectedSongs;
            this.numberOfPlayingSongs = selectedSongs.Length;
            this.currentSongIndex = 0;
        }

        //functiile de navigare intre melodii
        public Song nextSong()
        {
            if (numberOfPlayingSongs == 0)
                return null;

            currentSongIndex = (currentSongIndex + 1) % numberOfPlayingSongs;
            return playingSongs[currentSongIndex];
        }

        public Song previousSong()
        {
            if (numberOfPlayingSongs == 0)
                return null;

            currentSongIndex = (currentSongIndex - 1 + numberOfPlayingSongs) % numberOfPlayingSongs;
            return playingSongs[currentSongIndex];
        }

        public Song currentSong()
        {
            return playingSongs[currentSongIndex];
        }
        //functiile de update
        public void updateSong(Song song)
        {
            repository.updateSong(song);
        }
    }
}