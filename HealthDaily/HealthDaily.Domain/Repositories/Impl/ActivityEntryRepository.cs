using HealthDaily.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Repositories.Impl
{
	public class ActivityEntryRepository : IActivityEntryRepository
	{
		private List<ActivityEntry> fakeData;

		public ActivityEntryRepository()
		{
			this.fakeData = new List<ActivityEntry>();
		}

		public ActivityEntry Add(ActivityEntry item)
		{
			this.fakeData.Add(item);
			return item;
		}

		public void Delete(ActivityEntry item)
		{
			throw new InvalidOperationException();
		}

		public IList<ActivityEntry> FindAll()
		{
			return this.fakeData;
		}

		public ActivityEntry FindById(Guid id)
		{
			return this.fakeData.FirstOrDefault(i => i.Id == id);
		}

		public void SaveEntryAsDone(Guid entryId)
		{
			var entry = this.fakeData.FirstOrDefault(i => i.Id == entryId);
			if (entry != null)
			{
				entry.IsDone = true;
			}
		}
	}
}
