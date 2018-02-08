using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace POS
{
    public partial class Form1 : Form
    {
        SQLiteConnection handler;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            handler = new SQLiteConnection("Data Source=pos.sqlite;Version=3;");
            handler.Open();

            string sql = "SELECT * FROM highscores";
            SQLiteCommand command = new SQLiteCommand(sql, handler);
            SQLiteDataReader reader = command.ExecuteReader();

            Data.insert(reader, dataGridView1);
        }

        private void fetch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM highscores WHERE name LIKE '%" + searchbox.Text + "%'";
            SQLiteCommand command = new SQLiteCommand(sql, handler);
            SQLiteDataReader reader = command.ExecuteReader();

            Data.insert(reader, dataGridView1);
        }

        private void show_add_form(object sender, EventArgs e)
        {
            Add addForm = new Add(handler, dataGridView1);
            addForm.Show();
        }
    }
}
