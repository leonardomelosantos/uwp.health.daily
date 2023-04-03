using HealthDaily.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.Views
{
	public sealed partial class WelcomeCardView : UserControl
	{
		public WelcomeCardViewModel ViewModel => (WelcomeCardViewModel)this.DataContext;

		public WelcomeCardView()
		{
			this.InitializeComponent();
		}
	}
}
