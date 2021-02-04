using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TAMAGOTCHI.Models
{
    public partial class TamagotchiContext : DbContext
    {
        public TamagotchiContext()
        {
        }

        public TamagotchiContext(DbContextOptions<TamagotchiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActionOption> ActionOptions { get; set; }
        public virtual DbSet<ActionType> ActionTypes { get; set; }
        public virtual DbSet<History> Histories { get; set; }
        public virtual DbSet<LifeCycle> LifeCycles { get; set; }
        public virtual DbSet<LifeStatus> LifeStatuses { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = localhost\\SQLEXPRESS03; Database=Tamagotchi;  Trusted_Connection=true; MultipleActiveResultSets=true; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionOption>(entity =>
            {
                entity.HasKey(e => e.OptionId)
                    .HasName("PK__ActionOp__92C7A1DF83F06323");

                entity.HasOne(d => d.ActionType)
                    .WithMany(p => p.ActionOptions)
                    .HasForeignKey(d => d.ActionTypeId)
                    .HasConstraintName("FK_ActionTypeID");
            });

            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => new { e.PetId, e.TimeOfAction })
                    .HasName("PK__History__356F3D1653203104");

                entity.HasOne(d => d.LifeCycle)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.LifeCycleId)
                    .HasConstraintName("FK_HistoryLifeCycleID");

                entity.HasOne(d => d.LifeStatus)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.LifeStatusId)
                    .HasConstraintName("FK_HistoryLifeStatusID");

                entity.HasOne(d => d.Option)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.OptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryOptionID");

                entity.HasOne(d => d.Pet)
                    .WithMany(p => p.Histories)
                    .HasForeignKey(d => d.PetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryPetID");
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasOne(d => d.LifeCycle)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.LifeCycleId)
                    .HasConstraintName("FK_PetLifeCycleID");

                entity.HasOne(d => d.LifeStatus)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.LifeStatusId)
                    .HasConstraintName("FK_PetLifeStatusID");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK_PlayerID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
