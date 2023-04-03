using HealthDaily.Domain.Entities;
using HealthDaily.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HealthDaily.Domain.Services.Impl
{
	public class FoodService : IFoodService
	{
		private readonly IFoodEntryRepository foodEntryRepository;

		public FoodService(IFoodEntryRepository foodEntryRepository)
		{
			this.foodEntryRepository = foodEntryRepository;
		}

		public List<FoodEntry> FindFoodsEntries(DateTime date)
		{
			return this.foodEntryRepository.FindByDate(date.Date);
		}

		public FoodEntry SaveFood(DateTime date, StorageFile file)
		{
			FoodEntry newEntry = new FoodEntry()
			{
				Id = Guid.NewGuid(),
				DateTime = date,
				Picture = file
			};
			foodEntryRepository.Add(newEntry);
			return newEntry;
		}

		public async Task DeleteFoodById(Guid id)
		{
			await Task.Run( () => foodEntryRepository.DeleteyId(id));
		}
	}
}
