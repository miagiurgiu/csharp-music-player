using MusicPlayer;
using System.Linq;
using System;

public class Repository
{
    private Song[] songs = new Song[100];
    private Playlist[] playlists = new Playlist[100];
    private Artist[] artists = new Artist[100];
    private SqlConn conn;
    private int numberOfSongs = 0;
    private int numberOfPlaylists = 0;
    private int numberOfArtists = 0;

    public Repository(SqlConn conn)
    {
        this.conn = conn;
        readArtistsFromDatabase();
        readPlaylistsFromDatabase();
        readSongsFromDatabase();
    }

    // ------------------------ ADD ------------------------
    public void addSong(Song song)
    {
        if (numberOfSongs < songs.Length)
        {
            songs[numberOfSongs] = song;
            numberOfSongs++;
        }
        conn.addSong(song);
    }

    public void addSongToPlaylist(Song song, Playlist playlist)
    {
        conn.addSongToPlaylist(song, playlist);
    }

    public int addPlaylist(Playlist playlist)
    {
        return conn.addPlaylist(playlist);
    }

    // ------------------------ GET ------------------------
    public Song getSong(int idSong)
    {
        for (int i = 0; i < numberOfSongs; i++)
            if (songs[i].IdSong == idSong)
                return songs[i];
        return null;
    }

    public Artist getArtist(int idArtist)
    {
        for (int i = 0; i < numberOfArtists; i++)
            if (artists[i] != null && artists[i].IdArtist == idArtist)
                return artists[i];
        return null;
    }

    public Playlist getPlaylist(int idPlaylist)
    {
        for (int i = 0; i < numberOfPlaylists; i++)
            if (playlists[i].IdPlaylist == idPlaylist)
                return playlists[i];
        Playlist[] all = conn.getPlaylists();
        return all.FirstOrDefault(p => p.IdPlaylist == idPlaylist);
    }

    public Song[] getAllSongs()
    {
        Song[] allSongs = new Song[numberOfSongs];
        Array.Copy(songs, allSongs, numberOfSongs);
        return allSongs;
    }

    public Playlist[] getAllPlaylists()
    {
        return playlists;
    }

    public Song[] getSongsFromPlaylist(int idPlaylist)
    {
        Playlist playlist = getPlaylist(idPlaylist);
        return conn.getSongsFromPlaylist(playlist);
    }

    public int getNumberOfSongs()
    {
        return numberOfSongs;
    }

    public int getNumberOfArtists()
    {
        return numberOfArtists;
    }

    public int getAllPlaylistsCount()
    {
        return numberOfPlaylists;
    }

    public int getNumberOfSongsFromPlaylist(int idPlaylist)
    {
        Playlist playlist = getPlaylist(idPlaylist);
        return conn.getSongsFromPlaylist(playlist).Length;
    }

    public (Song, Artist) getSongWithArtist(int idSong)
    {
        return conn.getFullSongDetailsById(idSong);
    }

    // ------------------------ UPDATE ------------------------
    public void updateSong(Song song)
    {
        for (int i = 0; i < numberOfSongs; i++)
        {
            if (songs[i].IdSong == song.IdSong)
            {
                songs[i] = song;
                return;
            }
        }
    }

    // ------------------------ DELETE ------------------------
    public void deleteSong(int idSong)
    {
        for (int i = 0; i < numberOfSongs; i++)
        {
            if (songs[i].IdSong == idSong)
            {
                for (int j = i; j < numberOfSongs - 1; j++)
                    songs[j] = songs[j + 1];
                numberOfSongs--;
                break;
            }
        }
        conn.deleteSongById(idSong);
    }

    public void deleteAllSongs()
    {
        Array.Clear(songs, 0, songs.Length);
        numberOfSongs = 0;
    }

    public void removeSongFromPlaylist(Song song, Playlist playlist)
    {
        conn.removeSongFromPlaylist(song.IdSong, playlist.IdPlaylist);
    }

    public void deletePlaylist(int idPlaylist)
    {
        conn.deletePlaylistById(idPlaylist);
    }

    // ------------------------ READ FROM DB (private) ------------------------
    private void readPlaylistsFromDatabase()
    {
        playlists = conn.getPlaylists();
        numberOfPlaylists = conn.getNumberOfPlaylists();
    }

    public void readSongsFromDatabase()
    {
        songs = conn.getSongs();
        numberOfSongs = conn.getNumberOfSongs();
    }

    public void readArtistsFromDatabase()
    {
        artists = conn.getArtists();
        numberOfArtists = conn.getNumberOfArtists();
    }
}
