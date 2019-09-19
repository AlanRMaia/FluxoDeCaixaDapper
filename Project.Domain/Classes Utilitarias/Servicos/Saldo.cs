using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Services;

namespace Project.Domain.Classes_Utilitarias.Servicos
{
	public class Saldo : ISaldo
	{
		private readonly ILancamentosDomainServices domainServices;

		public Saldo(ILancamentosDomainServices domainServices)
		{
			this.domainServices = domainServices;
		}

		public decimal ConsultarSaldoTotal()
		{
			return domainServices.ConsultaSaldoTotal();
		}

		public decimal ColsultarSaldoDia()
		{
			return domainServices.ColsultarSaldoDia();
		}
	}
}
