using System;
using System.Collections.Generic;
using System.Text;
using Project.Application.Contracts;
using Project.Domain.Contracts.Services;
using Project.Domain.Entities;
using AutoMapper;
using Project.Application.Models;


namespace Project.Application.Services
{
	public class LancamentosApplicationServices : ILancamentosApplicationServices
	{

		private readonly ILancamentosDomainServices domainServices;

		public LancamentosApplicationServices(ILancamentosDomainServices domainServices)
		{
			this.domainServices = domainServices;
		}

		public void Cadastrar(LancamentosCadastroModel model)
		{
			var entity = Mapper.Map<Lancamentos>(model);
			domainServices.Cadastrar(entity);
		}

		public void Atualizar(LancamentosEdicaoModel model)
		{
			var entity = Mapper.Map<Lancamentos>(model);
			domainServices.Atualizar(entity);
		}

		public void Excluir(int id)
		{
			var entity = domainServices.ConsultarPorId(id);
			domainServices.Excluir(entity);
		}

		public List<LancamentosConsultaModel> ConsultarTodos()
		{
			var entityList = domainServices.ConsultarTodos();
			return Mapper.Map<List<LancamentosConsultaModel>>(entityList);
		}

		public LancamentosConsultaModel ConsultarPorId(int id)
		{
			var entity = domainServices.ConsultarPorId(id);
			return Mapper.Map<LancamentosConsultaModel>(entity);
		}

		public void Dispose()
		{
			domainServices.Dispose();
		}
	}
}
