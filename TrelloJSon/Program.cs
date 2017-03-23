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
            Rootobject trello = LoadJson();
            WriteDocX( trello );
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

        private static void WriteDocX( Rootobject trello )
        {
            string fileName = @"DocXExample.docx";
            // Create a document in memory:
            var doc = DocX.Create( fileName );

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

            Process.Start( "WINWORD.EXE", fileName );
        }
    }
}
