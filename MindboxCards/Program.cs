using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mindbox.Cards.Cases;
using Mindbox.Cards.Solvers;

namespace Mindbox.Cards
{
    public class Program
    {
        readonly ITestCase _case;
        readonly ICardsSolver _solver;

        Program (ITestCase @case, ICardsSolver solver)
        {
            _case = @case;
            _solver = solver;
        }

        [MTAThread]
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();

            Console.WriteLine();
            Console.WriteLine("Press a key...");
            Console.ReadLine();
        }

        [MTAThread]
        public static async Task MainAsync (string[] args)
        {
            try
            {
                new Program(new Case1(), new RegularCardsSolver()).Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\r\n" + ex.Message);
            }
        }

        void Run ()
        {
            var cards = _case.Cards;
            Console.WriteLine($"Source cards ({cards.Count}): ");            
            PrintCards(cards);

            cards = _solver.Solve(cards);
            Console.WriteLine($"\r\nSolved cards ({cards.Count}): ");
            PrintCards(cards);
        }

        static void PrintCards (IEnumerable<RouteCard> cards)
        {
            foreach (var c in cards)            
                Console.WriteLine($"\t{c.From} --> {c.To}");
        }
    }
}
