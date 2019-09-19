using System;
using System.Collections.Generic;
using System.Text;
using Project.Application.Models;
using Project.Domain.Entities;
using AutoMapper;

namespace Project.Application.Adapters
{
	public class ModelToDomainEntity : Profile
	{
		public ModelToDomainEntity()
		{
			CreateMap<LancamentosCadastroModel, Lancamentos>();
			CreateMap<LancamentosEdicaoModel, Lancamentos>();
		}
	}
}
