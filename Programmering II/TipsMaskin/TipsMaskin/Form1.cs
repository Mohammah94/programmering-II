using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipsMaskin
{
    public partial class Form1 : Form
    {
        FileLoader f = new FileLoader();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)  // Köd här.
        {
            textBox1.Text = string.Empty;
            // deklarera variable som innehåller alla olika texter att välja. 
            Random random = new Random();
            int num = random.Next(f.boklista.Count);

           textBox1.Text +=  f.boklista[num];



        }
    }
}
