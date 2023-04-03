using HealthDaily.Domain.Services;
using HealthDaily.Main.Common;
using HealthDaily.Main.Events;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;

namespace HealthDaily.Main.ViewModels
{
	public class DashboardPageViewModel : ViewModelBase
	{
		private readonly INavigationService navigationService;
		private readonly IEventAggregator eventAggregator;

		public DashboardPageViewModel(
			INavigationService navigationService,
			IEventAggregator eventAggregator,
			IActivityService activityService)
		{
			this.navigationService = navigationService;
			this.eventAggregator = eventAggregator;
		}

		public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
		{
			base.OnNavigatedTo(e, viewModelState);

			eventAggregator.GetEvent<PageNavigatedEvent>().Publish(PageTokens.DashboardPage);
		}
	}
}
