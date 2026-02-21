using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace avioanele_atestat
{
    public partial class Avioanele : Form
    {
        int n;
        int nr = 0, nr1, nr2;
        int castiga = 0, castigb = 0, okstart = 0,ok=0,i1,j1;
        Button[,] b;
        Button[,] a;
        int[,] avioaneb = new int[10, 10];
        int[,] avioanea = new int[10, 10];
        Random r = new Random();
        public Avioanele()
        {
            InitializeComponent();
            n = 10;
            b = new Button[n, n];
            int lb = 35;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    b[i, j] = new Button();
                    b[i, j].Name = (i * n + j).ToString();
                    b[i, j].BackColor = Color.White;
                    b[i, j].Location = new Point(lb + j * lb, lb + i * lb);
                    b[i, j].Click += new EventHandler(MyClickB);
                    b[i, j].Size = new Size(lb, lb);
                    panel1.Controls.Add(b[i, j]);
                }
            panel1.Enabled = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    avioaneb[i, j] = 0;

            a = new Button[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    a[i, j] = new Button();
                    a[i, j].Name = (i * n + j).ToString();
                    a[i, j].BackColor = Color.White;
                    a[i, j].Location = new Point(lb + j * lb, lb + i * lb);
                    a[i, j].Click += new EventHandler(MyClickA);
                    a[i, j].Size = new Size(lb, lb);
                    panel2.Controls.Add(a[i, j]);
                }
            panel2.Enabled = true;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    avioanea[i, j] = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nr1 = 1;
        } 
        private void button3_Click(object sender, EventArgs e)
        {
            nr1 = 2;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            nr1 = 3;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            nr1 = 4;
        }

        private int pozibuton(Button button)
        {
            int index = panel1.Controls.IndexOf(button);
            int i = index / n;
            return i;
        }
        private int pozjbuton(Button button)
        {
            int index = panel1.Controls.IndexOf(button);
            int j = index % n;
            return j;
        }
        private int verif(int nr2, int i, int j, int[,] avioanea)
        {
            if (nr2 == 1)
            {
                if (avioanea[i, j] >= 1 ||
                    avioanea[i + 1, j] >= 1 ||
                    avioanea[i + 2, j] >= 1 ||
                    avioanea[i + 3, j] >= 1 ||
                    avioanea[i + 1, j - 1] >= 1 ||
                    avioanea[i + 1, j - 2] >= 1 ||
                    avioanea[i + 1, j + 1] >= 1 ||
                    avioanea[i + 1, j + 2] >= 1 ||
                    avioanea[i + 3, j - 1] >= 1 ||
                    avioanea[i + 3, j + 1] >= 1)
                    return 0;
            }
            else if (nr2 == 2)
            {
                if (avioanea[i, j] >= 1 ||
               avioanea[i - 1, j] >= 1 ||
                avioanea[i - 2, j] >= 1 ||
                avioanea[i - 3, j] >= 1 ||
                avioanea[i - 1, j - 1] >= 1 ||
                avioanea[i - 1, j - 2] >= 1 ||
                avioanea[i - 1, j + 1] >= 1 ||
                avioanea[i - 1, j + 2] >= 1 ||
                avioanea[i - 3, j - 1] >= 1 ||
                avioanea[i - 3, j + 1] >= 1)
                    return 0;
            }
            else if (nr2 == 3)
            {

                if (avioanea[i, j] >= 1 ||
                avioanea[i, j - 1] >= 1 ||
                avioanea[i, j - 2] >= 1 ||
                avioanea[i, j - 3] >= 1 ||
                avioanea[i - 1, j - 1] >= 1 ||
                avioanea[i - 2, j - 1] >= 1 ||
                avioanea[i + 1, j - 1] >= 1 ||
                avioanea[i + 2, j - 1] >= 1 ||
                avioanea[i - 1, j - 3] >= 1 ||
                avioanea[i + 1, j - 3] >= 1)
                    return 0;
            }
            else if (nr2 == 4)
            {
                if (avioanea[i, j] >= 1 ||
                 avioanea[i, j + 1] >= 1 ||
                 avioanea[i, j + 2] >= 1 ||
                 avioanea[i, j + 3] >= 1 ||
                 avioanea[i - 1, j + 1] >= 1 ||
                 avioanea[i - 2, j + 1] >= 1 ||
                 avioanea[i + 1, j + 1] >= 1 ||
                 avioanea[i + 2, j + 1] >= 1 ||
                 avioanea[i - 1, j + 3] >= 1 ||
                 avioanea[i + 1, j + 3] >= 1)
                    return 0;
            }
            return 1;

        }
        private void MyClickB(object sender, EventArgs e)
        {
            Button o = sender as Button;
            int i = pozibuton(o);
            int j = pozjbuton(o);
            if (nr < 3)
            {
                if (nr1 == 1 && i + 3 < n && j + 2 < n && j - 2 >= 0)
                    if (verif(nr1, i, j,avioaneb) == 1)
                    {
                        b[i, j].BackColor = Color.Purple; avioaneb[i, j] = 2;
                        b[i + 1, j].BackColor = Color.Purple; avioaneb[i + 1, j] = 1;
                        b[i + 2, j].BackColor = Color.Purple; avioaneb[i + 2, j] = 1;
                        b[i + 3, j].BackColor = Color.Purple; avioaneb[i + 3, j] = 1;
                        b[i + 1, j - 1].BackColor = Color.Purple; avioaneb[i + 1, j - 1] = 1;
                        b[i + 1, j - 2].BackColor = Color.Purple; avioaneb[i + 1, j - 2] = 1;
                        b[i + 1, j + 1].BackColor = Color.Purple; avioaneb[i + 1, j + 1] = 1;
                        b[i + 1, j + 2].BackColor = Color.Purple; avioaneb[i + 1, j + 2] = 1;
                        b[i + 3, j - 1].BackColor = Color.Purple; avioaneb[i + 3, j - 1] = 1;
                        b[i + 3, j + 1].BackColor = Color.Purple; avioaneb[i + 3, j + 1] = 1;
                        nr1 = 0;
                        nr++;
                    }
                if (nr1 == 2 && i - 3 >= 0 && j + 2 < n && j - 2 >= 0)
                    if (verif(nr1, i, j,avioaneb) == 1)
                    {
                        b[i, j].BackColor = Color.SkyBlue; avioaneb[i, j] = 2;
                        b[i - 1, j].BackColor = Color.SkyBlue; avioaneb[i - 1, j] = 1;
                        b[i - 2, j].BackColor = Color.SkyBlue; avioaneb[i - 2, j] = 1;
                        b[i - 3, j].BackColor = Color.SkyBlue; avioaneb[i - 3, j] = 1;
                        b[i - 1, j - 1].BackColor = Color.SkyBlue; avioaneb[i - 1, j - 1] = 1;
                        b[i - 1, j - 2].BackColor = Color.SkyBlue; avioaneb[i - 1, j - 2] = 1;
                        b[i - 1, j + 1].BackColor = Color.SkyBlue; avioaneb[i - 1, j + 1] = 1;
                        b[i - 1, j + 2].BackColor = Color.SkyBlue; avioaneb[i - 1, j + 2] = 1;
                        b[i - 3, j - 1].BackColor = Color.SkyBlue; avioaneb[i - 3, j - 1] = 1;
                        b[i - 3, j + 1].BackColor = Color.SkyBlue; avioaneb[i - 3, j + 1] = 1;
                        nr1 = 0;
                        nr++;
                    }
                if (nr1 == 3 && j - 3 >= 0 && i - 2 >= 0 && i + 2 < n)
                    if (verif(nr1, i, j,avioaneb) == 1)
                    {
                        b[i, j].BackColor = Color.HotPink; avioaneb[i, j] = 2;
                        b[i, j - 1].BackColor = Color.HotPink; avioaneb[i, j - 1] = 1;
                        b[i, j - 2].BackColor = Color.HotPink; avioaneb[i, j - 2] = 1;
                        b[i, j - 3].BackColor = Color.HotPink; avioaneb[i, j - 3] = 1;
                        b[i - 1, j - 1].BackColor = Color.HotPink; avioaneb[i - 1, j - 1] = 1;
                        b[i - 2, j - 1].BackColor = Color.HotPink; avioaneb[i - 2, j - 1] = 1;
                        b[i + 1, j - 1].BackColor = Color.HotPink; avioaneb[i + 1, j - 1] = 1;
                        b[i + 2, j - 1].BackColor = Color.HotPink; avioaneb[i + 2, j - 1] = 1;
                        b[i - 1, j - 3].BackColor = Color.HotPink; avioaneb[i - 1, j - 3] = 1;
                        b[i + 1, j - 3].BackColor = Color.HotPink; avioaneb[i + 1, j - 3] = 1;
                        nr1 = 0;
                        nr++;
                    }
                if (nr1 == 4 && j + 3 < n && i - 2 >= 0 && i + 2 < n)
                    if (verif(nr1, i, j,avioaneb) == 1)
                    {
                        b[i, j].BackColor = Color.DarkSeaGreen; avioaneb[i, j] = 2;
                        b[i, j + 1].BackColor = Color.DarkSeaGreen; avioaneb[i, j + 1] = 1;
                        b[i, j + 2].BackColor = Color.DarkSeaGreen; avioaneb[i, j + 2] = 1;
                        b[i, j + 3].BackColor = Color.DarkSeaGreen; avioaneb[i, j + 3] = 1;
                        b[i - 1, j + 1].BackColor = Color.DarkSeaGreen; avioaneb[i - 1, j + 1] = 1;
                        b[i - 2, j + 1].BackColor = Color.DarkSeaGreen; avioaneb[i - 2, j + 1] = 1;
                        b[i + 1, j + 1].BackColor = Color.DarkSeaGreen; avioaneb[i + 1, j + 1] = 1;
                        b[i + 2, j + 1].BackColor = Color.DarkSeaGreen; avioaneb[i + 2, j + 1] = 1;
                        b[i - 1, j + 3].BackColor = Color.DarkSeaGreen; avioaneb[i - 1, j + 3] = 1;
                        b[i + 1, j + 3].BackColor = Color.DarkSeaGreen; avioaneb[i + 1, j + 3] = 1;
                        nr1 = 0;
                        nr++;
                    }


            }
            else
                MessageBox.Show("și tu și calculatorul ați completat toate avioanele, apasă pe butonul începe pentru a da start jocului :)");
            completare_random(avioanea);

        }
        private void completare_random(int[,] avioanea)
        {
            int pozi = r.Next(0, 10);
            int pozj = r.Next(0, 10);
            int nrrandom = r.Next(1, 5);
            if (nr2 < 3)
            {
                if (nrrandom == 1 && pozi + 3 < n && pozj + 2 < n && pozj - 2 >= 0 && verif(nrrandom, pozi, pozj,avioanea) == 1)
                {
                    avioanea[pozi, pozj] = 2;
                    avioanea[pozi + 1, pozj] = 1;
                    avioanea[pozi + 2, pozj] = 1;
                    avioanea[pozi + 3, pozj] = 1;
                    avioanea[pozi + 1, pozj - 1] = 1;
                    avioanea[pozi + 1, pozj - 2] = 1;
                    avioanea[pozi + 1, pozj + 1] = 1;
                    avioanea[pozi + 1, pozj + 2] = 1;
                    avioanea[pozi + 3, pozj - 1] = 1;
                    avioanea[pozi + 3, pozj + 1] = 1;
                    nr2++;
                }
                else if (nrrandom == 2 && pozi - 3 >= 0 && pozj + 2 < n && pozj - 2 >= 0 && verif(nrrandom, pozi, pozj,avioanea) == 1)
                {
                    avioanea[pozi, pozj] = 2;
                    avioanea[pozi - 1, pozj] = 1;
                    avioanea[pozi - 2, pozj] = 1;
                    avioanea[pozi - 3, pozj] = 1;
                    avioanea[pozi - 1, pozj - 1] = 1;
                    avioanea[pozi - 1, pozj - 2] = 1;
                    avioanea[pozi - 1, pozj + 1] = 1;
                    avioanea[pozi - 1, pozj + 2] = 1;
                    avioanea[pozi - 3, pozj - 1] = 1;
                    avioanea[pozi - 3, pozj + 1] = 1;
                    nr2++;

                }
                else if (nrrandom == 3 && pozj - 3 >= 0 && pozi - 2 >= 0 && pozi + 2 < n && verif(nrrandom, pozi, pozj,avioanea) == 1)
                {
                    avioanea[pozi, pozj] = 2;
                    avioanea[pozi, pozj - 1] = 1;
                    avioanea[pozi, pozj - 2] = 1;
                    avioanea[pozi, pozj - 3] = 1;
                    avioanea[pozi - 1, pozj - 1] = 1;
                    avioanea[pozi - 2, pozj - 1] = 1;
                    avioanea[pozi + 1, pozj - 1] = 1;
                    avioanea[pozi + 2, pozj - 1] = 1;
                    avioanea[pozi - 1, pozj - 3] = 1;
                    avioanea[pozi + 1, pozj - 3] = 1;
                    nr2++;
                }
                else if (nrrandom == 4 && pozj + 3 < n && pozi - 2 >= 0 && pozi + 2 < n && verif(nrrandom, pozi, pozj,avioanea) == 1)
                {
                    avioanea[pozi, pozj] = 2;
                    avioanea[pozi, pozj + 1] = 1;
                    avioanea[pozi, pozj + 2] = 1;
                    avioanea[pozi, pozj + 3] = 1;
                    avioanea[pozi - 1, pozj + 1] = 1;
                    avioanea[pozi - 2, pozj + 1] = 1;
                    avioanea[pozi + 1, pozj + 1] = 1;
                    avioanea[pozi + 2, pozj + 1] = 1;
                    avioanea[pozi - 1, pozj + 3] = 1;
                    avioanea[pozi + 1, pozj + 3] = 1;
                    nr2++;
                }
                else
                {
                    completare_random(avioanea);
                }
            }
        }

        private int pozibuton1(Button button)
        {
            int index = panel2.Controls.IndexOf(button);
            int i = index / n;
            return i;
        }
        private int pozjbuton1(Button button)
        {
            int index = panel2.Controls.IndexOf(button);
            int j = index % n;
            return j;
        }
        private void inconjorrandomi(int i1,int i)
        {
            int x=0, nr1, nr2;
            while (i1 - x > 0 && x < 3)
                x++;
            nr1 = x;
            x = 0;
            while (i1 + x < n && x < 3)
                x++;
            nr2 = x;
            i = r.Next(i1 - nr1, i1 + nr2 + 1);
                
        }
        private void inconjorrandomj(int j1, int j)
        {
            int x = 0, nr1, nr2;
            while (j1 - x > 0 && x < 3)
                x++;
            nr1 = x;
            x = 0;
            while (j1 + x < n && x < 3)
                x++;
            nr2 = x;
            j = r.Next(j1 - nr1, j1 + nr2 + 1);

        }
        private void MyClickA(object sender, EventArgs e)
        {
            if (okstart == 1)
            {
                Button o = sender as Button;
                int i = pozibuton1(o);
                int j = pozjbuton1(o);
                Image imgnimic = Properties.Resources.aer1;
                Image imgcorp = Properties.Resources.corp1;
                Image imgmort = Properties.Resources.cap1;
                if (avioanea[i, j] == 2)
                {
                    castigb++;
                    avioanea[i, j] = -1;
                    a[i, j].BackColor = Color.Red;
                    a[i, j].Image = imgmort;
                }
                else if (avioanea[i, j] == 1)
                {
                    avioanea[i, j] = -1;
                    a[i, j].BackColor = Color.Red;
                    a[i, j].Image = imgcorp;
                }
                else if (avioanea[i, j] == 0)
                {
                    a[i, j].BackColor = Color.Thistle;
                    a[i, j].Image = imgnimic;
                }
                if (ok == 0)
                {
                    i = r.Next(0, 10);
                    j = r.Next(0, 10);
                }
                else
                {
                    inconjorrandomi(i1, i);
                    inconjorrandomj(j1, j);
                }
                if (avioaneb[i,j]==-1)
                {
                    i = r.Next(0, 10);
                    j = r.Next(0, 10);
                }
                if (avioaneb[i, j] == 2)
                {
                    castiga++;
                    avioaneb[i, j] = -1;
                    b[i, j].Image = imgmort;
                }
                else if (avioaneb[i, j] == 1)
                {
                    avioaneb[i, j] = -1;
                    b[i, j].Image = imgcorp;
                    ok = 1;
                    i1 = i;
                    j1 = j;
                }
                else if (avioaneb[i, j] == 0)
                {
                    b[i, j].Image = imgnimic;
                    b[i, j].BackColor = Color.Thistle;
                    ok = 0;
                }
                if (castigb == 3)
                {
                    MessageBox.Show("BRAVO AI CASTIGAT!!!!");
                    panel2.Enabled = false;
                }
                if (castiga == 3)
                {
                    MessageBox.Show("AI PIERDUT! :( POATE O SĂ AI MAI MULT NOROC DATA VIITOARE");
                    panel2.Enabled = false;
                }
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (nr == 3 && nr2 == 3)
                okstart = 1;
            else
                MessageBox.Show("nu ați completat toate cele 3 avioane!");
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
