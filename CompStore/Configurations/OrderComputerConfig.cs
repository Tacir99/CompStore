using CompStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompStore.Configurations
{
    public class OrderComputerConfig : IEntityTypeConfiguration<OrderComputer>
    {
        public void Configure(EntityTypeBuilder<OrderComputer> builder)
        {
            builder.HasKey(x => new {x.OredrId, x.ComputerId});
            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrderComputers)
                .HasForeignKey(x => x.OredrId);
            builder.HasOne(x => x.Computer)
                .WithMany(x => x.OrderComputers)
                .HasForeignKey(x => x.ComputerId);
        }
    }
}
