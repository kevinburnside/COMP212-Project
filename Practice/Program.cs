using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {       
        static void Main(string[] args)
        {
            //Create Dictionaries
            Dictionary<char, int> ASCII = new Dictionary<char, int>();
            Dictionary<char, int> Occurrence = new Dictionary<char, int>();
            Dictionary<char, double> Frequency = new Dictionary<char, double>();
            Dictionary<char, double> Sorted_Frequency = new Dictionary<char, double>();

            //Instance variables
            string fileName = "IronHeel.txt"; //Hardcoded textfile
            FileStream inFile;
            StreamReader reader;
            string nextRecord; 
            bool done = false;
            int count = 0, count2 = 0;
            double count3 = 0;

            //Initialize ASCII dictionary
            ASCII.Add(' ', 32);
            for (int i = 97; i <= 122; i++)
            {
                ASCII.Add(Convert.ToChar(i), i);
            }

            //Display ASCII dictionary
            foreach (var item in ASCII)
            {
                char key = item.Key;
                int value = ASCII[item.Key];                
                Console.WriteLine(key + " -> " + value);
            }

            //Initialize Occurrence dictionary
            foreach (var item in ASCII)
            {
                Occurrence.Add(item.Key, 0);
            }
                        
            //Read the text file character by character
            do
            {
                try
                {
                    inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(inFile);
                    nextRecord = reader.ReadLine();
                    while (nextRecord != null)
                    {
                        foreach (var letter in nextRecord.ToLower())
                        {
                            foreach (var item in ASCII)
                            {
                                if (letter.Equals(item.Key))
                                {
                                    int currentCount;
                                    Occurrence.TryGetValue(item.Key, out currentCount);
                                    Occurrence[item.Key] = currentCount + 1;
                                    count++;
                                    break;
                                }
                                else if(letter.Equals(',') || letter.Equals(':') || letter.Equals(';'))
                                {
                                    Occurrence[' '] += 1;
                                    count2++;
                                    break;
                                }
                                else if(item.Key.Equals('z') && !letter.Equals('z'))
                                {
                                    count3++;
                                    break;
                                }
                            }
                            
                        }
                        
                        nextRecord = reader.ReadLine();
                    }
                    reader.Close();
                    done = true;
                }
                catch (Exception ex)
                {
                    Console.Write("\nError: " + ex.Message + ". Press Enter");
                }

            } while (!done);

            //Display character counts
            double final = count + count2 + count3;
            Console.WriteLine(count + " + " + count2 + " + " + count3 + " = " + final);

            //Display Occurence dictionary and initialize Frequency dictionary
            foreach (var item in Occurrence)
            {
                char key = item.Key;
                int value = Occurrence[item.Key];
                Frequency.Add(key, double.Parse(string.Format("{0:f2}", (value/final) * 100)));
                Console.WriteLine(key + " -> " + value);
            }

            //Display Frequency dictionary
            foreach (var item in Frequency)
            {
                char key = item.Key;
                double value = Frequency[item.Key];
                Console.WriteLine(key + " -> " + value);
            }

            //Store the sorted Frequency dictionary into a variable
            var items = from pair in Frequency
                    orderby pair.Value descending
                    select pair;

            //Initialize Sorted_Frequency dictionary
            foreach (KeyValuePair<char, double> pair in items)
            {
                Sorted_Frequency.Add(pair.Key, pair.Value);
            }

            //Display Sorted_Frequency dictionary
            foreach (var item in Sorted_Frequency)
            {
                char key = item.Key;
                double value = Frequency[item.Key];
                Console.WriteLine(key + " -> " + value);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Display all the information
            foreach (KeyValuePair<char, int> pair in ASCII)
            {
                char key = pair.Key;
                int value1 = ASCII[pair.Key];
                int value2 = Occurrence[pair.Key];
                double value3 = Frequency[pair.Key];

                Console.WriteLine(key + "    " + value1 + " \t " + value2 + " \t " + value3);                
            }
            
        }
        
    }
}
