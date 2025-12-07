using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace FabrikaAutomation
{
    public partial class StokListesiForm : Form
    {
        string conStr = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FabrikaDB;Integrated Security=True";

        public StokListesiForm()
        {
            InitializeComponent();
            RefreshEvents.RefreshStockList = LoadStockData;
        }

        private void StokListesiForm_Load(object sender, EventArgs e)
        {
            LoadStockData();
            SetupRowAlerts();
        }

        // ============================================================
        // 1) تحميل البيانات من جدول Stoklar
        // ============================================================
        public void LoadStockData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(
                        "SELECT StokID, MalzemeKodu, MalzemeAdi, Birim, MevcutMiktar, MinimumSeviye, SonGuncellemeTarihi FROM Stoklar",
                        con);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Liste yüklenemedi: " + ex.Message);
            }
        }

        // ============================================================
        // 2) زر Yeni (إضافة)
        // ============================================================
        private void btnYeni_Click(object sender, EventArgs e)
        {
            StokGirisFormu frm = new StokGirisFormu();
            frm.ShowDialog();
        }

        // ============================================================
        // 3) زر Güncelle (تحديث)
        // ============================================================
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("StokID") == null)
            {
                MessageBox.Show("Lütfen güncellenecek satırı seçiniz!");
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("StokID"));
            decimal miktar = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("MevcutMiktar"));
            decimal min = Convert.ToDecimal(gridView1.GetFocusedRowCellValue("MinimumSeviye"));

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE Stoklar SET MevcutMiktar=@miktar, MinimumSeviye=@min, SonGuncellemeTarihi=GETDATE() WHERE StokID=@id",
                    con);

                cmd.Parameters.AddWithValue("@miktar", miktar);
                cmd.Parameters.AddWithValue("@min", min);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Stok başarıyla güncellendi!");
            LoadStockData();
        }

        // ============================================================
        // 4) زر Sil (حذف)
        // ============================================================
        private void btnSil_Click(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("StokID") == null)
            {
                MessageBox.Show("Silinecek satır seçilmedi!");
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("StokID"));

            if (MessageBox.Show("Bu ürünü silmek istiyor musunuz?",
                                "Sil", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Stoklar WHERE StokID=@id", con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Stok silindi!");
            LoadStockData();
        }

        // ============================================================
        // 5) تصدير إلى Excel
        // ============================================================
        private void btnExport_Click(object sender, EventArgs e)
        {
            string filePath = "StokListesi.xlsx";
            gridView1.ExportToXlsx(filePath);
            MessageBox.Show($"Excel oluşturuldu:\n{filePath}");
        }

        // ============================================================
        // 6) تنبيه نقص المخزون (تلوين الصف)
        // ============================================================
        private void SetupRowAlerts()
        {
            gridView1.RowStyle += (s, eArgs) =>
            {
                if (eArgs.RowHandle >= 0)
                {
                    decimal miktar = Convert.ToDecimal(
                        gridView1.GetRowCellValue(eArgs.RowHandle, "MevcutMiktar"));
                    decimal min = Convert.ToDecimal(
                        gridView1.GetRowCellValue(eArgs.RowHandle, "MinimumSeviye"));

                    if (miktar < min)
                    {
                        eArgs.Appearance.BackColor = Color.FromArgb(255, 200, 200);
                        eArgs.Appearance.ForeColor = Color.DarkRed;
                    }
                }
            };
        }
    }
}
