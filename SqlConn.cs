using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace MusicPlayer
{
    public class SqlConn
    {
        private string _connectionString;

        public SqlConn(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Playlist[] getPlaylists()
        {
            List<Playlist> playlists = new List<Playlist>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Playlists";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Playlist playlist = new Playlist(
                            (int)reader["idPlaylist"],
                            reader["name"].ToString(),
                            reader["description"].ToString(),
                            (int)reader["idUser"] // ← adăugat aici!
                        );
                        playlists.Add(playlist);
                    }
                }
            }
            return playlists.ToArray();
        }


       

        public Song[] getSongs()
        {
            List<Song> songs = new List<Song>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Songs";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Song song = new Song(
                            (int)reader["idSong"],
                            reader["title"].ToString(),
                            reader["duration"].ToString(), 
                            reader["releaseDate"].ToString(),
                            reader["genre"].ToString(), 
                            reader["studio"].ToString(), 
                            reader["info"].ToString(), 
                            reader["path"].ToString(), 
                            (int)reader["idArtist"]);
                        songs.Add(song);
                    }
                }
            }
            return songs.ToArray();
        }

        public int getNumberOfSongs()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Songs";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public int getNumberOfPlaylists()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Playlists";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }
        public int getNumberOfArtists()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Artists";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public Artist[] getArtists()
        {
            List<Artist> artists = new List<Artist>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Artists";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Artist artist = new Artist(
                            (int)reader["idArtist"],
                            reader["name"].ToString(),
                            reader["nationality"].ToString(),
                            reader["birthdate"].ToString(), 
                            reader["style"].ToString());
                        artists.Add(artist);
                    }
                }
            }
            return artists.ToArray();
        }

        

        public void addSong(Song song)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Songs(title, duration, releaseDate, genre, studio, info, path, idArtist)" +
                    "VALUES (@title, @duration, @releaseDate, @genre, @studio, @info, @path, @idArtist)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", song.Title);
                    command.Parameters.AddWithValue("@duration", song.Duration);
                    command.Parameters.AddWithValue("@releaseDate", song.ReleaseDate);
                    command.Parameters.AddWithValue("@genre", song.Genre);
                    command.Parameters.AddWithValue("@studio", song.Studio);
                    command.Parameters.AddWithValue("@info", song.Info);
                    command.Parameters.AddWithValue("@path", song.Path);
                    command.Parameters.AddWithValue("@idArtist", song.IdArtist);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void addSongToPlaylist(Song song, Playlist playlist)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Connections(idSong, idPlaylist) VALUES (@idSong, @idPlaylist)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idSong", song.IdSong);
                    command.Parameters.AddWithValue("@idPlaylist", playlist.IdPlaylist);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void removeSongFromPlaylist(int idSong, int idPlaylist)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Connections WHERE idSong = @idSong AND idPlaylist = @idPlaylist";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idSong", idSong);
                    command.Parameters.AddWithValue("@idPlaylist", idPlaylist);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Song[] getSongsFromPlaylist(Playlist playlist)
        {
            List<Song> songs = new List<Song>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Songs S JOIN Connections C on S.idSong=C.idSong WHERE C.idPlaylist=@idPlaylist";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idPlaylist", playlist.IdPlaylist);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Song song = new Song(
                                (int)reader["idSong"], 
                                reader["title"].ToString(), 
                                reader["duration"].ToString(), 
                                reader["releaseDate"].ToString(),
                                reader["genre"].ToString(), 
                                reader["studio"].ToString(),
                                reader["info"].ToString(), 
                                reader["path"].ToString(), 
                                (int)reader["idArtist"]);
                            songs.Add(song);
                        }
                    }
                }
            }
            return songs.ToArray();
        }

        public void updateSong(Song song)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Songs SET 
                        title = @title, 
                        duration = @duration, 
                        releaseDate = @releaseDate,
                        genre = @genre,
                        studio = @studio,
                        info = @info,
                        path = @path,
                        idArtist = @idArtist
                    WHERE idSong = @idSong";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", song.Title);
                    command.Parameters.AddWithValue("@duration", song.Duration);
                    command.Parameters.AddWithValue("@releaseDate", song.ReleaseDate);
                    command.Parameters.AddWithValue("@genre", song.Genre);
                    command.Parameters.AddWithValue("@studio", song.Studio);
                    command.Parameters.AddWithValue("@info", song.Info);
                    command.Parameters.AddWithValue("@path", song.Path);
                    command.Parameters.AddWithValue("@idArtist", song.IdArtist);
                    command.Parameters.AddWithValue("@idSong", song.IdSong);
                    command.ExecuteNonQuery();
                }
            }
        }
        public (Song, Artist) getFullSongDetailsById(int idSong)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT S.*, A.idArtist, A.name AS artistName, A.nationality, A.birthdate, A.style
                FROM Songs S JOIN Artists A ON S.idArtist = A.idArtist
                WHERE S.idSong = @idSong";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idSong", idSong);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Song song = new Song(
                                (int)reader["idSong"],
                                reader["title"].ToString(),
                                reader["duration"].ToString(),
                                reader["releaseDate"].ToString(),
                                reader["genre"].ToString(),
                                reader["studio"].ToString(),
                                reader["info"].ToString(),
                                reader["path"].ToString(),
                                (int)reader["idArtist"]
                            );

                            Artist artist = new Artist(
                                (int)reader["idArtist"],
                                reader["artistName"].ToString(),
                                reader["nationality"].ToString(),
                                reader["birthdate"].ToString(),
                                reader["style"].ToString()
                            );

                            return (song, artist);
                        }
                    }
                }
            }

            return (null, null); // dacă nu există melodia
        }
        public int addPlaylist(Playlist playlist)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            INSERT INTO Playlists(name, description, idUser) 
            OUTPUT INSERTED.idPlaylist 
            VALUES (@name, @description, @idUser)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", playlist.Name);
                    command.Parameters.AddWithValue("@description", playlist.Description);
                    command.Parameters.AddWithValue("@idUser", playlist.IdUser);

                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void deleteSongById(int idSong)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Șterge întâi din conexiuni (altfel dă eroare de integritate referențială)
                string deleteConnectionsQuery = "DELETE FROM Connections WHERE idSong = @idSong";
                using (SqlCommand command = new SqlCommand(deleteConnectionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSong", idSong);
                    command.ExecuteNonQuery();
                }

                // Apoi șterge din Songs
                string deleteSongQuery = "DELETE FROM Songs WHERE idSong = @idSong";
                using (SqlCommand command = new SqlCommand(deleteSongQuery, connection))
                {
                    command.Parameters.AddWithValue("@idSong", idSong);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void deletePlaylistById(int idPlaylist)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Șterge întâi legăturile din Connections
                string deleteConnectionsQuery = "DELETE FROM Connections WHERE idPlaylist = @idPlaylist";
                using (SqlCommand cmd = new SqlCommand(deleteConnectionsQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@idPlaylist", idPlaylist);
                    cmd.ExecuteNonQuery();
                }

                // Apoi șterge playlistul
                string deletePlaylistQuery = "DELETE FROM Playlists WHERE idPlaylist = @idPlaylist";
                using (SqlCommand cmd = new SqlCommand(deletePlaylistQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@idPlaylist", idPlaylist);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
