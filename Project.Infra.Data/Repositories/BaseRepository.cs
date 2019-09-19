using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Repositories;
using Project.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity : class
	{
		private readonly DataContext dataContext;

		protected BaseRepository(DataContext dataContext)
		{
			this.dataContext = dataContext;
		}

		public void Insert(TEntity obj)
		{
			dataContext.Entry(obj).State = EntityState.Added;
			dataContext.SaveChanges();
		}

		public void Update(TEntity obj)
		{
			dataContext.Entry(obj).State = EntityState.Modified;
			dataContext.SaveChanges();
		}

		public void Delete(TEntity obj)
		{
			dataContext.Entry(obj).State = EntityState.Deleted;
			dataContext.SaveChanges();
		}

		public List<TEntity> SelectAll()
		{
			return dataContext.Set<TEntity>().ToList();
		}
		

		public List<TEntity> SelectAllDate(DateTime obj)
		{
			return dataContext.Set<TEntity>().ToList();
		}

		public TEntity SelectOne(int id)
		{
			return dataContext.Set<TEntity>().Find(id);
		}

		public virtual TEntity SelectOne(DateTime obj)
		{
			return dataContext.Set<TEntity>().SingleOrDefault();
		}

		public virtual int Count()
		{
			throw new NotImplementedException();
		}

		public int Count(DateTime obj)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			dataContext.Dispose();
		}

		public List<TEntity> SelectAllDate(DateTime of, DateTime to)
		{
			throw new NotImplementedException();
		}
	}
}
