using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using CatalogData;

namespace CatalogClient
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:55872/") };

        public static void Main()
        {
            // Add an Accept header for JSON format.
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/xml"));
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            #region AlbumsOperations
            //Get All albums
            IEnumerable<Album> albums = GetAllAlbums();
            foreach (var album in albums)
            {
                Console.WriteLine(album.Title);
            }

            //Get album by id
            Album singleAlbum = GetAlbumById(1);
            Console.WriteLine(singleAlbum.Title);

            //PostAlbum
            Album albumForPost = new Album()
            {
                Title = "PostedAlbum",
                Producer = "PostedProducer",
                Year = new DateTime(2011, 01, 01)
            };
            PostAlbum(albumForPost);

            //Put album
            Album albumForPut = new Album()
            {
                AlbumID = 2,
                Title = "PutedAlbum",
                Producer = "PutedProducer",
                Year = new DateTime(2012, 01, 01)
            };
            PutAlbum(2, albumForPut);

            //Delete album
            DeleteAlbum(4);
            #endregion

            #region ArtistsOperations
            //Get all artists
            IEnumerable<Artist> artists = GetAllArtists();
            foreach (var artist in artists)
            {
                Console.WriteLine(artist.Name);
            }

            //Get artist by id
            Artist artistById = GetArtistById(1);
            Console.WriteLine(artistById.Name);

            //Post artist
            Artist artistForPost = new Artist()
            {
                Name = "PostName",
                Country = "PostCountry",
                DateOfBirth = new DateTime(2010, 01, 01)
            };
            PostArtist(artistForPost);

            //Put artist
            Artist artistForPut = new Artist()
            {
                ArtistID = 2,
                Name = "PutName",
                Country = "PutCountry",
                DateOfBirth = new DateTime(2010, 01, 01)
            };
            PutArtist(2, artistForPut);

            //Delete artist
            DeleteArtist(3);

            #endregion

            #region SongsOperations

            //GetAllSongs
            IEnumerable<Song> songs = GetAllSongs();
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title);
            }

            //GetSongById
            Song songById = GetSongById(3);
            Console.WriteLine(songById.Title);

            //Post song
            Song songForPost = new Song()
            {
                ArtistID = 1,
                AlbumID = 1,
                Title = "PostSong",
                Year = new DateTime(2002, 01, 01),
                Genre = "TestGenre"
            };
            PostSong(songForPost);

            //Put song
            Song songForPut = new Song()
            {
                SongID = 3,
                ArtistID = 1,
                AlbumID = 1,
                Title = "PutSong",
                Year = new DateTime(2002, 01, 01),
                Genre = "PutGenre"
            };
            PutSong(3, songForPut);

            //Delete song
            DeleteSong(7);
            #endregion
         
        }

        //Songs
        public static void DeleteSong(int id)
        {
            var response = Client.DeleteAsync("api/Songs/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Delete complete!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PutSong(int id, Song newSong)
        {


            var response = Client.PutAsJsonAsync("api/Songs/" + id, newSong).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Put complete!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PostSong(Song song)
        {

            var response = Client.PostAsJsonAsync("api/Songs", song).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Song added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static IEnumerable<Song> GetAllSongs()
        {
            HttpResponseMessage response = Client.GetAsync("api/Songs").Result;

            if (response.IsSuccessStatusCode)
            {
                var songs = response.Content.ReadAsAsync<IEnumerable<Song>>().Result;
                return songs;
            }
            else
            {
                string msg = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new ArgumentException(msg);
            }
        }

        public static Song GetSongById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/Songs/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var song = response.Content.ReadAsAsync<Song>().Result;
                return song;
            }
            else
            {
                string msg = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new ArgumentException(msg);
            }
        }

        //Albums
        public static void DeleteAlbum(int id)
        {
            var response = Client.DeleteAsync("api/Albums/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Delete complete!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PutAlbum(int id, Album newAlbum)
        {
           
            
            var response = Client.PutAsJsonAsync("api/Albums/"+id, newAlbum).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Put complete!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PostAlbum(Album album)
        {
            
            var response = Client.PostAsJsonAsync("api/Albums", album).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Album added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static IEnumerable<Album> GetAllAlbums()
        {
            HttpResponseMessage response = Client.GetAsync("api/albums").Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<IEnumerable<Album>>().Result;
                return albums;
            }
            else
            {
                string msg = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new ArgumentException(msg);
            }
        }

        public static Album GetAlbumById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/albums/"+id).Result;

            if (response.IsSuccessStatusCode)
            {
                var albums = response.Content.ReadAsAsync<Album>().Result;
                return albums;
            }
            else
            {
                string msg = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new ArgumentException(msg);
            }
        }

        //Artists
        public static void DeleteArtist(int id)
        {
            var response = Client.DeleteAsync("api/Artists/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Delete complete!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PutArtist(int id, Artist newArtist)
        {


            var response = Client.PutAsJsonAsync("api/Artists/" + id, newArtist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Put complete!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PostArtist(Artist artist)
        {

            var response = Client.PostAsJsonAsync("api/Artists", artist).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static IEnumerable<Artist> GetAllArtists()
        {
            HttpResponseMessage response = Client.GetAsync("api/Artists").Result;

            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<Artist>>().Result;
                return artists;
            }
            else
            {
                string msg = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new ArgumentException(msg);
            }
        }

        public static Artist GetArtistById(int id)
        {
            HttpResponseMessage response = Client.GetAsync("api/Artists/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var artist = response.Content.ReadAsAsync<Artist>().Result;
                return artist;
            }
            else
            {
                string msg = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                throw new ArgumentException(msg);
            }
        }
    }
}
