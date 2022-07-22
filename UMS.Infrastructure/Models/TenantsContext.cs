using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UMS.Infrastructure.Models
{
    public partial class TenantsContext : DbContext
    {
        public TenantsContext()
        {
        }

        public TenantsContext(DbContextOptions<TenantsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tenant> Tenants { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Tenants;Username=postgres;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.Tenant1Id)
                    .HasName("tenants_pk");

                entity.ToTable("Tenants", "Tenants");

                entity.HasIndex(e => e.Tenant1Id, "tenants_tenant_1_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Tenant2Id, "tenants_tenant_2_id_uindex")
                    .IsUnique();

                entity.HasIndex(e => e.Tenant3Id, "tenants_tenant_3_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Tenant1Id)
                    .ValueGeneratedNever()
                    .HasColumnName("Tenant_1_ID");

                entity.Property(e => e.Tenant2Id).HasColumnName("Tenant_2_ID");

                entity.Property(e => e.Tenant3Id).HasColumnName("Tenant_3_ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
