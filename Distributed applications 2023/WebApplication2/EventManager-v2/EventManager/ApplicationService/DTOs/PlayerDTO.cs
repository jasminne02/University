using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
	public class PlayerDTO : BaseDTO
	{
		public string Names { get; set; }
		public int? TeamID { get; set; }
		public virtual TeamDTO Team { get; set; }

		public bool Validate()
		{
			return !String.IsNullOrEmpty(Names);
		}
	}
}
