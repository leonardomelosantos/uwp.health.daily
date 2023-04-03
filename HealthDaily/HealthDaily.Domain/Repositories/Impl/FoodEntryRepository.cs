using HealthDaily.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Repositories.Impl
{
	public class FoodEntryRepository : IFoodEntryRepository
	{
		private IList<FoodEntry> fakeData;

		public FoodEntryRepository()
		{
			this.fakeData = new List<FoodEntry>();
		}

		public FoodEntry Add(FoodEntry item)
		{
			this.fakeData.Add(item);
			return item;
		}

		public async void Delete(FoodEntry item)
		{
			await Task.Run(() => this.fakeData.Remove(item));
		}

		public async void DeleteyId(Guid id)
		{
			await Task.Run(() => {
				List<WeakReference<FoodEntry>> entriesToDelete =
				this.fakeData.Where(x => x.Id == id).Select(x => new WeakReference<FoodEntry>(x)).ToList();

				foreach (var item in entriesToDelete) {
					FoodEntry objToDelete;
					if (item.TryGetTarget(out objToDelete))
					{
						this.fakeData.Remove(objToDelete);
					}
				}
			}
			);
		}

		public IList<FoodEntry> FindAll()
		{
			return this.fakeData.ToList();
		}

		public List<FoodEntry> FindByDate(DateTime date)
		{
			return this.fakeData.Where(i => i.DateTime.Date == date.Date).ToList();
		}

		public FoodEntry FindById(Guid id)
		{
			return this.fakeData.FirstOrDefault(f => f.Id == id);
		}
	}
}
