using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;

namespace Project.Domain.Class_Utilities.Contracts
{
	public interface IEncargosUtilidades
	{
		decimal ColsultarSaldoDia();
		decimal ConsultaSaldoTotal();
		
		void EncargosDia(Lancamentos lancamentos);
		
	}
}
