using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Entities
{
	public class ActivityEntry
	{
		public Guid Id { get; set; }

		public Activity Activity { get; set; }

		public TimeSpan Duration { get; set; }

		public DateTime ScheduledTime { get; set; }

		public bool IsDone { get; set; }
	}
}
