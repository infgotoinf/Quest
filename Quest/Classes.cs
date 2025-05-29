
namespace Classes
{
    public abstract class Choise
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int[] ChoisesId { get; set; }
        public string[] ChoisesText { get; set; }

        public abstract int MakeChoise();
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
        // Спрашивает пользователя его выбор в виде строчки, при этом не показывая возможные варианты ответов V
        public override int MakeChoise()
        {
            Console.WriteLine(Text);

            string choise = Console.ReadLine();
            int counter = 0;
            foreach (string i in ChoisesText)
            {
                if (i == choise)
                {
                    Console.Clear();
                    return ChoisesId[counter];
                }
                counter++;
            }

            Console.Clear();
            return ChoisesId.Last();
        }
    }

    public class TimelimitedChoise : Choise
    {
        public int timeToChoose;
        private bool timeExpired = false;

        // Спрашивает пользователя его выбор в виде числа но ограничивает время на выбор V
        public override int MakeChoise()
        {
            if (timeToChoose <= 0)
                return ChoisesId.Last();

            Console.Clear();
            timeExpired = false;

            Thread timerThread = new Thread(CountdownTimer);
            timerThread.IsBackground = true;
            timerThread.Start();

            while (true)
            {
                Console.WriteLine($"{Text}\n");
                Console.WriteLine($"Осталось времени: {timeToChoose}");

                int counter = 1;
                foreach (string i in ChoisesText)
                {
                    Console.WriteLine($"    {counter++}) {i}");
                }

                if (timeExpired)
                {
                    Console.Clear();
                    return ChoisesId.Last();
                }

                if (Console.KeyAvailable)
                {
                    string answer = Console.ReadLine();

                    if (!int.TryParse(answer, out int choice))
                    {
                        HandleInvalidInput();
                        continue;
                    }

                    if (choice < 1 || choice >= counter)
                    {
                        HandleInvalidInput();
                        continue;
                    }

                    timeExpired = true;
                    Console.Clear();
                    return ChoisesId[choice - 1];
                }

                Thread.Sleep(100);
                Console.Clear();
            }
        }

        private void CountdownTimer()
        {
            int timeLeft = timeToChoose;
            while (timeLeft > 0 && !timeExpired)
            {
                Thread.Sleep(1000);
                timeLeft--;
                timeToChoose = timeLeft;
            }
            timeExpired = true;
        }

        private void HandleInvalidInput()
        {
            Console.WriteLine("Wrong Input!");
            Thread.Sleep(1000);
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
