
/*  ----------------------------------------
 * 
 *  COMP 212 - Programming 3                
 *  Final Project - Substitute Compression
 *  Submission date: 17/08/2016
 *  ----------------------------------------
 *  Selina Daley
 *  Amna Gulraiz - 300627536
 *  Kevin 
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
            string fileName = "IronHeel.txt", fileName2 = "encrypt.txt"; //Hardcoded textfile
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
              dlg.InitialDirectory = "C:\\Users\\COMP212-Project\\COMP212-FinalProject\\bin\\Debug\\IronHeel.txt";
              dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
              if (dlg.ShowDialog() == DialogResult.OK)
              {
                  txtFileName.Text = Path.GetFileName(dlg.FileName);
              }

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {

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

    }
}
