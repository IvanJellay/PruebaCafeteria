using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Cafeteria.Models;

public partial class DbCafeteriaContext : DbContext
{
    public DbCafeteriaContext()
    {
    }

    public DbCafeteriaContext(DbContextOptions<DbCafeteriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbHccAlmacen> TbHccAlmacens { get; set; }

    public virtual DbSet<TbHccCatEstatusOrden> TbHccCatEstatusOrdens { get; set; }

    public virtual DbSet<TbHccMesas> TbHccMesas { get; set; }

    public virtual DbSet<TbHccOrdenes> TbHccOrdenes { get; set; }

    public virtual DbSet<TbHccOrdenesDetalle> TbHccOrdenesDetalles { get; set; }

    public virtual DbSet<TbHccProductos> TbHccProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbHccAlmacen>(entity =>
        {
            entity.HasKey(e => e.AlmId).HasName("PK__Tb_HccAl__827601FCBFDCB1AF");

            entity.ToTable("Tb_HccAlmacen");

            entity.Property(e => e.AlmId)
                .ValueGeneratedNever()
                .HasColumnName("alm_id");
            entity.Property(e => e.AlmCantidad).HasColumnName("alm_cantidad");
            entity.Property(e => e.AlmEstatus).HasColumnName("alm_estatus");
            entity.Property(e => e.AlmFechaActualizacion).HasColumnName("alm_fecha_actualizacion");
        });

        modelBuilder.Entity<TbHccCatEstatusOrden>(entity =>
        {
            entity.HasKey(e => e.CatordId).HasName("PK__Tb_HccCa__83E92BB395AB79BE");

            entity.ToTable("Tb_HccCatEstatusOrden");

            entity.Property(e => e.CatordId)
                .ValueGeneratedNever()
                .HasColumnName("catord_id");
            entity.Property(e => e.CatordEstatus).HasColumnName("catord_estatus");
            entity.Property(e => e.CatordNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("catord_nombre");
        });

        modelBuilder.Entity<TbHccMesas>(entity =>
        {
            entity.HasKey(e => e.MesId).HasName("PK__Tb_HccMe__86A20DC326BABF4D");

            entity.ToTable("Tb_HccMesas");

            entity.Property(e => e.MesId)
                .ValueGeneratedNever()
                .HasColumnName("mes_id");
            entity.Property(e => e.MesDisponible).HasColumnName("mes_disponible");
            entity.Property(e => e.MesEstatus).HasColumnName("mes_estatus");
            entity.Property(e => e.MesLugares).HasColumnName("mes_lugares");
        });

        modelBuilder.Entity<TbHccOrdenes>(entity =>
        {
            entity.HasKey(e => e.OrdId).HasName("PK__Tb_HccOr__DC39D7DFA72CAA29");

            entity.ToTable("Tb_HccOrdenes");

            entity.Property(e => e.OrdId)
                .ValueGeneratedNever()
                .HasColumnName("ord_id");
            entity.Property(e => e.CatordId).HasColumnName("catord_id");
            entity.Property(e => e.MesId).HasColumnName("mes_id");
            entity.Property(e => e.OrdEstatus).HasColumnName("ord_estatus");
            entity.Property(e => e.OrdFechaInicio).HasColumnName("ord_fecha_inicio");

            entity.HasOne(d => d.Catord).WithMany(p => p.TbHccOrdenes)
                .HasForeignKey(d => d.CatordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tb_HccOrd__cator__49C3F6B7");

            entity.HasOne(d => d.Mes).WithMany(p => p.TbHccOrdenes)
                .HasForeignKey(d => d.MesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tb_HccOrd__mes_i__48CFD27E");
        });

        modelBuilder.Entity<TbHccOrdenesDetalle>(entity =>
        {
            entity.HasKey(e => e.OrddetId).HasName("PK__Tb_HccOr__9BFA4D2F77DA1BE0");

            entity.ToTable("Tb_HccOrdenesDetalle");

            entity.Property(e => e.OrddetId)
                .ValueGeneratedNever()
                .HasColumnName("orddet_id");
            entity.Property(e => e.OrdId).HasColumnName("ord_id");
            entity.Property(e => e.OrddetCantidad).HasColumnName("orddet_cantidad");
            entity.Property(e => e.OrddetEstatus).HasColumnName("orddet_estatus");
            entity.Property(e => e.ProId).HasColumnName("pro_id");

            entity.HasOne(d => d.Ordenes).WithMany(p => p.TbHccOrdenesDetalles)
                .HasForeignKey(d => d.OrdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tb_HccOrd__ord_i__4CA06362");

            entity.HasOne(d => d.Productos).WithMany(p => p.TbHccOrdenesDetalles)
                .HasForeignKey(d => d.ProId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tb_HccOrd__pro_i__4D94879B");
        });

        modelBuilder.Entity<TbHccProductos>(entity =>
        {
            entity.HasKey(e => e.ProId).HasName("PK__Tb_HccPr__335E4CA6EC746989");

            entity.ToTable("Tb_HccProductos");

            entity.Property(e => e.ProId)
                .ValueGeneratedNever()
                .HasColumnName("pro_id");
            entity.Property(e => e.AlmId).HasColumnName("alm_id");
            entity.Property(e => e.ProDescripcion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("pro_descripcion");
            entity.Property(e => e.ProEstatus).HasColumnName("pro_estatus");
            entity.Property(e => e.ProNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pro_nombre");
            entity.Property(e => e.ProPrecio)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("pro_precio");

            entity.HasOne(d => d.Alm).WithMany(p => p.TbHccProductos)
                .HasForeignKey(d => d.AlmId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Tb_HccPro__alm_i__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
