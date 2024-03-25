using Live.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;
namespace Live.InfrastructureMongoDB
{
    public class DBMongoContext : DbContext
    {

        public DBMongoContext()
        {
        }

        public DBMongoContext(DbContextOptions options)
          : base(options)
        {
        }
        public DbSet<MyTask<ObjectId>> Tasks { get; init; }

        public virtual DbSet<TaskType<ObjectId>> TaskTypes { get; set; }

        public virtual DbSet<User<ObjectId>> Users { get; set; }

        //public static DBMongoContext Create(IMongoDatabase database) =>
        //    new(new DbContextOptionsBuilder<DBMongoContext>()
        //        .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
        //        .Options);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MyTask<ObjectId>>().ToCollection("tasks");

            modelBuilder.Entity<TaskType<ObjectId>>().ToCollection("taskTypes");

            modelBuilder.Entity<User<ObjectId>>().ToCollection("users");



            //modelBuilder.Entity<MyTask>(entity =>
            //{
            //    entity.HasKey(e => e.TaskId).HasName("PK__Tasks__7C6949D1492D95B8");

            //    entity.Property(e => e.TaskId)
            //        .ValueGeneratedNever()
            //        .HasColumnName("TaskID");
            //    entity.Property(e => e.Status)
            //        .HasMaxLength(20)
            //        .HasDefaultValue("Pending");

            //    entity.OwnsOne(o => o.TaskName, conf =>
            //    {
            //        conf.Property(x => x.Name).HasColumnName("TaskName").HasMaxLength(100);
            //    });

            //    // entity.Property(e => e.TaskName).HasMaxLength(100);

            //    entity.Property(e => e.TaskTypeId).HasColumnName("TaskTypeID");

            //    entity.Property(e => e.UserId).HasColumnName("UserID");

            //    entity.HasOne(d => d.TaskType).WithMany(p => p.Tasks)
            //        .HasForeignKey(d => d.TaskTypeId)
            //        .HasConstraintName("FK__Tasks__TaskTypeI__3D5E1FD2");

            //    entity.HasOne(d => d.User).WithMany(p => p.Tasks)
            //        .HasForeignKey(d => d.UserId)
            //        .HasConstraintName("FK__Tasks__UserID__3C69FB99");
            //});
        }

    }
}
