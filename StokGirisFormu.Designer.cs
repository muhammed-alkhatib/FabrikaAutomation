using System;
using System.Drawing;
using System.Windows.Forms;

namespace FabrikaAutomation
{
    partial class StokGirisFormu
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblKod;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.Label lblBirim;
        private System.Windows.Forms.Label lblMiktar;
        private System.Windows.Forms.Label lblMin;

        private System.Windows.Forms.TextBox txtKod;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtMiktar;
        private System.Windows.Forms.TextBox txtMin;

        private System.Windows.Forms.ComboBox cmbBirim;
        private System.Windows.Forms.Button btnKaydet;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Designer code
        private void InitializeComponent()
        {
            this.lblKod = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.lblBirim = new System.Windows.Forms.Label();
            this.lblMiktar = new System.Windows.Forms.Label();
            this.lblMin = new System.Windows.Forms.Label();

            this.txtKod = new System.Windows.Forms.TextBox();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();

            this.cmbBirim = new System.Windows.Forms.ComboBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // --- LABEL STYLES ---
            Font labelFont = new Font("Segoe UI", 11F, FontStyle.Bold);
            Color labelColor = Color.FromArgb(40, 40, 40);

            // Malzeme Kodu Label
            this.lblKod.Text = "Malzeme Kodu";
            this.lblKod.Font = labelFont;
            this.lblKod.ForeColor = labelColor;
            this.lblKod.Location = new Point(60, 40);

            // Malzeme Adı Label
            this.lblAd.Text = "Malzeme Adı";
            this.lblAd.Font = labelFont;
            this.lblAd.ForeColor = labelColor;
            this.lblAd.Location = new Point(60, 110);

            // Birim Label
            this.lblBirim.Text = "Birim";
            this.lblBirim.Font = labelFont;
            this.lblBirim.ForeColor = labelColor;
            this.lblBirim.Location = new Point(60, 180);

            // Mevcut Miktar Label
            this.lblMiktar.Text = "Mevcut Miktar";
            this.lblMiktar.Font = labelFont;
            this.lblMiktar.ForeColor = labelColor;
            this.lblMiktar.Location = new Point(60, 250);

            // Minimum Seviye Label
            this.lblMin.Text = "Minimum Seviye";
            this.lblMin.Font = labelFont;
            this.lblMin.ForeColor = labelColor;
            this.lblMin.Location = new Point(60, 320);

            // --- TextBoxes ---
            Font inputFont = new Font("Segoe UI", 11.5F);
            Size inputSize = new Size(300, 34);

            this.txtKod.Font = inputFont;
            this.txtKod.Location = new Point(60, 70);
            this.txtKod.Size = inputSize;

            this.txtAd.Font = inputFont;
            this.txtAd.Location = new Point(60, 140);
            this.txtAd.Size = inputSize;

            this.cmbBirim.Font = inputFont;
            this.cmbBirim.Location = new Point(60, 210);
            this.cmbBirim.Size = inputSize;
            this.cmbBirim.Items.AddRange(new object[] { "Adet", "Kg", "Litre", "Metre" });

            this.txtMiktar.Font = inputFont;
            this.txtMiktar.Location = new Point(60, 280);
            this.txtMiktar.Size = inputSize;

            this.txtMin.Font = inputFont;
            this.txtMin.Location = new Point(60, 350);
            this.txtMin.Size = inputSize;

            // --- Save Button ---
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnKaydet.Location = new Point(60, 410);
            this.btnKaydet.Size = new Size(300, 45);
            this.btnKaydet.BackColor = Color.RoyalBlue;
            this.btnKaydet.ForeColor = Color.White;
            this.btnKaydet.FlatStyle = FlatStyle.Flat;
            this.btnKaydet.Click += new EventHandler(this.btnKaydet_Click);

            // --- Add Controls ---
            this.Controls.Add(this.lblKod);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.lblBirim);
            this.Controls.Add(this.lblMiktar);
            this.Controls.Add(this.lblMin);

            this.Controls.Add(this.txtKod);
            this.Controls.Add(this.txtAd);
            this.Controls.Add(this.cmbBirim);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.txtMin);

            this.Controls.Add(this.btnKaydet);

            this.ClientSize = new Size(450, 500);
            this.Name = "StokGirisFormu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
    }
}
