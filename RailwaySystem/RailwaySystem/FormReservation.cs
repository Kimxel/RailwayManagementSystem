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
    public partial class FormReservation : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi Konn = new Koneksi();

        public FormReservation()
        {
            InitializeComponent();
        }

        void TampilTabel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Reservation", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Reservation");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Reservation";
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
                cmd = new SqlCommand("Select * from Reservation where TicketID like '%" + textBox5.Text + "%' ", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Reservation");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Reservation";
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

        void ComboPenumpang()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                string query = "Select PId, PName from Passenger";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["PId"].ToString());
                    comboBox3.DisplayMember = (dr["PId"].ToString());
                    comboBox3.ValueMember = (dr["PName"].ToString());
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            string q = "SELECT PName FROM Passenger WHERE PId = '" + comboBox3.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox4.Text = dr[0].ToString();
            }
            conn.Close();
        }

        void ComboTravel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                string query = "Select TravCode from Travel";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox4.Items.Add(dr["TravCode"].ToString());
                    comboBox4.DisplayMember = (dr["TravCode"].ToString());
                    comboBox4.ValueMember = (dr["TravCode"].ToString());
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

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            string q = "SELECT TravDate, Src, Dest, Cost FROM Travel WHERE TravCode = '" + comboBox4.SelectedItem + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dateTimePicker1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
                textBox5.Text = dr[3].ToString();
            }
            conn.Close();
        }

        void IdOtomatis()
        {
            long hitung;
            string urutan;
            SqlDataReader rd;
            SqlConnection conn = Konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("SELECT TicketID FROM Reservation WHERE TicketID in (select max(TicketID) from Reservation) order by TicketID desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["TicketID"].ToString().Length - 2, 2)) + 1;
                string kodeurutan = "000" + hitung;
                urutan = "TCKT" + kodeurutan.Substring(kodeurutan.Length - 2, 2);
            }
            else
            {
                urutan = "TCKT01";
            }
            rd.Close();
            textBox1.Enabled = true;
            textBox1.Text = urutan;
            conn.Close();
        }

        void Bersihkan()
        {
            textBox1.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox4.Text = "";           
            dateTimePicker1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            TampilTabel();
            Bersihkan();
            ComboPenumpang();
            ComboTravel();
            IdOtomatis();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            CariTabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || comboBox3.Text.Trim() == "" || comboBox4.Text.Trim() == "" || textBox4.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox5.Text.Trim() == "" )
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Reservation VALUES ('" + textBox1.Text + "', '" + comboBox3.Text + "', '" + comboBox4.Text + "', '" + textBox4.Text + "', '" + dateTimePicker1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox5.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Reservasi " + textBox1.Text + " Berhasil Ditambahkan");
                    TampilTabel();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Data Reservasi dengan ID = " + textBox1.Text + " sudah ada di database");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || comboBox3.Text.Trim() == "" || comboBox4.Text.Trim() == "" || textBox4.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox5.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else if (MessageBox.Show("Yakin akan memperbarui data reservasi : " + textBox1.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("UPDATE Reservation SET PId ='" + comboBox3.Text + "',TravCode ='" + comboBox4.Text + "', Pname ='" + textBox4.Text + "' , TravDate ='" + dateTimePicker1.Text + "' , TravSrc ='" + textBox2.Text + "', TravDest ='" + textBox3.Text + "', TravCost ='" + textBox5.Text + "' WHERE TicketID = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Reservasi " + textBox1.Text + " Berhasil Diperbarui");
                    TampilTabel();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Data Reservasi " + textBox1.Text + " gagal diperbarui");

                }
            }
        }

        /*
        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data Reservation : " + textBox7.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Reservation WHERE TicketID = '" + textBox7.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Reservasi " + textBox1.Text + " Berhasil Dihapus");
                    TampilTabel();
                    Bersihkan();
                }
            }
        }
        */

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["TicketID"].Value.ToString();                
                comboBox3.Text = row.Cells["PId"].Value.ToString();
                comboBox4.Text = row.Cells["TravCode"].Value.ToString();
                textBox4.Text = row.Cells["Pname"].Value.ToString();
                dateTimePicker1.Text = row.Cells["TravDate"].Value.ToString();
                textBox2.Text = row.Cells["TravSrc"].Value.ToString();
                textBox3.Text = row.Cells["TravDest"].Value.ToString();
                textBox5.Text = row.Cells["TravCost"].Value.ToString();

            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }
    }
}
