using System;
using Windows.UI.Xaml.Data;

namespace HealthDaily.Main.Converters
{
	public class DurationConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is TimeSpan valueConverted)
			{
				int totalMinutes = (int)valueConverted.TotalMinutes;
				int totalHours = totalMinutes / 60;
				if (totalHours <= 0)
				{
					return $"{totalMinutes} min";
				} 
				else
				{
					return $"{totalHours}h {totalMinutes-(totalHours*60)} min";
				}
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value;
		}
	}
}
