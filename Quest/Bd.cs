
using Microsoft.EntityFrameworkCore;

using Classes;

namespace Bd
{
    public class AppDbContext : DbContext
    {
        public DbSet<BasicChoise> DbBasicChoises { get; set; }
        public DbSet<CoolChoise> DbCoolChoises { get; set; }
        public DbSet<TimelimitedChoise> DbTimelimitedChoises { get; set; }
        public DbSet<RandomChoise> DbRandomChoises { get; set; }
        public DbSet<StrangeChoise> DbStrangeChoises { get; set; }
        public DbSet<EndMessage> DbEndMessages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Use a dedicated database name instead of 'postgres'
            optionsBuilder.UseNpgsql("Host=localhost;Database=QuestDB;Username=postgres;Password=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choise>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever(); // Add this line

                entity.Property(e => e.ChoisesId)
                    .HasColumnType("integer[]");

                entity.Property(e => e.ChoisesText)
                    .HasColumnType("text[]");
            });
        }

        public void CreateDb()
        {
            var context = new AppDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 0,
                    Text = "Вы проспаетесь в автобусе, ваши действия:",
                    ChoisesId = new int[] { 1, 2, 3 },
                    ChoisesText = new string[]
                    {
                        "Остановить автобус",
                        "Заорать на весь автобус",
                        "Продолжить спать"
                    }
                }
            );
            context.DbBasicChoises.AddRange(
                new BasicChoise
                {
                    Id = 1,
                    Text = "Вы проспаетесь в автобусе, ваши действия:",
                    ChoisesId = new int[] { 1, 2, 3 },
                    ChoisesText = new string[]
                    {
                        "Остановить автобус",
                        "Заорать на весь автобус",
                        "Продолжить спать"
                    }
                }
            );
            context.SaveChanges();
        }

        public void DeleteDb()
        {
            context.DbBasicChoises.RemoveRange(context.DbBasicChoises);
            context.DbCoolChoises.RemoveRange(context.DbCoolChoises);
            context.DbTimelimitedChoises.RemoveRange(context.DbTimelimitedChoises);
            context.DbRandomChoises.RemoveRange(context.DbRandomChoises);
            context.DbStrangeChoises.RemoveRange(context.DbStrangeChoises);
            context.DbEndMessages.RemoveRange(context.DbEndMessages);

            context.SaveChanges();
        };
    }
}