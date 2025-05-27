
namespace Classes
{
    public abstract class Choise
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int[] ChoisesId { get; set; }
        public string[] ChoisesText { get; set; }

        public abstract int MakeChoise();
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
        public override int MakeChoise()
        {
            while (true)
            {
                Console.WriteLine(Text);
                int counter = 1;
                foreach (string i in ChoisesText)
                {
                    Console.WriteLine($"\t{counter++}) {i}");
                }
                string answer = Console.ReadLine();

                var WrongInputMassage = () => {
                    Console.WriteLine("Wrong Input!");
                    Console.ReadKey();
                    Console.Clear();
                };

                if (!int.TryParse(answer, out var choise))
                {
                    WrongInputMassage();
                    continue;
                }

                if (!(choise > 0 && choise < counter))
                {
                    WrongInputMassage();
                    continue;
                }

                Console.Clear();
                return ChoisesId[choise - 1];
            }
        }
    }

    public class CoolChoise : Choise
    {
        public override int MakeChoise()
        {
            string choise = Console.ReadLine();
            return 1;
        }
    }

    public class TimelimitedChoise : Choise
    {
        public override int MakeChoise()
        {
            return 1;
        }
    }

    public class RandomChoise : Choise
    {
        public override int MakeChoise()
        {
            return 1;
        }
    }

    public class StrangeChoise : Choise
    {
        public override int MakeChoise()
        {
            return 1;
        }
    }


    public class EndMessage : Choise
    {
        public int EndId { get; set; }
        public override int MakeChoise()
        {
            return 1;
        }
    }
}
