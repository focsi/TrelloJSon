using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrelloJSon.JSonClasses;

namespace TrelloJSon
{
    class Program
    {
        static void Main( string[] args )
        {
            Rootobject trello = LoadJson();
            Write( trello );
            Console.ReadLine();
        }

        public static Rootobject LoadJson()
        {
            Rootobject ret;
            using( StreamReader r = new StreamReader( "file.json" ) )
            {
                string json = r.ReadToEnd();
                ret = JsonConvert.DeserializeObject<Rootobject>( json );
            }
            return ret;
        }
        private static void Write( Rootobject trello )
        {
            foreach( var list in trello.lists )
            {
                Console.WriteLine( list.name );
                Console.WriteLine( "= = = = =" );

                var cards = trello.cards.Where( c => c.idList == list.id );
                foreach( var card in cards )
                {
                    Console.WriteLine( card.name );

                    Console.WriteLine( "vvvvvv" );
                    var hozzaszolasok = trello.actions.Where( a => a.type == "commentCard" && a.data.card?.id == card.id );
                    foreach( var hozzaszolas in hozzaszolasok )
                    {
                        Console.WriteLine( hozzaszolas.data.text );
                        Console.WriteLine( "---" );
                    }

                    Console.WriteLine( "^^^^^^^^^" );

                }

            }
        }
    }
}
