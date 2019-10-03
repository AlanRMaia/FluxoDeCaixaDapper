using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Services;
using Project.Domain.Entities;

namespace Project.Domain.Contracts.Services
{
	public interface IEncargosDomainServices		
	{		
		void Insert(Encargos obj);		
		Encargos SelectOne(DateTime obj);
	}
}
