using HealthDaily.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.Views
{
	public sealed partial class ActivitiesDailyView : UserControl
	{
		public ActivitiesDailyViewModel ViewModel => (ActivitiesDailyViewModel)this.DataContext;

		public ActivitiesDailyView()
		{
			this.InitializeComponent();
		}
	}
}
