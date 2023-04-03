using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace HealthDaily.Main.Util
{
	public static class Extensions
	{
		public static BitmapImage AsBitmapImage(this StorageFile file)
		{
			using (var stream = file.OpenReadAsync().AsTask().Result)
			{
				var bitmapImage = new BitmapImage();
				bitmapImage.SetSource(stream);
				return bitmapImage;
			}
		} 
	}
}
