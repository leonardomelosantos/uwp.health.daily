using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HealthDaily.Domain.Entities
{
	public class ActivitiesDay
	{
		public Guid Id { get; set; }

		public DateTime Date { get; set; }

		public DayInfo DayInfo { get; set; }

		public List<ActivityEntry> Activities { get; set; }

	}
}
