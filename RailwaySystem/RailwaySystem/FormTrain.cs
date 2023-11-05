using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RailwaySystem
{
    public partial class FormTrain : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi Konn = new Koneksi();

        public FormTrain()
        {
            InitializeComponent();
        }

        void MunculCombo()
        {
            comboBox1.Items.Add("Beroperasi");
            comboBox1.Items.Add("Tidak Beroperasi");
            
        }

        void Bersihkan()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void TampilTabel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Train", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Train");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Train";
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
                cmd = new SqlCommand("Select * from Train where TrainID like '%" + textBox4.Text + "%' or TrainName like '%" + textBox4.Text + "%' ", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Train");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Train";
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
            cmd = new SqlCommand("SELECT TrainID FROM Train WHERE TrainID in (select max(TrainID) from Train) order by TrainID desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["TrainID"].ToString().Length - 3, 3)) + 1;
                string kodeurutan = "000" + hitung;
                urutan = "TRN" + kodeurutan.Substring(kodeurutan.Length - 3, 3);
            }
            else
            {
                urutan = "TRN001";
            }
            rd.Close();
            textBox1.Enabled = true;
            textBox1.Text = urutan;
            conn.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            TampilTabel();
            MunculCombo();
            Bersihkan();
            IdOtomatis();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Train VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox5.Text + "', '" + comboBox1.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Kereta " + textBox1.Text + " Berhasil Ditambahkan");
                    TampilTabel();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Data kereta dengan ID = " + textBox1.Text + " sudah ada di database");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox5.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else if (MessageBox.Show("Yakin akan memperbarui data kereta : " + textBox1.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("UPDATE Train SET TrainName ='" + textBox2.Text + "',TrainCap ='" + textBox5.Text + "', TrainStatus ='" + comboBox1.Text + "' WHERE TrainID = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Kereta " + textBox1.Text + " Berhasil Diperbarui");
                    TampilTabel();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Data kereta " + textBox1.Text + " gagal diperbarui");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data kereta : " + textBox3.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Train WHERE TrainID = '" + textBox3.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Kereta " + textBox3.Text + " Berhasil Dihapus");
                    TampilTabel();
                    Bersihkan();
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            CariTabel();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["TrainID"].Value.ToString();
                textBox2.Text = row.Cells["TrainName"].Value.ToString();
                textBox5.Text = row.Cells["TrainCap"].Value.ToString();
                comboBox1.Text = row.Cells["TrainStatus"].Value.ToString();
                textBox3.Text = row.Cells["TrainID"].Value.ToString();

            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }
    }
}
