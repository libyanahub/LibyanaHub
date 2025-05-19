using LibyanaHub.Services.DataAccess.Data;
using LibyanaHub.Services.DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LibyanaHub.Services.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly AppDbContext _context;
		internal DbSet<T> dbSet;

		public Repository(AppDbContext context)
		{
			_context = context;
			//_db.ShoppingCarts.Include(u => u.Product).Include(u=>u.CoverType);
			this.dbSet = _context.Set<T>();
		}

		public async Task<bool> Save()
		{
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> Add(T entity)
		{
			await dbSet.AddAsync(entity);

			return await Save();
		}

		public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, int PageSize = 10, int PageNumber = 1)
		{
			try
			{
				PageNumber = PageNumber <= 0 ? 1 : PageNumber;

				IQueryable<T> query = dbSet;
				if (filter != null)
				{
					query = query.Where(filter).Skip((PageNumber - 1) * PageSize).Take(PageSize);
				}
				else
				{
					query = query.Skip((PageNumber - 1) * PageSize).Take(PageSize);
				}

				if (includeProperties != null)
				{
					foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
					{
						query = query.Include(includeProp).Skip((PageNumber - 1) * PageSize).Take(PageSize);
					}
				}
				var result = await query.ToListAsync();

				return result;
			}
			catch (Exception ex)
			{
				return Enumerable.Empty<T>();
			}
		}

		public async Task<T?> GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = true)
		{
			IQueryable<T> query = tracked ? dbSet : dbSet.AsNoTracking();

			query = query.Where(filter);

			if (!string.IsNullOrWhiteSpace(includeProperties))
			{
				foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
				{
					query = query.Include(includeProp);
				}
			}

			T result = await query.FirstOrDefaultAsync();

			return result;
		}

		public void Remove(T entity)
		{
			dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<T> entity)
		{
			dbSet.RemoveRange(entity);
		}

		public bool IsCheckDuplicate(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;

			// Applying the filter if provided
			if (filter != null)
			{
				query = query.Where(filter);
			}

			// Check if any duplicates exist by using the Contains command directly on the query
			return query.Any();
		}

		public async Task<bool> IsCheckDuplicateAsync(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;

			// Applying the filter if provided
			if (filter != null)
			{
				query = query.Where(filter);
			}

			// Check if any duplicates exist by using the Contains command directly on the query
			return await query.AnyAsync();
		}
	}
}