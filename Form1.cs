using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace TurkeySpanningTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CityCombo();
            listBox1.Hide();
        }

        int[,] Coordinats = new int[81, 2];

       
        int[,] distances = new int[81, 81];

        string[] citiesName ={"ADANA","ADIYAMAN","AFYON","AĞRI","AMASYA","ANKARA","ANTALYA","ARTVİN","AYDIN","BALIKESİR","BİLECİK","BİNGÖL","BİTLİS","BOLU","BURDUR","BURSA",
                            "ÇANAKKALE","ÇANKIRI","ÇORUM","DENİZLİ","DİYARBAKIR","EDİRNE","ELAZIĞ","ERZİNCAN","ERZURUM","ESKİŞEHİR","GAZİANTEP","GİRESUN","GÜMÜŞHANE",
                            "HAKKARİ","HATAY","ISPARTA","MERSİN","İSTANBUL","İZMİR","KARS","KASTAMONU","KAYSERİ","KIRKLARELİ","KIRŞEHİR","KOCAELİ","KONYA","KÜTAHYA",
                            "MALATYA","MANİSA","KAHRAMANMARAŞ","MARDİN","MUĞLA","MUŞ","NEVŞEHİR","NİĞDE","ORDU","RİZE","SAKARYA","SAMSUN","SİİRT","SİNOP","SİVAS","TEKİRDAĞ",
                            "TOKAT","TRABZON","TUNCELİ","ŞANLIURFA","UŞAK","VAN","YOZGAT","ZONGULDAK","AKSARAY","BAYBURT","KARAMAN","KIRIKKALE","BATMAN","ŞIRNAK","BARTIN",
                            "ARDAHAN","IĞDIR","YALOVA","KARABÜK","KİLİS","OSMANİYE","DÜZCE"
                            };

        int[] visited = new int[81];
        private void button1_Click(object sender, EventArgs e)
        {
            
            Graphics graphics = map.CreateGraphics();
            int u = 0;
            int v = 0;
            int min;
            int total = 0;

            listBox1.Items.Clear();
            if (comboBox1.SelectedIndex < 0)
                comboBox1.SelectedIndex = 5;

            Drawelements();
            readDistance();

            //fixDistance();
            visited[comboBox1.SelectedIndex] = 1;
            int city1 = comboBox1.SelectedIndex, city2 = comboBox1.SelectedIndex;

            for (int counter = 0; counter < 80; counter++)
            {
                min =99999;
                for (int x = 0; x < 81; x++)
                {
                    if (visited[x] == 1)
                    {
                        for (int y = 0; y < 81; y++)
                        {
                            if (visited[y] != 1)
                            {
                                if (min > distances[x, y])
                                {
                                    min = distances[x, y];
                                    u = x;
                                    v = y;
                                    city2 = v;
                                    city1 = u;
                                }
                            }
                        }
                    }
                }

                visited[v] = 1;
                total += min;
                Pen pen2 = new Pen(Color.Snow, 2);
                graphics.DrawLine(pen2, new Point(Coordinats[city1, 0], Coordinats[city1, 1]), new Point(Coordinats[city2, 0], Coordinats[city2, 1]));
                listBox1.Items.Add(citiesName[city1] + "---" + citiesName[city2] + "-->" + min + " km\n");
                System.Threading.Thread.Sleep(200);
                
                //MessageBox.Show(sehirler[city1]+"-----"+sehirler[city2]+"--->"+min+"km");

            }
            listBox1.Show();

            MessageBox.Show("Total Distance of Spanning Tree is "+Convert.ToString( total)+" km");

        }
        public void readDistance()
        {
            try
            {
                StreamReader distanceText = new StreamReader(@"\\ilmesafe.txt");
                string distance = distanceText.ReadToEnd();

                string[] distanceTemp = distance.Split('\t');
                int[] distancesTemp = new int[distanceTemp.Length];
                int i = 0;

                for (int a = 0; a < distanceTemp.Length; a++)
                    distancesTemp[a] = Convert.ToInt32(distanceTemp[a]);

                for (int j = 0; j < 81; j++)
                {
                    visited[j] = 0;
                    int k = 0;
                    while (k < 81)
                    {
                        distances[j, k] = distancesTemp[i];
                        if (distances[j, k] == 0)
                            distances[j, k] = 99999;
                        i++;
                        k++;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }

        }
        //public void fixDistance()
        //{


        //    for (int j = 0; j < 81; j++)
        //    {

        //        int k = 0;
        //        while (k < 81)
        //        {
        //            if (j == 0)//adana
        //            {
        //                if (((k == 32) && (k == 50) && (k == 37) && (k == 45) && (k == 79) && (k == 30)))
        //                {

        //                    distances[j, k] = 9999;

        //                }
        //            }
        //            else if (j == 1)//adıyaman
        //            {
        //                if (((k == 43) && (k == 20) && (k == 62) && (k == 26) && (k == 45)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 2)//afyon
        //            {
        //                if (((k == 25) && (k == 41) && (k == 61) && (k == 19) && (k == 63) && (k == 42)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 3)//ağrı
        //            {
        //                if (((k == 24) && (k == 48) && (k == 35) && (k == 64) && (k == 12) && (k == 75)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 4)//amasya
        //            {
        //                if (((k == 59) && (k == 65) && (k == 18) && (k == 54)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 5)//ankara
        //            {
        //                if (((k == 17) && (k == 77) && (k == 13) && (k == 25) && (k == 41) && (k == 67) && (k == 39) && (k == 49) && (k == 70)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 6)//antalya
        //            {
        //                if (((k == 47) && (k == 14) && (k == 32) && (k == 31) && (k == 41) && (k == 69)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 7)//artvin
        //            {
        //                if (((k == 35) && (k == 24) && (k == 7)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 8)//aydın
        //            {
        //                if (((k == 34) && (k == 44) && (k == 47) && (k == 19)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 9)//balıkesir
        //            {
        //                if (((k == 16) && (k == 15) && (k == 43) && (k == 44) && (k == 34)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 10)//bilecik
        //            {
        //                if (((k == 40) && (k == 53) && (k == 13) && (k == 25) && (k == 42) && (k == 15)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 11)//bingöl
        //            {
        //                if (((k == 23) && (k == 61) && (k == 22) && (k == 20) && (k == 48) && (k == 24)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 12)//bitlis
        //            {
        //                if (((k == 64) && (k == 55) && (k == 71) && (k == 48) && (k == 3)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 13)//bolu
        //            {
        //                if (((k == 5) && (k == 25) && (k == 10) && (k == 53) && (k == 80) && (k == 66) && (k == 77)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 14)//burdur
        //            {
        //                if (((k == 6) && (k == 47) && (k == 17) && (k == 2) && (k == 31)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 15)//bursa
        //            {
        //                if (((k == 76) && (k == 9) && (k == 42) && (k == 10) && (k == 40) && (k == 53)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 16)//çanakkale
        //            {
        //                if (((k == 58) && (k == 9) && (k == 21)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 17)//çankırı
        //            {
        //                if (((k == 5) && (k == 77) && (k == 36) && (k == 18) && (k == 70)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 18)//çorum
        //            {
        //                if (((k == 36) && (k == 56) && (k == 54) && (k == 4) && (k == 65) && (k == 70) && (k == 17)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 19)//denizli
        //            {
        //                if (((k == 47) && (k == 8) && (k == 63) && (k == 2) && (k == 14)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 20)//diyarbakır
        //            {
        //                if (((k == 11) && (k == 22) && (k == 43) && (k == 1) && (k == 62) && (k == 46) && (k == 71) && (k == 48)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 21)//edirne
        //            {
        //                if (((k == 16) && (k == 58) && (k == 38)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 22)//elazığ
        //            {
        //                if (((k == 43) && (k == 23) && (k == 61) && (k == 11) && (k == 20)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 23)//erzincan
        //            {
        //                if (((k == 27) && (k == 28) && (k == 68) && (k == 57) && (k == 43) && (k == 61) && (k == 24)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 24)//erzurum
        //            {
        //                if (((k == 7) && (k == 74) && (k == 35) && (k == 3) && (k == 48) && (k == 11) && (k == 23) && (k == 68) && (k == 52)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 25)//eskişehir
        //            {
        //                if (((k == 5) && (k == 13) && (k == 10) && (k == 42) && (k == 2) && (k == 41)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 26)//gaziantep
        //            {
        //                if (((k == 78) && (k == 30) && (k == 79) && (k == 45) && (k == 1) && (k == 62)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 27)//giresun
        //            {
        //                if (((k == 51) && (k == 57) && (k == 23) && (k == 28) && (k == 60)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 28)//gümüşhane
        //            {
        //                if (((k == 27) && (k == 60) && (k == 68) && (k == 23)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 29)//hakkari
        //            {
        //                if (((k == 64) && (k == 72)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 30)//hatay
        //            {
        //                if (((k == 0) && (k == 79) && (k == 26) && (k == 78)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 31)//ıspARTA
        //            {
        //                if (((k == 2) && (k == 41) && (k == 6) && (k == 14)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 32)//MERSİN
        //            {
        //                if (((k == 0) && (k == 50) && (k == 41) && (k == 69) && (k == 6)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 33)//istanbul
        //            {
        //                if (((k == 38) && (k == 58) && (k == 40)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 34)//izmir
        //            {
        //                if (((k == 8) && (k == 44) && (k == 9)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 35)//kars
        //            {
        //                if (((k == 74) && (k == 24) && (k == 3) && (k == 75)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 36)//kastamonu
        //            {
        //                if (((k == 73) && (k == 77) && (k == 56) && (k == 18) && (k == 17)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 37)//kayseri
        //            {
        //                if (((k == 65) && (k == 57) && (k == 45) && (k == 0) && (k == 50) && (k == 49)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 38)//kırklareli
        //            {
        //                if (((k == 58) && (k == 21)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 39)//kırşehir
        //            {
        //                if (((k == 5) && (k == 49) && (k == 65) && (k == 70)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 40)//kocaeli
        //            {
        //                if (((k == 76) && (k == 15) && (k == 53) && (k == 33)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 41)//konya
        //            {
        //                if (((k == 5) && (k == 67) && (k == 50) && (k == 32) && (k == 69) && (k == 6) && (k == 31) && (k == 2) && (k == 25)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 42)//kütahya
        //            {
        //                if (((k == 9) && (k == 15) && (k == 10) && (k == 25) && (k == 2) && (k == 63) && (k == 44)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 43)//malatya
        //            {
        //                if (((k == 1) && (k == 45) && (k == 57) && (k == 23) && (k == 61) && (k == 22) && (k == 20)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 44)//manisa
        //            {
        //                if (((k == 34) && (k == 8) && (k == 19) && (k == 63) && (k == 42) && (k == 9)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 45)//maraş
        //            {
        //                if (((k == 37) && (k == 57) && (k == 43) && (k == 1) && (k == 26) && (k == 79) && (k == 0)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 46)//mardin
        //            {
        //                if (((k == 62) && (k == 20) && (k == 71) && (k == 55) && (k == 72)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 47)//muğla
        //            {
        //                if (((k == 6) && (k == 14) && (k == 19) && (k == 8)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 48)//muş
        //            {
        //                if (((k == 12) && (k == 71) && (k == 20) && (k == 11) && (k == 24) && (k == 3)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 49)//nevşehir
        //            {
        //                if (((k == 65) && (k == 39) && (k == 67) && (k == 50) && (k == 37) && (k == 5)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 50)//niğde
        //            {
        //                if (((k == 41) && (k == 32) && (k == 0) && (k == 37) && (k == 49) && (k == 67)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 51)//ordu
        //            {
        //                if (((k == 54) && (k == 59) && (k == 57) && (k == 27)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 52)//rize
        //            {
        //                if (((k == 60) && (k == 68) && (k == 24) && (k == 7)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 53)//sakarya
        //            {
        //                if (((k == 40) && (k == 15) && (k == 10) && (k == 13) && (k == 80)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 54)//samsun
        //            {
        //                if (((k == 56) && (k == 18) && (k == 4) && (k == 59) && (k == 51)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 55)//siirt
        //            {
        //                if (((k == 71) && (k == 12) && (k == 64) && (k == 72) && (k == 46)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 56)//sinop
        //            {
        //                if (((k == 36) && (k == 18) && (k == 54)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 57)//sivas
        //            {
        //                if (((k == 59) && (k == 51) && (k == 27) && (k == 23) && (k == 43) && (k == 45) && (k == 37) && (k == 65)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 58)//tekirdağ
        //            {
        //                if (((k == 16) && (k == 21) && (k == 38) && (k == 33)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 59)//tokat
        //            {
        //                if (((k == 4) && (k == 51) && (k == 54) && (k == 57) && (k == 65)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 60)//trabzon
        //            {
        //                if (((k == 27) && (k == 28) && (k == 68) && (k == 52)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 61)//tunceli
        //            {
        //                if (((k == 23) && (k == 11) && (k == 22) && (k == 43)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 62)//sanlıurfa
        //            {
        //                if (((k == 26) && (k == 1) && (k == 20) && (k == 46)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 63)//uşak
        //            {
        //                if (((k == 19) && (k == 44) && (k == 42) && (k == 2)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 64)//van
        //            {
        //                if (((k == 3) && (k == 12) && (k == 55) && (k == 72) && (k == 29)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 65)//yozgat
        //            {
        //                if (((k == 57) && (k == 59) && (k == 4) && (k == 18) && (k == 70) && (k == 39) && (k == 49) && (k == 37)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 66)//zonguldak
        //            {
        //                if (((k == 80) && (k == 13) && (k == 77) && (k == 73)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 67)//aksaray
        //            {
        //                if (((k == 5) && (k == 49) && (k == 41) && (k == 50) && (k == 39)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 68)//bayburt
        //            {
        //                if (((k == 23) && (k == 28) && (k == 60) && (k == 52) && (k == 24)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 69)//karaman
        //            {
        //                if (((k == 41) && (k == 6) && (k == 32)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 70)//kırıkkale
        //            {
        //                if (((k == 6) && (k == 39) && (k == 65) && (k == 18) && (k == 17)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 71)//batman
        //            {
        //                if (((k == 46) && (k == 20) && (k == 48) && (k == 12) && (k == 55)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 72)//şırnak
        //            {
        //                if (((k == 46) && (k == 55) && (k == 64) && (k == 29)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 73)//bartın
        //            {
        //                if (((k == 66) && (k == 77) && (k == 36)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 74)//ardahan
        //            {
        //                if (((k == 24) && (k == 35) && (k == 7)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 75)//ığdır
        //            {
        //                if (((k == 3) && (k == 35)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 76)//yalova
        //            {
        //                if (((k == 15) && (k == 40)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 77)//karabük
        //            {
        //                if (((k == 66) && (k == 73) && (k == 36) && (k == 17) && (k == 5) && (k == 13)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 78)//kilis
        //            {
        //                if (((k == 30) && (k == 26)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 79)//osmaniye
        //            {
        //                if (((k == 30) && (k == 26) && (k == 0) && (k == 45)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }
        //            else if (j == 80)//düzce
        //            {
        //                if (((k == 53) && (k == 66) && (k == 13)))
        //                {
        //                    distances[j, k] = 9999;
        //                }
        //            }

        //            k++;
        //        }
        //    }



        //} 
        public void Drawelements()
        {
            try
            {                                                   
                StreamReader koordinatsTxt = new StreamReader(@"\\ilKoordinat.txt");
                string koordinat = koordinatsTxt.ReadToEnd();
                string[] koordinatTemp = koordinat.Split('\t');
                int[] koordinatsTemp = new int[koordinatTemp.Length];
                for (int a = 0; a < koordinatTemp.Length; a++)
                    koordinatsTemp[a] = Convert.ToInt32(koordinatTemp[a]);
                int i = 0;
                for (int j = 0; j < 81; j++)
                {
                    int k = 0;
                    while (k < 2)
                    {
                        Coordinats[j, k] = koordinatsTemp[i];
                        k++;
                        i++;
                    }

                }
                Graphics graphics = map.CreateGraphics();
                Pen pen1 = new Pen(Color.Black, 5);
                Pen pen2 = new Pen(Color.White, 5);


                for (int b = 0; b < 81; b++)
                    for (int c = 0; c < 2; c++)
                    {
                        if(comboBox1.SelectedIndex==b)
                            graphics.DrawEllipse(pen2, Coordinats[b, c], Coordinats[b, ++c], 6, 6);
                        else
                        graphics.DrawEllipse(pen1, Coordinats[b, c], Coordinats[b, ++c], 6, 6);
                    }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        public void CityCombo()
        {
            for (int i = 0; i < 80; i++)
                comboBox1.Items.Add(citiesName[i]);

        }
     

    }
}