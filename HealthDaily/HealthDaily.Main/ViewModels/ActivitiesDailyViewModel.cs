using HealthDaily.Domain.Entities;
using HealthDaily.Domain.Services;
using Microsoft.Practices.ServiceLocation;
using Prism.Events;
using Prism.Mvvm;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Main.ViewModels
{
	public class ActivitiesDailyViewModel : ViewModelBase
	{
		private readonly INavigationService navigationService;
		private readonly IEventAggregator eventAggregator;
		private readonly IActivityService activityService;

		private DateTime date;
		public DateTime Date
		{
			get { return date; }
			set { SetProperty(ref date, value); }
		}

		private DayInfo dayInfo;
		public DayInfo DayInfo
		{
			get { return dayInfo; }
			set { SetProperty(ref dayInfo, value); }
		}

		private ObservableCollection<ActivityEntryModel> activities;
		public ObservableCollection<ActivityEntryModel> Activities
		{
			get { return activities; }
			set { SetProperty(ref activities, value); }
		}

		public ActivitiesDailyViewModel(
			INavigationService navigationService,
			IEventAggregator eventAggregator,
			IActivityService activityService)
		{
			this.navigationService = navigationService;
			this.eventAggregator = eventAggregator;
			this.activityService = activityService;

			if (this.Date == DateTime.MinValue)
			{
				this.Date = DateTime.Now.Date;
			}
			RefreshData();
		}

		public void OnDateChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			RefreshData();
		}

		private void RefreshData()
		{
			var activitiesDay = activityService.FindActivitiesDay(this.Date);
			if (activitiesDay != null)
			{
				this.DayInfo = activitiesDay.DayInfo;

				var activitiesViewModel = activitiesDay.Activities.Select(a => ActivityEntryModel.Create(a)).ToList();
				this.Activities = new ObservableCollection<ActivityEntryModel>(activitiesViewModel);
			} 
			else
			{
				this.DayInfo = new DayInfo();
				this.Activities = new ObservableCollection<ActivityEntryModel>();
			}
		}
	}
}
