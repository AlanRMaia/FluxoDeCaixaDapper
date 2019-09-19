using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Application.Models
{
	public class LancamentosConsultaModel
	{
		public string Tipo { get; set; }
		public DateTime DataLancamento { get; set; }
		public decimal ValorLancamento { get; set; }
	}
}
