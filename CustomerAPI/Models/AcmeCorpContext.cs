using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Models;

public partial class AcmeCorpContext : DbContext
{
    public AcmeCorpContext()
    {
    }

    public AcmeCorpContext(DbContextOptions<AcmeCorpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressInfo> AddressInfos { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerOrderInfo> CustomerOrderInfos { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<State> States { get; set; }

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Server=LAPTOP-H8N7AGSM\\SQL2019EXPRESS;Database=AcmeCorp;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AddressInfo>(entity =>
        {
            entity.ToTable("AddressInfo");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AptmntOrUnitNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StreetAddress2).HasMaxLength(100);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.State).WithMany(p => p.AddressInfos)
                .HasForeignKey(d => d.StateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AddressInfo_State");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);            

            entity.HasOne(d => d.BillingAddress).WithMany(p => p.CustomerBillingAddresses)
                .HasForeignKey(d => d.BillingAddressId)
                .HasConstraintName("FK_Customer_BillingAddressInfo");

            entity.HasOne(d => d.MailingAddress).WithMany(p => p.CustomerMailingAddresses)
                .HasForeignKey(d => d.MailingAddressId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Customer_MailingAddressInfo");
        });

        modelBuilder.Entity<CustomerOrderInfo>(entity =>
        {
            entity.ToTable("CustomerOrderInfo");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Count).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerOrderInfos)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerOrderInfo_Customer");

            //entity.HasOne(d => d.Product).WithMany(p => p.CustomerOrderInfos)
            //    .HasForeignKey(d => d.ProductId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_CustomerOrderInfo_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Cost).HasColumnType("numeric(18, 3)");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.ToTable("State");

            entity.Property(e => e.Code)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
