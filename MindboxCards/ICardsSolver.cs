using System.Collections.Generic;


namespace Mindbox.Cards
{
    //Represents a generic route card solver
    public interface ICardsSolver
    {
        List<RouteCard> Solve (List<RouteCard> cards);
    }
}
