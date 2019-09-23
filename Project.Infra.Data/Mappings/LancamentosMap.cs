using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infra.Data.Mappings
{
	public class LancamentosMap : IEntityTypeConfiguration<Lancamentos>
	{
		public void Configure(EntityTypeBuilder<Lancamentos> builder)
		{
			builder.HasKey(l => new { l.IdLancamento });

			builder.Property(l => l.Tipo)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(l => l.ContaDestino)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(l => l.BancoDestino)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(l => l.TipoConta)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(l => l.CpfCnpjDestino)
				.HasMaxLength(14)
				.IsRequired();

			builder.Property(l => l.ValorLancamento)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(l => l.DataLancamento)
				.HasColumnType("date")
				.IsRequired();

			builder.Property(l => l.ValorEncargos)
				.HasColumnType("decimal(18,2)")
				.IsRequired();


			builder.Property(l => l.Descricao)
				.HasMaxLength(150)
				.IsRequired();
		}
	}
}
