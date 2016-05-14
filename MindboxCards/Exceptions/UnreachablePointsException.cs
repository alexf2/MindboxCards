using System;
using System.Linq;

namespace Mindbox.Cards.Exceptions
{
    public sealed class UnreachablePointsException: Exception
    {
        public UnreachablePointsException (RouteCard[] cards): base("Unreacable points found: " + GetDestList(cards))
        {            
        }

        static string GetDestList(RouteCard[] cards)
        {
            return string.Join(", ", cards.Select(x => x.From + "-->" + x.To).ToArray());
        }
    }
}
