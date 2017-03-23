using Newtonsoft.Json;
using Novacode;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine( "Feldolgozás indul" );
            if( args.Length == 0 )
            {
                Console.WriteLine( "Missing json file path. Usage: TrelloJSon test.json" );
                return;
            }

            Rootobject trello = LoadJson( args[0] );

            if ( trello == null )
            {
                Console.WriteLine( "JSon beolvasás nem adott vissza eredményt" );
                return;
            }

            if( args.Length == 2 )
            {
                WriteDocX( trello, args[1] );
            }
            else
            {
                WriteConsole( trello );
            }

            Console.WriteLine( "Feldolgozás kész" );
        }

        public static Rootobject LoadJson( string jsonPath )
        {
            try
            {
                Rootobject ret;
                using( StreamReader r = new StreamReader( jsonPath ) )
                {
                    string json = r.ReadToEnd();
                    ret = JsonConvert.DeserializeObject<Rootobject>( json );
                }
                return ret;
            }
            catch( Exception ex )
            {
                Console.WriteLine( $"Hiba a JSon beolvasás során: {ex.Message} " );
                return null;
            }
        }

        private static void WriteConsole( Rootobject trello )
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

        private static void WriteDocX( Rootobject trello, string docPath )
        {
            try
            {
                // Create a document in memory:
                var doc = DocX.Create( docPath );

                foreach( var list in trello.lists )
                {
                    Paragraph paragraph = doc.InsertParagraph( list.name );
                    paragraph.StyleName = "Heading1";

                    var cards = trello.cards.Where( c => c.idList == list.id );
                    foreach( var card in cards )
                    {
                        paragraph = doc.InsertParagraph( card.name );
                        paragraph.StyleName = "Heading5";

                        var hozzaszolasok = trello.actions.Where( a => a.type == "commentCard" && a.data.card?.id == card.id ).OrderBy( a => a.date ).ToArray();
                        if ( hozzaszolasok.Count() > 0 )
                        {
                            var bulletedList = doc.AddList( hozzaszolasok[0].data.text, 0, ListItemType.Bulleted );
                            for( int i = 1; i < hozzaszolasok.Count(); i++ )
                                doc.AddListItem( bulletedList, hozzaszolasok[i].data.text );

                            doc.InsertList( bulletedList );

                        }
                    }
                }

                doc.Save();
            }
            catch( Exception ex)
            {
                Console.WriteLine( $"Hiba a mentés során: {ex.Message} " );

                
            }

            //            Process.Start( "WINWORD.EXE", docPath );
        }
    }
}
