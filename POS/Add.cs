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
    public partial class Add : Form
    {
        SQLiteConnection handler;
        DataGridView dataGridView1;

        public Add(SQLiteConnection _handler, DataGridView _dataGridView1)
        {
            InitializeComponent();

            handler = _handler;
            dataGridView1 = _dataGridView1;
        }

        private void add_record(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int scores = Convert.ToInt32(numericUpDown1.Value);

            string sql = "INSERT INTO `highscores` VALUES('"+name+"', "+scores+")";
            SQLiteCommand cmd = new SQLiteCommand(sql, handler);
            int result = cmd.ExecuteNonQuery();

            if (result > 0)
            {
                MessageBox.Show("Record added");
                dataGridView1.Rows.Add(new string[] { "", name, scores.ToString()});
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
