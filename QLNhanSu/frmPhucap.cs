using System;
using System.Windows.Forms;

using BUS;
using DTO;

namespace QLNhanSu
{
    public partial class frmPhucap : DevExpress.XtraEditors.XtraForm
    {
        public frmPhucap()
        {
            InitializeComponent();
        }
        #region load
        private void frmPhucap_Load(object sender, EventArgs e)
        {
            LoadFullDanhsach();
        }
        private void LoadFullDanhsach()
        {
            grid_phucap.DataSource = BUS_PhuCap.getDanhSachPhuCap();
            txtMapc.DataBindings.Clear();
            txtMapc.DataBindings.Add("Text", grid_phucap.DataSource, "maloaipc");
            txtTenpc.DataBindings.Clear();
            txtTenpc.DataBindings.Add("Text", grid_phucap.DataSource, "tenloai");
            txtTienpc.DataBindings.Clear();
            txtTienpc.DataBindings.Add("Text", grid_phucap.DataSource, "tien");
        }
        private void menustrip_pc_restart_Click(object sender, EventArgs e)
        {
            LoadFullDanhsach();
        }
        #endregion
        #region them
        private void them()
        { 
            frmThemphucap frm = new frmThemphucap();
            frm.reload = new frmThemphucap.Reload(LoadFullDanhsach);
            frm.Show();
        }
        private void btThemPc_Click(object sender, EventArgs e)
        {
            them();
        }
        private void menustrip_pc_them_Click(object sender, EventArgs e)
        {
            them();
        }
        #endregion
        #region xoa
        private void xoa()
        {
            if (grid_phucap.MainView.RowCount > 0)
            {
                    if (MessageBox.Show("Bạn có muốn xóa phụ cấp có mã " + txtMapc.Text + " hay không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (BUS_PhuCap.deletePhuCap(txtMapc.Text))
                        {
                            LoadFullDanhsach();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa phụ cấp này do đang được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
            }
            else
            {
                MessageBox.Show("Bạn không có phụ cấp nào để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btXoaPc_Click(object sender, EventArgs e)
        {
            xoa();
        }
        private void menustrip_pc_xoa_Click(object sender, EventArgs e)
        {
            xoa();
        }
        #endregion
        #region sua
        private void sua()
        {
            if (grid_phucap.MainView.RowCount > 0)
            {
                PhuCap pc = new PhuCap();
                pc.Maloaipc = txtMapc.Text;
                pc.Tenloai = txtTenpc.Text;
                pc.Tien = txtTienpc.Text;
                frmSuaphucap frm = new frmSuaphucap(pc);
                frm.reload = new frmSuaphucap.Reload(LoadFullDanhsach);
                frm.Show();
            }
            else
                MessageBox.Show("không tồn tại phụ cập để sửa","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }
        private void btsuaPc_Click(object sender, EventArgs e)
        {
            sua();
        }
        private void menustrip_pc_sua_Click(object sender, EventArgs e)
        {
            sua();
        }
        #endregion
        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}