using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Contracts.Services;
using Project.Domain.Entities;

namespace Project.Domain.Services
{
	public class EncargosDomainServices 
		: BaseDomainServices<Encargos>, IEncargosDomainServices
	{
		private readonly IEncargosRepository repository;

		public EncargosDomainServices(IEncargosRepository repository)
			:base(repository)
		{
			this.repository = repository;
		}
	}
}
