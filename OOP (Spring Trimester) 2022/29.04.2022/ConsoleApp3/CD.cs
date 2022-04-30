using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class CD : MusicCarrier
    {
        private int songsNumber;
        private double songsDuration;
        private string[] songsNames = new string[30];

        public int SongsNumber { get { return songsNumber; } set { } }
        public double SongsDuration { get { return songsDuration; } set { } }
        public string[] SongsName { get { return songsNames; } set { } }

        public CD(Group group, string albumName, int songsNumber, double songsDuration, string[] songsName) : base(group, albumName)
        {
            if(songsNumber <= 30)
            {
                this.songsNumber = songsNumber;
                this.songsDuration = songsDuration;
                this.songsNames = songsName;
            }
        }

        public override string[] GetTracks()
        {
            Array.Sort(this.songsNames);
            return songsNames;
        }

        public override double GetLength()
        {
            return songsNumber * songsDuration;
        }
    }
}
