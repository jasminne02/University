using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
	public class Event : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? StartDate { get; set; }
		public int Duration { get; set; } // InMinutes?Hours?Days?

		public int? HomeTeamID { get; set; }
		public virtual Team HomeTeam { get; set; }
		public int HomeScore { get; set; }

		public int? AwayTeamID { get; set; }
		public virtual Team AwayTeam { get; set; }
		public int AwayScore { get; set; }


	}
}
