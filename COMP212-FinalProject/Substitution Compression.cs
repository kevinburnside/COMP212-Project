
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
        string fileName = "IronHeel.txt", fileName2 = "Huffman_ciphered.txt", fileName3 = "Huffman_decoded.txt"; //Hardcoded textfile
        FileStream inFile, newFile;
        StreamReader reader;
        StreamWriter writer;
        string nextRecord;
        bool done = false;
        int count = 0, count2 = 0;
        double count3 = 0, count4 = 0;
        double characterCount, cipheredCount;
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
            // dlg.InitialDirectory = "C:\\COMP212-Project\\Ironheel.txt";

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
            characterCount = count + count2;
            //Console.WriteLine(count + " + " + count2 + " = " + final);

            //Display Occurence dictionary and initialize Frequency dictionary
            foreach (var item in Occurrence)
            {
                char key = item.Key;
                int value = Occurrence[item.Key];
                count4 += double.Parse(string.Format("{0:f2}", (value / characterCount) * 100));
                Frequency.Add(key, double.Parse(string.Format("{0:f2}", (value / characterCount) * 100)));
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
                    Console.Write("\nError: " + ex.Message + ". Press Enter");
                }
            } while (!done);

            writer.Close();
            newFile.Close();
            System.Diagnostics.Process.Start(fileName2);
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
                                        string letter = (item.Key).ToString();
                                        writer.Write(letter.ToUpper());
                                        sb.Clear();
                                        break;
                                    }
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
                    Console.Write("\nError: " + ex.Message + ". Press Enter");
                }
            } while (!done);

            writer.Close();
            newFile.Close();
            System.Diagnostics.Process.Start(fileName3);
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

            List<TextBox> list = new List<TextBox>();
            for (int i = 0; i < 28; i++)
            {
                list.Add(new TextBox());
                list[i].Name = i.ToString();
                list[i].Location = new System.Drawing.Point(40, (i * 20) + 60);
                list[i].ReadOnly = true;
                list[i].TextAlign = HorizontalAlignment.Center;
                this.Controls.Add(list[i]);
            }
            list[0].Text = "Letter";
            list[1].Text = "Space";
            list[2].Text = "A";
            list[3].Text = "B";
            list[4].Text = "C";
            list[5].Text = "D";
            list[6].Text = "E";
            list[7].Text = "F";
            list[8].Text = "G";
            list[9].Text = "H";
            list[10].Text = "I";
            list[11].Text = "J";
            list[12].Text = "K";
            list[13].Text = "L";
            list[14].Text = "M";
            list[15].Text = "N";
            list[16].Text = "O";
            list[17].Text = "P";
            list[18].Text = "Q";
            list[19].Text = "R";
            list[20].Text = "S";
            list[21].Text = "T";
            list[22].Text = "U";
            list[23].Text = "V";
            list[24].Text = "W";
            list[25].Text = "X";
            list[26].Text = "Y";
            list[27].Text = "Z";

            List<TextBox> list2 = new List<TextBox>();
            for (int i = 0; i < 27; i++)
            {
                list2.Add(new TextBox());
                //list2[i].Name = (i + 28).ToString();
                list2[i].Location = new System.Drawing.Point(140, (i * 20) + 80);
                this.Controls.Add(list2[i]);
                list2[i].TextAlign = HorizontalAlignment.Center;
                //var lines = ASCII.Select(kv => kv.Key + ": " + kv.Value.ToString());
                //list2[i].Text = string.Join(Environment.NewLine, lines);
                //list2[i].Text = ASCII.ToString();
            }

            List<TextBox> list3 = new List<TextBox>();
            for (int i = 0; i < 27; i++)
            {
                list3.Add(new TextBox());
                list3[i].Location = new System.Drawing.Point(240, (i * 20) + 80);
                this.Controls.Add(list3[i]);
                list3[i].TextAlign = HorizontalAlignment.Center;
                //var lines = Occurrence.Select(kv => kv.Key + ": " + kv.Value.ToString());
                //list3[i].Text = string.Join(Environment.NewLine, lines);
            }

            List<TextBox> list4 = new List<TextBox>();
            for (int i = 0; i < 27; i++)
            {
                list4.Add(new TextBox());
                list4[i].Location = new System.Drawing.Point(340, (i * 20) + 80);
                this.Controls.Add(list4[i]);
                list4[i].TextAlign = HorizontalAlignment.Center;
                //var lines = Sorted_Frequency.Select(kv => kv.Key + ": " + kv.Value.ToString());
                //list4[i].Text = string.Join(Environment.NewLine, lines);
            }

            List<TextBox> list5 = new List<TextBox>();
            for (int i = 0; i < 27; i++)
            {
                list5.Add(new TextBox());
                list5[i].Location = new System.Drawing.Point(440, (i * 20) + 80);
                this.Controls.Add(list5[i]);
                list5[i].TextAlign = HorizontalAlignment.Center;
                //var lines = Huffman_Code.Select(kv => kv.Key + ": " + kv.Value.ToString());
                //list5[i].Text = string.Join(Environment.NewLine, lines);
            }
            List<TextBox> list6 = new List<TextBox>();
            for (int i = 0; i < 4; i++)
            {
                list6.Add(new TextBox());
                list6[i].ReadOnly = true;
                list6[i].Location = new System.Drawing.Point(140 + (i * 100), 60);
                this.Controls.Add(list6[i]);
                list6[i].TextAlign = HorizontalAlignment.Center;
            }
            list6[0].Text = "Ascii";
            list6[1].Text = "Occurence";
            list6[2].Text = "Frequency";
            list6[3].Text = "Huffman_Code";
            foreach (KeyValuePair<char, int> pair in ASCII)
            {

                char key = pair.Key;
                int value1 = ASCII[pair.Key];
                int value2 = Occurrence[pair.Key];
                double value3 = Frequency[pair.Key];
                string value4 = Huffman_Code[pair.Key];
                for (int i = 0; i < 27; i++)
                {
                    //Console.WriteLine(ASCII.Keys + " " + ASCII.Values);
                    list2[i].Text = value1.ToString();
                    list3[i].Text = value2.ToString();
                    list4[i].Text = value3.ToString();
                    list4[i].Text = value4;
                }
            }

        }

        private void FrmSubstitutionCompression_Load(object sender, EventArgs e)
        {

        }
    }
}
