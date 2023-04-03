using HealthDaily.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Repositories.Impl
{
	public class ActivityRepository : IActivityRepository
	{
		private List<Activity> activities { get; set; }

		public ActivityRepository()
		{
			activities = new List<Activity>();
			activities.Add(new Activity() { Id = 1, Description = "Aerobics", IconTag = "aerobics" } );
			activities.Add(new Activity() { Id = 2, Description = "Circuit training", IconTag = "circuit_training" });
			activities.Add(new Activity() { Id = 3, Description = "Cycling", IconTag = "cycling" });
			activities.Add(new Activity() { Id = 4, Description = "Handball", IconTag = "handball" });
			activities.Add(new Activity() { Id = 5, Description = "Running", IconTag = "running" });
			activities.Add(new Activity() { Id = 6, Description = "Stretching", IconTag = "stretching" });
			activities.Add(new Activity() { Id = 7, Description = "Swimming", IconTag = "swimming" });
		}

		public IList<Activity> FindAll()
		{
			return this.activities;
		}

		public Activity FindById(int id)
		{
			return this.activities.FirstOrDefault(a => a.Id == id);
		}

		public Activity Add(Activity item)
		{
			this.activities.Add(item);
			return item;
		}

		public void Delete(Activity item)
		{
			this.activities.Remove(item);
		}
	}
}
