using System;


namespace Mindbox.Cards.Exceptions
{
    public class NoStartPointException: Exception
    {
        public NoStartPointException() : base("Start point is not found")
        {
        }
    }
}
