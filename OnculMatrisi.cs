using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //public OnculMatrisi(int Dugum_I, string Dugum_J,int Miktar)
        //{
        //    this.Dugum_I = Dugum_I;
        //    this.Dugum_J= Dugum_J;
        //    this.Miktar = Miktar;
        //}
   


    }
    //public class OnculMiktari : ICloneable
    //{

    //    public object Clone()
    //    {
    //        return this.MemberwiseClone();
    //    }
    //    public OnculMiktari()
    //    {

    //    }
    //    public OnculMiktari(int Dugum_I, int Miktar)
    //    {
    //        this.Dugum_I = Dugum_I;
    //        this.Miktar = Miktar;
    //    }


    //    public int Dugum_I { get; set; }
    //    public int Miktar { get; set; }

    //}

}
