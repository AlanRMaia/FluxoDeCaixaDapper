using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts;
using Project.Domain.Entities;

namespace Project.Domain.Contracts.Services
{
	public interface ILancamentosDomainServices
		: IBaseDomainServices<Lancamentos> 
	{
	}
}
