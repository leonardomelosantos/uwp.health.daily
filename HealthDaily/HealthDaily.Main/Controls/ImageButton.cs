using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace HealthDaily.Main.Controls
{
	public sealed class ImageButton : Button
	{
		#region Dependency Properties

		public ImageSource DefaultImageSource
		{
			get { return (ImageSource)GetValue(DefaultImageSourceProperty); }
			set { SetValue(DefaultImageSourceProperty, value); }
		}

		public static readonly DependencyProperty DefaultImageSourceProperty =
			DependencyProperty.Register("DefaultImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(String.Empty));

		public ImageSource HoverImageSource
		{
			get { return (ImageSource)GetValue(HoverImageSourceProperty); }
			set { SetValue(HoverImageSourceProperty, value); }
		}

		public static readonly DependencyProperty HoverImageSourceProperty =
			DependencyProperty.Register("HoverImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(String.Empty));

		public ImageSource PressedImageSource
		{
			get { return (ImageSource)GetValue(PressedImageSourceProperty); }
			set { SetValue(PressedImageSourceProperty, value); }
		}

		public static readonly DependencyProperty PressedImageSourceProperty =
			DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(String.Empty));

		#endregion

		public ImageButton()
		{
			this.DefaultStyleKey = typeof(ImageButton);
		}
	}
}
