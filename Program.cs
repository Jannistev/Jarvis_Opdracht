namespace roulette
{
    internal class Program
    {
        bool loop = true;
        int chips = 10;
        int counter = 0;
        bool dead = false;
        List<int> nummerLijst = new List<int>();
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();
        }
        void Start()
        {
            while (loop)
            {
                if (chips <= 0)
                {
                    Console.WriteLine("je hebt geen chips meer");
                    RandomChance();
                    if (dead == true)
                    {
                        break;
                    }
                }
                Console.WriteLine("welke nummer wil je?????");
                string stringNummer = Console.ReadLine().ToLower();
                try
                {
                    int intNummer = int.Parse(stringNummer);
                   
                    if (intNummer >= 0 && intNummer <= 36)
                    {
                        chips--;
                        nummerLijst.Add(intNummer);
                    }
                    else
                    {
                        Error();
                    }

                }
                catch (Exception e)
                {
                    if (stringNummer == "stop")
                    {
                        RandomChance();
                    }
                    else
                    {
                        Console.WriteLine("kies een getal van 1 t/m 35 of typ stop");
                        Console.ReadKey(true);
                    }
                }
                Console.Clear();
            }
        }
        void Error()
        {
            Console.WriteLine("schrijf een getal tussen de 1 en de 36");
            Console.ReadKey(true);
        }
        void RandomChance()
        {
            Console.WriteLine("rien ne va plus \n");
            Random rd = new Random();
            int randomNummer = rd.Next(1, 36);
            Console.WriteLine("de getal is " + randomNummer);
            for (int i = 0; i < nummerLijst.Count; i++)
            {
                if (nummerLijst[i] == randomNummer)
                {
                    chips = chips + 35;
                    counter++;
                }
            }
            if (counter > 0)
            {
                Console.WriteLine("je hebt gewonnen!");
            }
            Console.WriteLine("je hebt nu zoveel punten: " + chips);
            Console.ReadKey(true);
            nummerLijst.Clear();
            if (chips == 0)
            {
                Console.WriteLine("Game Over");
                loop = false;
                dead = true;
            }
        }
    }
}