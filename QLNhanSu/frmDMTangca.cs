using System;
using System.Windows.Forms;

using BUS;

namespace QLNhanSu
{
    public partial class frmDMTangca : DevExpress.XtraEditors.XtraForm
    {
        public frmDMTangca()
        {
            InitializeComponent();
        }
        private void frmDMTangca_Load(object sender, EventArgs e)
        {
            loadFull();
        }
        private void loadFull()
        {
            gridTangca.DataSource = BUS_TangCa.getDanhSachLoaiCa();
            txtMatc.DataBindings.Clear();
            txtMatc.DataBindings.Add("Text", gridTangca.DataSource, "maloai");
            txtTentc.DataBindings.Clear();
            txtTentc.DataBindings.Add("Text", gridTangca.DataSource, "tenca");
            txtTientc.DataBindings.Clear();
            txtTientc.DataBindings.Add("Text", gridTangca.DataSource, "heso");
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
        }

        public bool kt_SoThuc(string val)
        {
            try
            {
                float f = float.Parse(val);
                                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool kiemtra()
        {
            if (txtTientc.Text == "" || !kt_SoThuc(txtTientc.Text))
                return false;
            return true;
        }
        private void btSua_kt_Click(object sender, EventArgs e)
        {
            txtTientc.Enabled = true;
            layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            btSua_kt.Enabled = false;
        }

        private void btCapnhat_Click(object sender, EventArgs e)
        {
            if (kiemtra())
            {
                if (BUS_TangCa.updateTienLoaiCa(txtMatc.Text, float.Parse(txtTientc.Text)))
                {
                    layoutControlItem6.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
                    btSua_kt.Enabled = true;
                    txtTientc.Enabled = false;
                    loadFull();
                }
                else
                {
                    MessageBox.Show("Lỗi từ hệ thống! hãy liên hệ với bộ phận kỹ thuật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                MessageBox.Show("Hệ số tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}