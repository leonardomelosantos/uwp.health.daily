using HealthDaily.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.Views
{
	public sealed partial class DashboardPage : Page
	{
		public DashboardPageViewModel ViewModel => (DashboardPageViewModel)this.DataContext;

		public DashboardPage()
		{
			this.InitializeComponent();
		}
	}
}
