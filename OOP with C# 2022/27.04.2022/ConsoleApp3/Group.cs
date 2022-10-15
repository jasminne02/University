using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Group
    {
        private List<Musician> musicGroup = new List<Musician>();

        public List<Musician> MusicGroup { get { return musicGroup; } }

        public void Add(Musician musician)
        {
            if(musicGroup.Count < 10)
            {
                musicGroup.Add(musician);
            }
        }

    }
}
