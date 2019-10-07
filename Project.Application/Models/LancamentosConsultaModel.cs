using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;

namespace Project.Application.Models
{
	public class LancamentosConsultaModel
	{

		public string DiaConsulta { get; set; }
		public List<FormatoJson> LancamentosDoDia { get; set; }
		public string SaldoTotalDoDia { get; set; }
		public string ComparacaoDiaAnterior { get; set; }
		public List<FormatoJson> TrintaDiasSeguintes { get; set; }


		
	}
}
