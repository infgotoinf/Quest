
using Microsoft.EntityFrameworkCore;
using Classes;
using Bd;

class Program2
{
    static void Main()
    {
        var choise = choises[0].MakeChoise();

        while (true)
        {
            choise = choises[choise].MakeChoise();
        }


    Console.WriteLine("\nОчистка таблицы:");

        context.DbBasicChoises      .RemoveRange(context.DbBasicChoises);
        context.DbCoolChoises       .RemoveRange(context.DbCoolChoises);
        context.DbTimelimitedChoises.RemoveRange(context.DbTimelimitedChoises);
        context.DbRandomChoises     .RemoveRange(context.DbRandomChoises);
        context.DbStrangeChoises    .RemoveRange(context.DbStrangeChoises);
        context.DbEndMessages       .RemoveRange(context.DbEndMessages);

        context.SaveChanges();

        Console.WriteLine("Таблица очищена.");

        foreach (var b in choises)
        {
            b.PrintChoise();
        }
    }
}