using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;
using Project.Domain.Contracts.Repositories;
using Project.Infra.Data.Context;

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


	}
}
