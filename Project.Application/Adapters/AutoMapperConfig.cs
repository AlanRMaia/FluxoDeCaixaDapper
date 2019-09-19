using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Project.Application.Adapters
{
	public class AutoMapperConfig
	{
		public static void Register()
		{
			//rotina de inicialização do AutoMapper
			Mapper.Initialize(
				map =>
				{
					map.AddProfile<DomainEntityToModel>();
					map.AddProfile<ModelToDomainEntity>();
				}
				);
		}
	}
}
