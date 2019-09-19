using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Contracts.Services
{
	public interface IBaseDomainServices<TEntity> : IDisposable
		where TEntity : class
	{
		void Cadastrar(TEntity obj);
		void Atualizar(TEntity obj);
		void Excluir(TEntity obj);

		List<TEntity> ConsultarTodos();
		TEntity ConsultarPorId(int id);

	}
}
