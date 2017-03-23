using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloJSon
{
    class Parser
    {
        private JSonClasses.Rootobject Trello { get; set; }

        public Parser( JSonClasses.Rootobject trello )
        {
            Trello = trello;
        }

        public IEnumerable<JSonClasses.Card1> GetCards( JSonClasses.List1 list )
        {
            return Trello.cards.Where( c => c.idList == list.id );
        }

        public IEnumerable<JSonClasses.Action> GetComments( JSonClasses.Card1 card )
        {
            return Trello.actions.Where( a =>   a.type == "commentCard" 
                                             && a.data.card?.id == card.id )
                                 .OrderBy( a => a.date );
        }

        public IEnumerable<JSonClasses.List1> GetLists()
        {
            return Trello.lists;
        }


    }
}
