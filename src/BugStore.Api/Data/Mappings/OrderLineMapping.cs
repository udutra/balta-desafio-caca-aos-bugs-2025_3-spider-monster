using BugStore.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BugStore.Api.Data.Mappings;

public class OrderLineMapping: IEntityTypeConfiguration<OrderLine>{
    public void Configure(EntityTypeBuilder<OrderLine> builder){
        builder.ToTable("OrderLines");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Quantity)
            .IsRequired()
            .HasColumnType("INTEGER");

        builder.Property(x => x.Total)
            .IsRequired()
            .HasColumnType("DECIMAL(18,2)");

        builder.Property(x => x.ProductId)
            .IsRequired()
            .HasColumnType("TEXT")
            .HasMaxLength(160);

        builder.HasIndex(x => x.ProductId);

        builder.HasOne(x => x.Order)
            .WithMany()
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        builder.HasOne(x => x.Product)
            .WithMany()
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}