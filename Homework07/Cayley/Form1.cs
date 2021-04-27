using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cayley
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public int Th1 { get; set; } = 20;
        public int Th2 { get; set; } = 30;
        public double Per1 { get; set; } = 0.7;
        public double Per2 { get; set; } = 0.6;
        public int Leng { get; set; } = 100;
        public int N { get; set; } = 10;
        public Pen Pen { get; set; } = Pens.Red;
        private Pen[] Mypens { get; set; } = new Pen[] { Pens.Red, Pens.Purple, Pens.Blue, Pens.Orange, Pens.Green, Pens.Yellow };

        public Form1()
        {
            InitializeComponent();
            textBoxN.DataBindings.Add("Text", this, "N");
            textBoxPer1.DataBindings.Add("Text", this, "Per1");
            textBoxPer2.DataBindings.Add("Text", this, "Per2");
            textBoxTh1.DataBindings.Add("Text", this, "Th1");
            textBoxTh2.DataBindings.Add("Text", this, "Th2");
            textBoxLeng.DataBindings.Add("Text", this, "Leng");

            comboBox1.DataSource = Mypens;
            comboBox1.DisplayMember = "Color";
            comboBox1.DataBindings.Add("SelectedItem", this, "Pen");
        }


        public void DrawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            graphics.DrawLine(Pen,
         (int)x0, (int)y0, (int)x1, (int)y1);

            DrawCayleyTree(n - 1, x1, y1, Per1 * leng, th + Th1 * Math.PI / 180);
            DrawCayleyTree(n - 1, x1, y1, Per2 * leng, th - Th2 * Math.PI / 180);
        }

        public void PaintTree()
        {
            graphics = panel1.CreateGraphics();
            graphics.Clear(BackColor);
            Task.Run(() =>
            {
                DrawCayleyTree(N, panel1.Width / 2, panel1.Height / 1.5, Leng, -Math.PI / 2);
            });
        }


        private void Form1_Resize(object sender, EventArgs e)
        {
            PaintTree();
            //多个线程都在使用一个graphics对象，异常
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PaintTree();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            graphics = panel1.CreateGraphics();
            graphics.Clear(BackColor);
            DrawCayleyTree(N, MousePosition.X, MousePosition.Y, Leng, -Math.PI / 2);
        }
    }
}
