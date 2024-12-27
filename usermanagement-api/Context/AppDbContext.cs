using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using usermanagement_api.Models;

namespace usermanagement_api.Context;

public partial class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<accessgroupright> accessgrouprights { get; set; }

    public virtual DbSet<companysitemaster> companysitemasters { get; set; }

    public virtual DbSet<conditionmaster> conditionmasters { get; set; }

    public virtual DbSet<logintracking> logintrackings { get; set; }

    public virtual DbSet<rightmaster> rightmasters { get; set; }

    public virtual DbSet<shiftmaster> shiftmasters { get; set; }

    public virtual DbSet<skillmaster> skillmasters { get; set; }

    public virtual DbSet<useraccessgroupmaster> useraccessgroupmasters { get; set; }

    public virtual DbSet<usercompanysite> usercompanysites { get; set; }

    public virtual DbSet<usermaster> usermasters { get; set; }

    public virtual DbSet<userskill> userskills { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<accessgroupright>(entity =>
        {
            entity.HasKey(e => e.accessgrouprightid).HasName("accessgroupright_pkey");

            entity.ToTable("accessgroupright");

            entity.Property(e => e.accessgrouprightid).ValueGeneratedNever();
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.updatedby).HasMaxLength(128);

            entity.HasOne(d => d.conditionmaster).WithMany(p => p.accessgrouprights)
                .HasForeignKey(d => d.conditionmasterid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_condition_master");

            entity.HasOne(d => d.rightmaster).WithMany(p => p.accessgrouprights)
                .HasForeignKey(d => d.rightmasterid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_right_master");

            entity.HasOne(d => d.useraccessgroup).WithMany(p => p.accessgrouprights)
                .HasForeignKey(d => d.useraccessgroupid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_access_group");
        });

        modelBuilder.Entity<companysitemaster>(entity =>
        {
            entity.HasKey(e => e.companysitemasterid).HasName("companysitemaster_pkey");

            entity.ToTable("companysitemaster");

            entity.Property(e => e.companysitemasterid).ValueGeneratedNever();
            entity.Property(e => e.active).HasDefaultValue(true);
            entity.Property(e => e.companycode).HasMaxLength(50);
            entity.Property(e => e.companyname).HasMaxLength(255);
            entity.Property(e => e.companysite).HasMaxLength(255);
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.sitecode).HasMaxLength(50);
            entity.Property(e => e.sitename).HasMaxLength(255);
            entity.Property(e => e.updatedby).HasMaxLength(128);
        });

        modelBuilder.Entity<conditionmaster>(entity =>
        {
            entity.HasKey(e => e.conditionmasterid).HasName("conditionmaster_pkey");

            entity.ToTable("conditionmaster");

            entity.Property(e => e.conditionmasterid).ValueGeneratedNever();
            entity.Property(e => e.appliestoobject).HasMaxLength(255);
            entity.Property(e => e.conditionname).HasMaxLength(255);
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.updatedby).HasMaxLength(128);
        });

        modelBuilder.Entity<logintracking>(entity =>
        {
            entity.HasKey(e => e.logintrackingid).HasName("logintracking_pkey");

            entity.ToTable("logintracking");

            entity.Property(e => e.logintrackingid).ValueGeneratedNever();
            entity.Property(e => e.loginresult).HasMaxLength(512);
            entity.Property(e => e.logintriedip).HasMaxLength(50);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.username).HasMaxLength(50);

            entity.HasOne(d => d.profile).WithMany(p => p.logintrackings)
                .HasForeignKey(d => d.profileid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_profile");
        });

        modelBuilder.Entity<rightmaster>(entity =>
        {
            entity.HasKey(e => e.rightmasterid).HasName("rightmaster_pkey");

            entity.ToTable("rightmaster");

            entity.Property(e => e.rightmasterid).ValueGeneratedNever();
            entity.Property(e => e.companycode).HasMaxLength(50);
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.description).HasMaxLength(100);
            entity.Property(e => e.platform).HasMaxLength(255);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rightname).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.sitecode).HasMaxLength(50);
            entity.Property(e => e.updatedby).HasMaxLength(128);
        });

        modelBuilder.Entity<shiftmaster>(entity =>
        {
            entity.HasKey(e => e.shiftmasterid).HasName("shiftmaster_pkey");

            entity.ToTable("shiftmaster");

            entity.Property(e => e.shiftmasterid).ValueGeneratedNever();
            entity.Property(e => e.companycode).HasMaxLength(50);
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.shiftname).HasMaxLength(100);
            entity.Property(e => e.sitecode).HasMaxLength(50);
            entity.Property(e => e.status).HasMaxLength(20);
            entity.Property(e => e.updatedby).HasMaxLength(128);
        });

        modelBuilder.Entity<skillmaster>(entity =>
        {
            entity.HasKey(e => e.skillmasterid).HasName("skillmaster_pkey");

            entity.ToTable("skillmaster");

            entity.Property(e => e.skillmasterid).ValueGeneratedNever();
            entity.Property(e => e.companycode).HasMaxLength(50);
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.description).HasMaxLength(100);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.sitecode).HasMaxLength(50);
            entity.Property(e => e.skillname).HasMaxLength(255);
            entity.Property(e => e.updatedby).HasMaxLength(128);
        });

        modelBuilder.Entity<useraccessgroupmaster>(entity =>
        {
            entity.HasKey(e => e.useraccessgroupid).HasName("useraccessgroupmaster_pkey");

            entity.ToTable("useraccessgroupmaster");

            entity.Property(e => e.useraccessgroupid).ValueGeneratedNever();
            entity.Property(e => e.accessgroupname).HasMaxLength(128);
            entity.Property(e => e.createdby).HasMaxLength(20);
            entity.Property(e => e.description).HasMaxLength(100);
            entity.Property(e => e.rcreate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.updatedby).HasMaxLength(20);
        });

        modelBuilder.Entity<usercompanysite>(entity =>
        {
            entity.HasKey(e => e.usercompanysiteid).HasName("usercompanysite_pkey");

            entity.ToTable("usercompanysite");

            entity.Property(e => e.usercompanysiteid).ValueGeneratedNever();
            entity.Property(e => e.companycode).HasMaxLength(50);
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.sitecode).HasMaxLength(50);
            entity.Property(e => e.updatedby).HasMaxLength(128);

            entity.HasOne(d => d.user).WithMany(p => p.usercompanysites)
                .HasForeignKey(d => d.userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        });

        modelBuilder.Entity<usermaster>(entity =>
        {
            entity.HasKey(e => e.profileid).HasName("usermaster_pkey");

            entity.ToTable("usermaster");

            entity.Property(e => e.profileid).ValueGeneratedNever();
            entity.Property(e => e.addressline1).HasMaxLength(20);
            entity.Property(e => e.addressline2).HasMaxLength(20);
            entity.Property(e => e.addressline3).HasMaxLength(20);
            entity.Property(e => e.city).HasMaxLength(20);
            entity.Property(e => e.contactno).HasMaxLength(20);
            entity.Property(e => e.contactno1).HasMaxLength(20);
            entity.Property(e => e.country).HasMaxLength(20);
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.displayname).HasMaxLength(100);
            entity.Property(e => e.district).HasMaxLength(20);
            entity.Property(e => e.emailid).HasMaxLength(100);
            entity.Property(e => e.firstname).HasMaxLength(50);
            entity.Property(e => e.lastname).HasMaxLength(50);
            entity.Property(e => e.managername).HasMaxLength(100);
            entity.Property(e => e.mfatoken).HasMaxLength(20);
            entity.Property(e => e.middlename).HasMaxLength(50);
            entity.Property(e => e.password).HasMaxLength(100);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.state).HasMaxLength(20);
            entity.Property(e => e.town).HasMaxLength(20);
            entity.Property(e => e.updateby).HasMaxLength(128);
            entity.Property(e => e.username).HasMaxLength(50);
            entity.Property(e => e.zipcode).HasMaxLength(20);

            entity.HasOne(d => d.manager).WithMany(p => p.Inversemanager)
                .HasForeignKey(d => d.managerid)
                .HasConstraintName("fk_manager");
        });

        modelBuilder.Entity<userskill>(entity =>
        {
            entity.HasKey(e => e.userskillid).HasName("userskill_pkey");

            entity.ToTable("userskill");

            entity.Property(e => e.userskillid).ValueGeneratedNever();
            entity.Property(e => e.createdby).HasMaxLength(128);
            entity.Property(e => e.rcreate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.revent).HasMaxLength(255);
            entity.Property(e => e.rupdate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(e => e.updatedby).HasMaxLength(128);

            entity.HasOne(d => d.skillmaster).WithMany(p => p.userskills)
                .HasForeignKey(d => d.skillmasterid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_skill_master");

            entity.HasOne(d => d.user).WithMany(p => p.userskills)
                .HasForeignKey(d => d.userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
