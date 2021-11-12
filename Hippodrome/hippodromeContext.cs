using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Hippodrome
{
    public partial class hippodromeContext : DbContext
    {
        public hippodromeContext()
        {
        }

        public hippodromeContext(DbContextOptions<hippodromeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BettingTable> BettingTables { get; set; }
        public virtual DbSet<ClientTable> ClientTables { get; set; }
        public virtual DbSet<HorseTable> HorseTables { get; set; }
        public virtual DbSet<Logging> Loggings { get; set; }
        public virtual DbSet<MembersRaceTable> MembersRaceTables { get; set; }
        public virtual DbSet<RaceTable> RaceTables { get; set; }
        public virtual DbSet<RiderTable> RiderTables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ViewBetClientHistory> ViewBetClientHistories { get; set; }
        public virtual DbSet<ViewInfoMember> ViewInfoMembers { get; set; }
        public virtual DbSet<ViewRiderHistoryRace> ViewRiderHistoryRaces { get; set; }
        public virtual DbSet<ViewStatisticsHorse> ViewStatisticsHorses { get; set; }
        public virtual DbSet<ViewWinner> ViewWinners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ElizavetaLaptop;Initial Catalog=hippodrome;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<BettingTable>(entity =>
            {
                entity.HasKey(e => e.BetNumber);

                entity.ToTable("Betting_table");

                entity.Property(e => e.BetSum).HasColumnType("money");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.HasOne(d => d.BetHorseNumberNavigation)
                    .WithMany(p => p.BettingTables)
                    .HasForeignKey(d => d.BetHorseNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betting_table_Horse_table");

                entity.HasOne(d => d.BetRaceNumberNavigation)
                    .WithMany(p => p.BettingTables)
                    .HasForeignKey(d => d.BetRaceNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Betting_table_Race_table");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.BettingTables)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Betting_table_Client_table");
            });

            modelBuilder.Entity<ClientTable>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.ToTable("Client_table");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.AccountMoney)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClientBetCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClientMiddleName).HasMaxLength(20);

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.ClientSurname)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.ClientWinCount).HasDefaultValueSql("((0))");

                entity.Property(e => e.ClientWinSum)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12);
            });

            modelBuilder.Entity<HorseTable>(entity =>
            {
                entity.HasKey(e => e.HorseNumber);

                entity.ToTable("Horse_table");

                entity.Property(e => e.Coefficient).HasDefaultValueSql("((0))");

                entity.Property(e => e.HorseColor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HorseName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Logging>(entity =>
            {
                entity.HasKey(e => e.Idaction);

                entity.ToTable("Logging");

                entity.Property(e => e.Idaction).HasColumnName("IDAction");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<MembersRaceTable>(entity =>
            {
                entity.HasKey(e => e.MembersRaceId);

                entity.ToTable("MembersRace_table");

                entity.Property(e => e.MembersRaceId).HasColumnName("MembersRaceID");

                entity.HasOne(d => d.HorseNumberNavigation)
                    .WithMany(p => p.MembersRaceTables)
                    .HasForeignKey(d => d.HorseNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersRace_table_Horse_table");

                entity.HasOne(d => d.RaceNumberNavigation)
                    .WithMany(p => p.MembersRaceTables)
                    .HasForeignKey(d => d.RaceNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersRace_table_Race_table");

                entity.HasOne(d => d.RiderNumberNavigation)
                    .WithMany(p => p.MembersRaceTables)
                    .HasForeignKey(d => d.RiderNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MembersRace_table_Rider_table");
            });

            modelBuilder.Entity<RaceTable>(entity =>
            {
                entity.HasKey(e => e.RaceNumber);

                entity.ToTable("Race_table");

                entity.Property(e => e.RaceDate).HasColumnType("date");
            });

            modelBuilder.Entity<RiderTable>(entity =>
            {
                entity.HasKey(e => e.RiderId);

                entity.ToTable("Rider_table");

                entity.Property(e => e.RiderId).HasColumnName("RiderID");

                entity.Property(e => e.Master)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RiderMiddleName).HasMaxLength(50);

                entity.Property(e => e.RiderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RiderSurname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ClientId)
                    .HasConstraintName("FK_Users_Client_table");
            });

            modelBuilder.Entity<ViewBetClientHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_BetClientHistory");

                entity.Property(e => e.BetSum).HasColumnType("money");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.RaceDate).HasColumnType("date");
            });

            modelBuilder.Entity<ViewInfoMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_InfoMembers");

                entity.Property(e => e.HorseName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Master)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RaceDate).HasColumnType("date");

                entity.Property(e => e.RiderMiddleName).HasMaxLength(50);

                entity.Property(e => e.RiderName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.RiderSurname)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ViewRiderHistoryRace>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_RiderHistoryRace");

                entity.Property(e => e.RaceDate).HasColumnType("date");

                entity.Property(e => e.RiderId).HasColumnName("RiderID");

                entity.Property(e => e.RiderMiddleName).HasMaxLength(892);

                entity.Property(e => e.RiderName)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.RiderSurname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<ViewStatisticsHorse>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_StatisticsHorse");

                entity.Property(e => e.HorseColor)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.HorseName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.RaceDate).HasColumnType("date");
            });

            modelBuilder.Entity<ViewWinner>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Winners");

                entity.Property(e => e.HorseColor)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.HorseName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.RiderMiddleName).HasMaxLength(892);

                entity.Property(e => e.RiderName)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.RiderSurname)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
