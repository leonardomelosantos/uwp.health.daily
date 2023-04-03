using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Main.ViewModels
{
	public class WelcomeCardViewModel : ViewModelBase
	{
		private string title;
		public string Title
		{
			get { return title; }
			set { SetProperty(ref title, value); }
		}

		private string dailyMessage;
		public string DailyMessage
		{
			get { return dailyMessage; }
			set { SetProperty(ref dailyMessage, value); }
		}

		public WelcomeCardViewModel()
		{
			Title = "Hello, John!";
			DailyMessage = "Tiny dust warning! Be careful today: wear a mask walking in the streets and use a filter in your house!";
		}
	}
}
