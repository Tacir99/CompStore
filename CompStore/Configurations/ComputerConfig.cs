using CompStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompStore.Configurations
{
    public class ComputerConfig : IEntityTypeConfiguration<Computer>
    {
        public void Configure(EntityTypeBuilder<Computer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MarkName)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
            builder.HasOne(x => x.Detail)
                .WithMany(x => x.Computers)
                .HasForeignKey(x => x.DetailId);
        }
    }
}
