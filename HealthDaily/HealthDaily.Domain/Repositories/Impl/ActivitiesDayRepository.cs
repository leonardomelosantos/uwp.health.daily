using HealthDaily.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Repositories.Impl
{
	public class ActivitiesDayRepository : IActivitiesDayRepository
	{
		private List<ActivitiesDay> fakeData;

		private readonly IActivityRepository activityRepository;
		private readonly IActivityEntryRepository activityEntryRepository;

		public ActivitiesDayRepository(
			IActivityRepository activityRepository,
			IActivityEntryRepository activityEntryRepository)
		{
			this.activityRepository = activityRepository;
			this.activityEntryRepository = activityEntryRepository;

			this.fakeData = new List<ActivitiesDay>();
		}

		public ActivitiesDay Add(ActivitiesDay item)
		{
			this.fakeData.Add(item);
			return item;
		}

		public void Delete(ActivitiesDay item)
		{
			throw new InvalidOperationException();
		}

		public IList<ActivitiesDay> FindAll()
		{
			GenerateFakeDataIfEmpty();
			return this.fakeData.ToList();
		}

		public ActivitiesDay FindByDate(DateTime dateRef)
		{
			GenerateFakeDataIfEmpty();
			return this.fakeData.FirstOrDefault(x => x.Date == dateRef);
		}

		public ActivitiesDay FindById(Guid id)
		{
			GenerateFakeDataIfEmpty();
			return this.fakeData.FirstOrDefault(x => x.Id == id);
		}

		#region Fake data

		private void GenerateFakeDataIfEmpty()
		{
			if (this.fakeData == null || !this.fakeData.Any())
			{
				var activities = this.activityRepository.FindAll();
				var randomAct = new Random();
				var randomDuration = new Random();
				var randomHour = new Random();

				for (int i = 0; i >= -4; i--)
				{
					var dateRef = DateTime.Now.Date.AddDays(i);
					string city = GetCity();

					ActivitiesDay newDay = new ActivitiesDay()
					{
						Date = dateRef,
						DayInfo = new DayInfo()
						{
							City = city,
							Temperature = GetTemperature(city, dateRef),
							Weather = GetDayWeather(city, dateRef)
						},
						Activities = new List<ActivityEntry>()
					};

					for (int j = 0; j < 3; j++)
					{
						var newEntry = new ActivityEntry()
						{
							Id = Guid.NewGuid(),
							Activity = activities[randomAct.Next(1, 7)],
							Duration = new TimeSpan(randomDuration.Next(0, 2), randomDuration.Next(30, 55), 0),
							ScheduledTime = new DateTime(dateRef.Year, dateRef.Month, dateRef.Day, randomHour.Next(7, 21), 0, 0)
						};
						newDay.Activities.Add(this.activityEntryRepository.Add(newEntry));
					}

					this.Add(newDay);
				}
			}
		}

		private string GetDayWeather(string city, DateTime dateRef)
		{
			return "Cloudy";
		}

		private int GetTemperature(string city, DateTime dateRef)
		{
			return (new Random().Next(15, 28));
		}

		private string GetCity()
		{
			return "Seul, KR";
		}

		#endregion 
	}
}
