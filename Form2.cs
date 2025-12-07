using System;
using System.Data;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace FabrikaAutomation
{
    // الوراثة من XtraForm
    public partial class Form2 : DevExpress.XtraEditors.XtraForm
    {
        // ***** سلسلة الاتصال: تأكد من أنها صحيحة لسيرفرك *****
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=FabrikaDB;Integrated Security=True";

        public Form2()
        {
            InitializeComponent();

            // جلب البيانات عند فتح النموذج
            StokVerileriniGetir();
        }

        // دالة جلب بيانات المخزون وعرضها في gridControl1
        private void StokVerileriniGetir()
        {
            // الاستعلام لجلب الأعمدة المطلوبة من جدول Stoklar
            string query = "SELECT StokID, MalzemeKodu, MalzemeAdi, Birim, MevcutMiktar, MinimumSeviye FROM Stoklar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    // البحث عن gridControl1 وربط البيانات به
                    if (this.Controls.Find("gridControl1", true).Length > 0 && this.Controls.Find("gridControl1", true)[0] is DevExpress.XtraGrid.GridControl gridControl)
                    {
                        gridControl.DataSource = dataTable;
                    }
                    else
                    {
                        XtraMessageBox.Show("Hata: GridControl tasarımda bulunamadı.", "Tasarım Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    XtraMessageBox.Show($"Veritabanı bağlantı hatası veya sorgu hatası oluştu!\nHata: {ex.Message}", "Kritik Hata", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.Close();
                }
            }
        }
    }
}