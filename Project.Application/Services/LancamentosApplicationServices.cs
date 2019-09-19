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

		public LancamentosConsultaModel ConsultarTodosOsDados()
		{
			var json = new LancamentosConsultaModel();
			var formatoJson = new FormatoJson();

			var dia = DateTime.Now;

			var lancamentosDia = domainServices.LancamentosDoDia(DateTime.Now);
			var saldoDia = domainServices.ColsultarSaldoDia();
			var saldoDiaAnteri = domainServices.ColsultarSaldoDiaAnterior();
			var trintaDias = domainServices.LancamentosDoDia(DateTime.Now, DateTime.Now.AddMonths(1));
			var porcentagem = 1 - saldoDia / saldoDiaAnteri;
			var valorPorcen = $"{porcentagem}%";

			var listLancamentosDia = new List<FormatoJson>();
			foreach (var item in lancamentosDia)
			{
				formatoJson.Tipo = item.Tipo;
				formatoJson.DataLancamento = item.DataLancamento;
				formatoJson.ValorLancamento = item.ValorLancamento;

				listLancamentosDia.Add(formatoJson);
			}

			var listTrintaDias = new List<FormatoJson>();
			foreach (var item in trintaDias)
			{
				formatoJson.Tipo = item.Tipo;
				formatoJson.DataLancamento = item.DataLancamento;
				formatoJson.ValorLancamento = item.ValorLancamento;

				listTrintaDias.Add(formatoJson);
			}

			json.DiaConsulta = dia;
			json.LancamentosDoDia = listLancamentosDia;
			json.TrintaDiasSeguintes = listTrintaDias;
			json.ComparacaoDiaAnterior = valorPorcen;
			json.SaldoTotalDoDia = saldoDia;
			


			return Mapper.Map<LancamentosConsultaModel>(json);
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
