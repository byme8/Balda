using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Balda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] x = new int[20];//нада динамично 
        int[] y = new int[20];//

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = dataGridView1.RowCount = 4;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = 35;
                dataGridView1.Columns[i].Resizable = DataGridViewTriState.False;
                dataGridView1.Rows[i].Resizable = DataGridViewTriState.False;
            }
            Balda.BaldaGame game = new BaldaGame();
        }
    }
}
