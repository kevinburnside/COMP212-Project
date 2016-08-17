
/*  ----------------------------------------
 * 
 *  COMP 212 - Programming 3                
 *  Final Project - Substitute Compression
 *  Submission date: 17/08/2016
 *  ----------------------------------------
 *  Selina Daley
 *  Amna Gulraiz - 300627536
 *  Kevin Burnside - 300454171
 *  Max
 *  Kadim 
 *  ----------------------------------------
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMP212_FinalProject
{
    public partial class FrmSubstitutionCompression : Form
    {
        //Create Dictionaries
        Dictionary<char, int> ASCII = new Dictionary<char, int>();
        Dictionary<char, int> Occurrence = new Dictionary<char, int>();
        Dictionary<char, double> Frequency = new Dictionary<char, double>();
        Dictionary<char, double> Sorted_Frequency = new Dictionary<char, double>();
        Dictionary<char, string> Huffman_Code = new Dictionary<char, string>();

        //Create a list to hold the huffman values and populate the list
        List<string> HuffmanValues = new List<string>();

        //Instance variables
        string fileName = "IronHeel.txt", fileName2 = "Huffman_ciphered.txt", 
            fileName3 = "Huffman_decoded.txt"; //Hardcoded textfile
        FileStream inFile, newFile;
        StreamReader reader;
        StreamWriter writer;
        string nextRecord;
        bool done = false;
        int count = 0, count2 = 0;
        double count3 = 0, count4 = 0;
        int startValue = 1;
        public FrmSubstitutionCompression()
        {
            InitializeComponent();
            PopulateHuffmanList(HuffmanValues);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //browse button functionality --- OpenFile Dialog opens the location of the file

            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "C:\\COMP212-Project\\Ironheel.txt"; // this is the path that you are checking.
            dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = Path.GetFileName(dlg.FileName);
            }

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
                        foreach (var letter in nextRecord.ToUpper())
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
                                else if (letter.Equals(',') || letter.Equals(':') || letter.Equals(';'))
                                {
                                    Occurrence[' '] += 1;
                                    count2++;
                                    break;
                                }
                                else if (item.Key.Equals('z') && !letter.Equals('z'))
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
            double final = count + count2;
            //Console.WriteLine(count + " + " + count2 + " = " + final);

            //Display Occurence dictionary and initialize Frequency dictionary
            foreach (var item in Occurrence)
            {
                char key = item.Key;
                int value = Occurrence[item.Key];
                count4 += double.Parse(string.Format("{0:f2}", (value / final) * 100));
                Frequency.Add(key, double.Parse(string.Format("{0:f2}", (value / final) * 100)));
                // Console.WriteLine(key + " -> " + value);
            }

            //Display Frequency dictionary
            foreach (var item in Frequency)
            {
                char key = item.Key;
                double value = Frequency[item.Key];
                //  Console.WriteLine(key + " -> " + value);
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
                // Console.WriteLine(key + " -> " + value);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Initialize the Huffman_Code dictionary
            foreach (var item in Sorted_Frequency)
            {
                Huffman_Code.Add(item.Key, HuffmanValues.ElementAt(startValue - 1));
                startValue++;
            }

            //method call to display table
            DisplayTable();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            // Encoding --- build the ciphered text by converting each 
            //              characters into its Huffman representation
            if (File.Exists(fileName2))
            {
                File.Delete(fileName2);
            }

            newFile = new FileStream(fileName2, FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(newFile);
            done = false;

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
                                    writer.Write(Huffman_Code[item.Key]);
                                    break;
                                }
                                else if (letter.Equals(',') || letter.Equals(':') || letter.Equals(';'))
                                {
                                    writer.Write(Huffman_Code[item.Key]);
                                    break;
                                }
                            }
                        }
                        nextRecord = reader.ReadLine();
                        writer.WriteLine();
                    }
                    reader.Close();
                    inFile.Close();
                    done = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("\nError: " + ex.Message + ". Press Enter");
                }
            } while (!done);

            writer.Close();
            newFile.Close();
            System.Diagnostics.Process.Start("Huffman_ciphered.txt");
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

            // Deccoding ---

            if (File.Exists(fileName3))
            {
                File.Delete(fileName3);
            }

            newFile = new FileStream(fileName3, FileMode.Create, FileAccess.Write);
            writer = new StreamWriter(newFile);
            done = false;

            do
            {
                try
                {

                    inFile = new FileStream(fileName2, FileMode.Open, FileAccess.Read);
                    reader = new StreamReader(inFile);
                    nextRecord = reader.ReadLine();
                    StringBuilder sb = new System.Text.StringBuilder();
                    StringBuilder nextChar = new StringBuilder();
                    while (nextRecord != null)
                    {
                        //Reads each character in and appends it to a stringbuilder                     
                        foreach (var character in nextRecord)
                        {
                            sb.Append(character);
                            //Checks to see if the StringBuilder matches to a value in the Huffman_Code Dictionary
                            if (Huffman_Code.ContainsValue(sb.ToString()))
                            {
                                foreach (var item in Huffman_Code)
                                {
                                    if (item.Value.Equals(sb.ToString()))
                                    {
                                        writer.Write(item.Key);
                                        sb.Clear();
                                        break;
                                    }

                                }

                            }
                            nextRecord = reader.ReadLine();
                            writer.WriteLine();
                        }

                    }

                    reader.Close();
                    inFile.Close();
                    done = true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("\nError: " + ex.Message + ". Press Enter");
                }
            } while (!done);

            writer.Close();
            newFile.Close();
            System.Diagnostics.Process.Start("Huffman_decoded.txt");
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static void PopulateHuffmanList(List<string> huffmanList)
        {
            huffmanList.Add("100");
            huffmanList.Add("0010");
            huffmanList.Add("0011");
            huffmanList.Add("1111");
            huffmanList.Add("1110");//5
            huffmanList.Add("1100");
            huffmanList.Add("1011");
            huffmanList.Add("1010");
            huffmanList.Add("0110");
            huffmanList.Add("0101");//10
            huffmanList.Add("11011");
            huffmanList.Add("01111");
            huffmanList.Add("01001");
            huffmanList.Add("01000");
            huffmanList.Add("00011");//15
            huffmanList.Add("00010");
            huffmanList.Add("00001");
            huffmanList.Add("00000");
            huffmanList.Add("110101");
            huffmanList.Add("011101");//20
            huffmanList.Add("011100");
            huffmanList.Add("1101001");
            huffmanList.Add("110100011");
            huffmanList.Add("110100001");
            huffmanList.Add("110100000");//25
            huffmanList.Add("1101000101");
            huffmanList.Add("1101000100");
        }

        private void DisplayTable()
        {

            //Display all the information
            foreach (KeyValuePair<char, int> pair in ASCII)
            {
                char key = pair.Key;
                int value1 = ASCII[pair.Key];
                int value2 = Occurrence[pair.Key];
                double value3 = Frequency[pair.Key];
                string value4 = Huffman_Code[pair.Key];
               
            }

        }
    }
}
