using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class Choise
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int[] ChoisesId { get; set; }
    public string[] ChoisesText { get; set; }
    public void PrintChoise()
    {
        for (int i = 0; i < ChoisesId.Length; i++)
        {
            Console.WriteLine($"{ChoisesId[i]}: {ChoisesText[i]}");
        }
    }
}

public class BasicChoise : Choise
{
    public int MakeBasicChoise(int choise)
    {
        return choise;
    }
}

public class CoolChoise : Choise
{
    public int MakeCoolChoise(string choise)
    {
        return 1;
    }
}

public class TimelimitedChoise : Choise
{
    public int MakeCoolTimeLimit(int choise)
    {
        return 1;
    }
}

public class EndMessage : Choise
{
    public int EndId { get; set; }
}

public class MakeRandomChoise : Choise
{
    public int MakeCoolTimeLimit()
    {
        return 1;
    }
}



public class StrangeChoise : Choise
{
    public int MakeStrangeChoise(string choise)
    {
        return 1;
    }
}
public class AppDbContext : DbContext
{
    public DbSet<Choise> DbChoises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Use a dedicated database name instead of 'postgres'
        optionsBuilder.UseNpgsql("Host=localhost;Database=QuestDB;Username=postgres;Password=1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Choise>()
            .Property(e => e.ChoisesId)
            .HasColumnType("integer[]");

        modelBuilder.Entity<Choise>()
            .Property(e => e.ChoisesText)
            .HasColumnType("text[]");
    }
}

class Program2
{
    static void Main()
    {
        var context = new AppDbContext();

        // Terminate active connections to QuestDB before deletion
        using (var adminConn = new Npgsql.NpgsqlConnection("Host=localhost;Database=postgres;Username=postgres;Password=1234"))
        {
            adminConn.Open();
            using (var cmd = new Npgsql.NpgsqlCommand(
                $"SELECT pg_terminate_backend(pg_stat_activity.pid) " +
                $"FROM pg_stat_activity " +
                $"WHERE pg_stat_activity.datname = 'QuestDB' " +
                $"AND pid <> pg_backend_pid();", adminConn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        // Now safely delete and recreate the database
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        // Add sample data
        context.DbChoises.AddRange(
            new Choise
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
            },
            new Choise
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

        Console.WriteLine("Хныки добавлены.\n");

        Console.WriteLine("Все выборы:");
        var choises = context.DbChoises.ToList();

        foreach (var b in choises)
        {
            b.PrintChoise();
        }


        Console.WriteLine("\nОчистка таблицы:");

        context.DbChoises.RemoveRange(context.DbChoises);

        context.SaveChanges();

        Console.WriteLine("Таблица очищена.");

        choises = context.DbChoises.ToList();
        foreach (var b in choises)
        {
            b.PrintChoise();
        }
    }
}