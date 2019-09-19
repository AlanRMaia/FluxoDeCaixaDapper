using System;
using System.Collections.Generic;
using System.Text;
using Project.Application.Models;

namespace Project.Application.Contracts
{
	public interface ILancamentosApplicationServices : IDisposable		
	{
		void Cadastrar(LancamentosCadastroModel model);
		void Atualizar(LancamentosEdicaoModel model);
		void Excluir(int id);

		//List<LancamentosConsultaModel> ConsultarTodos();
		LancamentosConsultaModel ConsultarTodosOsDados();
		LancamentosConsultaModel ConsultarPorId(int id);

	}
}
