using System;
using System.Collections.Generic;
using System.Text;
using Project.Infra.Data.Context;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Project.Infra.Data.Repositories
{
	public class EncargosRepository 
		: IEncargosRepository
	{
		private readonly DataContext dataContext;

		public EncargosRepository(DataContext dataContext)			
		{
			this.dataContext = dataContext;
		}		

		public void Insert(Encargos obj)
		{
			dataContext.Entry(obj).State = EntityState.Added;
			dataContext.SaveChanges() ;
		}		

		public void Delete(Encargos obj)
		{
			dataContext.Entry(obj).State = EntityState.Deleted;
			dataContext.SaveChanges();
		}			

		public Encargos SelectOne(DateTime obj)
		{

			return dataContext.Encargos.AsNoTracking()
				.Where(e => e.DataLancamento == obj)
				.SingleOrDefault();
					
		}

		
	}
}
