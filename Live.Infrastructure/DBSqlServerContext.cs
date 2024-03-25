using Live.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Live.Infrastructure
{
    public partial class DBSqlServerContext: DbContext
    {
        public DBSqlServerContext()
        {
        }

        public DBSqlServerContext(DbContextOptions<DBSqlServerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MyTask<Guid>> Tasks { get; set; }

        public virtual DbSet<TaskType<Guid>> TaskTypes { get; set; }

        public virtual DbSet<User<Guid>> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* 
             * Se realiza un mapeo con el propósito de evitar que la lógica del objeto de valor interfiera con las propiedades definidas en la base de datos. 
             */
            //modelBuilder.Entity<MyTask>().OwnsOne(o => o.TaskName, conf =>
            //{
            //    conf.Property(x => x.Name).HasColumnName("TaskName").HasMaxLength(100);
            //});

            modelBuilder.Entity<MyTask<Guid>>().Ignore(t => t.TaskName);

            modelBuilder.Entity<MyTask<Guid>>(entity =>
            {
                entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949D1492D95B8");

                entity.Property(e => e.TaskId)
                    .ValueGeneratedNever()
                    .HasColumnName("TaskID");
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .HasDefaultValue("Pending");

                entity.OwnsOne(o => o.TaskName, conf =>
                {
                    conf.Property(x => x.Name).HasColumnName("TaskName").HasMaxLength(100);
                });

                // entity.Property(e => e.TaskName).HasMaxLength(100);

                entity.Property(e => e.TaskTypeId).HasColumnName("TaskTypeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.TaskType).WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TaskTypeId)
                    .HasConstraintName("FK__Tasks__TaskTypeI__3D5E1FD2");

                entity.HasOne(d => d.User).WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Tasks__UserID__3C69FB99");
            });


            modelBuilder.Entity<TaskType<Guid>>().Ignore(t => t.TypeName);

            modelBuilder.Entity<TaskType<Guid>>(entity =>
            {
                entity.HasKey(e => e.TaskTypeId).HasName("PK__TaskType__66B23E53D5A98904");

                entity.Property(e => e.TaskTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("TaskTypeID");


                // entity.Property(e => e.TypeName).HasMaxLength(50);

                entity.OwnsOne(o => o.TypeName, conf =>
                {
                    conf.Property(x => x.Name).HasColumnName("TypeName").HasMaxLength(50);
                });
            });

            modelBuilder.Entity<User<Guid>>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC392E5F29");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.UserName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
