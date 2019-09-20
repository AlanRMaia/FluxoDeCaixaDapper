using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;
using Project.Domain.Contracts.Repositories;
using Project.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
	public class LancamentosRepository 
		: ILancamentosRepository
	{
		private readonly DataContext dataContext;

		public LancamentosRepository(DataContext dataContext)			
		{
			this.dataContext = dataContext;
		}


		public  List<Lancamentos> SelectAllDate(DateTime of, DateTime to)
		{
			return dataContext.Lancamentos
				.Where(l => l.DataLancamento >= of && l.DataLancamento <= to)
				.OrderByDescending(l => l.DataLancamento)
				.ToList();
				
		}

		public List<Lancamentos> SelectAllDate(DateTime obj)
		{
			return dataContext.Lancamentos
				.Where(l => l.DataLancamento == obj)
				.OrderByDescending(l => l.DataLancamento)
				.ToList();
		}

		

		public void Insert(Lancamentos obj)
		{
			dataContext.Entry(obj).State = EntityState.Added;
			dataContext.SaveChanges();
		}

		public void Update(Lancamentos obj)
		{
			dataContext.Entry(obj).State = EntityState.Modified;
			dataContext.SaveChanges();
		}

		public void Delete(Lancamentos obj)
		{
			dataContext.Entry(obj).State = EntityState.Deleted;
			dataContext.SaveChanges();
		}

		public List<Lancamentos> SelectAll()
		{
			return dataContext.Set<Lancamentos>().ToList();
		}		
		

		public Lancamentos SelectOne(int id)
		{
			return dataContext.Set<Lancamentos>().Find(id);
		}

		public virtual Lancamentos SelectOne(DateTime obj)
		{
			return dataContext.Set<Lancamentos>().SingleOrDefault();
		}

		public virtual int Count()
		{
			throw new NotImplementedException();
		}

		public int Count(DateTime obj)
		{
			throw new NotImplementedException();
		}	

		
	}
}
