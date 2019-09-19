using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Infra.Data.Mappings;

namespace Project.Infra.Data.Context
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> builder)
			:base(builder)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new LancamentosMap());
			modelBuilder.ApplyConfiguration(new EncargosMap());

		}

		public DbSet<Lancamentos> Lancamentos { get; set; }
		public DbSet<Encargos> Encargos { get; set; }

	}
}
