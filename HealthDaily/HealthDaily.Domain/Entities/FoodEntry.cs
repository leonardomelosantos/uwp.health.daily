using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HealthDaily.Domain.Entities
{
	public class FoodEntry
	{
		public Guid Id { get; set; }

		public DateTime DateTime { get; set; }

		public StorageFile Picture { get; set; }
	}
}
