using System;

namespace Mindbox.Cards.Cases
{
    /// <summary>
    /// Provides a base for testcases
    /// </summary>
    public class CaseBase
    {
        protected RouteCard[] Shuffle (RouteCard[] cards)
        {
            var r = new Random();
            for (int i = r.Next(cards.Length/2, 2*cards.Length); i > 0; --i)
            {
                var i1 = r.Next(0, cards.Length);
                var i2 = r.Next(0, cards.Length);
                if (i1 == i2)
                    continue;

                var tmp = cards[ i1 ];
                cards[ i1 ] = cards[ i2 ];
                cards[ i2 ] = tmp;
            }

            return cards;
        }
    }
}
