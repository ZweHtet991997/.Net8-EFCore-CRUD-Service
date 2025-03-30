
namespace AppDbContext;

public partial class EFDbContext : DbContext
{
    public EFDbContext(DbContextOptions<EFDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblEmployee> TblEmployees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblEmployee>(entity =>
        {
            entity.ToTable("Tbl_Employee");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Department)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.EmployeeCode)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.OfficeLocation).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}