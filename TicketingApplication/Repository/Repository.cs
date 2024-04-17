using  TicketingApplication.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace  TicketingApplication.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly TicketingApplicationDBContext _tsContext;
		public Repository(TicketingApplicationDBContext tsDBContext)
		{
			_tsContext = tsDBContext;
		}
		public IEnumerable<T> GetAll(Expression<Func<T, object>>[] includes)
		{
			if (includes != null)
			{
				IQueryable<T> query = _tsContext.Set<T>();
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
				return query.ToList();
			}
			else
				return _tsContext.Set<T>().ToList();
		}
		public IEnumerable<T> GetAllByFilter(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[] includes,
			Expression<Func<T, object>> orderby)
		{
			if (includes != null)
			{
				IQueryable<T> query = _tsContext.Set<T>();
				foreach (var include in includes)
				{
					query = query.Include(include);
				}
				if (orderby != null)
					return query.Where(expression).OrderByDescending(orderby).ToList();
				else
					return query.Where(expression).ToList();
			}
			else
			{
				if (orderby != null)
					return _tsContext.Set<T>().Where(expression).OrderByDescending(orderby).ToList();
				else
					return _tsContext.Set<T>().Where(expression).ToList();
			}
		}

		public T GetById(int id)
		{
			return _tsContext.Set<T>().Find(id);
		}

		public void AddEntity(T entity)
		{
			_tsContext.Set<T>().Add(entity);
		}
		public void UpdateEntity(T entity)
		{
			_tsContext.Set<T>().Update(entity);
		}
		public void RemoveEntity(int id)
		{
			T RemoveEnt = GetById(id);
			_tsContext.Set<T>().Remove(RemoveEnt);
		}
		public bool SaveChange()
		{
			return _tsContext.SaveChanges() > 0;
		}
	}

}
