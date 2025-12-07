using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace FabrikaAutomation
{
    public partial class Form1 : RibbonForm
    {
        public Form1()
        {
            InitializeComponent();

            // تحويل الفورم إلى MDI
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Fabrika Automation";
        }

        // دالة عامّة لفتح الفورمات داخل MDI (Tabbed)
        private void OpenChild<T>() where T : Form, new()
        {
            // إذا الفورم مفتوح سابقاً → نفعّله فقط
            var existing = this.MdiChildren.FirstOrDefault(f => f is T);
            if (existing != null)
            {
                existing.Activate();
                return;
            }

            // إنشاء فورم جديد كـ MDI Child
            T frm = new T();
            frm.MdiParent = this;
            frm.Show();
        }

        // زر Stok Listesi في الـ Ribbon
        private void btnStokListesi_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChild<StokListesiForm>();
        }

        // زر Stok Girişi في الـ Ribbon
        private void btnStokGiris_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenChild<StokGirisFormu>();
        }
    }
}
