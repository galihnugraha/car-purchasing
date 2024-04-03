﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarPurchasing_DAL.Models;

public partial class CarpurchasingContext : DbContext
{
    public CarpurchasingContext()
    {
    }

    public CarpurchasingContext(DbContextOptions<CarpurchasingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MstBrand> MstBrands { get; set; }

    public virtual DbSet<MstCar> MstCars { get; set; }

    public virtual DbSet<MstCustomer> MstCustomers { get; set; }

    public virtual DbSet<MstModel> MstModels { get; set; }

    public virtual DbSet<MstSale> MstSales { get; set; }

    public virtual DbSet<MstType> MstTypes { get; set; }

    public virtual DbSet<MstUsage> MstUsages { get; set; }

    public virtual DbSet<MstUser> MstUsers { get; set; }

    public virtual DbSet<TrnCarPurchase> TrnCarPurchases { get; set; }

    public virtual DbSet<VwBrand> VwBrands { get; set; }

    public virtual DbSet<VwCar> VwCars { get; set; }

    public virtual DbSet<VwCustomer> VwCustomers { get; set; }

    public virtual DbSet<VwModel> VwModels { get; set; }

    public virtual DbSet<VwSale> VwSales { get; set; }

    public virtual DbSet<VwTagihan> VwTagihans { get; set; }

    public virtual DbSet<VwType> VwTypes { get; set; }

    public virtual DbSet<VwUsage> VwUsages { get; set; }

    public virtual DbSet<VwUser> VwUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MstBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MST_BRAND_pkey");

            entity.ToTable("MST_BRAND");

            entity.HasIndex(e => e.Name, "MST_BRAND_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasColumnType("character varying")
                .HasColumnName("country");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<MstCar>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MST_CAR_pkey");

            entity.ToTable("MST_CAR");

            entity.HasIndex(e => e.CdChassis, "MST_CAR_cd_chassis_key").IsUnique();

            entity.HasIndex(e => e.CdEngine, "MST_CAR_cd_engine_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.CdChassis)
                .HasColumnType("character varying")
                .HasColumnName("cd_chassis");
            entity.Property(e => e.CdEngine)
                .HasColumnType("character varying")
                .HasColumnName("cd_engine");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.EngineSize).HasColumnName("engine_size");
            entity.Property(e => e.FuelType)
                .HasColumnType("character varying")
                .HasColumnName("fuel_type");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.ManufactureYear).HasColumnName("manufacture_year");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.UsageId).HasColumnName("usage_id");

            entity.HasOne(d => d.Brand).WithMany(p => p.MstCars)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("MST_CAR_brand_id_fkey");

            entity.HasOne(d => d.Model).WithMany(p => p.MstCars)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("MST_CAR_model_id_fkey");

            entity.HasOne(d => d.Type).WithMany(p => p.MstCars)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("MST_CAR_type_id_fkey");

            entity.HasOne(d => d.Usage).WithMany(p => p.MstCars)
                .HasForeignKey(d => d.UsageId)
                .HasConstraintName("MST_CAR_usage_id_fkey");
        });

        modelBuilder.Entity<MstCustomer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MST_CUSTOMER_pkey");

            entity.ToTable("MST_CUSTOMER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasColumnType("character varying")
                .HasColumnName("gender");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Occupancy)
                .HasColumnType("character varying")
                .HasColumnName("occupancy");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<MstModel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MST_MODEL_pkey");

            entity.ToTable("MST_MODEL");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BrandId).HasColumnName("brand_id");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.HasOne(d => d.Brand).WithMany(p => p.MstModels)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("MST_MODEL_brand_id_fkey");
        });

        modelBuilder.Entity<MstSale>(entity =>
        {
            entity.HasKey(e => e.IdSales).HasName("MST_SALES_pkey");

            entity.ToTable("MST_SALES");

            entity.Property(e => e.IdSales)
                .ValueGeneratedNever()
                .HasColumnName("id_sales");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.JumlahPenjualan).HasColumnName("jumlah_penjualan");
            entity.Property(e => e.Komisi).HasColumnName("komisi");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<MstType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MST_TYPE_pkey");

            entity.ToTable("MST_TYPE");

            entity.HasIndex(e => e.Name, "MST_TYPE_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<MstUsage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MST_USAGE_pkey");

            entity.ToTable("MST_USAGE");

            entity.HasIndex(e => e.Name, "MST_USAGE_name_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<MstUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("MST_USER_pkey");

            entity.ToTable("MST_USER");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.IdSales).HasColumnName("id_sales");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");

            entity.HasOne(d => d.IdSalesNavigation).WithMany(p => p.MstUsers)
                .HasForeignKey(d => d.IdSales)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("MST_USER_id_sales_fkey");
        });

        modelBuilder.Entity<TrnCarPurchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TRN_CAR_PURCHASE_pkey");

            entity.ToTable("TRN_CAR_PURCHASE");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.DownPayment).HasColumnName("down_payment");
            entity.Property(e => e.DtAdded)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_added");
            entity.Property(e => e.DtUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("dt_updated");
            entity.Property(e => e.IdUserAdded).HasColumnName("id_user_added");
            entity.Property(e => e.IdUserUpdated).HasColumnName("id_user_updated");
            entity.Property(e => e.PaymentStatus)
                .HasColumnType("character varying")
                .HasColumnName("payment_status");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Tax).HasColumnName("tax");
            entity.Property(e => e.Tenor).HasColumnName("tenor");

            entity.HasOne(d => d.Car).WithMany(p => p.TrnCarPurchases)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("TRN_CAR_PURCHASE_car_id_fkey");

            entity.HasOne(d => d.Cust).WithMany(p => p.TrnCarPurchases)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("TRN_CAR_PURCHASE_cust_id_fkey");
        });

        modelBuilder.Entity<VwBrand>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_brand");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasColumnType("character varying")
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<VwCar>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_car");

            entity.Property(e => e.CdChassis)
                .HasColumnType("character varying")
                .HasColumnName("cd_chassis");
            entity.Property(e => e.CdEngine)
                .HasColumnType("character varying")
                .HasColumnName("cd_engine");
            entity.Property(e => e.EngineSize).HasColumnName("engine_size");
            entity.Property(e => e.FuelType)
                .HasColumnType("character varying")
                .HasColumnName("fuel_type");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ManufactureYear).HasColumnName("manufacture_year");
            entity.Property(e => e.NamaBrand)
                .HasColumnType("character varying")
                .HasColumnName("nama_brand");
            entity.Property(e => e.NamaModel)
                .HasColumnType("character varying")
                .HasColumnName("nama_model");
            entity.Property(e => e.NamaType)
                .HasColumnType("character varying")
                .HasColumnName("nama_type");
            entity.Property(e => e.NamaUsage)
                .HasColumnType("character varying")
                .HasColumnName("nama_usage");
        });

        modelBuilder.Entity<VwCustomer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_customer");

            entity.Property(e => e.Id)
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasColumnType("character varying")
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Occupancy)
                .HasColumnType("character varying")
                .HasColumnName("occupancy");
            entity.Property(e => e.Salary).HasColumnName("salary");
        });

        modelBuilder.Entity<VwModel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_model");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NamaBrand)
                .HasColumnType("character varying")
                .HasColumnName("nama_brand");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<VwSale>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_sales");

            entity.Property(e => e.JumlahPenjualan).HasColumnName("jumlah_penjualan");
            entity.Property(e => e.Komisi).HasColumnName("komisi");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<VwTagihan>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_tagihan");

            entity.Property(e => e.CarId).HasColumnName("car_id");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.DownPayment).HasColumnName("down_payment");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NamaBrand)
                .HasColumnType("character varying")
                .HasColumnName("nama_brand");
            entity.Property(e => e.NamaCust)
                .HasColumnType("character varying")
                .HasColumnName("nama_cust");
            entity.Property(e => e.NamaModel)
                .HasColumnType("character varying")
                .HasColumnName("nama_model");
            entity.Property(e => e.PaymentStatus)
                .HasColumnType("character varying")
                .HasColumnName("payment_status");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Tax).HasColumnName("tax");
            entity.Property(e => e.Tenor).HasColumnName("tenor");
        });

        modelBuilder.Entity<VwType>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<VwUsage>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_usage");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<VwUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_user");

            entity.Property(e => e.NamaSales)
                .HasColumnType("character varying")
                .HasColumnName("nama_sales");
            entity.Property(e => e.Status)
                .HasColumnType("character varying")
                .HasColumnName("status");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
