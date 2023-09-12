using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace JWTEg.Models;

public partial class LoanwfContext : DbContext
{
    public LoanwfContext()
    {
    }

    public LoanwfContext(DbContextOptions<LoanwfContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Logintbl> Logintbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=loanwf;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Accno).HasName("PK__account__A472931DE8810886");

            entity.ToTable("account");

            entity.Property(e => e.Accno).HasColumnName("accno");
            entity.Property(e => e.Actype)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("actype");
            entity.Property(e => e.Custid).HasColumnName("custid");
            entity.Property(e => e.Doc)
                .HasColumnType("date")
                .HasColumnName("doc");

            entity.HasOne(d => d.Cust).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Custid)
                .HasConstraintName("FK__account__custid__25869641");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Customer__D837D05F2C28B508");

            entity.ToTable("Customer");

            entity.Property(e => e.Cid).HasColumnName("cid");
            entity.Property(e => e.Bal).HasColumnName("bal");
            entity.Property(e => e.Cadd)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cadd");
            entity.Property(e => e.Cname)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cname");
            entity.Property(e => e.Doj)
                .HasColumnType("date")
                .HasColumnName("doj");
        });

        modelBuilder.Entity<Logintbl>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__logintbl__F3DBC57397197C57");

            entity.ToTable("logintbl");

            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.IsEmployee).HasColumnName("isEmployee");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
