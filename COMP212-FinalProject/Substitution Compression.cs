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
        public FrmSubstitutionCompression()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //browse button functionality begins here
              OpenFileDialog dlg = new OpenFileDialog();
              dlg.InitialDirectory = "C:\\Users\\COMP212-Project\\COMP212-FinalProject\\bin\\Debug\\IronHeel.txt";
              dlg.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
              if (dlg.ShowDialog() == DialogResult.OK)
              {
                  txtFileName.Text = Path.GetFileName(dlg.FileName);
              }
            //browse button functionality ends here
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
    }
}
