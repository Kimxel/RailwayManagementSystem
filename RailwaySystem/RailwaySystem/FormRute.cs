using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RailwaySystem
{
    public partial class FormRute : Form
    {
        public FormRute()
        {
            InitializeComponent();
        }

        private void FormRute_Load(object sender, EventArgs e)
        {
            listBox1.Items.Add("Gambir → Semarangtawang");
            listBox1.Items.Add("Surabaya → Malang");
            listBox1.Items.Add("Bekasi → Pasar Senen");
            listBox1.Items.Add("Madiun → Jember");
            listBox1.Items.Add("Tegal → Padalarang");
            listBox1.Items.Add("Blitar → Kutoarjo");          
            listBox1.Items.Add("Cirebon → Solobalapan");
            listBox1.Items.Add("Sidoarjo → Mojokerto");
            listBox1.Items.Add("Brebes → Sukabumi");
            listBox1.Items.Add("Bojonegoro → Banyuwangi");
            listBox1.Items.Add("Malang → Sudimara");
            listBox1.Items.Add("Padalarang → Cicalengka");
            listBox1.Items.Add("Purwosari → Blitar");
        }
    }
}
