using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibyanaHub.Services.DataAccess.IRepository
{
	public interface IRepository<T> where T : class
	{
		Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true);

		Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int PageSize = 100, int PageNumber = 1);

		Task<bool> Save();
		Task<bool> Add(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entity);
		bool IsCheckDuplicate(Expression<Func<T, bool>> filter);
		Task<bool> IsCheckDuplicateAsync(Expression<Func<T, bool>> filter);
	}
}