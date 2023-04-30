using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
	public class Player : BaseEntity
	{
		public string Names { get; set; }
		public int? Age { get; set; }
		public int? TeamID { get; set; }
		public virtual Team Team { get; set; }
	}
}
