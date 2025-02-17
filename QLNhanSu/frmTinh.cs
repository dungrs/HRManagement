using System;
using System.Windows.Forms;
using System.Collections.Generic;
using BUS;
using DTO;
namespace QLNhanSu
{
    public partial class frmTinh : DevExpress.XtraEditors.XtraForm
    {
        bool flag = true;
        string macu = "";
        public frmTinh()
        {
            InitializeComponent();
        }
        public void binding()
        {
            // Kiểm tra xem grid_tinh có dữ liệu không
            if (grid_tinh.DataSource == null || ((List<Tinh>)grid_tinh.DataSource).Count == 0)
            {
                txt_ma.DataBindings.Clear();
                txt_ten.DataBindings.Clear();
                return;
            }

            // Xóa ràng buộc cũ
            txt_ma.DataBindings.Clear();
            txt_ten.DataBindings.Clear();

            // Gán ràng buộc dữ liệu mới
            txt_ma.DataBindings.Add("Text", grid_tinh.DataSource, "Id", true, DataSourceUpdateMode.Never);
            txt_ten.DataBindings.Add("Text", grid_tinh.DataSource, "Tentinh", true, DataSourceUpdateMode.Never);
        }

        public void loadFull()
        {
            txt_ma.Text = txt_ten.Text = "";
            txt_ma.Enabled = txt_ten.Enabled = false;
            grid_tinh.Enabled = bt_them.Enabled = true;
            bt_restart.Enabled = bt_capnhat.Enabled = false;
            lb_loi.Text = "";
            grid_tinh.DataSource = BUS_Tinh.selectTinh();
            binding();
            if (grid_tinh.MainView.RowCount > 0)
            {
                bt_sua.Enabled = bt_xoa.Enabled = true;
            }
            else
            {
                bt_xoa.Enabled = bt_sua.Enabled = false;
            }
        }
        private void frmTinh_Load(object sender, EventArgs e)
        {
            loadFull();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            flag = true;
            txt_ma.DataBindings.Clear();
            txt_ten.DataBindings.Clear();
            txt_ma.Text = txt_ten.Text = "";
            txt_ma.Enabled = txt_ten.Enabled = true;
            bt_capnhat.Enabled = bt_restart.Enabled = true;
            bt_them.Enabled = bt_xoa.Enabled = bt_sua.Enabled = false;
            grid_tinh.Enabled = false;
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            flag = false;
            macu = txt_ma.Text;
            txt_ma.DataBindings.Clear();
            txt_ten.DataBindings.Clear();
            txt_ma.Enabled = txt_ten.Enabled = true;
            bt_capnhat.Enabled = bt_restart.Enabled = true;
            bt_them.Enabled = bt_xoa.Enabled = bt_sua.Enabled = false;
            grid_tinh.Enabled = false;
        }

        private void bt_restart_Click(object sender, EventArgs e)
        {
            loadFull();
        }

        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                if (txt_ma.Text == "" || txt_ten.Text == "")
                {
                    lb_loi.Text = "Hãy điền đầy đủ thông tin.";
                }
                else if (BUS_Tinh.kiemTraMaTinhKhiThem(txt_ma.Text))
                {
                    lb_loi.Text = "Mã tỉnh này đã tồn tại.";
                }
                else
                {
                    if (BUS_Tinh.insertTinh(txt_ma.Text, txt_ten.Text))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadFull();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi từ hệ thống, hãy liên hệ với bộ phận kỹ thuật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadFull();
                    }
                }
            }
            else
            {
                if (txt_ma.Text == "" || txt_ten.Text == "")
                {
                    lb_loi.Text = "Hãy điền đầy đủ thông tin.";
                }
                else if (BUS_Tinh.kiemTraMaTinhKhiSua(macu, txt_ma.Text))
                {
                    lb_loi.Text = "Mã tỉnh này đã tồn tại.";
                }
                else
                {
                    if (BUS_Tinh.updateTinh(macu, txt_ma.Text, txt_ten.Text))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadFull();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi từ hệ thống, hãy liên hệ với bộ phận kỹ thuật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadFull();
                    }
                }
            }
        }

        private void bt_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa Tỉnh có mã là " + txt_ma.Text + " hay không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                BUS_Tinh.deleteTinh(txt_ma.Text);
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadFull();
            }
        }
    }
}