using System;
using System.Windows.Forms;
using BUS;

namespace QLNhanSu
{
    public partial class frmKhautru : DevExpress.XtraEditors.XtraForm
    {
        public frmKhautru()
        {
            InitializeComponent();
        }

        private void frmKhautru_Load(object sender, EventArgs e)
        {
            loadFull();
        }
        private void loadFull()
        {
            gridKhautru.DataSource = BUS_KhauTru.getDanhSachKhauTru();
            txtMakhautru.DataBindings.Clear();
            txtMakhautru.DataBindings.Add("Text", gridKhautru.DataSource, "makt");
            txtTenkhautru.DataBindings.Clear();
            txtTenkhautru.DataBindings.Add("Text", gridKhautru.DataSource, "tenkt");
            txtTienkhautru.DataBindings.Clear();
            txtTienkhautru.DataBindings.Add("Text", gridKhautru.DataSource, "tien");
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }
        private bool kiemtra()
        {
            if (txtTienkhautru.Text == "")
                return false;
            return true;
        }
        private void btSua_kt_Click(object sender, EventArgs e)
        {
            txtTienkhautru.Enabled = true;
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            btSua_kt.Enabled = false;
        }

        private void btCapnhat_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {
                if (BUS_KhauTru.updateTienKhauTru(txtMakhautru.Text, float.Parse(txtTienkhautru.Text)))
                {
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                    btSua_kt.Enabled = true;
                    txtTienkhautru.Enabled = false;
                    loadFull();
                }
                else
                {
                    MessageBox.Show("Lỗi từ hệ thống! hãy liên hệ với bộ phận kỹ thuật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Hãy nhập số tiền","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        private void txtTienkhautru_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}