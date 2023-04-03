using HealthDaily.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Services
{
	public interface IActivityService
	{
		ActivitiesDay FindActivitiesDay(DateTime date);

		void SaveActivityEntryDone(Guid id, bool value);
	}
}
