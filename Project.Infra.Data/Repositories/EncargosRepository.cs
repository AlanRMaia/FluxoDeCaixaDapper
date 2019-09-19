using System;
using System.Collections.Generic;
using System.Text;
using Project.Infra.Data.Context;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;

namespace Project.Infra.Data.Repositories
{
	public class EncargosRepository 
		: BaseRepository<Encargos>, IEncargosRepository
	{
		private readonly DataContext dataContext;

		public EncargosRepository(DataContext dataContext)
			:base(dataContext)
		{
			this.dataContext = dataContext;
		}
	}
}
