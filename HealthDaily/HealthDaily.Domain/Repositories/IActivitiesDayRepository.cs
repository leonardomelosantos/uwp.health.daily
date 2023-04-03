using HealthDaily.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Repositories
{
	public interface IActivitiesDayRepository : IRepositoryBase<ActivitiesDay, Guid>
	{
		ActivitiesDay FindByDate(DateTime dateRef);
	}
}
