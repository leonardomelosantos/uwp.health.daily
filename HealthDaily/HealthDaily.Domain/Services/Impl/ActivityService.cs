using HealthDaily.Domain.Entities;
using HealthDaily.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Services.Impl
{
	public class ActivityService : IActivityService
	{
		private readonly IActivitiesDayRepository activitiesDayRepository;
		private readonly IActivityEntryRepository activityEntryRepository;

		public ActivityService(IActivitiesDayRepository activitiesDayRepository,
			IActivityEntryRepository activityEntryRepository)
		{
			this.activitiesDayRepository = activitiesDayRepository;
			this.activityEntryRepository = activityEntryRepository;
		}

		public ActivitiesDay FindActivitiesDay(DateTime date)
		{
			return activitiesDayRepository.FindByDate(date);
		}

		public void SaveActivityEntryDone(Guid id, bool value)
		{
			var activityEntry = activityEntryRepository.FindById(id);
			if (activityEntry != null)
			{
				activityEntry.IsDone = value;
			}
		}
	}
}
