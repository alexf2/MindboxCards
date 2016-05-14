using System.Collections.Generic;
using System.Linq;

namespace Mindbox.Cards.Cases
{
    /// <summary>
    /// A simple test case
    /// </summary>
    public sealed class Case1: CaseBase, ITestCase
    {
        public List<RouteCard> Cards => Shuffle(new[]
        {
            new RouteCard("Москва", "Кёльн"),
            new RouteCard("Кёльн", "Париж"),
            new RouteCard("Париж", "Лондон"),
            new RouteCard("Лондон", "Стокгольм"),
            new RouteCard("Стокгольм", "Осло")            
        }).ToList();
    }
}
