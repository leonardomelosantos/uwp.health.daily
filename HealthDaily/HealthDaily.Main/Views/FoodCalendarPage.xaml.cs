using HealthDaily.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.Views
{
	public sealed partial class FoodCalendarPage : Page
	{
		public FoodCalendarPageViewModel ViewModel => (FoodCalendarPageViewModel)this.DataContext;

		public FoodCalendarPage()
		{
			this.InitializeComponent();
		}
	}
}
