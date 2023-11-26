using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module13Pr
{
    class MusicCatalog
    {
        Hashtable catalog = new Hashtable();

        public void AddDisk(string diskName)
        {
            catalog[diskName] = new ArrayList();
        }

        public void RemoveDisk(string diskName)
        {
            catalog.Remove(diskName);
        }

        public void AddSong(string diskName, string artist, string songTitle)
        {
            if (catalog.ContainsKey(diskName))
            {
                var songs = (ArrayList)catalog[diskName];
                songs.Add($"{artist} - {songTitle}");
            }
            else
            {
                Console.WriteLine("Диск не найден.");
            }
        }

        public void RemoveSong(string diskName, string artist, string songTitle)
        {
            if (catalog.ContainsKey(diskName))
            {
                var songs = (ArrayList)catalog[diskName];
                songs.Remove($"{artist} - {songTitle}");
            }
            else
            {
                Console.WriteLine("Диск не найден.");
            }
        }

        public void ShowCatalog()
        {
            foreach (var disk in catalog.Keys)
            {
                Console.WriteLine($"Диск: {disk}");
                var songs = (ArrayList)catalog[disk];
                foreach (var song in songs)
                {
                    Console.WriteLine($"  {song}");
                }
            }
        }

        public void ShowArtistSongs(string artist)
        {
            foreach (var disk in catalog.Keys)
            {
                var songs = (ArrayList)catalog[disk];
                var artistSongs = songs.Cast<string>().Where(s => s.StartsWith(artist));
                foreach (var song in artistSongs)
                {
                    Console.WriteLine($"{disk}: {song}");
                }
            }
        }
    }

    class Task5
    {
        static void Main()
        {
            MusicCatalog catalog = new MusicCatalog();

            catalog.AddDisk("Rock Classics");
            catalog.AddSong("Rock Classics", "Queen", "Bohemian Rhapsody");
            catalog.AddSong("Rock Classics", "Led Zeppelin", "Stairway to Heaven");

            catalog.AddDisk("Pop Hits");
            catalog.AddSong("Pop Hits", "Taylor Swift", "Shake It Off");
            catalog.AddSong("Pop Hits", "Ed Sheeran", "Shape of You");

            catalog.ShowCatalog();

            catalog.RemoveSong("Rock Classics", "Queen", "Bohemian Rhapsody");

            Console.WriteLine("\nКаталог после удаления песни:");
            catalog.ShowCatalog();

            Console.WriteLine("\nПоиск всех записей Queen:");
            catalog.ShowArtistSongs("Queen");
        }
    }
}
