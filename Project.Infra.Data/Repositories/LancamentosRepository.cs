using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;
using Project.Domain.Contracts.Repositories;
using Project.Infra.Data.Context;
using System.Linq;

namespace Project.Infra.Data.Repositories
{
	public class LancamentosRepository 
		: BaseRepository<Lancamentos> , ILancamentosRepository
	{
		private readonly DataContext dataContext;

		public LancamentosRepository(DataContext dataContext)
			:base(dataContext)
		{
			this.dataContext = dataContext;
		}

		public override List<Lancamentos> SelectAllDate(DateTime of, DateTime to)
		{
			return dataContext.Lancamentos
				.Where(l => l.DataLancamento >= of && l.DataLancamento <= to)
				.OrderByDescending(l => l.DataLancamento)
				.ToList();
				
		}

		public override List<Lancamentos> SelectAllDate(DateTime obj)
		{
			return dataContext.Lancamentos
				.Where(l => l.DataLancamento == obj)
				.OrderByDescending(l => l.DataLancamento)
				.ToList();
		}
	}
}
