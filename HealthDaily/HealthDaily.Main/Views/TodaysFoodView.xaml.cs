using HealthDaily.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.Views
{
	public sealed partial class TodaysFoodView : UserControl
	{
		public TodaysFoodViewModel ViewModel => (TodaysFoodViewModel)this.DataContext;

		public TodaysFoodView()
		{
			this.InitializeComponent();
		}
	}
}
