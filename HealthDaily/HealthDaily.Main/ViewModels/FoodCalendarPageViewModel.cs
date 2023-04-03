using HealthDaily.Domain.Services;
using HealthDaily.Main.Common;
using HealthDaily.Main.Events;
using HealthDaily.Main.Util;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.ViewModels
{
	public class FoodCalendarPageViewModel : ViewModelBase
	{
		private readonly IEventAggregator eventAggregator;
		private readonly IFoodService foodService;

		#region Properties

		private DateTime date;
		public DateTime Date
		{
			get { return date; }
			set { SetProperty(ref date, value); }
		}

		private ObservableCollection<FoodEntryModel> entriesFood;
		public ObservableCollection<FoodEntryModel> EntriesFood
		{
			get { return entriesFood; }
			set { SetProperty(ref entriesFood, value); }
		}

		private StorageFile selectedFoodImage;
		public StorageFile SelectedFoodImage
		{
			get { return selectedFoodImage; }
			set { SetProperty(ref selectedFoodImage, value); }
		}

		#endregion

		public FoodCalendarPageViewModel(
			IEventAggregator eventAggregator,
			IFoodService foodService)
		{
			this.eventAggregator = eventAggregator;
			this.foodService = foodService;
		}

		public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
		{
			base.OnNavigatedTo(e, viewModelState);

			eventAggregator.GetEvent<PageNavigatedEvent>().Publish(PageTokens.FoodCalendarPage);

			if (this.Date == DateTime.MinValue)
			{
				this.Date = DateTime.Now.Date;
				
			}

			await LoadFoodEntries();
		}

		public async void OnDateChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			await LoadFoodEntries();
		}

		private async Task LoadFoodEntries()
		{
			var foods = foodService.FindFoodsEntries(this.Date);
			var entriesViewModel = foods.Select(f => FoodEntryModel.CreateAsync(f, RemoveFoodEntry)).ToList();

			FoodEntryModel[] models = await Task.WhenAll(entriesViewModel);

			this.EntriesFood = new ObservableCollection<FoodEntryModel>(models);
		}

		public async void AddNewFoodClick(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			IReadOnlyList<StorageFile> files = await FileHelper.SelectFilesFilePicker();

			if (files != null)
			{
				foreach (var file in files)
				{
					try
					{
						var foodEntrySaved = this.foodService.SaveFood(this.Date, file);
						var foodEntryViewModel = await FoodEntryModel.CreateAsync(foodEntrySaved);
					}
					catch (Exception ex)
					{

					}
				}
				await LoadFoodEntries();
			}
		}

		public async void RemoveFoodEntry(FoodEntryModel foodEntryViewModel)
		{
			this.EntriesFood.Remove(foodEntryViewModel);
			await this.foodService.DeleteFoodById(foodEntryViewModel.Id);
		}

	}
}
