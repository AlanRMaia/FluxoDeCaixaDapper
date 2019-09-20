using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts;
using Project.Domain.Entities;

namespace Project.Domain.Contracts.Services
{
	public interface ILancamentosDomainServices		
	{

		void Cadastrar(Lancamentos model);
		void Atualizar(Lancamentos model);
		void Excluir(Lancamentos id);

		//List<LancamentosConsultaModel> ConsultarTodos();
		List<Lancamentos> ConsultarTodosOsLancamentos();
		List<Lancamentos> ConsultarLancamentosDia(DateTime date);
		List<Lancamentos> ConsultarTrintaDias(DateTime of, DateTime to);
		Lancamentos ConsultarPorId(int id);

		decimal ConsultaSaldoTotal();
		decimal ColsultarSaldoDia();
		decimal ColsultarSaldoDiaAnterior();
		/*List<Lancamentos> ConsultaLayout(DateTime de, DateTime para);*/
	}
}
