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
    public partial class FormTravel : Form
    {
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;

        Koneksi Konn = new Koneksi();

        public FormTravel()
        {
            InitializeComponent();
        }

        void TampilTabel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Travel", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Travel");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Travel";
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

        void MunculCombo()
        {
            comboBox1.Items.Add("Gambir");
            comboBox1.Items.Add("Surabaya");
            comboBox1.Items.Add("Bekasi");
            comboBox1.Items.Add("Madiun");
            comboBox1.Items.Add("Tegal");
            comboBox1.Items.Add("Blitar");
            comboBox1.Items.Add("Cirebon");
            comboBox1.Items.Add("Sidoarjo");
            comboBox1.Items.Add("Brebes");
            comboBox1.Items.Add("Bojonegoro");
            comboBox1.Items.Add("Malang");
            comboBox1.Items.Add("Padalarang");
            comboBox1.Items.Add("Purwosari");


            comboBox2.Items.Add("Semarangtawang");
            comboBox2.Items.Add("Malang");
            comboBox2.Items.Add("Pasar Senen");
            comboBox2.Items.Add("Jember");
            comboBox2.Items.Add("Padalarang");
            comboBox2.Items.Add("Kutoarjo");
            comboBox2.Items.Add("Solobalapan");
            comboBox2.Items.Add("Mojokerto");
            comboBox2.Items.Add("Bandung");
            comboBox2.Items.Add("Sukabumi");
            comboBox2.Items.Add("Banyuwangi");
            comboBox2.Items.Add("Sudimara");
            comboBox2.Items.Add("Cicalengka");
            comboBox2.Items.Add("Blitar");
        }

        void ComboTrainID()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                string query = "Select TrainID from Train WHERE TrainStatus = 'Beroperasi'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    comboBox3.Items.Add(dr["TrainID"].ToString());
                    comboBox3.DisplayMember = (dr["TrainID"].ToString());
                    comboBox3.ValueMember = (dr["TrainID"].ToString());
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

        void CariTabel()
        {
            SqlConnection conn = Konn.GetConn();
            try
            {
                conn.Open();
                cmd = new SqlCommand("Select * from Travel where TravCode like '%" + textBox5.Text + "%' or TrainID like '%" + textBox5.Text + "%' ", conn);
                ds = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Travel");
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Travel";
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
            cmd = new SqlCommand("SELECT TravCode FROM Travel WHERE TravCode in (select max(TravCode) from Travel) order by TravCode desc", conn);
            rd = cmd.ExecuteReader();
            rd.Read();
            if (rd.HasRows)
            {
                hitung = Convert.ToInt64(rd[0].ToString().Substring(rd["TravCode"].ToString().Length - 3, 3)) + 1;
                string kodeurutan = "000" + hitung;
                urutan = "TRV" + kodeurutan.Substring(kodeurutan.Length - 3, 3);
            }
            else
            {
                urutan = "TRV001";
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
            textBox3.Text = "";
            dateTimePicker1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            TampilTabel();
            MunculCombo();
            Bersihkan();
            ComboTrainID();
            IdOtomatis();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            CariTabel(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || comboBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("INSERT INTO Travel VALUES ('" + textBox1.Text + "', '" + dateTimePicker1.Value + "', '" + comboBox3.Text + "', '" + comboBox1.Text + "', '" + comboBox2.Text + "', '" + textBox3.Text + "')", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Travel " + textBox1.Text + " Berhasil Ditambahkan");
                    TampilTabel();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Data Travel dengan ID = " + textBox1.Text + " sudah ada di database");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || dateTimePicker1.Text.Trim() == "" || comboBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "" || comboBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Data Belum Lengkap!");
            }
            else if (MessageBox.Show("Yakin akan memperbarui data travel : " + textBox1.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                try
                {
                    cmd = new SqlCommand("UPDATE Travel SET TravDate ='" + dateTimePicker1.Text + "',TrainID ='" + comboBox3.Text + "', Src ='" + comboBox1.Text + "' , Dest ='" + comboBox2.Text + "' , Cost ='" + textBox3.Text + "' WHERE TravCode = '" + textBox1.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Travel " + textBox1.Text + " Berhasil Diperbarui");
                    TampilTabel();
                    Bersihkan();
                }
                catch
                {
                    MessageBox.Show("Data travel " + textBox1.Text + " gagal diperbarui");

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin akan menghapus data travel : " + textBox4.Text + " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlConnection conn = Konn.GetConn();
                {
                    cmd = new SqlCommand("DELETE Travel WHERE TravCode = '" + textBox4.Text + "'", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Travel " + textBox4.Text + " Berhasil Dihapus");
                    TampilTabel();
                    Bersihkan();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["TravCode"].Value.ToString();
                dateTimePicker1.Text = row.Cells["TravDate"].Value.ToString();
                comboBox3.Text = row.Cells["TrainID"].Value.ToString();
                comboBox1.Text = row.Cells["Src"].Value.ToString();
                comboBox2.Text = row.Cells["Dest"].Value.ToString();
                textBox3.Text = row.Cells["Cost"].Value.ToString();
                textBox4.Text = row.Cells["TravCode"].Value.ToString();

            }
            catch (Exception X)
            {
                MessageBox.Show(X.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var harga1 = "80000";
            var harga2 = "65000";
            var harga3 = "90000";
            var harga4 = "70000";
            var harga5 = "85000";
            var harga6 = "60000";
            var harga7 = "55000";

            if (comboBox1.Text == "Gambir" && comboBox2.Text == "Semarangtawang" || comboBox1.Text == "Sidoarjo" && comboBox2.Text == "Mojokerto")
            {
                textBox3.Text = (harga1);
            }
            else if (comboBox1.Text == "Surabaya" && comboBox2.Text == "Malang" || comboBox1.Text == "Cirebon" && comboBox2.Text == "Solobalapan")
            {
                textBox3.Text = (harga2);
            }
            else if (comboBox1.Text == "Bekasi" && comboBox2.Text == "Pasar Senen" || comboBox1.Text == "Blitar" && comboBox2.Text == "Kutoarjo")
            {
                textBox3.Text = (harga3);
            }
            else if (comboBox1.Text == "Madiun" && comboBox2.Text == "Jember" || comboBox1.Text == "Tegal" && comboBox2.Text == "Padalarang")
            {
                textBox3.Text = (harga4);
            }
            else if (comboBox1.Text == "Brebes" && comboBox2.Text == "Sukabumi" || comboBox1.Text == "Purwosari" && comboBox2.Text == "Blitar")
            {
                textBox3.Text = (harga5);
            }
            else if (comboBox1.Text == "Bojonegoro" && comboBox2.Text == "Banyuwangi" || comboBox1.Text == "Padalarang" && comboBox2.Text == "Cicalengka")
            {
                textBox3.Text = (harga6);
            }
            else if (comboBox1.Text == "Malang" && comboBox2.Text == "Sudimara")
            {
                textBox3.Text = (harga7);
            }
            else
            {
                MessageBox.Show("Tidak ada rute dari stasiun " + comboBox1.SelectedItem + " menuju stasiun " + comboBox2.SelectedItem);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormRute fr = new FormRute();
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Bersihkan();
        }
    }
}
