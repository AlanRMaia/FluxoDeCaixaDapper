using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Classes_Utilitarias
{
	public interface ISaldo
	{
		decimal ConsultarSaldoTotal();
		decimal ColsultarSaldoDia();
	}
}
