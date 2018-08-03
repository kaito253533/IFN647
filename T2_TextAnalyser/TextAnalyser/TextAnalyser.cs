using System;
using System.Collections.Generic;
using System.IO;

namespace TextAnalyser
{
    class TextAnalyser
    {
        PorterStemmerAlgorithm.PorterStemmer myStemmer; // for Activity 4,5
        System.Collections.Generic.Dictionary<string, int> tokenCount; // for Activity 5

        public TextAnalyser()
        {
            myStemmer = new PorterStemmerAlgorithm.PorterStemmer();
            tokenCount = new Dictionary<string,int>();
        }

        //Activity 3
        /// <summary>
        /// Convert the  given text into tokens and then splits it into tokens according to whitespace and punctuation. 
        /// </summary>
        /// <param name="text">Some text</param>
        /// <returns>Lower case tokens</returns>
        public string[] TokeniseString(string text)
        {
            // stub
            char[] delimiter = new char[] { ' ', '"', '\'', ',', '?'};
            string[] result = text.ToLower().Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }

        /// <summary>
        /// Prints out tokens for a given text string
        /// </summary>
        /// <param name="str">a string of text</param>
        public void OutputTokens(string str)
        {
            System.Console.WriteLine("Orginal: \"" + str + "\"");
            string[] tokens = TokeniseString(str);
            Console.WriteLine("Tokens: ");
            foreach (string t in tokens)
            {
                System.Console.WriteLine(t);
            }

           
        }

        public string[] stemTokens (string str){
            string result = myStemmer.stemTerm(str);
            
            String[] resultToken = TokeniseString(result);
            return resultToken;
        }
        public void OutputStems(string str) {
            System.Console.WriteLine("Orginal: \"" + str + "\"");
            string[] result = stemTokens(str);
            Console.WriteLine("Stem: ");
            foreach (string t in result)
            {
                System.Console.WriteLine(t);
            }
        }

        public void OutputTokenCount(string str) {
            System.Console.WriteLine("Orginal: \"" + str + "\"");
            string[] result = stemTokens(str.ToLower());
            foreach (string t in result)
            {
                
                if (tokenCount.ContainsKey(t)) {
                    int value = tokenCount[t];
                    tokenCount[t] = value+1;
                }
                else
                {
                    tokenCount.Add(t, 1);
                }
            }

            foreach (KeyValuePair<string, int> pair in tokenCount) {
                Console.WriteLine(String.Format("Token is {0}, The number of occurances are {1}", pair.Key, pair.Value));
            }
        }

        public void ProcessText(string FileName) {
            StreamReader sr = new StreamReader(FileName);
            OutputTokenCount(sr.ReadToEnd());
        }
        static void Main(string[] args)
        {


            TextAnalyser textAnalyser = new TextAnalyser();

            System.Console.WriteLine("Activity 3");
            string text1 = "Tokenising, even in english, is a difficult problem. It's even harder in other languages - such as Chinese!";
            textAnalyser.OutputTokens(text1);

            Console.WriteLine();
            System.Console.WriteLine("Activity 4");
            string text4_1 = "hypothetically";
            string text4_2 = "destructiveness";
            string text4_3 = "adjustment";
            textAnalyser.OutputStems(text4_1);
            textAnalyser.OutputStems(text4_2);
            textAnalyser.OutputStems(text4_3);

            Console.WriteLine();
            System.Console.WriteLine("Activity 5");
            string text5 = "The world \"the\" is the most common word in the English lanagage.";
            textAnalyser.OutputTokenCount(text5);

            Console.WriteLine();
            System.Console.WriteLine("Activity 6");

            textAnalyser.ProcessText("./AlicePara.txt");

            System.Console.ReadLine();

        }



    }
}
