using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.Entities;

namespace Project.Infra.Data.Mappings
{
	public class EncargosMap : IEntityTypeConfiguration<Encargos>
	{
		public void Configure(EntityTypeBuilder<Encargos> builder)
		{
			builder.HasKey(c => new { c.IdEncargo });

			builder.Property(c => c.Tipo)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.ContaDestino)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.BancoDestino)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.TipoConta)
				.HasMaxLength(150)
				.IsRequired();

			builder.Property(c => c.CpfCnpjDestino)
				.HasMaxLength(14)
				.IsRequired();

			builder.Property(c => c.ValorLancamento)
				.HasColumnType("decimal(18,2)")
				.IsRequired();

			builder.Property(c => c.DataLancamento)
				.HasColumnType("date")
				.IsRequired();

			builder.Property(c => c.ValorEncargo)
				.HasColumnType("decimal(18,2)")
				.IsRequired();


			builder.Property(c => c.Descricao)
				.HasMaxLength(150)
				.IsRequired();
		}
	}
}
