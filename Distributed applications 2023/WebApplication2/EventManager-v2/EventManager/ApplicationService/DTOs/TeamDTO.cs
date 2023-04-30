using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
	public class TeamDTO : BaseDTO
	{
		public string Title { get; set; }
		public virtual ICollection<PlayerDTO> Players { get; set; }
		public string Country { get; set; }
	}
}
