﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            // Установить свойство ControlBox в false
            this.ControlBox = false;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Form1 = new Form1();
            Form1.Show();

           
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.Show();


            this.Hide();
        }
    }
}
