using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace HealthDaily.Main.Controls
{
	[TemplatePart(Name = PART_RemoveButton, Type=typeof(ButtonBase))]
	public sealed class ImageCustomViewer : Control
	{
		#region Constants

		private const string PART_RemoveButton = "PART_RemoveButton";
		private const string STATE_Normal = "Normal";
		private const string STATE_PointerOver = "PointerOver";

		#endregion

		#region Dependency properties

		public ImageSource Source
		{
			get { return (ImageSource)GetValue(SourceProperty); }
			set { SetValue(SourceProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SourceProperty =
			DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageCustomViewer), new PropertyMetadata(null));

		public DateTime DateTime
		{
			get { return (DateTime)GetValue(DateTimeProperty); }
			set { SetValue(DateTimeProperty, value); }
		}

		// Using a DependencyProperty as the backing store for DateTime.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DateTimeProperty =
			DependencyProperty.Register("DateTime", typeof(DateTime), typeof(ImageCustomViewer), new PropertyMetadata(DateTime.MinValue));
		
		#endregion

		#region Events

		public event RoutedEventHandler OnRemove;

		#endregion

		#region Control customs and mouse events

		/// <summary>
		/// Quando o ponteiro do mouse passa por cima do Control.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPointerEntered(PointerRoutedEventArgs e)
		{
			base.OnPointerEntered(e);
			VisualStateManager.GoToState(this, STATE_PointerOver, false);
		}

		/// <summary>
		/// Quando o ponteiro do mouse sai do Control.
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPointerExited(PointerRoutedEventArgs e)
		{
			base.OnPointerExited(e);
			VisualStateManager.GoToState(this, STATE_Normal, false);
		}

		#endregion

		#region Construtor

		public ImageCustomViewer()
		{
			this.DefaultStyleKey = typeof(ImageCustomViewer);
		}

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			AssignEvents();
		}

		#endregion

		#region Methods

		private void AssignEvents()
		{
			if (GetTemplateChild(PART_RemoveButton) is ButtonBase btnRemove)
			{
				btnRemove.Click += BtnRemove_Click;
			}
		}

		private void BtnRemove_Click(object sender, RoutedEventArgs e)
		{	
			if (this.OnRemove != null)
			{
				this.OnRemove.Invoke(this, e);
			}
		}

		#endregion
	}
}
