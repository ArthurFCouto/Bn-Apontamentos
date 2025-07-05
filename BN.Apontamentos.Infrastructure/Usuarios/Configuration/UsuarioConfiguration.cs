using BN.Apontamentos.Domain.Usuarios.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BN.Apontamentos.Infrastructure.Usuarios.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.IdUsuario)
                .HasColumnName("id_usuario");

            builder.Property(u => u.Nome)
                .HasColumnName("nm_usuario")
                .IsRequired();

            builder.Property(u => u.Matricula)
                .HasColumnName("no_matricula")
                .IsRequired();

            builder.Property(u => u.Senha)
                .HasColumnName("ds_senha")
                .IsRequired();

            builder.Property(u => u.DataInclusao)
                .HasColumnName("dt_data_inclusao");

            builder.Property(u => u.DataModificacao)
                .HasColumnName("dt_data_modificacao");

            builder.Property(u => u.DataInativacao)
                .HasColumnName("dt_data_inativacao");
        }
    }
}
