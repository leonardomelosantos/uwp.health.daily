using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

namespace HealthDaily.Main.Converters
{
	/// <summary>
	/// Se nenhum parâmetro for passado para o "parameter", será considerado o "ShortTimePattern"
	/// </summary>
	public class CustomTimeConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
			if (value is DateTime valueConverted)
			{
				if (parameter is null)
				{
					return valueConverted.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern);
				}
				return valueConverted.ToString((string)parameter);
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			return value;
		}
	}
}
