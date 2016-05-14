using System.Collections.Generic;


namespace Mindbox.Cards
{
    /// <summary>
    /// Represents a set of unordered cards
    /// </summary>
    public interface ITestCase
    {
        List<RouteCard> Cards { get; }
    }
}
