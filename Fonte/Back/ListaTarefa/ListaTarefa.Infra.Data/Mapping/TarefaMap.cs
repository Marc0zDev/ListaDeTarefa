using ListaTarefa.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefa.Infra.Data.Mapping
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("titulo")
                .HasColumnType("varchar(100)");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnName("descricao")
                .HasColumnType("varchar(500)");

            builder.Property(x => x.DataVencimento)
                .IsRequired()
                .HasColumnName("data_vencimento")
                .HasColumnType("date");

            builder.Property(x => x.Status)
                .HasColumnName("status");
        }
    }
}
