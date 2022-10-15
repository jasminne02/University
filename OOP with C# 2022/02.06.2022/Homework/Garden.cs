using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Garden
    {
        private List<IGardenItem> gardenList = new List<IGardenItem>();

        public List<IFood> Foods
        {
            get
            {
                return gardenList.OfType<IFood>().ToList();
            }
        }
        public List<IBeauty> Beauties
        {
            get
            {
                return gardenList.OfType<IBeauty>().ToList();
            }
        }

        public void AddToGarden(Tree tree)
        {
            gardenList.Add(tree);
        }

        public void AddToGarden(Plant plant)
        {
            gardenList.Add(plant);
        }
    }
}
