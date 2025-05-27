
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
        // Спрашивает пользователя его выбор в виде числа V
        public override int MakeChoise()
        {
            while (true)
            {
                Console.WriteLine($"{Text}\n");
                int counter = 1;
                foreach (string i in ChoisesText)
                {
                    Console.WriteLine($"    {counter++}) {i}");
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
        // Спрашивает пользователя его выбор в виде строчки, при этом не показывая возможные варианты ответов X
        public override int MakeChoise()
        {
            string choise = Console.ReadLine();
            return 1;
        }
    }

    public class TimelimitedChoise : Choise
    {
        // Спрашивает пользователя его выбор в виде числа но ограничивает время на выбор X
        public override int MakeChoise()
        {
            
            return 1;
        }
    }

    public class RandomChoise : Choise
    {
        // Делает случайный выбор за пользователя V
        public override int MakeChoise()
        {
            while (true)
            {
                Console.WriteLine(Text);

                Console.ReadKey();
                Random rnd = new Random();

                Console.Clear();
                return ChoisesId[rnd.Next(ChoisesId.Length)];
            }
        }
    }

    public class StrangeChoise : Choise
    {
        // Спрашивает пользователя его выбор в виде буквы V
        public override int MakeChoise()
        {
            while (true)
            {
                Console.WriteLine($"{Text}\n");
                int counter = 1;
                foreach (string i in ChoisesText)
                {
                    Console.WriteLine($"    {counter++}) {i}");
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

    public class EndMessage : Choise
    {
        public int EndId { get; set; }

        // Выводит пользователю сообщение и за тем перекидывает в начало игры V
        public override int MakeChoise()
        {
            Console.WriteLine($"Концовка {EndId}");
            Console.WriteLine(Text);
            Console.ReadKey();
            Console.Clear();
            return 0;
        }
    }
}
