using System;
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
