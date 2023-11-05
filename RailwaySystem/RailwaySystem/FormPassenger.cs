using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace RailwaySystem
{
    public partial class FormPassenger : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi Konn = new Koneksi();

        public FormPassenger()
        {
            InitializeComponent();
        }
        void Bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
        }

        void TampilTabel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Passenger", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Passenger");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Passenger";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        void CariTabel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Passenger where PId like '%" + textBox5.Text + "%' or PName like '%" + textBox5.Text + "%' ", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Passenger");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Passenger";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception G)
            {
                MessageBox.Show(G.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        void IdOtomatis()
        {
            long hitung;
            string urutan;
            SqlDataReader rd;
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("SELECT PId FROM Passenger WHERE PId in (select max(PId) from Passenger) order by PId desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["PId"].ToString().Length - 3, 3)) + 1;
                string kodeurutan = "000" + hitung;
                urutan = "PSG" + kodeurutan.Substring(kodeurutan.Length - 3, 3);
            }
            else
            {
                urutan = "PSG001";
            }
            rd.Close();
            textBox1.Enabled = true;
            textBox1.Text = urutan;
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TampilTabel();
            Bersihkan();
            IdOtomatis();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CariTabel();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["PId"].Value.ToString();
                textBox2.Text = row.Cells["PName"].Value.ToString();
                textBox3.Text = row.Cells["PAdd"].Value.ToString();
                textBox4.Text = row.Cells["PPhone"].Value.ToString();
                textBox6.Text = row.Cells["PId"].Value.ToString();

            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Passenger VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Penumpang " + textBox1.Text + " Berhasil Ditambahkan");
                    TampilTabel();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Data penumpang dengan ID = " + textBox1.Text + " sudah ada di database");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else if (MessageBox.Show("Yakin akan memperbarui data penumpang : " + textBox1.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("UPDATE Passenger SET PName = '" + textBox2.Text + "', PAdd ='" + textBox3.Text + "', PPhone ='" + textBox4.Text + "' WHERE PId = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Penumpang " + textBox1.Text + " Berhasil Diperbarui");
                    TampilTabel();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Data penumpang " + textBox1.Text + " gagal diperbarui");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data penumpang : " + textBox6 .Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Passenger WHERE PId = '" + textBox6.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Penumpang " + textBox6.Text + " Berhasil Dihapus");
                    TampilTabel();
                    Bersihkan();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }
    }
}
