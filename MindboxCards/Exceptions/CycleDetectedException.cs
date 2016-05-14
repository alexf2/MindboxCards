using System;


namespace Mindbox.Cards.Exceptions
{
    public sealed class CycleDetectedException: Exception
    {
        public CycleDetectedException() : base("A cycled path found")
        {
        }
    }
}
