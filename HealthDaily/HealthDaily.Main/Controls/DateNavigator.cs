using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.Controls
{
	/// <summary>
	/// Controle desenvolvido para navegação de datas, com possibilidade de customizar a formatação da data.
	/// </summary>
	[TemplatePart(Name = PART_NextButton, Type = typeof(Button))]
	[TemplatePart(Name = PART_PreviousButton, Type = typeof(Button))]
	[TemplatePart(Name = PART_DateDescription, Type = typeof(TextBlock))]
	public sealed class DateNavigator : Control
	{
		#region Constants

		private const string PART_NextButton = "PART_NextButton";
		private const string PART_PreviousButton = "PART_PreviousButton";
		private const string PART_DateDescription = "PART_DateDescription";

		#endregion

		#region Dependency Properties

		public DateTime Date
		{
			get { return (DateTime)GetValue(DateProperty); }
			set { SetValue(DateProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Date.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DateProperty =
			DependencyProperty.Register("Date", typeof(DateTime), typeof(DateNavigator), new PropertyMetadata(DateTime.Now, OnDatePropertyChanged));

		/// <summary>
		/// Método implementado intencionalmente para tratar a mudança da data.
		/// </summary>
		/// <param name="d"></param>
		/// <param name="e"></param>
		private static void OnDatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var self = (DateNavigator)d;
			self.UpdateDateDescription();
		}

		public string DateTimeFormat
		{
			get { return (string)GetValue(DateTimeFormatProperty); }
			set { SetValue(DateTimeFormatProperty, value); }
		}

		// Using a DependencyProperty as the backing store for DateTimeFormat.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DateTimeFormatProperty =
			DependencyProperty.Register("DateTimeFormat", typeof(string), typeof(DateNavigator), new PropertyMetadata(CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern));

		#endregion

		#region Events

		public event RoutedEventHandler OnDateChanged;

		#endregion

		#region Constructor and methods

		public DateNavigator()
		{
			this.DefaultStyleKey = typeof(DateNavigator);
		}

		/// <summary>
		/// Sobrescrevendo este método apenas para dar a oportunidade de assinar os eventos dos elementos internos
		/// </summary>
		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			AssignEvents();
			UpdateDateDescription();
		}

		private void UpdateDateDescription()
		{
			if (GetTemplateChild(PART_DateDescription) is TextBlock txtBlockFormated)
			{
				txtBlockFormated.Text =
					string.IsNullOrWhiteSpace(this.DateTimeFormat)
					? this.Date.ToString(CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern)
					: this.Date.ToString(this.DateTimeFormat);
			}
		}

		/// <summary>
		/// Assinando os eventos dos componentes/controles internos.
		/// </summary>
		private void AssignEvents()
		{
			if (GetTemplateChild(PART_NextButton) is Button btnNext)
			{
				btnNext.Click += BtnNext_Click;
			}
			if (GetTemplateChild(PART_PreviousButton) is Button btnPrevious)
			{
				btnPrevious.Click += BtnPrevious_Click;
			}
		}

		private void BtnNext_Click(object sender, RoutedEventArgs e)
		{
			Date = Date.AddDays(1);
			UpdateDateDescription();
			OnDateChanged?.Invoke(this, new RoutedEventArgs());
		}

		private void BtnPrevious_Click(object sender, RoutedEventArgs e)
		{
			Date  = Date.AddDays(-1);
			UpdateDateDescription();
			OnDateChanged?.Invoke(this, new RoutedEventArgs());
		}

		#endregion
	}
}
