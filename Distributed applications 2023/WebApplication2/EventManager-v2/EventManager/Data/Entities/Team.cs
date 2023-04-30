using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
	public class Team : BaseEntity
	{
		public string Title { get; set; }
		public virtual ICollection<Player> Players { get; set; }
		public string Country { get; set; }

		public virtual ICollection<Event> Events { get; set; }
	}
}
