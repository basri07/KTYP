using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KTYP
{
    public partial class ANASAYFA : Form
    {
        public ANASAYFA()
        {
            InitializeComponent();
        }

        private void Algoritmalar_Click(object sender, EventArgs e)
        {
            DEVELOPER Developer_Form = new DEVELOPER();
            Developer_Form.Show();
        }
    }
}
