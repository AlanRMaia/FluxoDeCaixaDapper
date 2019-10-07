using System;
using System.Collections.Generic;
using System.Text;
using Project.Application.Contracts;
using Project.Domain.Contracts.Services;
using Project.Domain.Entities;
using Project.Domain.Class_Utilities.Contracts;
using AutoMapper;
using Project.Application.Models;
using System.Globalization;

namespace Project.Application.Services
{
	public class LancamentosApplicationServices : ILancamentosApplicationServices
	{

		private readonly ILancamentosDomainServices domainServices;
		private readonly IEncargosUtilidades utilidades;
		private readonly IEncargosDomainServices encargosDomain;
		

		public LancamentosApplicationServices(ILancamentosDomainServices domainServices, IEncargosUtilidades utilidades, IEncargosDomainServices encargosDomain)
		{
			this.domainServices = domainServices;
			this.utilidades = utilidades;
			this.encargosDomain = encargosDomain;
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
			var lancamentosDia = new List<Lancamentos>();			
			var dia = DateTime.Today;
			
			if (encargosDomain.SelectOne(dia) == null)
			{				
				lancamentosDia = domainServices.ConsultarLancamentosDia(dia);
			}
			else
			{
				Lancamentos lancamentoDia = new Lancamentos();

				var encargosDia = encargosDomain.SelectOne(dia);
				lancamentoDia.BancoDestino = encargosDia.BancoDestino;
				lancamentoDia.ContaDestino = encargosDia.ContaDestino;
				lancamentoDia.CpfCnpjDestino = encargosDia.CpfCnpjDestino;
				lancamentoDia.DataLancamento = encargosDia.DataLancamento;
				lancamentoDia.Descricao = encargosDia.Descricao;
				lancamentoDia.Tipo = "encargos";
				lancamentoDia.TipoConta = encargosDia.TipoConta;
				lancamentoDia.ValorLancamento = encargosDia.ValorLancamento;

				lancamentosDia = domainServices.ConsultarLancamentosDia(dia);

				lancamentosDia.Add(lancamentoDia);


			}

			var saldoDia = utilidades.ColsultarSaldoDia();
			var saldoDiaAnteri = domainServices.ColsultarSaldoDiaAnterior();
			var trintaDias = domainServices.ConsultarTrintaDias(DateTime.Now, DateTime.Now.AddMonths(1));
			decimal porcentagem;
			try
			{
				porcentagem = ((saldoDia - saldoDiaAnteri) / saldoDiaAnteri) * 100;
			}
			catch (DivideByZeroException)
			{

				porcentagem = 0;
			}
			var culture = CultureInfo.CurrentCulture;
			var valorPorcen = $"{porcentagem.ToString("##.##", culture)}%";

			var listLancamentosDia = new List<FormatoJson>();

			foreach (var item in lancamentosDia)
			{
				var formatoJson = new FormatoJson();

				formatoJson.Tipo = item.Tipo;
				formatoJson.DataLancamento = item.DataLancamento.ToString("dd/MM/yyyy");
				formatoJson.ValorLancamento = item.ValorLancamento.ToString("R$#,0.00");

				listLancamentosDia.Add(formatoJson);
			}

			var listTrintaDias = new List<FormatoJson>();
			foreach (var item in trintaDias)
			{
				var formatoJson = new FormatoJson();

				formatoJson.Tipo = item.Tipo;
				formatoJson.DataLancamento = item.DataLancamento.ToString("dd/MM/yyyy");
				formatoJson.ValorLancamento = item.ValorLancamento.ToString("R$#,0.00");

				listTrintaDias.Add(formatoJson);
			}

			json.DiaConsulta = dia.ToString("dd/MM/yyyy");
			json.LancamentosDoDia = listLancamentosDia;
			json.SaldoTotalDoDia = saldoDia.ToString("R$#,0.00");
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
