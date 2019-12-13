using AccountingReportsManagement.MODULES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccountingReportsManagement
{
    public partial class Frm_ChartofAccnt : Form
    {
        public Frm_ChartofAccnt()
        {
            InitializeComponent();
        }

        private void Frm_ChartofAccnt_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = false;
            button2.Visible = true;
           
        }
        int x = 0;
        int y = -350;
        private void timer1_Tick(object sender, EventArgs e)
        {
           
            if (panel1.Location.X != y)
            {
                panel1.Location = new Point(x, 167);
                x -= 50;
                if (y == -700)
                {
                    button1.Visible = false;
                }
                
            }else { 
                timer1.Enabled = false;
                y = -700;    
            }

          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = true;
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled==false){
                panel1.Location = new Point(x, 167);
                x += 50;
                if (panel1.Location.X > 0)
                {
                    y = -350;
                    panel1.Location = new Point(0, 167);
                    timer2.Enabled = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
          
        }
        ClientSupplier asd = new ClientSupplier();
        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = asd.Load();
        }
    }
}

