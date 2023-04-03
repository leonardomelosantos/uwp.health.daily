using HealthDaily.Domain.Services;
using HealthDaily.Main.Util;
using Prism.Mvvm;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;

namespace HealthDaily.Main.ViewModels
{
	public class TodaysFoodViewModel : ViewModelBase
	{
		private readonly IFoodService foodService;

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

		public TodaysFoodViewModel(IFoodService foodService)
		{
			this.foodService = foodService;

			LoadFoodEntries();
		}

		private async void LoadFoodEntries()
		{
			var foods = foodService.FindFoodsEntries(DateTime.Now.Date);
			var entriesViewModel = foods.Select(async f => await FoodEntryModel.CreateAsync(f)).ToList();

			var models = await Task.WhenAll(entriesViewModel);

			this.EntriesFood = new ObservableCollection<FoodEntryModel>(models);
			this.EntriesFood.Add(null);
		}

		public async void AddNewFoodClick(object sender, ItemClickEventArgs e)
		{
			if (e.ClickedItem != null)
			{
				return;
			}

			IReadOnlyList<StorageFile> files = await FileHelper.SelectFilesFilePicker();

			if (files != null)
			{
				foreach (var file in files)
				{
					try
					{
						var foodEntrySaved = this.foodService.SaveFood(DateTime.Now, file);
						var foodEntryViewModel = await FoodEntryModel .CreateAsync(foodEntrySaved);

						this.EntriesFood.Insert(this.EntriesFood.Count - 1, foodEntryViewModel);
					}
					catch (Exception ex)
					{

					}
				}
			}
		}

		
	}
}
