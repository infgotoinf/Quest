using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class Choise
{
    public int Id { get; set; }
    public SortedDictionary<int, string> choises { get; set; }
    public void PrintChoise()
    {
        foreach (var choise in choises)
        {
            Console.WriteLine($"{choise.Key}: {choise.Value} \n");
        }
    }
}
public class AppDbContext : DbContext
{
    public DbSet<Choise> Choises { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=1234");
    }
}

class Program2
{
    static void Main()
    {
        var context = new AppDbContext();
        context.Database.EnsureCreated();

        context.Choises.AddRange(
            new Choise
            {
                Id = 1,
                Title = "Phython",
                Author = "Bullied Nerd",
                Genre = "Programming",
                PublicationYear = 19999,
                Pages = 2,
                IsAvalible = false,
                Rating = -228,
                Description = "LEARN HOW TO SPEAAK PYTHON IN TWO DAYS",
                Price = -1000
            },
            new Choise
            {
                Id = 2,
                Title = "Gore & Flowers",
                Author = "Lingus Dingus",
                Genre = "Diary",
                PublicationYear = 2025,
                Pages = 4,
                IsAvalible = true,
                Rating = 99,
                Description = "A short but cute story about Lingus Dingus playing with his friends :3 ... and their guts... UwU",
                Price = 0
            }
        );

        context.SaveChanges();

        Console.WriteLine("Хныки добавлены.\n");

        Console.WriteLine("Все продукты:");
        var choises = context.Choises.ToList();

        foreach (var b in choises)
        {
            b.PrintChoise();
        }


        Console.WriteLine("\nОчистка таблицы:");

        context.Choises.RemoveRange(context.Choises);

        context.SaveChanges();

        Console.WriteLine("Таблица очищена.");

        choises = context.Choises.ToList();
        foreach (var b in choises)
        {
            b.PrintChoise();
        }
    }
}