using System;
using System.Collections.Generic;
using System.Linq;
using Mindbox.Cards.Exceptions;

namespace Mindbox.Cards.Solvers
{
    /// <summary>
    /// Memory:
    ///     3N: 2 dictionaries + result
    /// Cpmplexity:
    ///   4N: building 2 dictionaries + searching a start point + traversing order
    /// </summary>
    public sealed class RegularCardsSolver: ICardsSolver
    {
        public List<RouteCard> Solve (List<RouteCard> cards)
        {
            //1. Building maps
            var dicFrom = BuildMap(cards, (c) => c.From, false);
            var dicTo = BuildMap(cards, (c) => c.To, true);

            //2. Searching for the start point
            var start = cards.FirstOrDefault(c => !dicTo.ContainsKey(c.From));
            if (start == null)
                throw new NoStartPointException();

            //3. Recovering card sequence starting from the first not reachable point 
            var res = new List<RouteCard>(cards.Count) {start};

            RouteCard cardTo;
            while (dicFrom.TryGetValue(start.To, out cardTo))
            {
                res.Add(cardTo);
                start = cardTo;

                if (res.Count > cards.Count)
                    throw new CycleDetectedException();
            }

            if (res.Count != cards.Count)
                throw new UnreachablePointsException(cards.Where(x => !res.Contains(x)).ToArray());

            return res;
        }

        static IDictionary<string, RouteCard> BuildMap (IList<RouteCard> cards, Func<RouteCard, string> pointGetter,
            bool isTo)
        {
            var res = new Dictionary<string, RouteCard>(cards.Count, StringComparer.OrdinalIgnoreCase);
            
            foreach (var c in cards)
            {
                var pointname = pointGetter(c);
                if (res.ContainsKey(pointname))
                    throw new DuplicatedDestinationException(pointname, isTo);
                res.Add(pointname, c);
            }
            return res;
        }
    }
}
