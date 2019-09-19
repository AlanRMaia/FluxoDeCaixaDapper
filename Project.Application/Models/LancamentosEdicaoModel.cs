using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Project.Application.Models
{
	public class LancamentosEdicaoModel
	{
		[Required(ErrorMessage = "Campo {0} é obrigatótio.")]
		public int IdLancamento { get; set; }
		[Required(ErrorMessage = "Campo {0} é obrigatório.")]
		public string Tipo { get; set; }
		[Required(ErrorMessage = "Campo {0} é obrigatório.")]
		public string Descricao { get; set; }
		[Required(ErrorMessage = "Campo {0} é obrigatório.")]
		public string ContaDestino { get; set; }
		[Required(ErrorMessage = "Campo {0} é obrigatório.")]
		public string BancoDestino { get; set; }
		[Required(ErrorMessage = "Campo {0} é obrigatório.")]
		public string TipoConta { get; set; }
		[Required(ErrorMessage = "Campo {0} é obrigatório.")]
		public string CpfCnpjDestino { get; set; }
		[Required(ErrorMessage = "Campo {0} é obrigatório.")]
		public decimal ValorLancamento { get; set; }
		[Required(ErrorMessage = "Campo {0} é obrigatório.")]
		public DateTime DataLancamento { get; set; }
	}
}
