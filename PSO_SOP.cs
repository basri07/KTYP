using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;


namespace KTYP
{
    public class PSO_SOP : SOP
    {
        UygunCozum1 SopU;
        UzaklikHesapla UH;
        public PSO_SOP(SqlConnection baglanti, SOPAtanabilirListeGuncelle sopk, string dataId) : base(baglanti, sopk, dataId)
        {
            this.baglanti = baglanti;
            this.dataId = dataId;
            this.sopk = sopk;
            this.SopU = new UygunCozum1();
            this.UH = new UzaklikHesapla(baglanti, sopk, dataId);
        }
        public override string SOPCoz(int nodeCount, ArrayList atanabilirDugumIDListesi, bool EYKS)
        {
            throw new NotImplementedException();

        }
        public void psoSOP(string dataID, int ParcacikSayisi, int iterasyonSayisi, bool EYKS, int LastResult)
        {
            List<OnculMatrisi> onculMatrisi = this.OnculMatrisi();
            SOP_RASSAL sopr = new SOP_RASSAL(baglanti, sopk, dataID);
            int nodeCount = sopr.NodeCount();
            int Gi = 0;
            int Gk = 0;
            List<string[]> Sonuc = new List<string[]>();
            //Parcacik o anki Pozisyon
            int[,] PPozition = new int[ParcacikSayisi, nodeCount];
            //Parçacığın o an ki Fitness Valuesi
            int[] PFV = new int[ParcacikSayisi];
            //Parçacığın Kişisel En iyi Fitnes Valuesi
            int[] PPBFV = new int[ParcacikSayisi];
            //Parçacığın Kişisel En iyi Pozisyonu
            int[,] PPBPozition = new int[ParcacikSayisi, nodeCount];
            //Gloval Fitnes Value
            int GBFV = 2000000000;
            //Global En iyi Pozisyon
            int[] GBPozisyon = new int[nodeCount];
            StringBuilder Show = new StringBuilder("");
            int[] Dugumler = new int[nodeCount];
            //StringBuilder sbrndNode_i = new StringBuilder("sbrndNode_i[i düğümü ve indexi]\n");
            //StringBuilder sbrndNode_j = new StringBuilder("sbrndNode_j[j düğümü ve indexi]\n");
            //StringBuilder sbrndPhiz = new("sbrndPhiz[i,j] İ parçacığının Dugumindex_i'yi Dugumindex_j'ye\n");
            Random Alfarandom = new Random();
            Random rastgeleHizMiktari = new Random();
            double ilkhizmiktari = (nodeCount / 2);
            var listnodes = new List<int>();
            var Phiz = new int[ParcacikSayisi, nodeCount];
            ArrayList PPozitionList = new ArrayList();
            Stopwatch PSOSureHesapla = new Stopwatch();
            Stopwatch BaslangıcSureHesapla = new Stopwatch();
            PSOSureHesapla.Start();
            //iterasyon Sayisi kadar döngü
            for (int k = 0; k < iterasyonSayisi; k++)
            {
                //Parcacik Sayısı kadar döngü
                for (int i = 0; i < ParcacikSayisi; i++)
                {
                    //ilk iterasyonda Parcacik Sayisi Kadar RASTSAL Çözüm Üret
                    if (k == 0)
                    {
                        if (i == 0)
                        {
                            BaslangıcSureHesapla.Start();
                        }
                        ArrayList atanabilirDugumIDListesi = sopr.AtabilirDugumIdListele();
                        String sonuc = sopr.SOPCoz(nodeCount, atanabilirDugumIDListesi, EYKS);
                        //MessageBox.Show(" " + sonuc + " ");
                        var a = sonuc.Split(" ");
                        Sonuc.Add(a);
                        //Parçacik Pozisyonlarını String Olarak Ekle
                        for (int j = 0; j < nodeCount; j++)
                        {
                            PPozition[i, j] = Convert.ToInt32(Sonuc[i][j]);
                            Dugumler[j] = Convert.ToInt32(Sonuc[i][j]);
                            PPozitionList.Add(Dugumler[j]);
                            Phiz[i, j] = 0;
                            PPBPozition[i, j] = Dugumler[j];
                        }
                        if (i == ParcacikSayisi - 1)
                        {
                            BaslangıcSureHesapla.Stop();
                            TimeSpan BHesaplananZaman = BaslangıcSureHesapla.Elapsed;
                            string BaslangıcSure = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                            BHesaplananZaman.Hours, BHesaplananZaman.Minutes, BHesaplananZaman.Seconds, BHesaplananZaman.Milliseconds / 10);
                            string SqlUpdate = "UPDATE KTYP..SONUCLAR SET B_SURE='" + BaslangıcSure + "' WHERE COZUM_ID =" + LastResult + "";
                            baglanti.Open();
                            SqlCommand SqlUpdatecmd = new SqlCommand(SqlUpdate, baglanti);
                            SqlUpdatecmd.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        //Parçacikların Fitness Valuesunu ekle
                        PFV[i] = Convert.ToInt32(Sonuc[i][nodeCount]);
                        //Parçacıkların Kişisel En iyi Fitness Valuesu ilk üretilen çözümler için Kendi fitnesValuesine eşittir
                        PPBFV[i] = PFV[i];
                        //Parçacıklar arasında en iyi Fitness Value Sahip olanı Global Fitnes Value Olarak seç ve Global En iyi Pozisyonu Güncelle
                        if (PPBFV[i] < GBFV)
                        {
                            GBFV = PPBFV[i];
                            Gi = i;
                            Gk = k;
                            for (int j = 0; j < nodeCount; j++)
                            {
                                GBPozisyon[j] = PPozition[i, j];
                            }
                        }
                        double alfa = Alfarandom.NextDouble();
                        double beta = 1 - alfa;
                        //Vi(k+1) = w.Vi(k) + alfa*(Particle(i)PBP-Particle(ik)Pozition) +beta*(GlobalBestPoz-Particle(ik)Pozition)
                        //Buna göre ilk hız için w yani ivme tanımı yapmadım. ilk hız globale göre Düğümsayısı/2 çarpı Beta olarak tanımlandı.
                        //Örneğin hız miktarı 5 olsun 5 tane rastsal düğümü yer değiştireceğiz.
                        int hızmiktari = rastgeleHizMiktari.Next((int)Math.Ceiling(ilkhizmiktari * beta));
                        if (hızmiktari == 0)
                        {
                            hızmiktari = 1;
                        }
                        ArrayList rndnoteslist_i = new ArrayList();
                        ArrayList rndnotesindexlist_i = new ArrayList();
                        ArrayList rndnoteslist_j = new ArrayList();
                        ArrayList rndnotesindexlist_j = new ArrayList();

                        int Dugumindex_i;
                        int Dugumindex_j;

                        for (int h = 0; h < hızmiktari; h++)
                        {
                        //Random olarak Yer Değiştirecek Düğüm seçilir ve o Düğümün Pozisyon içerisindeki indexi bulunur.
                        RandomDugum_i:
                            var rndnotes_i = rastgeleHizMiktari.Next(1, nodeCount - 2);
                            if (h == 0 || rndnoteslist_i.Contains(rndnotes_i) == false)
                            {
                                Dugumindex_i = PPozitionList.IndexOf(rndnotes_i);
                                rndnoteslist_i.Add(rndnotes_i);
                                rndnotesindexlist_i.Add(Dugumindex_i);
                            }
                            else
                            {
                                goto RandomDugum_i;
                            }
                        RandomDugum_j:
                            var rndnotes_j = rastgeleHizMiktari.Next(1, nodeCount - 2);
                            if (h == 0 || rndnoteslist_i.Contains(rndnotes_j) == false && rndnoteslist_j.Contains(rndnotes_j) == false)
                            {
                                Dugumindex_j = PPozitionList.IndexOf(rndnotes_j);
                                rndnoteslist_j.Add(rndnotes_j);
                                rndnotesindexlist_j.Add(Dugumindex_j);
                                Phiz[i, Dugumindex_i] = Dugumindex_j;
                            }
                            else
                            {
                                goto RandomDugum_j;
                            }
                        }
                        rndnoteslist_i.Clear();
                        rndnotesindexlist_i.Clear();
                        rndnoteslist_j.Clear();
                        rndnotesindexlist_j.Clear();
                    }
                    else
                    {
                        StringBuilder sbHiz = new StringBuilder("HIZ\ni.parçacığın  j. indeksinde bulunan değeri Phiz[i,j]=çıkan sonuca insert et\n" + i.ToString() + "PARÇACIK\n" + k.ToString() + "İTERASYON\n");
                        StringBuilder sbPozition_i = new StringBuilder("Pozition_i[j]\n" + i.ToString() + " PARÇACIK\n" + k.ToString() + "İTERASYON\n");
                        StringBuilder sbSonuc = new StringBuilder("SONUC\n");
                        sbPozition_i.AppendLine("HIZ EKLENMEMİŞ\n");
                        ArrayList Pozition_i = new ArrayList();

                        for (int j = 0; j < nodeCount; j++)
                        {
                            sbHiz.Append(" [" + i.ToString() + "," + j.ToString() + "] = " + Phiz[i, j] + "\n");
                            Pozition_i.Add(PPozition[i, j]);
                            sbPozition_i.Append(" " + i + "," + +j + " = " + Pozition_i[j] + "\n");
                        }
                        //Hız Ekle
                        sbPozition_i.AppendLine("HIZ EKLENMİŞ\n");
                        for (int j = 0; j < nodeCount; j++)
                        {
                            if (Phiz[i, j] != 0)
                            {
                                if (Phiz[i, j] < j)
                                {
                                    Pozition_i.Insert(Phiz[i, j], PPozition[i, j]);
                                    Pozition_i.RemoveAt(j + 1);
                                }
                                if (Phiz[i, j] > j)
                                {
                                    Pozition_i.Insert(Phiz[i, j] + 1, PPozition[i, j]);
                                    Pozition_i.RemoveAt(j);
                                }
                            }

                        }
                        //Uygun Çözüme Çevir
                        Pozition_i = SopU.UygunCozum(Pozition_i, onculMatrisi, nodeCount);
                        //Uzaklik Hesapla
                        PFV[i] = UH.UzaklikHesabi(Pozition_i);
                        sbPozition_i.Append(" UYGUN ÇÖZÜM Pozition_i[j]\n" + i.ToString() + " PARÇACIK\n" + k.ToString() + "İTERASYON\n");
                        //Uygun Çözümü Güncelle Global en iyi ve kişisel en iyiler varsa güncelle
                        for (int j = 0; j < nodeCount; j++)
                        {
                            int Node = Convert.ToInt32(Pozition_i[j]);
                            PPozition[i, j] = Node;
                            Phiz[i, j] = 0;
                            sbPozition_i.Append(" " + i + "," + +j + " = " + Pozition_i[j] + "\n");
                            if (PFV[i] < PPBFV[i])
                            {
                                PPBPozition[i, j] = Node;
                                PPBFV[i] = PFV[i];
                            }
                            if (PFV[i] < GBFV)
                            {
                                GBFV = PFV[i];
                                GBPozisyon[j] = Node;
                                Gi = i;
                                Gk = k;
                            }
                        }
                        //Hız Hesapla
                        if (k != nodeCount - 1)
                        {
                            int P = 0;
                            int G = 0;
                            ArrayList PIndexi = new ArrayList();
                            ArrayList PIndexJ = new ArrayList();
                            ArrayList GIndexi = new ArrayList();
                            ArrayList GIndexJ = new ArrayList();
                            for (int j = 0; j < nodeCount; j++)
                            {
                                if (PPBPozition[i, j] != GBPozisyon[j] && PIndexJ.Contains(j) == false)
                                {
                                    G++;
                                    GIndexi.Add(Pozition_i.IndexOf(GBPozisyon[j]));
                                    GIndexJ.Add(j);
                                }
                                if (PPozition[i, j] != PPBPozition[i, j] && GIndexJ.Contains(j) == false)
                                {
                                    P++;
                                    PIndexi.Add(Pozition_i.IndexOf(PPBPozition[i, j]));
                                    PIndexJ.Add(j);
                                }
                            }
                            double Alfa = (rastgeleHizMiktari.Next(50, 100)) / (100);
                            double Beta = 1 - Alfa;
                            int GHizMik = (int)Math.Ceiling(Alfa * G);
                            int PhizMik = (int)Math.Floor(Alfa * P);
                            int ToplamHizMik = GHizMik + PhizMik;
                            for (int f = 0; f < G - GHizMik; f++)
                            {
                                GIndexi.RemoveAt(GIndexi.Count - 1);
                                GIndexJ.RemoveAt(GIndexJ.Count - 1);
                            }
                            for (int f = 0; f < P - P - PhizMik; f++)
                            {
                                PIndexi.RemoveAt(PIndexi.Count - 1);
                                PIndexJ.RemoveAt(PIndexJ.Count - 1);
                            }
                            for (int j = 0; j < PhizMik; j++)
                            {
                                GIndexi.Add(PIndexi[j]);
                                GIndexJ.Add(PIndexJ[j]);
                            }
                            for (int j = 0; j < ToplamHizMik; j++)
                            {
                                int IndexJ = Convert.ToInt32(GIndexJ[j]);
                                int left = 0;
                                int right = 0;
                                for (int f = j + 1; f < ToplamHizMik; f++)
                                {
                                    if (Convert.ToInt32(GIndexi[f]) > IndexJ && Convert.ToInt32(GIndexJ[f]) <= IndexJ)
                                    {
                                        right++;
                                    }
                                    if (IndexJ > Convert.ToInt32(GIndexi[f]) && Convert.ToInt32(GIndexJ[f]) > IndexJ)
                                    {
                                        left++;
                                    }
                                }
                                int gPHiz = j + (right - left);

                                Phiz[i, Convert.ToInt32(GIndexi[j])] = gPHiz;
                            }
                        }
                        // MessageBox.Show(sbSonuc.ToString());
                    }
                }
            }
            PSOSureHesapla.Stop();
            TimeSpan HesaplananZaman = PSOSureHesapla.Elapsed;
            string PSOSure = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            HesaplananZaman.Hours, HesaplananZaman.Minutes, HesaplananZaman.Seconds, HesaplananZaman.Milliseconds / 10);
            //Show.Append("En iyi Parçacık" + Gi.ToString()+"En iyi İterasyon"+Gk.ToString()+"\n");
            for (int j = 0; j < nodeCount; j++)
            {
                Show.Append(GBPozisyon[j].ToString() + "\n");
            }
            Show.Append(GBFV.ToString());
            #region Log Dosyası
            //sbSonuc.AppendLine(sbPozition_i.ToString()+"\n");
            string fileName = @"C:\Users\hbasr\OneDrive\Masaüstü\YLKODLAMA\KARALAMA\Logs.txt";
            string writeText = Show.ToString();
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fs.Close();
            File.AppendAllText(fileName, Environment.NewLine + writeText);
            #endregion

            //MessageBox.Show(Show.ToString());
            string SqlUpdate1 = "UPDATE KTYP..SONUCLAR SET ENIYI_PARCACIK=" + Gi + ",ENIYI_ITERASYON=" + Gk + ",GOSTERIM='" + Show.ToString() + "',UZAKLIK=" + GBFV + " WHERE COZUM_ID =" + LastResult + "";
            baglanti.Open();
            SqlCommand SqlUpdatecmd1 = new SqlCommand(SqlUpdate1, baglanti);
            SqlUpdatecmd1.ExecuteNonQuery();
            baglanti.Close();
        }
    }
    #region Liste kopyalama ve Swap işlemleri için gerekli metotlar.
    internal static class Extensions
    {
        public static IList<T> CloneList<T>(this IList<T> list) where T : ICloneable
        {
            return list.Select(item => (T)item.Clone()).ToList();
        }
        public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
            return list;
        }

    }
    #endregion

}

