﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Project.Application.Contracts;
using Project.Application.Services;
using Project.Domain.Contracts.Services;
using Project.Domain.Services;
using Project.Infra.Data.Repositories;
using Project.Domain.Contracts.Repositories;
using Project.Application.Adapters;
using Project.Domain.Class_Utilities.Contracts;
using Project.Domain.Class_Utilities;
using System.Threading;

namespace Project.Presentation.Api
{
	public class Startup
	{
		
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;			
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			//ler a string de conexão contida no arquivo appsettings.json
			var connectionString = Configuration.GetConnectionString("Conexao");

			//mapeamento da injeção de dependência		

			#region Configuração para Injeção de Dependência

			//camada de aplicação
			services.AddTransient<ILancamentosApplicationServices, LancamentosApplicationServices>();

			//camada de dominio
			services.AddTransient<ILancamentosDomainServices, LancamentoDomainServices>();
			services.AddTransient<IEncargosDomainServices, EncargosDomainServices>();
			services.AddTransient<IEncargosUtilidades, EncargosUtilidades>();

			//camada de infra estrutura do repositorio
			services.AddTransient<ILancamentosRepository, LancamentosRepository>
				(s => new LancamentosRepository(connectionString)); 
			services.AddTransient<IEncargosRepository, EncargosRepository>
				(s => new EncargosRepository(connectionString));
			

			#endregion


			#region Configuracão do AutoMapper
			AutoMapperConfig.Register(); 
			#endregion


			#region Configuração layout Swagger

			services.AddSwaggerGen(
					swagger =>
					{
						swagger.SwaggerDoc("v1",
							new Info
							{
								Title = "Sistema de Fluxo de Caixa",
								Version = "v1",
								Description = "Projeto desenvolvido por Alan Maia",
								Contact = new Contact
								{
									Name = " Alan Rodrigues Maia",
									Email = "alanr.maia@hotmail.com"

								}
							});
					}
				);
			#endregion


			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			#region Configuração do Swagger
			app.UseSwagger(); //definindo o uso do Swagger para o projeto
			app.UseSwaggerUI(
			swagger =>
			{
				swagger.SwaggerEndpoint
				("/swagger/v1/swagger.json", "Projeto");
			}
			); 
			#endregion


			app.UseMvc();
		}
	}
}
