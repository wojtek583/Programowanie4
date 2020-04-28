using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
        //  Project not finished yet
        //  Made by Wojciech Moc
        //  April, 2020
        //  https://github.com/wojtek583/Programowanie4 - Zombie Apocalypse

namespace ZombieApocalypse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Size = new System.Drawing.Size(495, 344);
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }

        int people, soldiers, zombies;
        int round=0;
        Random rnd = new Random();

        public void button1_Click(object sender, EventArgs e)
        {

            if (int.TryParse(textBox1.Text, out people) != true || int.TryParse(textBox2.Text, out soldiers) != true || int.TryParse(textBox3.Text, out zombies) != true || textBox1.Text == string.Empty)
            {
                MessageBox.Show("Must be non-decimal!");
            }
            else
            {
                map();
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                label5.Text = $"People:\t  { textBox1.Text} \nSoldiers:\t { textBox2.Text} \nZombies:\t { textBox3.Text} \nRounds: {round}";
            }

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            round++;
        }

        public void map()
        {
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    var btn = new Button
                    {
                        Text = (i + j).ToString(),
                        Width = 10,
                        Height = 10,
                        Top = 12 + i * 10,
                        Left = 217 + j * 10,
                        Tag = (i, j),
                        Parent = this
                    };
                    btn.Click += Form1_Click;
                }
            }
        }
        public class Human
        {
            public int coordX { get; set; }
            public int coordY { get; set; }
            public int Pieniadze { get; set; }
        }
        public class Zombie
        {
            public int coordX { get; set; }
            public int coordY { get; set; }
            public int Rounds { get; set; }
            public int Strength { get; set; }
        }
        public class Soldier
        {
            public int coordX { get; set; }
            public int coordY { get; set; }
            public int Money { get; set; }
            public int Durability { get; set; }
        }
        private void Form1_Click(object sender, EventArgs e)
        {
            var (a, b) = ((int, int))(sender as Control).Tag;
            MessageBox.Show($"x={a},  y={b}");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
