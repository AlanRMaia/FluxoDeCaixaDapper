using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Contracts.Repositories
{
	public interface IBaseRepository<TEntity> : IDisposable
		where TEntity : class
	{
		void Insert(TEntity obj);
		void Update(TEntity obj);
		void Delete(TEntity obj);

		List<TEntity> SelectAll();		
		List<TEntity> SelectAllDate(DateTime obj);
		List<TEntity> SelectAllDate(DateTime of, DateTime to);

		TEntity SelectOne(int id);
		TEntity SelectOne(DateTime obj);

		int Count();
		int Count(DateTime obj);
	}
}
