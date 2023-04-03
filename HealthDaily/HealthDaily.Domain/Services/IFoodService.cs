using HealthDaily.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace HealthDaily.Domain.Services
{
	public interface IFoodService
	{
		List<FoodEntry> FindFoodsEntries(DateTime date);

		FoodEntry SaveFood(DateTime date, StorageFile file);

		Task DeleteFoodById(Guid id);
	}
}
