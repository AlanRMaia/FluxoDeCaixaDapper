using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Services;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;

namespace Project.Domain.Services
{
	public class LancamentoDomainServices :
		BaseDomainServices<Lancamentos>, ILancamentosDomainServices
	{
		private readonly ILancamentosRepository repository;
	

		public LancamentoDomainServices(ILancamentosRepository repository)
			: base(repository)
		{
			this.repository = repository;
			
		}


		public override void Cadastrar(Lancamentos obj)
		{
			if (ConsultaSaldoTotal() <= -20000)
			{
				return;
			}
			else if (ConsultaSaldoTotal() < 0 && ConsultaSaldoTotal() > -20000)
			{
				
				repository.Insert(obj);
				encargos.EncargosDia(obj);
			}

			repository.Insert(obj);

			
			if (ConsultaSaldoTotal() < 0 && ConsultaSaldoTotal() > -20000)
			{

				encargos.EncargosDia(obj);
			}
		}



		public decimal ConsultaSaldoTotal()
		{
			var todos = repository.SelectAll();

			decimal saida = 0;
			decimal entrada = 0;
			decimal saldo;

			foreach (var item in todos)
			{

				if (item.Tipo.Contains("entrada"))
				{
					entrada += item.ValorLancamento;
				}
				else
				{
					saida += item.ValorLancamento;
				}

			}

			saldo = entrada - saida;

			return saldo;

		}

		public decimal ColsultarSaldoDia()
		{
			var timer = DateTime.Now.Date;

			var dia = repository.SelectAllDate(timer);
			decimal saida = 0;
			decimal entrada = 0;
			decimal saldo;

			foreach (var item in dia)
			{

				if (item.Tipo.Contains("entrada"))
				{
					entrada += item.ValorLancamento;
				}
				else
				{
					saida += item.ValorLancamento;
				}

			}

			saldo = entrada - saida;

			return saldo;
		}

		public decimal ColsultarSaldoDiaAnterior()
		{
			var timer = DateTime.Today.AddDays(-1);

			var dia = repository.SelectAllDate(timer);
			decimal saida = 0;
			decimal entrada = 0;
			decimal saldo;

			foreach (var item in dia)
			{

				if (item.Tipo.Contains("entrada"))
				{
					entrada += item.ValorLancamento;
				}
				else
				{
					saida += item.ValorLancamento;
				}

			}

			saldo = entrada - saida;

			return saldo;
		}

		/*public List<Lancamentos> ConsultaLayout(DateTime de, DateTime para)
		{

			var conjuntos = repository.SelectAllDate(de, para);

			var list = new List<Lancamentos>();
			var indice = new Lancamentos();


			foreach (var item in conjuntos)
			{

				indice.Tipo = item.Tipo;
				indice.DataLancamento = item.DataLancamento;
				indice.ValorLancamento = item.ValorLancamento;

				list.Add(indice);
			}

			return list;
		}*/
	}
}
