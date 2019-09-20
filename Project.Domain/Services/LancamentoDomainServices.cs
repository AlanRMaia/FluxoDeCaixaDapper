using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Services;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;

namespace Project.Domain.Services
{
	public class LancamentoDomainServices :
		ILancamentosDomainServices
	{
		private readonly ILancamentosRepository repository;
		EncargosDomainServices encargos;


		public LancamentoDomainServices(ILancamentosRepository repository)
		{
			this.repository = repository;
		
		}

		public LancamentoDomainServices()
		{
		}

		public void Cadastrar(Lancamentos obj)
		{
			//método para impedir o cadastro quando o saldo está negativo igual ou que -20000
			if (ConsultaSaldoTotal() <= -20000)
			{
				return;
			}
			else if (ConsultaSaldoTotal() < 0 && ConsultaSaldoTotal() > -20000)
			{
				//verificar se o lancamento colocado irá exceder os -20000
				//caso sim o lancamento será cancelado
				var saldoTotal = ConsultaSaldoTotal();
				var saldo = saldoTotal - obj.ValorLancamento;

				if (saldo <= -20000)
				{
					return ;
				}
				
				repository.Insert(obj);

				encargos.EncargosDia(obj);//inclui encargos e o lancamento na tabela lancamento com tipo "saida"
			}

			//verificar se o lancamento colocado vai exceder os - 20000, mesmo com o saldo acima de 0
			var _saldoTotal = ConsultaSaldoTotal();
			var _saldo = _saldoTotal - obj.ValorLancamento;

			if (_saldo <= -20000)
			{
				return;
			}

			repository.Insert(obj);

			//verificar se depois do saldo incluso ele ficou negativo
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

		public void Atualizar(Lancamentos model)
		{
			repository.Update(model);
		}

		public void Excluir(Lancamentos id)
		{
		   repository.Delete(id);
		}

		public List<Lancamentos> ConsultarTodosOsLancamentos()
		{
			return repository.SelectAll();
		}

		public Lancamentos ConsultarPorId(int id)
		{
			return repository.SelectOne(id);
		}

		public List<Lancamentos> ConsultarTrintaDias(DateTime of, DateTime to)
		{
			return repository.SelectAllDate(of, to);
		}

		public List<Lancamentos> ConsultarLancamentosDia(DateTime date)
		{
			return repository.SelectAllDate(date);
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
