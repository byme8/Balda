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

        Balda.BaldaGame game = new BaldaGame();
        int x=-1, y=-1;
        DataGridViewRow[] rows;

        private void CheckData(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                return;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Length > 1)
            {
                MessageBox.Show("В ячейке может быть только один символ", "Внимание...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                return;
            }

            if (x != -1)
                dataGridView1.Rows[y].Cells[x].Value = "";

                x = e.ColumnIndex;
                y = e.RowIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Scells = dataGridView1.SelectedCells;
            string maybeWord = "";

            for (int i = Scells.Count-1; i >=0 ; i--)
                maybeWord += Scells[i].Value;

            if (lsFirstPlayer.FindString(maybeWord) != -1 || lsSecondPlayer.FindString(maybeWord) != -1)
            {
                MessageBox.Show("Слово " + maybeWord + " уже использовалось.", "Внимание...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (x != -1)
                if (!dataGridView1.Rows[y].Cells[x].Selected)
                    dataGridView1.Rows[y].Cells[x].Value = "";

            if (game.CheckWord(maybeWord))
            {
                if (game.FirstPlayer)
                {
                    lsFirstPlayer.Items.Add(maybeWord);
                    console.Text = "Ход второго игрока";
                    game.NextPlayer();
                }
                else
                {
                    lsSecondPlayer.Items.Add(maybeWord);
                    console.Text = "Ход первого игрока.";
                    game.NextPlayer();
                }
                x = -1; 
                y = -1;
            }
            else 
            {
                MessageBox.Show(maybeWord + ": нет такого слова", "Внимание...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string r = game.GetRandWord();
            while (r.Length > 8)
                r = game.GetRandWord();

            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 10;
            dataGridView1.RowCount = 11;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = 30;
                dataGridView1.Columns[i].Resizable = DataGridViewTriState.False;
                dataGridView1.Rows[i].Resizable = DataGridViewTriState.False;
            }
            for (int i = 0; i < r.Length; i++)
                dataGridView1.Rows[5].Cells[1 + i].Value = r[i];
            console.Text = "Ход первого игрока.";
        }
    }
}
