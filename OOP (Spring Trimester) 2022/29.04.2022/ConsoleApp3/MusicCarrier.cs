using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    abstract class MusicCarrier
    {
        private Group group;
        private string albumName;

        public Group Group { get { return group; } }
        public string AlbumName { get { return albumName; } }

        public MusicCarrier(Group group, string albumName)
        {
            this.group = group;
            this.albumName = albumName;
        }

        public abstract string[] GetTracks();
        public abstract double GetLength();
    }
}
