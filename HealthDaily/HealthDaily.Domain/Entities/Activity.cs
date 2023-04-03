using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Entities
{
	public class Activity
	{
		public int Id { get; set; }

		public string Description { get; set; }

		public string IconTag { get; set; }
	}
}
