using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//  Projekt do dokonczenia
//  made by Wojciech Moc
//  2020
//  https://github.com/wojtek583/Programowanie4 - Zombie Apocalypse

namespace ZombieApocalypse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            this.Size = new System.Drawing.Size(495,344);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        PictureBox[,] Box;
        int czlowiekX, czlowiekY, ludzie, wojsko, zombie, tura;
        Random rnd = new Random();
           
        
        public void button1_Click(object sender, EventArgs e)
        {
            
            if(int.TryParse(textBox1.Text, out ludzie)!=true || int.TryParse(textBox2.Text, out wojsko) != true || int.TryParse(textBox3.Text, out zombie) != true || textBox1.Text==string.Empty)
            {
                MessageBox.Show("Musisz wpisac liczbe calkowita!");
            }
            else
            {
                timer1.Start();
                timer1.Interval = 5000;
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                plansza(czlowiekX,czlowiekY);
                label5.Text = $"Ludzie:\t  { textBox1.Text} \nWojsko:\t { textBox2.Text} \nZombie:\t { textBox3.Text} \nIlosc tur: {tura}";

                
                timer1.Tick += Timer1_Tick;
                
            }
            
        }
     
        private void Timer1_Tick(object sender, EventArgs e)
        {
            tura++;
            
        }

        public void plansza(int x, int y)
        {
            Box = new PictureBox[30, 30];
            for (int i = 0; i < 25; ++i)
            {
                for (int j = 0; j < 25; j++)
                {
                    Box[i, j] = new PictureBox();
                    Box[i, j].Top = 12 + i * 10;
                    Box[i, j].Left = 217 + j * 10;
                    Box[i, j].Width = 10;
                    Box[i, j].Height = 10;
                    Box[i, j].BackColor = Color.DarkCyan;
                    Box[i, j].BorderStyle = BorderStyle.FixedSingle;
                    Controls.Add(Box[i, j]);
                }
            }
            for (int i = 0; i < ludzie; i++)
            {
                
                Box[rnd.Next(0, 25), rnd.Next(0, 25)].BackColor = Color.Yellow;
            }
            for (int i = 0; i < zombie; i++)
            {
                Box[rnd.Next(0, 25), rnd.Next(0, 25)].BackColor = Color.Green;
            }
            for (int i = 0; i < wojsko; i++)
            {

                Box[rnd.Next(0, 25), rnd.Next(0, 25)].BackColor = Color.Orange;
            }
            /*    
             *    
             *    Albo obsluka click albo tooltip
            ToolTip tool = new ToolTip();
            tool.SetToolTip(Box[1, 1],"To jest pierwszy klocuch");
            */
            
            for (int i = 0; i < 25; ++i)
            {
                for (int j = 0; j < 25; j++)
                {
                    Box[i, j].Click += Form1_Click;
                    //Info(Box[1, 1]);
                }
            }
            

        }

        private void Info(PictureBox box)
        {
            if (box.BackColor==Color.Yellow)
            {
                MessageBox.Show("Zycie:\nPieniadze:", "Czlowiek");
            }
            if (box.BackColor == Color.Green)
            {
                MessageBox.Show("Zycie:\nPieniadze:\nLiczba Tur:", "Zombie");
            }
            if (box.BackColor == Color.Orange)
            {
                MessageBox.Show("Zycie:\nPieniadze:", "Wojsko");
            }
        }
      
        private void Form1_Click(object sender, EventArgs e)
        {
            if (BackColor == Color.Yellow)
            {
                MessageBox.Show("Zycie:\nPieniadze:", "Czlowiek");
            }
            else MessageBox.Show("dziala?");
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Buton");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Text = String.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
