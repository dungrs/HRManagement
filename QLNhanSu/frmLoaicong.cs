using System;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLNhanSu
{
    public partial class frmLoaicong : DevExpress.XtraEditors.XtraForm
    {
        public frmLoaicong()
        {
            InitializeComponent();
        }

        private void frmLoaicong_Load(object sender, EventArgs e)
        {
            Loadtoanbothongtin();
        }
        public void Loadtoanbothongtin()
        {
            grid_loaicong.DataSource = BUS.BUS_LoaiCong.getDanhSachLoaiCong();
            txtMaloaicong.DataBindings.Clear();
            txtMaloaicong.DataBindings.Add("Text", grid_loaicong.DataSource, "maloai");
            txtTenloaicong.DataBindings.Clear();
            txtTenloaicong.DataBindings.Add("Text", grid_loaicong.DataSource, "tenloai");
            txtHeso.DataBindings.Clear();
            txtHeso.DataBindings.Add("Text", grid_loaicong.DataSource, "heso");
        }
        #region them
        private void them()
        {
            frmThemloaicong frm = new frmThemloaicong();
            frm.load = new frmThemloaicong.reload(Loadtoanbothongtin);
            frm.Show();
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            them();
        }
        private void menustrip_loaicong_them_Click(object sender, EventArgs e)
        {
            them();
        }
        #endregion
        #region xoa
        private void Xoa()
        {
            if (grid_loaicong.MainView.RowCount > 0)
            {
                if (txtMaloaicong.Text == "CN" || txtMaloaicong.Text == "1" || txtMaloaicong.Text == "L")
                {
                    MessageBox.Show("Không thể xóa được loại công này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Bạn có muốn xóa loại công có mã " + txtMaloaicong.Text + " hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (BUS_LoaiCong.deleteLoaiCong(txtMaloaicong.Text))
                        {
                            Loadtoanbothongtin();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa loại công này do đang được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Bạn không có loại công nào để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        private void menustrip_loaicong_xoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        #endregion
        #region sua
        private void sua()
        {
            LoaiCong lc = new LoaiCong();
            lc.Maloai = txtMaloaicong.Text;
            lc.Tenloai = txtTenloaicong.Text;
            lc.Heso = txtHeso.Text;
            frmSualoaicong frm = new frmSualoaicong(lc);
            frm.reload = new frmSualoaicong.Reload(Loadtoanbothongtin);
            frm.Show();
        }
        private void btsua_Click(object sender, EventArgs e)
        {
            sua();
        }
        private void menustrip_loaicong_sua_Click(object sender, EventArgs e)
        {
            sua();
        }
        #endregion
        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void memustrip_loaicong_them_Click(object sender, EventArgs e)
        {
            Loadtoanbothongtin();
        }

        private void btDong_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}