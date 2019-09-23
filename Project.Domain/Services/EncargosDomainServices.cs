using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Contracts.Services;
using Project.Domain.Services;
using Project.Domain.Entities;

namespace Project.Domain.Services
{
	public class EncargosDomainServices 
		: IEncargosDomainServices
	{
		private readonly IEncargosRepository repository;

		public EncargosDomainServices(IEncargosRepository repository)
		{
			this.repository = repository;			
		}		
		

		public void Insert(Encargos obj)
		{
			repository.Insert(obj);
		}

		public void Delete(Encargos obj)
		{
			repository.Delete(obj);
		}

		public Encargos SelectOne(DateTime obj)
		{
		 return repository.SelectOne(obj);
		}
	}
}
