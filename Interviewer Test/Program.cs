using System;
using System.Diagnostics;
namespace Interviewer_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Trail Interviewer!");
            var (dices, sides, rounds) = InputParams();
            CalculateScore(dices, sides, rounds);
            Console.ReadKey();
        }

        public static (int,int,int) InputParams()
        {            
            int dices, sides, rounds;

            Console.WriteLine("Enter number of dices:");
            while (!int.TryParse(Console.ReadLine(), out dices))
            {
                Console.Write("Wrong! Please enter correct number of dices: ");
            }

            Console.WriteLine("Enter number of sides:");
            while (!int.TryParse(Console.ReadLine(), out sides))
            {
                Console.Write("Wrong! Please enter correct number of sides: ");
            }

            Console.WriteLine("Enter number of rounds:");
            while (!int.TryParse(Console.ReadLine(), out rounds))
            {
                Console.Write("Wrong! Please enter correct number of rounds: ");
            }

            return (dices, sides, rounds);
        }

        public static void CalculateScore(int dices, int sides, int rounds)
        {
            var watch = Stopwatch.StartNew();
            var random = new Random();
            int[] arrRounds;
            string resultOneRound;
            int score, scoreSameSides;
            for (int round = 0; round < rounds; round++)
            {
                // New instance for these variables for each loop
                resultOneRound = string.Empty;
                arrRounds = new int[dices];
                for (int i = 0; i < dices; i++)
                {
                    arrRounds[i] = random.Next(1, sides + 1);
                    resultOneRound = string.IsNullOrEmpty(resultOneRound) ? Convert.ToString(arrRounds[i]) : resultOneRound + ", " + arrRounds[i];
                }

                // Sort array
                Array.Sort(arrRounds);

                // Assign the score to first element of array
                score = arrRounds[0];

                // Assign the score of same side to first element of array
                scoreSameSides = arrRounds[0];
                for (int i = 0; i < dices - 1; i++)
                {
                    // Sum 2 dices if they have same side
                    if (arrRounds[i] == arrRounds[i + 1])
                    {
                        scoreSameSides += arrRounds[i];
                    }
                    else
                    {
                        // If score less than score of the same side, assign it as the max value 
                        if (score < scoreSameSides)
                        {
                            score = scoreSameSides;
                        }

                        // Go to the next dice
                        scoreSameSides = arrRounds[i + 1];
                    }
                }

                // Evaluate the score again
                if (score < scoreSameSides)
                {
                    score = scoreSameSides;
                }

                resultOneRound = string.Format("[{0}] => Score: {1}", resultOneRound, score);

                Console.WriteLine(resultOneRound);                
            }

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Time run (milliseconds): {0}", elapsedMs);
        }
    }
}
