using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDaily.Domain.Repositories
{
	public interface IRepositoryBase<T, T2>
	{
        IList<T> FindAll();
        T FindById(T2 id);
        T Add(T item);
        //T Update(T item);
        void Delete(T item);
    }
}
