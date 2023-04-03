using HealthDaily.Domain.Entities;
using HealthDaily.Domain.Services;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.ViewModels
{
	public class ActivityEntryModel : Prism.Mvvm.BindableBase
    {

		private Guid id;
		public Guid Id
		{
			get { return id; }
			set { SetProperty(ref id, value); }
		}

		private TimeSpan duartion;
		public TimeSpan Duration
		{
			get { return duartion; }
			set { SetProperty(ref duartion, value); }
		}

		private DateTime scheduledTime;
		public DateTime ScheduledTime
		{
			get { return scheduledTime; }
			set { SetProperty(ref scheduledTime, value); }
		}

		private string activityDescription;
		public string ActivityDescription
		{
			get { return activityDescription; }
			set { SetProperty(ref activityDescription, value); }
		}

		private string activityIconTag;
		public string ActivityIconTag
		{
			get { return activityIconTag; }
			set { SetProperty(ref activityIconTag, value); }
		}

		private bool isDone;
		public bool IsDone
		{
			get { return isDone; }
			set { SetProperty(ref isDone, value); }
		}

		public static ActivityEntryModel Create(ActivityEntry entity)
		{
			return new ActivityEntryModel()
			{
				ActivityDescription = entity.Activity.Description,
				ActivityIconTag = $"ms-appx:///Assets/Activities/shealth_ic_activity_{entity.Activity.IconTag}.png",
				Duration = entity.Duration,
				ScheduledTime = entity.ScheduledTime,
				IsDone = entity.IsDone,
				Id = entity.Id
			};
		}

		public void ClickActivityDone(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			if (sender is CheckBox controlCheck)
			{
				this.IsDone = controlCheck.IsChecked.Value;
				ServiceLocator.Current.GetInstance<IActivityService>().SaveActivityEntryDone(this.Id, this.IsDone);
			}
		}
	}
}
