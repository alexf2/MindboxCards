
using System;

namespace Mindbox.Cards
{
    public sealed class RouteCard
    {
        public string From { get; private set; }
        public string To { get; private set; }

        public RouteCard(string from, string to)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
                throw new Exception("Points can't be empty");

            if (string.Compare(from, to, StringComparison.OrdinalIgnoreCase) == 0)
                throw new Exception("Points should be distinct");

            From = from;
            To = to;
        }
    }
}
