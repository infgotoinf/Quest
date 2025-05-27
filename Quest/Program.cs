
using Classes;
using Bd;

class Program2
{
    static void Main()
    {
        Database database = new Database();

        database.CreateDb();

        var choises = new List<Choise>();
        choises.AddRange(database.context.DbBasicChoises.ToList());
        choises.AddRange(database.context.DbCoolChoises.ToList());
        choises.AddRange(database.context.DbTimelimitedChoises.ToList());
        choises.AddRange(database.context.DbRandomChoises.ToList());
        choises.AddRange(database.context.DbStrangeChoises.ToList());
        choises.AddRange(database.context.DbEndMessages.ToList());

        var choise = choises.First(c => c.Id == 0).MakeChoise();

        while (true)
        {
            choise = choises.First(c => c.Id == choise).MakeChoise();
        }
    }
}