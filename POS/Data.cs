using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace POS
{
    class Data
    {
        public static void insert(SQLiteDataReader reader, DataGridView dataGridView1)
        {
            if (reader.HasRows)
            {
                dataGridView1.Rows.Clear();

                while (reader.Read())
                {
                    string[] row = { "", reader["name"].ToString(), reader["score"].ToString() };

                    dataGridView1.Rows.Add(row);
                }
            }
            else
            {
                MessageBox.Show("No result found !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
