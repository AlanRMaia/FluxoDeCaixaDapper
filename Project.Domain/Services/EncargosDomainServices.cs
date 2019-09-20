using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Contracts.Services;
using Project.Domain.Services;
using Project.Domain.Entities;

namespace Project.Domain.Services
{
	public class EncargosDomainServices 
		: IEncargosDomainServices
	{
		private readonly IEncargosRepository repository;
		LancamentoDomainServices lancamentosDomain;

		public EncargosDomainServices(IEncargosRepository repository)
		{
			this.repository = repository;
			
		}

		public EncargosDomainServices()
		{
		}

		//método para incluir o encargo que é acionado ao descobir que cadastrar o lancamento
		//o saldo ficou abaixo de zero
		public void EncargosDia(Lancamentos lancamentos)
		{

			Encargos encargos = new Encargos();

			var porcentagem = (double)lancamentosDomain.ConsultaSaldoTotal();

			lancamentos.Tipo = "saida";
			lancamentos.ValorLancamento = (decimal)(0.83 * (porcentagem / 100));
			
			lancamentosDomain.Cadastrar(lancamentos);//inclusao do lancamento como saída na tabela "Lancamentos"

			encargos.BancoDestino = lancamentos.BancoDestino;
			encargos.ContaDestino = lancamentos.ContaDestino;
			encargos.CpfCnpjDestino = lancamentos.CpfCnpjDestino;
			encargos.DataLancamento = lancamentos.DataLancamento;
			encargos.Descricao = lancamentos.Descricao;
			encargos.Tipo = lancamentos.Tipo;
			encargos.TipoConta = lancamentos.TipoConta;
			encargos.ValorLancamento = lancamentos.ValorLancamento;


			repository.Insert(encargos);//inserir o encargo na tabela "Encargos"

			Encargos list;
			//rotina 24hs para verificar se o o saldo ainda está menor do que 0
			do
			{

				Thread.Sleep(TimeSpan.FromHours(24));

				if (lancamentosDomain.ConsultaSaldoTotal() >= 0)
				{
					var id = repository.SelectOne(1);
					repository.Delete(id);
				}

				list = repository.SelectOne(1);  

			} while (list == null);



		}

		public void Insert(Encargos obj)
		{
			repository.Insert(obj);
		}

		public void Delete(Encargos obj)
		{
			repository.Delete(obj);
		}
	}
}
