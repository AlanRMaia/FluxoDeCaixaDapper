using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;
using Project.Domain.Contracts.Repositories;
using System.Linq;
using Dapper;
using System.Data.SqlClient;


namespace Project.Infra.Data.Repositories
{
	public class LancamentosRepository
		: ILancamentosRepository
	{
		private readonly string connectionString;

		public LancamentosRepository(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public List<Lancamentos> SelectAllDate(DateTime of, DateTime to)
		{
			

			var query = "select * from Lancamentos where DataLancamento between @Of and @To";

			using (var conn = new SqlConnection(connectionString))
			{
				return conn.Query<Lancamentos>(query, new { Of = of, To = to }).ToList();
			}
			

		}

		public List<Lancamentos> SelectAllDate(DateTime obj)
		{
			var query = "select * from Lancamentos where DataLancamento = @DataLancamento";

			using (var conn = new SqlConnection(connectionString))
			{
				return conn.Query<Lancamentos>(query, new { DataLancamento = obj}).ToList(); 
			}
		}
		


		public void Insert(Lancamentos obj)
		{
			var query = "insert into Lancamentos(Tipo, Descricao, ContaDestino, BancoDestino, TipoConta, CpfCnpjDestino," +
						" ValorLancamento, DataLancamento, ValorEncargos) "
					  + "values(@Tipo, @Descricao, @ContaDestino, @BancoDestino, @TipoConta, @CpfCnpjDestino, @ValorLancamento, " +
						" @DataLancamento, @ValorEncargos)";

			using (var conn = new SqlConnection(connectionString))
			{
				conn.Execute(query, obj);
			}
		}	


		public void Update(Lancamentos obj)
		{
			var query = "update Lancamentos set Tipo = @Tipo, Descricao = @Descricao, ContaDestino = @ContaDestino, " +
				"BancoDestino = @BancoDestino, TipoConta = @TipoConta, CpfCnpjDestino = @CpfCnpjDestino, " +
				"ValorLancamento = @ValorLancamento, DataLancamento = @DataLancamento, ValorEncargos = @ValorEncargos " +
				"where IdLancamento = @IdLancamento";

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Execute(query, obj);
			}
		}

		public void Delete(Lancamentos obj)
		{
			var query = "delete from Lancamentos where IdLancamento = @IdLancamento ";

			using (var conn = new SqlConnection(connectionString))
			{
				conn.Execute(query, obj);
			}
		}

		public List<Lancamentos> SelectAll()
		{
			var query = "select * from Lancamentos";

			using (var conn = new SqlConnection(connectionString))
			{
				return conn.Query<Lancamentos>(query).ToList();
			}
		}


		public Lancamentos SelectOne(int id)
		{
			var query = "select * from Lancamentos where IdLancamento = @IdLancamento";

			using (var conn = new SqlConnection(connectionString))
			{
				return conn.QuerySingleOrDefault<Lancamentos>(query, new { IdLancamento = id });
			}
		}
		

		public int Count()
		{
			var query = "select count(*) from Lancamentos";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection.QuerySingleOrDefault<int>(query);
			}
		}

		public int Count(DateTime obj)
		{
			var query = "select count(*) from Lancamentos where DataLancamento = @DataLancamento";

			using (var connection = new SqlConnection(connectionString))
			{
				return connection.QuerySingleOrDefault<int>(query, new { DataLancamento = obj});
			};
		}
	}
}
