using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;
using Project.Domain.Contracts.Services;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Class_Utilities.Contracts;
using Project.Domain.Services;
using System.Threading;

namespace Project.Domain.Class_Utilities
{
	public class EncargosUtilidades : IEncargosUtilidades
	{
		
		
		private readonly IEncargosRepository encargosRepository;
		private readonly ILancamentosRepository lancamentosRepository;



		public EncargosUtilidades( IEncargosRepository encargosRepository, ILancamentosRepository lancamentosRepository)
		{
				
			this.encargosRepository = encargosRepository;
			this.lancamentosRepository = lancamentosRepository;
		}


		public decimal ConsultaSaldoTotal()
		{
			var todos = lancamentosRepository.SelectAll();

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

			var dia = lancamentosRepository.SelectAllDate(timer);
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

		public void EncargosDia(Lancamentos lancamentos)
		{

			Encargos encargos = new Encargos();

			var porcentagem = (double)ColsultarSaldoDia();

			lancamentos.Tipo = "saida";
			lancamentos.ValorLancamento = (decimal)(0.83 * (porcentagem / 100));
		
			lancamentosRepository.Insert(lancamentos);//inclusao do lancamento como saída na tabela "Lancamentos"

			encargos.BancoDestino = lancamentos.BancoDestino;
			encargos.ContaDestino = lancamentos.ContaDestino;
			encargos.CpfCnpjDestino = lancamentos.CpfCnpjDestino;
			encargos.DataLancamento = lancamentos.DataLancamento;
			encargos.Descricao = lancamentos.Descricao;
			encargos.Tipo = lancamentos.Tipo;
			encargos.TipoConta = lancamentos.TipoConta;
			encargos.ValorLancamento = lancamentos.ValorLancamento;


			encargosRepository.Insert(encargos);//inserir o encargo na tabela "Encargos"		



		}

	}
}
