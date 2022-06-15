using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KTYP
{
    public partial class UygunCozum1//:OnculMatrisi
    {
        public ArrayList UygunCozum(ArrayList array, List<OnculMatrisi> onculMatrisi,int nodeCount)
        {
            ArrayList oncularrayIndex = new ArrayList();
        BastanBasla:
            int i = 0;
            for (i = 0; i < nodeCount; i++)
            {
                oncularrayIndex.Clear();
#pragma warning disable CS8602 // Olası bir null başvurunun başvurma işlemi.
                int a = Convert.ToInt32(array[i]);
#pragma warning restore CS8602 // Olası bir null başvurunun başvurma işlemi.
                int insertTo = 0;
                int OnculMiktari = onculMatrisi[a].Miktar;
                if ( (array != null) && (i!=0)  && (OnculMiktari > 1) && (i != nodeCount-1))
                {
                    int aindex = i;
                    for (int k = 0; k < OnculMiktari; k++)
                    {
                        int OnculNode = Convert.ToInt32(onculMatrisi[a].Dugum_J[k]);
                        int Onculindex = array.IndexOf(OnculNode);
                        oncularrayIndex.Add(Onculindex);
                        oncularrayIndex.Sort();
                        insertTo = Convert.ToInt32(oncularrayIndex[^1]);
                    }
                    if (i<insertTo)
                    {
                        array.RemoveAt(i);
                        array.Insert(insertTo, a);
                        oncularrayIndex.Clear();
                        goto BastanBasla;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
#pragma warning disable CS8603 // Olası null başvuru dönüşü.
            return array;
#pragma warning restore CS8603 // Olası null başvuru dönüşü.
        }
    }
}
