using HealthDaily.Main.Common;
using HealthDaily.Main.Events;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace HealthDaily.Main.ViewModels
{
	public class MenuViewModel : ViewModelBase
	{
		private readonly INavigationService navigationService;
		private readonly IEventAggregator eventAgregator;

		private string currentPage;
		public string CurrentPage
		{
			get { return currentPage; }
			set { SetProperty(ref currentPage, value); }
		}

		public MenuViewModel(
			INavigationService navigationService, 
			IEventAggregator eventAgregator)
		{
			this.navigationService = navigationService;
			this.eventAgregator = eventAgregator;

			this.eventAgregator.GetEvent<PageNavigatedEvent>().Subscribe(OnPageNavigated);
		}

		private void OnPageNavigated(string pageNavigated)
		{
			this.CurrentPage = pageNavigated;
		}

		public void NavigateToDashboard()
		{
			this.navigationService.Navigate(PageTokens.DashboardPage, null);

		}

		public void NavigateToFoodCalendar()
		{
			this.navigationService.Navigate(PageTokens.FoodCalendarPage, null);
		}
	
		public bool IsSelected(string itemPage, string currentPage)
		{
			return itemPage == currentPage;
		}
	}
}
