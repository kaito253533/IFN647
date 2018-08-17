using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lucene.Net.Analysis; // for Analyser
using Lucene.Net.Documents; // for Socument
using Lucene.Net.Index; //for Index Writer
using Lucene.Net.Store; //for Directory

namespace LuceneApplication
{
    class LuceneApplication
    {
        Lucene.Net.Store.Directory luceneIndexDirectory;
        Lucene.Net.Analysis.Analyzer analyzer;
        Lucene.Net.Index.IndexWriter writer;
        public static Lucene.Net.Util.Version VERSION = Lucene.Net.Util.Version.LUCENE_30;

        public LuceneApplication()
        {
            luceneIndexDirectory = null; // Is set in Create Index
            analyzer = null;  // Is set in CreateAnalyser
            writer = null; // Is set in CreateWriter
        }

        // Activity 7

        public void OpenIndex(string indexPath)
        {
            /* Make sure to pass a new directory that does not exist */
            if (System.IO.Directory.Exists(indexPath)) {
                Console.WriteLine("This directory already exists - Choose a directory that does not exist");
                Console.Write("Hit any key to exit");
                Console.ReadKey();
                Environment.Exit(0);
            }
            luceneIndexDirectory = Lucene.Net.Store.FSDirectory.Open(indexPath);
        }

        // Activity 8

        public void CreateAnalyser()
        {
            // TODO: Enter code to create the Lucene Analyser 
            analyzer = new Lucene.Net.Analysis.SimpleAnalyzer();
        }

        public void CreateWriter()
        {


            IndexWriter.MaxFieldLength mfl = new IndexWriter.MaxFieldLength(IndexWriter.DEFAULT_MAX_FIELD_LENGTH);

            // TODO: Enter code to create the Lucene Writer
            writer = new Lucene.Net.Index.IndexWriter(luceneIndexDirectory, analyzer, true, mfl);
        }

        // Activity 9

        public void IndexText(string text)
        {

            // TODO: Enter code to index text
            Lucene.Net.Documents.Field field = new Lucene.Net.Documents.Field("text", text, Field.Store.NO, Field.Index.ANALYZED, Field.TermVector.WITH_POSITIONS_OFFSETS);
            Lucene.Net.Documents.Document doc = new Lucene.Net.Documents.Document();
            doc.Add(field);
            writer.AddDocument(doc);
        }


        public void CleanUp()
        {
            writer.Optimize();
            writer.Flush(true, true, true);
            writer.Dispose();
        }

        static void Main(string[] args)
        {

            System.Console.WriteLine("Hello Lucene.Net");
            
            LuceneApplication myLuceneApp = new LuceneApplication();
            myLuceneApp.OpenIndex("./index");
            myLuceneApp.CreateAnalyser();
            myLuceneApp.CreateWriter();

            myLuceneApp.IndexText("i love information retreval i love data science data scienctist is a dream job");
            myLuceneApp.CleanUp();
            System.Console.ReadLine();
        }
    }
}