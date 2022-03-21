using System;
using System.IO;
using System.Collections.Generic;

namespace SpoRenamer
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpoRenamer by Zephaniah Willima
            //I developed this peice of program to rename my song which I have downloaded from spotify using the allavasoft software. 
            //Create a tmp folder in c drive and place all your songs in the tmp folder, then create another folder inside of tmp. Name it Renamed files.
            //When you run this code it renames the files and places then in the new folder.
            //It is a project I developed to test my c sharp programming skills. 
            // Phase two is to try and develop a GUI application.
            //This has been backed up to github


            string[] filesToRename = Directory.GetFiles("C:/tmp"); // Gets all the files in the directory c:/tmp/
            Console.WriteLine("Total Files in the directory: " + filesToRename.Length); // Displays on the console how many files are in the directory
            


            foreach (var files in filesToRename) // The foreach loop, loops thru all the files in the directory and runs the code in the curly brackets
            {
                string newName = files.ToString(); //Converting the file in current read to a string
                
                bool hasHyphen = newName.Contains('-'); // Here we check if the string of file contains a hyphen, returns true if found. MIGHT Use This feature later.
                int firstDotndex = newName.IndexOf('.'); // Were are finding the position of the char '.' in the array of new name
                int lastHyphenIndex = newName.LastIndexOf('-'); // Were are finding the last position of the char '-' in the array of new name
                int lenghtOfStringToCut = lastHyphenIndex - firstDotndex;
                string newesteName = newName.Substring(lastHyphenIndex +2); // This line gets the substring of the lasthyphenindex and delete all the characters in front
    

                int theIndexOfTemp = newesteName.IndexOf(".temp"); // we will find the index of .temp and store it in an interger of the index of temp

                //Console.WriteLine("The last index of temp: " + theIndexOfTemp); // We are getting the last index of .temp in our string.

                if (newesteName.Contains(".temp")) // This conditional statement checks if it has the .temp in it. if true it excutes the code below
                {
                    string newnewName = newesteName.Remove(theIndexOfTemp); // we create a new variable and remove the characters starting from the Index of .temp
                    File.Move(files, "c:/tmp/RenamedFiles/" + newnewName + ".mp3"); //We move the renamed file to a new folder and add .mp3 keyword
                    Console.WriteLine("The file has been Renamed.");
                }
                Console.WriteLine("Old File: "+ files);
            }
            
            
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
