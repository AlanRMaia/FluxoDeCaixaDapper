using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Contracts.Services;
namespace Project.Domain.Services
{
	public abstract class BaseDomainServices<TEntity> 
		: IBaseDomainServices<TEntity> 
		where TEntity : class
	{

		private readonly IBaseRepository<TEntity> repository;

		protected BaseDomainServices(IBaseRepository<TEntity> repository)
		{
			this.repository = repository;
		}

		public void Cadastrar(TEntity obj)
		{
			repository.Insert(obj);
		}

		public void Atualizar(TEntity obj)
		{
			repository.Update(obj);
		}

		public void Excluir(TEntity obj)
		{
			repository.Delete(obj);
		}

		public List<TEntity> ConsultarTodos()
		{
			return repository.SelectAll();
		}

		public TEntity ConsultarPorId(int id)
		{
			return repository.SelectOne(id);
		}

		public void Dispose()
		{
			repository.Dispose();
		}

		public List<TEntity> LancamentosDoDia(DateTime obj)
		{
		 return repository.SelectAllDate(obj);
		}

		public List<TEntity> LancamentosDoDia(DateTime of, DateTime to)
		{
			return repository.SelectAllDate(of, to); ;
		}
	}
}
