using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HealthDaily.Main
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class AppShell : Page
	{
		public AppShell()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Método adicionado manualmente, que tem a ver com customização do AppShell.
		/// </summary>
		/// <param name="frame">Este parâmetro será passado pelo Prism</param>
		public void SetFrame(Frame frame)
		{
			MyContentPresenter.Content = frame;
		}
	}
}
