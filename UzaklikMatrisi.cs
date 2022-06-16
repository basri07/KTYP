using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTYP
{
    public class UzaklikMatrisi : ICloneable
    {
        public string DATA_ID { get; set; }
        public string DATA_ADI { get; set; }
        public int DUGUM_I { get; set; }
        public int DUGUM_J { get; set; }
        public decimal UZAKLIK { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public UzaklikMatrisi()
        {
            DATA_ID = "";
            DATA_ADI = "";
        }
        public UzaklikMatrisi(string DATA_ID, string DATA_ADI, int DUGUM_I, int DUGUM_J, decimal UZAKLIK)
        {
            this.DATA_ID = DATA_ID;
            this.DATA_ADI = DATA_ADI;

            this.DUGUM_I = DUGUM_I;
            this.DUGUM_J = DUGUM_J;
            this.UZAKLIK = UZAKLIK;
        }
    }
}
