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
    public partial class FormCancel : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataTable dt;
        private SqlDataReader dr;

        Koneksi Konn = new Koneksi();

        public FormCancel()
        {
            InitializeComponent();
        }

        void TampilTabel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Cancellation", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Cancellation");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Cancellation";
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
                cmd = new SqlCommand("Select * from Cancellation where CancID like '%" + textBox3.Text + "%' or TicketID like '%" + textBox3.Text + "%' ", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Cancellation");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Cancellation";
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

        void Bersihkan()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            textBox4.Text = "";
        }

        void ComboCancel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                string query = "Select TicketID from Reservation";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["TicketID"].ToString());
                    comboBox1.DisplayMember = (dr["TicketID"].ToString());
                    comboBox1.ValueMember = (dr["TicketID"].ToString());
                }
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
            cmd = new SqlCommand("SELECT CancID FROM Cancellation WHERE CancID in (select max(CancID) from Cancellation) order by CancID desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["CancID"].ToString().Length - 2, 2)) + 1;
                string kodeurutan = "000" + hitung;
                urutan = "CNCL" + kodeurutan.Substring(kodeurutan.Length - 2, 2);
            }
            else
            {
                urutan = "CNCL01";
            }
            rd.Close();
            textBox1.Enabled = true;
            textBox1.Text = urutan;
            conn.Close();
        }

        void IsiTiket()
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("SELECT TicketID FROM Reservation", conn);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TicketID", typeof(int));
            dt.Load(rdr);
            comboBox1.ValueMember = "TicketID";
            comboBox1.DataSource = dt;
        }


        private void Form7_Load(object sender, EventArgs e)
        {
            TampilTabel();
            Bersihkan();
            ComboCancel();
            IdOtomatis();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || comboBox1.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else if (MessageBox.Show("Yakin akan mengcancel data reservasi : " + comboBox1.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                try
                {                    
                    cmd = new SqlCommand("INSERT INTO Cancellation VALUES ('" + textBox1.Text + "', '" + comboBox1.Text + "', '" + dateTimePicker1.Text + "')", conn);
                    
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("DELETE Reservation WHERE TicketID = '" + comboBox1.Text + "'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data reservasi penumpang " + comboBox1.Text + " berhasil dibatalkan");
                    TampilTabel();
                    Bersihkan();
                    conn.Close();
                    //IsiTiket();
                }
                catch
                {
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data Cancel : " + textBox4.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Cancellation WHERE CancID = '" + textBox4.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Cancel " + textBox4.Text + " Berhasil Dihapus");
                    TampilTabel();
                    Bersihkan();
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            CariTabel();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["CancID"].Value.ToString();
                dateTimePicker1.Text = row.Cells["CancDate"].Value.ToString();
                comboBox1.Text = row.Cells["TicketID"].Value.ToString();
                textBox4.Text = row.Cells["CancID"].Value.ToString();
            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }
    }
    
}
