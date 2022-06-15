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
