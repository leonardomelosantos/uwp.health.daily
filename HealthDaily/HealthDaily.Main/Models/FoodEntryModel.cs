using HealthDaily.Domain.Entities;
using HealthDaily.Main.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;

namespace HealthDaily.Main.ViewModels
{
	public class FoodEntryModel : Prism.Mvvm.BindableBase
    {
		#region Properties 

		private Guid id;
		public Guid Id
		{
			get { return id; }
			set { SetProperty(ref id, value); }
		}

		private DateTime dateTime;
		public DateTime DateTime
		{
			get { return dateTime; }
			set { SetProperty(ref dateTime, value); }
		}

		private StorageFile picture;
		public StorageFile Picture
		{
			get { return picture; }
			set { SetProperty(ref picture, value); }
		}

		private BitmapImage thumbnail;
		public BitmapImage Thumbnail
		{
			get { return thumbnail; }
			set { SetProperty(ref thumbnail, value); }
		}

		#endregion

		#region Events/Actions

		public Action<FoodEntryModel> RemoveCustomAction;

		#endregion

		#region Factories/Builders/Creators

		public static async Task<FoodEntryModel> CreateAsync(FoodEntry foodEntry, Action<FoodEntryModel> removeCustomAction)
		{
			return new FoodEntryModel()
			{
				DateTime = foodEntry.DateTime,
				Id = foodEntry.Id,
				Picture = foodEntry.Picture,
				Thumbnail = foodEntry.Picture.AsBitmapImage(),
				RemoveCustomAction = removeCustomAction
			};
		}

		public static async Task<FoodEntryModel> CreateAsync(FoodEntry foodEntry)
		{
			return await CreateAsync(foodEntry, null);
		}
		
		#endregion

		public void Remove(object sender, Windows.UI.Xaml.RoutedEventArgs e)
		{
			if (this.RemoveCustomAction != null)
			{
				RemoveCustomAction.Invoke(this);
			}
		}
	}
}
