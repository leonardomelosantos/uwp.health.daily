using HealthDaily.Main.ViewModels;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.Views
{
	public sealed partial class MenuView : UserControl
	{
		public MenuViewModel ViewModel => (MenuViewModel)this.DataContext;

		public MenuView()
		{
			this.InitializeComponent();
		}
	}
}
