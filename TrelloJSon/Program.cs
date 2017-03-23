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
            Console.WriteLine( "Start" );
            try
            {
                if( args.Length == 0 )
                {
                    Console.WriteLine( "Missing json file path. Usage: TrelloJSon test.json" );
                    return;
                }

                Rootobject trello = LoadJson( args[0] );

                if( trello == null )
                {
                    Console.WriteLine( "JSon reading has not result" );
                    return;
                }

                Parser parser = new Parser( trello );

                if( args.Length == 2 )
                {
                    WriteDocX( parser, args[1] );
                }
                else
                {
                    WriteConsole( parser );
                }

            }
            catch( Exception ex )
            {
                Console.WriteLine( $"Error: {ex.Message} " );

                throw;
            }
            Console.WriteLine( "End" );
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
                Console.WriteLine( $"JSon reading error: {ex.Message} " );
                return null;
            }
        }

        private static void WriteConsole( Parser parser )
        {
            try
            {

                foreach( var list in parser.GetLists() )
                {
                    Console.WriteLine( list.name );

                    var cards = parser.GetCards( list );
                    foreach( var card in cards )
                    {
                        Console.WriteLine( $"   {card.name}" );

                        var comments = parser.GetComments( card );
                        foreach( var comment in comments )
                        {
                            Console.WriteLine( $"       {comment.data.text}" );
                        }
                    }
                }
            }
            catch( Exception ex )
            {
                Console.WriteLine( $"DocX saving error: {ex.Message} " );
            }
        }

        private static void WriteDocX( Parser parser, string docPath )
        {
            try
            {
                // Create a document in memory:
                var doc = DocX.Create( docPath );

                foreach( var list in parser.GetLists() )
                {
                    Paragraph paragraph = doc.InsertParagraph( list.name );
                    paragraph.StyleName = "Heading1";

                    var cards = parser.GetCards( list );
                    foreach( var card in cards )
                    {
                        paragraph = doc.InsertParagraph( card.name );
                        paragraph.StyleName = "Heading5";

                        var comments = parser.GetComments(card ).ToArray();
                        if ( comments.Count() > 0 )
                        {
                            var bulletedList = doc.AddList( comments[0].data.text, 0, ListItemType.Bulleted );
                            for( int i = 1; i < comments.Count(); i++ )
                                doc.AddListItem( bulletedList, comments[i].data.text );

                            doc.InsertList( bulletedList );
                        }
                    }
                }

                doc.Save();
            }
            catch( Exception ex)
            {
                Console.WriteLine( $"DocX saving error: {ex.Message} " );
            }

            //            Process.Start( "WINWORD.EXE", docPath );
        }
    }
}
