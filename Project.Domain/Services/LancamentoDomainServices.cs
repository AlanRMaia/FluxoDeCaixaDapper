using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Services;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using Project.Domain.Class_Utilities;
using Project.Domain.Class_Utilities.Contracts;

namespace Project.Domain.Services
{
	public class LancamentoDomainServices :
		ILancamentosDomainServices
	{
		private readonly ILancamentosRepository repository;
		private readonly IEncargosUtilidades encargosUtilidades;
		private readonly IEncargosDomainServices encargosDomain;

		public LancamentoDomainServices(ILancamentosRepository repository, IEncargosUtilidades encargosUtilidades, IEncargosDomainServices encargosDomain)
		{
			this.repository = repository;

			this.encargosUtilidades = encargosUtilidades;
			this.encargosDomain = encargosDomain;
		}



		public void Cadastrar(Lancamentos obj)
		{
			//método para impedir o cadastro quando o saldo está menor ou igual a -20000
			if (ColsultarSaldoDia() <= -20000)
			{
				throw new ArgumentException("Não é possível cadastrar o lancamento.  Saldo negativo!");
			}
			else if (obj.DataLancamento < DateTime.Now)
			{
				throw new ArgumentException("Data de lancamento não pode ser do dia anterior");
			}
			
			//verificar se o lancamento colocado vai exceder os - 20000, mesmo com o saldo acima de 0 ou 
			//com o desconto do encargo do dia
			var _saldoTotal = ColsultarSaldoDia();
			decimal _saldo = 0;
			if (obj.Tipo.Contains("entrada"))
			{
				_saldo = _saldoTotal + obj.ValorLancamento;
			}
			else
			{
				 _saldo = _saldoTotal - obj.ValorLancamento;
			}
			


			if (_saldo < -20000)
			{
				throw new ArgumentException("Não é possível cadastrar o lancamento. Saldo negativo!");
			}
			else
			{
				repository.Insert(obj);

			}


			//verificar se depois do saldo incluso ele ficou negativo
			if (ColsultarSaldoDia() < 0 && ColsultarSaldoDia() > -20000)
			{
				if (encargosDomain.SelectOne(DateTime.Now) == null)
				{
					encargosUtilidades.EncargosDia(obj);//inclui encargos e o lancamento na tabela lancamento com tipo "saida"
					obj.Tipo = "saida";

					repository.Insert(obj);
				}
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

		
	}
}
