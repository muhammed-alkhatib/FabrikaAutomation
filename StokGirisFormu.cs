using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FabrikaAutomation
{
    public partial class StokGirisFormu : Form
    {
        private readonly string connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FabrikaDB;Integrated Security=True";

        public StokGirisFormu()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Stok Girişi";

            // لو تحب تضيف قيم جاهزة للـ Birim
            if (cmbBirim.Items.Count == 0)
            {
                cmbBirim.Items.AddRange(new object[] { "KG", "Adet", "Lt", "Metre" });
            }

            // زر الحفظ
            btnKaydet.Click -= btnKaydet_Click; // نتأكد ما فيه دبل حدث
            btnKaydet.Click += btnKaydet_Click;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtKod.Text == "" || txtAd.Text == "" || cmbBirim.Text == "" ||
                txtMiktar.Text == "" || txtMin.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal miktar, minSeviye;

            if (!decimal.TryParse(txtMiktar.Text, out miktar) ||
                !decimal.TryParse(txtMin.Text, out minSeviye))
            {
                MessageBox.Show("Miktar ve Minimum Seviye sayısal olmalıdır!", "Uyarı",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Stoklar (MalzemeKodu, MalzemeAdi, Birim, MevcutMiktar, MinimumSeviye) " +
                    "VALUES (@kod, @ad, @birim, @miktar, @min)", con);

                cmd.Parameters.AddWithValue("@kod", txtKod.Text);
                cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                cmd.Parameters.AddWithValue("@birim", cmbBirim.Text);
                cmd.Parameters.AddWithValue("@miktar", miktar);
                cmd.Parameters.AddWithValue("@min", minSeviye);

                cmd.ExecuteNonQuery();
                con.Close();
            }

            MessageBox.Show("Stok başarıyla eklendi!", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            // نحدّث جدول Stok Listesi
            RefreshEvents.RefreshStockList?.Invoke();

            // مسح الحقول
            txtKod.Text = "";
            txtAd.Text = "";
            cmbBirim.SelectedIndex = -1;
            txtMiktar.Text = "";
            txtMin.Text = "";
        }
    }
}
