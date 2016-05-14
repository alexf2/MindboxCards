using System;


namespace Mindbox.Cards.Exceptions
{
    public sealed class DuplicatedDestinationException: Exception
    {
        public DuplicatedDestinationException(string dest, bool isTo): base(
            $"Duplicate {(isTo ? "destination" : "source")} found: {dest}")
        {
            Dest = dest;
        }

        public string Dest
        {
            get; private set;
        }
    }
}
