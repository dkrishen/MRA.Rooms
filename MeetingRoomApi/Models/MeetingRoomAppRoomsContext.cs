using Microsoft.EntityFrameworkCore;

namespace MeetingRoomApi.Models
{
    public partial class MeetingRoomAppRoomsContext : DbContext
    {
        public MeetingRoomAppRoomsContext()
        {
        }

        public MeetingRoomAppRoomsContext(DbContextOptions<MeetingRoomAppRoomsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-6PJL0PD;Database=MeetingRoomAppRooms;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
