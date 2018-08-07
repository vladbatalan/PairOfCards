using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Perechi_de_carti
{
    public partial class Form1 : Form
    {
        int[,] face = new int[4, 9];
        int[,] avanable = new int[4, 9];
        int[,] auxiliar = new int[4, 9];
        int[] numere = new int[36];
        Image[] cards = new Image[18];
        Button My1stBut = new Button();
        Button My2ndBut = new Button();
        int k=0, j=0,x=36,FrecventaCarte=0,linie,coloana,ok;
        int timp = 0,a;
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timp++;
            Timp.Text = "Timp: " + timp + " secunde";
        }

        private void Start_Click(object sender, EventArgs e)
        {
            ok = 1;
            Start.Enabled = false;
            pictureBox1.Visible = false;
            label1.Visible = false;
            cards[0] = Properties.Resources._2_t;
            cards[1] = Properties.Resources._3_t;
            cards[2] = Properties.Resources._4_t;
            cards[3] = Properties.Resources._5_t;
            cards[4] = Properties.Resources._6_t;
            cards[5] = Properties.Resources._7_t;
            cards[6] = Properties.Resources._8_t;
            cards[7] = Properties.Resources._9_t;
            cards[8] = Properties.Resources._10_t;
            cards[9] = Properties.Resources.J_t;
            cards[10] = Properties.Resources.J_i;
            cards[11] = Properties.Resources.Q_t;
            cards[12] = Properties.Resources.Q_i;
            cards[13] = Properties.Resources.K_t;
            cards[14] = Properties.Resources.K_i;
            cards[15] = Properties.Resources.As_t;
            cards[16] = Properties.Resources.As_i;
            cards[17] = Properties.Resources.Joker_color;
            x = 36;
            FrecventaCarte = 0;
            for (k = 0; k < 4; k++)
            {
                for (j = 0; j < 9; j++)
                {
                    avanable[k, j] = 1;
                    auxiliar[k, j] = 1;
                }
            }
            k = 0;
            while (k < 36)
            {
                numere[k] = k;
                k++;
            }
            k = 0;
            while (k < 4)
            {
                j = 0;
                while (j < 9)
                {
                    int c = rand.Next(0, x);
                    face[k,j] = numere[c];
                    while (c < x-1)
                    {
                        numere[c] = numere[c + 1];
                        c++;
                    }
                    x--;
                    j++;
                }
                k++;
            }
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button25.Enabled = true;
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = true;
            button29.Enabled = true;
            button30.Enabled = true;
            button31.Enabled = true;
            button32.Enabled = true;
            button33.Enabled = true;
            button34.Enabled = true;
            button35.Enabled = true;
            button36.Enabled = true;
            timer1.Enabled = true;
            timp = 0;
        }
        private void Flip()
        {
            for (k = 0; k < 4; k++)
            {
                for (j = 0; j < 9; j++)
                {
                    avanable[k, j] = 0;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (avanable[0, 0] == 1)
            {
                FrecventaCarte++;
                button1.Image = cards[face[0, 0] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button1;
                    linie = 0;
                    coloana = 0;
                    avanable[0, 0] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button1;
                    if (face[0, 0] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 0] = 0;
                        auxiliar[0, 0] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }
                        
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (avanable[0, 1] == 1) 
            {
                FrecventaCarte++;
                button2.Image = cards[face[0, 1] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button2;
                    linie = 0;
                    coloana = 1;
                    avanable[0, 1] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button2;
                    if (face[0, 1] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 1] = 0;
                        auxiliar[0, 1] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;

                        Flip();
                    }
                        
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (avanable[0, 2] == 1)
            {
                FrecventaCarte++;
                button3.Image = cards[face[0, 2] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button3;
                    linie = 0;
                    coloana = 2;
                    avanable[0, 2] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button3;
                    if (face[0, 2] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 2] = 0;
                        auxiliar[0, 2] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (avanable[0, 3] == 1)
            {
                FrecventaCarte++;
                button4.Image = cards[face[0, 3] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button4;
                    linie = 0;
                    coloana = 3;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button4;
                    if (face[0, 3] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 3] = 0;
                        auxiliar[0, 3] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (avanable[0, 4] == 1)
            {
                FrecventaCarte++;
                button5.Image = cards[face[0, 4] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button5;
                    linie = 0;
                    coloana = 4;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button5;
                    if (face[0, 4] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 4] = 0;
                        auxiliar[0, 4] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (avanable[0, 5] == 1)
            {
                FrecventaCarte++;
                button6.Image = cards[face[0, 5] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button6;
                    linie = 0;
                    coloana = 5;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button6;
                    if (face[0, 5] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 5] = 0;
                        auxiliar[0, 5] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (avanable[0, 6] == 1)
            {
                FrecventaCarte++;
                button7.Image = cards[face[0, 6] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button7;
                    linie = 0;
                    coloana = 6;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button7;
                    if (face[0, 6] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 6] = 0;
                        auxiliar[0, 6] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (avanable[0, 7] == 1)
            {
                FrecventaCarte++;
                button8.Image = cards[face[0, 7] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button8;
                    linie = 0;
                    coloana = 7;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button8;
                    if (face[0, 7] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 7] = 0;
                        auxiliar[0, 7] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (avanable[0, 8] == 1)
            {
                FrecventaCarte++;
                button9.Image = cards[face[0, 8] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button9;
                    linie = 0;
                    coloana = 8;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button9;
                    if (face[0, 8] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[0, 8] = 0;
                        auxiliar[0, 8] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (avanable[1, 0] == 1)
            {
                FrecventaCarte++;
                button10.Image = cards[face[1, 0] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button10;
                    linie = 1;
                    coloana = 0;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button10;
                    if (face[1, 0] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 0] = 0;
                        auxiliar[1, 0] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (avanable[1, 1] == 1)
            {
                FrecventaCarte++;
                button11.Image = cards[face[1, 1] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button11;
                    linie = 1;
                    coloana = 1;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button11;
                    if (face[1, 1] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 1] = 0;
                        auxiliar[1, 1] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (avanable[1, 2] == 1)
            {
                FrecventaCarte++;
                button12.Image = cards[face[1, 2] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button12;
                    linie = 1;
                    coloana = 2;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button12;
                    if (face[1, 2] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 2] = 0;
                        auxiliar[1, 2] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            if (avanable[1, 3] == 1)
            {
                FrecventaCarte++;
                button13.Image = cards[face[1, 3] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button13;
                    linie = 1;
                    coloana = 3;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button13;
                    if (face[1, 3] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 3] = 0;
                        auxiliar[1, 3] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {    
            if (avanable[1, 4] == 1)
            {
                FrecventaCarte++;
                button14.Image = cards[face[1, 4] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button14;
                    linie = 1;
                    coloana = 4;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button14;
                    if (face[1, 4] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 4] = 0;
                        auxiliar[1, 4] = 0;
                        auxiliar[linie, coloana] = 0;

                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {   
            if (avanable[1, 5] == 1)
            {
                FrecventaCarte++;
                button15.Image = cards[face[1, 5] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button15;
                    linie = 1;
                    coloana = 5;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button15;
                    if (face[1, 5] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 5] = 0;
                        auxiliar[1, 5] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {   
            if (avanable[1, 6] == 1)
            {
                FrecventaCarte++;
                button16.Image = cards[face[1, 6] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button16;
                    linie = 1;
                    coloana = 6;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button16;
                    if (face[1, 6] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 6] = 0;
                        auxiliar[1, 6] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {  
            if (avanable[1, 7] == 1)
            {
                FrecventaCarte++;
                button17.Image = cards[face[1, 7] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button17;
                    linie = 1;
                    coloana = 7;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button17;
                    if (face[1, 7] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 7] = 0;
                        auxiliar[1, 7] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {  
            if (avanable[1, 8] == 1)
            {
                FrecventaCarte++;
                button18.Image = cards[face[1, 8] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button18;
                    linie = 1;
                    coloana = 8;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button18;
                    if (face[1, 8] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[1, 8] = 0;
                        auxiliar[1, 8] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {   
            if (avanable[2, 0] == 1)
            {
                FrecventaCarte++;
                button19.Image = cards[face[2, 0] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button19;
                    linie = 2;
                    coloana = 0;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button19;
                    if (face[2, 0] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 0] = 0;
                        auxiliar[2, 0] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {  
            if (avanable[2, 1] == 1)
            {
                FrecventaCarte++;
                button20.Image = cards[face[2, 1] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button20;
                    linie = 2;
                    coloana = 1;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button20;
                    if (face[2, 1] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 1] = 0;
                        auxiliar[2, 1] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }

        }
        private void button21_Click(object sender, EventArgs e)
        {  
            if (avanable[2, 2] == 1)
            {
                FrecventaCarte++;
                button21.Image = cards[face[2, 2] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button21;
                    linie = 2;
                    coloana = 2;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button21;
                    if (face[2, 2] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 2] = 0;
                        auxiliar[2, 2] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {  
            if (avanable[2, 3] == 1)
            {
                FrecventaCarte++;
                button22.Image = cards[face[2, 3] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button22;
                    linie = 2;
                    coloana = 3;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button22;
                    if (face[1, 0] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 3] = 0;
                        auxiliar[2, 3] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }
        private void button23_Click(object sender, EventArgs e)
        {  
            if (avanable[2, 4] == 1)
            {
                FrecventaCarte++;
                button23.Image = cards[face[2, 4] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button23;
                    linie = 2;
                    coloana = 4;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button23;
                    if (face[2, 4] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 4] = 0;
                        auxiliar[2, 4] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {  
            if (avanable[2, 5] == 1)
            {
                FrecventaCarte++;
                button24.Image = cards[face[2, 5] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button24;
                    linie = 2;
                    coloana = 5;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button24;
                    if (face[2, 5] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 5] = 0;
                        auxiliar[2, 5] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {  
            if (avanable[2, 6] == 1)
            {
                FrecventaCarte++;
                button25.Image = cards[face[2, 6] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button25;
                    linie = 2;
                    coloana = 6;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button25;
                    if (face[2, 6] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 6] = 0;
                        auxiliar[2, 6] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {  
            if (avanable[2, 7] == 1)
            {
                FrecventaCarte++;
                button26.Image = cards[face[2, 7] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button26;
                    linie = 2;
                    coloana = 7;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button26;
                    if (face[2, 7] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 7] = 0;
                        auxiliar[2, 7] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {  
            if (avanable[2, 8] == 1)
            {
                FrecventaCarte++;
                button27.Image = cards[face[2, 8] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button27;
                    linie = 2;
                    coloana = 8;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button27;
                    if (face[2, 8] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[2, 8] = 0;
                        auxiliar[2, 8] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {  
            if (avanable[3, 0] == 1)
            {
                FrecventaCarte++;
                button28.Image = cards[face[3, 0] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button28;
                    linie = 3;
                    coloana = 0;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button28;
                    if (face[3, 0] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 0] = 0;
                        auxiliar[3, 0] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {  
            if (avanable[3, 1] == 1)
            {
                FrecventaCarte++;
                button29.Image = cards[face[3, 1] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button29;
                    linie = 3;
                    coloana = 1;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button29;
                    if (face[3, 1] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 1] = 0;
                        auxiliar[3, 1] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {  
            if (avanable[3, 2] == 1)
            {
                FrecventaCarte++;
                button30.Image = cards[face[3, 2] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button30;
                    linie = 3;
                    coloana = 1;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button30;
                    if (face[3, 2] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 2] = 0;
                        auxiliar[3, 2] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {  
            if (avanable[3, 3] == 1)
            {
                FrecventaCarte++;
                button31.Image = cards[face[3, 3] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button31;
                    linie = 3;
                    coloana = 3;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button31;
                    if (face[3, 3] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 3] = 0;
                        auxiliar[3, 3] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {  
            if (avanable[3, 4] == 1)
            {
                FrecventaCarte++;
                button32.Image = cards[face[3, 4] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button32;
                    linie = 1;
                    coloana = 0;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button32;
                    if (face[3, 4] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 4] = 0;
                        auxiliar[3, 4] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {  
            if (avanable[3, 5] == 1)
            {
                FrecventaCarte++;
                button33.Image = cards[face[3, 5] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button33;
                    linie = 3;
                    coloana = 5;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button33;
                    if (face[3, 5] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 5] = 0;
                        auxiliar[3, 5] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a == 1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a == 3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a == 4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {  
            if (avanable[3, 6] == 1)
            {
                FrecventaCarte++;
                button34.Image = cards[face[3, 6] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button34;
                    linie = 3;
                    coloana = 6;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button34;
                    if (face[3, 6] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 6] = 0;
                        auxiliar[3, 6] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            a = rand.Next(1, 5);
                            if (a ==1)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (a == 2)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (a==3)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (a==4)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {  
            if (avanable[3, 7] == 1)
            {
                FrecventaCarte++;
                button35.Image = cards[face[3, 7] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button35;
                    linie = 3;
                    coloana = 7;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button35;
                    if (face[3, 7] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 7] = 0;
                        auxiliar[3, 7] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;
                            if (timp < 101)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (timp > 100 && timp < 201)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (timp > 200 && timp < 301)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (timp > 300)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void button36_Click(object sender, EventArgs e)
        {
            if (avanable[3, 8] == 1)
            {
                FrecventaCarte++;
                button36.Image = cards[face[3, 8] % 18];
                if (FrecventaCarte % 2 == 1)
                {
                    My1stBut = button36;
                    linie = 3;
                    coloana = 8;
                    avanable[linie, coloana] = 0;
                }
                if (FrecventaCarte % 2 == 0)
                {
                    My2ndBut = button36;
                    if (face[3, 8] % 18 == face[linie, coloana] % 18)
                    {
                        avanable[3, 8] = 0;
                        auxiliar[3, 8] = 0;
                        auxiliar[linie, coloana] = 0;
                        ok = 1;
                        for (k = 0; k < 4; k++)
                        {
                            for (j = 0; j < 9; j++)
                            {
                                if (auxiliar[k, j] != 0)
                                {
                                    ok = 0;
                                }
                            }
                        }
                        if (ok == 1)
                        {
                            YouWon();
                            timer1.Enabled = false;
                            label1.Visible = true;
                            label1.Text = "Ai reusit!" + "\n" + "Timp: " + timp;

                            if (timp < 101)
                            {
                                pictureBox1.Image = Properties.Resources.Naruto_Win;
                            }
                            if (timp > 100 && timp < 201)
                            {
                                pictureBox1.Image = Properties.Resources.They_grow_so_fast;
                            }
                            if (timp > 200 && timp < 301)
                            {
                                pictureBox1.Image = Properties.Resources.Yugi_GoodJob;
                            }
                            if (timp > 300)
                            {
                                pictureBox1.Image = Properties.Resources.Yoshio_GoodJob;
                            }
                            pictureBox1.Visible = true;
                        }
                    }
                    else
                    {
                        ShowCard.Enabled = true;
                        Flip();
                    }

                }
            }
        }

        private void Restart_Click(object sender, EventArgs e)
        {
            for (k = 0; k < 4; k++)
            {
                for (j = 0; j < 9; j++)
                {
                    avanable[k, j] = 0;
                }
            }
            timer1.Enabled = false;
            Timp.Text = "Timp: 0 secunde";
            pictureBox1.Visible = false;
            label1.Visible = false;
            button1.Image = Properties.Resources.Fund;
            button2.Image = Properties.Resources.Fund;
            button3.Image = Properties.Resources.Fund;
            button4.Image = Properties.Resources.Fund;
            button5.Image = Properties.Resources.Fund;
            button6.Image = Properties.Resources.Fund;
            button7.Image = Properties.Resources.Fund;
            button8.Image = Properties.Resources.Fund;
            button9.Image = Properties.Resources.Fund;
            button10.Image = Properties.Resources.Fund;
            button11.Image = Properties.Resources.Fund;
            button12.Image = Properties.Resources.Fund;
            button13.Image = Properties.Resources.Fund;
            button14.Image = Properties.Resources.Fund;
            button15.Image = Properties.Resources.Fund;
            button16.Image = Properties.Resources.Fund;
            button17.Image = Properties.Resources.Fund;
            button18.Image = Properties.Resources.Fund;
            button19.Image = Properties.Resources.Fund;
            button20.Image = Properties.Resources.Fund;
            button21.Image = Properties.Resources.Fund;
            button22.Image = Properties.Resources.Fund;
            button23.Image = Properties.Resources.Fund;
            button24.Image = Properties.Resources.Fund;
            button25.Image = Properties.Resources.Fund;
            button26.Image = Properties.Resources.Fund;
            button27.Image = Properties.Resources.Fund;
            button28.Image = Properties.Resources.Fund;
            button29.Image = Properties.Resources.Fund;
            button30.Image = Properties.Resources.Fund;
            button31.Image = Properties.Resources.Fund;
            button32.Image = Properties.Resources.Fund;
            button33.Image = Properties.Resources.Fund;
            button34.Image = Properties.Resources.Fund;
            button35.Image = Properties.Resources.Fund;
            button36.Image = Properties.Resources.Fund;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button25.Enabled = true;
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = true;
            button29.Enabled = true;
            button30.Enabled = true;
            button31.Enabled = true;
            button32.Enabled = true;
            button33.Enabled = true;
            button34.Enabled = true;
            button35.Enabled = true;
            button36.Enabled = true;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            button14.Visible = true;
            button15.Visible = true;
            button16.Visible = true;
            button17.Visible = true;
            button18.Visible = true;
            button19.Visible = true;
            button20.Visible = true;
            button21.Visible = true;
            button22.Visible = true;
            button23.Visible = true;
            button24.Visible = true;
            button25.Visible = true;
            button26.Visible = true;
            button27.Visible = true;
            button28.Visible = true;
            button29.Visible = true;
            button30.Visible = true;
            button31.Visible = true;
            button32.Visible = true;
            button33.Visible = true;
            button34.Visible = true;
            button35.Visible = true;
            button36.Visible = true;
            Start.Enabled = true;
        }
        private void YouWon()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button25.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;
            button29.Enabled = false;
            button30.Enabled = false;
            button31.Enabled = false;
            button32.Enabled = false;
            button33.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            button16.Visible = false;
            button17.Visible = false;
            button18.Visible = false;
            button19.Visible = false;
            button20.Visible = false;
            button21.Visible = false;
            button22.Visible = false;
            button23.Visible = false;
            button24.Visible = false;
            button25.Visible = false;
            button26.Visible = false;
            button27.Visible = false;
            button28.Visible = false;
            button29.Visible = false;
            button30.Visible = false;
            button31.Visible = false;
            button32.Visible = false;
            button33.Visible = false;
            button34.Visible = false;
            button35.Visible = false;
            button36.Visible = false;
        }
        private void ShowCard_Tick(object sender, EventArgs e)
        {
            for (k = 0; k < 4; k++)
            {
                for (j = 0; j < 9; j++)
                {
                    avanable[k, j] = auxiliar[k, j];
                }
            }
            My1stBut.Image = Properties.Resources.Fund;
            My2ndBut.Image = Properties.Resources.Fund;
            ShowCard.Enabled = false;
        }


       

        
    }
}
