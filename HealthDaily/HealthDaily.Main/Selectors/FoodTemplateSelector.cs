using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.Selectors
{
	/// <summary>
	/// Referência de estudo: https://nicksnettravels.builttoroam.com/listview-gridview-templates/
	/// </summary>
	public class FoodTemplateSelector : DataTemplateSelector
	{
		public DataTemplate FoodImageTemplate { get; set; }
		public DataTemplate NewFoodImageTemplate { get; set; }


		/// <summary>
		/// Necessário sobrescrever este método.
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		protected override DataTemplate SelectTemplateCore(object item)
		{
			if (item == null)
			{
				return NewFoodImageTemplate;
			}
			return FoodImageTemplate;
		}
	}
}
