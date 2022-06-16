using System;
using System.Windows.Forms;

namespace KTYP
{
    public partial class DEVELOPER : Form
    {
        public DEVELOPER()
        {
            InitializeComponent();
        }

        private void VeriEkleButton_Click(object sender, EventArgs e)
        {
            VERİEKLE VeriEkle_Form = new VERİEKLE();
            VeriEkle_Form.Show();
        }

        private void StatikButton_Click(object sender, EventArgs e)
        {
            STATIK_ALGORITMALAR Statik_Form = new STATIK_ALGORITMALAR();
            Statik_Form.Show();
        }
    }
}
