using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Contracts.Repositories;
using Project.Domain.Entities;
using System.Linq;
using System.Data.SqlClient;
using Dapper;

namespace Project.Infra.Data.Repositories
{
	public class EncargosRepository 
		: IEncargosRepository
	{
		private readonly string connectionString;

		public EncargosRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public void Insert(Encargos obj)
		{
			var query = "insert into Encargos(Tipo, Descricao, ContaDestino, BancoDestino, TipoConta, CpfCnpjDestino," +
						" ValorLancamento, DataLancamento, ValorEncargo) "
					  + "values(@Tipo, @Descricao, @ContaDestino, @BancoDestino, @TipoConta, @CpfCnpjDestino, @ValorLancamento," +
						" @DataLancamento, @ValorEncargo)";

			using (var conn = new SqlConnection(connectionString))
			{
				conn.Execute(query, obj);
			}
		}		
		

		public Encargos SelectOne(DateTime obj)
		{

			var query = "select * from Encargos where DataLancamento = @DataLancamento";

			using (var conn = new SqlConnection(connectionString))
			{
				return conn.QuerySingleOrDefault<Encargos>(query, new { DataLancamento = obj });
			}
					
		}

		
	}
}
