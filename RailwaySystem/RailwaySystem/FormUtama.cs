namespace RailwaySystem
{
    public partial class FormUtama : Form
    {
        public FormUtama()
        {
            InitializeComponent();
        }

        public void loadform(object Form)
        {
            if (this.panelMain.Controls.Count > 0)
                this.panelMain.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(f);
            this.panelMain.Tag = f;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadform(new FormPassenger());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new FormTrain());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadform(new FormTravel());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Anda yakin ingin logout?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormLogin logout = new FormLogin();
                logout.Show();
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadform(new FormReservation());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadform(new FormCancel());
        }
    }
}