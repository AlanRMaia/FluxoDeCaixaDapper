using System;
using System.Collections.Generic;
using System.Text;
using Project.Application.Contracts;
using Project.Domain.Contracts.Services;
using Project.Domain.Entities;
using AutoMapper;
using Project.Application.Models;
using System.Globalization;

namespace Project.Application.Services
{
	public class LancamentosApplicationServices : ILancamentosApplicationServices
	{

		private readonly ILancamentosDomainServices domainServices;
		private CultureInfo culture;

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

			var dia = DateTime.Now;

			var lancamentosDia = domainServices.ConsultarLancamentosDia(dia);
			var saldoDia = domainServices.ColsultarSaldoDia();
			var saldoDiaAnteri = domainServices.ColsultarSaldoDiaAnterior();
			var trintaDias = domainServices.ConsultarTrintaDias(DateTime.Now, DateTime.Now.AddMonths(1));
			var porcentagem = (saldoDia - saldoDiaAnteri)/saldoDiaAnteri*100;
			culture = CultureInfo.InvariantCulture;
			var valorPorcen = $"{porcentagem.ToString("##.##", culture)}%";

			var listLancamentosDia = new List<FormatoJson>();
			foreach (var item in lancamentosDia)
			{
				var formatoJson = new FormatoJson();

				formatoJson.Tipo = item.Tipo;
				formatoJson.DataLancamento = item.DataLancamento;
				formatoJson.ValorLancamento = item.ValorLancamento;

				listLancamentosDia.Add(formatoJson);
			}

			var listTrintaDias = new List<FormatoJson>();
			foreach (var item in trintaDias)
			{
				var formatoJson = new FormatoJson();

				formatoJson.Tipo = item.Tipo;
				formatoJson.DataLancamento = item.DataLancamento;
				formatoJson.ValorLancamento = item.ValorLancamento;

				listTrintaDias.Add(formatoJson);
			}

			json.DiaConsulta = dia;
			json.LancamentosDoDia = listLancamentosDia;
			json.SaldoTotalDoDia = saldoDia;
			json.TrintaDiasSeguintes = listTrintaDias;
			json.ComparacaoDiaAnterior = valorPorcen;
			


			return Mapper.Map<LancamentosConsultaModel>(json);
		}

		public LancamentosConsultaModel ConsultarPorId(int id)
		{
			var entity = domainServices.ConsultarPorId(id);
			return Mapper.Map<LancamentosConsultaModel>(entity);
		}

		
	}
}
