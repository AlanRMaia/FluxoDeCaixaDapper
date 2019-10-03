using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;

namespace Project.Domain.Contracts.Repositories
{
	public interface IEncargosRepository 	
	{

		void Insert(Encargos obj);			
		Encargos SelectOne(DateTime obj);
	


	}
}
