using System;
using System.Collections;

namespace KTYP
{
    public class OnculMatrisi : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public OnculMatrisi()
        {
            Dugum_J = new ArrayList();
        }

        public int Dugum_I { get; set; }
        public ArrayList Dugum_J { get; set; }
        public int Miktar { get; set; }
    }
}
