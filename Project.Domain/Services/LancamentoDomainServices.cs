using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Services;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;

namespace Project.Domain.Services
{
	public class LancamentoDomainServices :
		BaseDomainServices<Lancamentos>, ILancamentosDomainServices
	{
		private readonly ILancamentosRepository repository;

		public LancamentoDomainServices(ILancamentosRepository repository)
			:base(repository)
		{
			this.repository = repository;
		}
	}
}
