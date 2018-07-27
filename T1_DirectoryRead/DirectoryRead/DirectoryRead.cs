using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryRead
{

    class DirectoryRead
    {

        static void Main(string[] args)
        {
            WalkDirectoryTree(@".\TextFiles\Activity7");
            System.Console.ReadLine();
        }

        static void OutputFileDetails(string name) {
            // ACTIVITY 7 - FILL IN CODE HERE
            Console.WriteLine(name);
        }

        static void WalkDirectoryTree(String path)
        {
            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(path);
            System.IO.FileInfo[] files = null;
            System.IO.DirectoryInfo[] subDirs = null;

            // First, process all the files directly under this folder 
            try
            {
                files = root.GetFiles("*.*");
            }

            catch (UnauthorizedAccessException e)
            {
                System.Console.WriteLine(e.Message);
            }

            catch (System.IO.DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            if (files != null)
            {
                // Process every file
                foreach (System.IO.FileInfo fi in files)
                {
                    string name = fi.FullName;
                    OutputFileDetails(name);
                }

                // Now find all the subdirectories under this directory.
                subDirs = root.GetDirectories();

                // Resursive call for each subdirectory.
                foreach (System.IO.DirectoryInfo dirInfo in subDirs)
                {
                    string name = dirInfo.FullName;
                    OutputFileDetails(name);
                }
            }
        }



    }
}
