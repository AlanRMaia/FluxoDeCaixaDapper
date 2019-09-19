using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;


namespace Project.Infra.Data.Context
{
	public class DataContextFactory
		: IDesignTimeDbContextFactory<DataContext>
	{
		public DataContext CreateDbContext(string[] args)
		{
			var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBFluxoDeCaixa02;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

			var builder = new DbContextOptionsBuilder<DataContext>();
			builder.UseSqlServer(connectionString);

			return new DataContext(builder.Options);
		}
	}
}
