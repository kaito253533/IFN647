using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1_FileRead
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("./TextFiles/Activity5/AlicePara.txt");
            String textString = sr.ReadToEnd();
            Console.Write(textString);

            string[] result = textString.Split();
            Console.Write("The number of words is " + result.Length);
            Console.ReadLine();
        }
    }
}
