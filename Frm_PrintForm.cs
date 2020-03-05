using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccountingReportsManagement.MODULES;
namespace AccountingReportsManagement
{
    public partial class Frm_PrintForm : Form
    {

        public Frm_PrintForm()
        {
            InitializeComponent();
        }

        private void Frm_PrintForm_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gunaDataGridView1.Rows.Count-1; i++)
            {
                foreach (DataGridViewRow dr in gunaDataGridView1.Rows)
                {

                    textBox1.Text = dr.Cells[0].Value.ToString();
                }
            }
        }
            private void gunaDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

        private void gunaDataGridView1_Click(object sender, EventArgs e)
        {
            label1.Text = gunaDataGridView1.Rows.Count.ToString();
        }
    }
    }
