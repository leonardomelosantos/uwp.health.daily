using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace HealthDaily.Main.Converters
{
	/// <summary>
	/// Se nenhum parâmetro for passado para o "parameter", será considerado o "LongDatePattern"
	/// </summary>
	public class CustomDateConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is DateTime dateConverted)
			{
				if (parameter is null)
				{
					return dateConverted.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern);
				}
				return dateConverted.ToString((string)parameter);
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value;
		}
	}
}
