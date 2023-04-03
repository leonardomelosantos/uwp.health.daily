using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace HealthDaily.Main.Controls
{
	public sealed class MenuButton : RadioButton
	{

		#region Dependency Properties - Images/icons

		public ImageSource ImageDefault
		{
			get { return (ImageSource)GetValue(ImageDefaultProperty); }
			set { SetValue(ImageDefaultProperty, value); }
		}

		public static readonly DependencyProperty ImageDefaultProperty =
			DependencyProperty.Register("ImageDefault", typeof(ImageSource), typeof(MenuButton), new PropertyMetadata(null));



		public ImageSource ImageSelected
		{
			get { return (ImageSource)GetValue(ImageSelectedProperty); }
			set { SetValue(ImageSelectedProperty, value); }
		}

		public static readonly DependencyProperty ImageSelectedProperty =
			DependencyProperty.Register("ImageSelected", typeof(ImageSource), typeof(MenuButton), new PropertyMetadata(null));

		#endregion

		public MenuButton()
		{
			this.DefaultStyleKey = typeof(MenuButton);
		}
	}
}
