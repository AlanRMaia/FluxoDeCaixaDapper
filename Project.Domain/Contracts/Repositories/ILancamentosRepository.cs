using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;

namespace Project.Domain.Contracts.Repositories
{
	public interface ILancamentosRepository 
	
	{
		void Insert(Lancamentos obj);
		void Update(Lancamentos obj);
		void Delete(Lancamentos id);

		List<Lancamentos> SelectAll();
		List<Lancamentos> SelectAllDate(DateTime obj);
		List<Lancamentos> SelectAllDate(DateTime of, DateTime to);

		Lancamentos SelectOne(int id);		

		int Count();
		int Count(DateTime obj);
	}
}
