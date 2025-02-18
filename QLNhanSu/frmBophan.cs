using System;
using System.Windows.Forms;
using BUS;
using DTO;
namespace QLNhanSu
{
    public partial class frmBophan : DevExpress.XtraEditors.XtraForm
    {
        bool flag = true;
        string macu="";
        public frmBophan()
        {
            InitializeComponent();
        }
        public void binding()
        {
            txt_mabophan.DataBindings.Clear();
            txt_mabophan.DataBindings.Add("Text",grid_bophan.DataSource,"MaBoPhan");
            txt_tenbophan.DataBindings.Clear();
            txt_tenbophan.DataBindings.Add("Text", grid_bophan.DataSource, "TenBoPhan");
        }
        public void loadFull()
        {
            txt_mabophan.Text = txt_tenbophan.Text = "";
            txt_mabophan.Enabled = txt_tenbophan.Enabled = false;
            grid_bophan.Enabled = bt_them.Enabled = true;
            bt_restart.Enabled = bt_capnhat.Enabled = false;
            lb_loi.Text = "";
            grid_bophan.DataSource = BUS_BoPhan.getDanhSachBoPhan();
            binding();
            if (grid_bophan.MainView.RowCount > 0)
            {
                bt_sua.Enabled = bt_xoa.Enabled = true;
            }
            else
            {
                bt_xoa.Enabled = bt_sua.Enabled = false;
            }
        }
        private void frmBophan_Load(object sender, EventArgs e)
        {
            loadFull();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            flag = true;
            txt_mabophan.DataBindings.Clear();
            txt_tenbophan.DataBindings.Clear();
            txt_mabophan.Text = txt_tenbophan.Text = "";
            txt_mabophan.Enabled = txt_tenbophan.Enabled = true;
            bt_capnhat.Enabled = bt_restart.Enabled = true;
            bt_them.Enabled = bt_xoa.Enabled = bt_sua.Enabled = false;
            grid_bophan.Enabled = false;
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            flag = false;
            macu = txt_mabophan.Text;
            txt_mabophan.DataBindings.Clear();
            txt_tenbophan.DataBindings.Clear();
            txt_mabophan.Enabled = txt_tenbophan.Enabled = true;
            bt_capnhat.Enabled = bt_restart.Enabled = true;
            bt_them.Enabled = bt_xoa.Enabled = bt_sua.Enabled = false;
            grid_bophan.Enabled = false;
        }

        private void bt_restart_Click(object sender, EventArgs e)
        {
            loadFull();
        }

        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                if (txt_mabophan.Text == "" || txt_tenbophan.Text == "")
                {
                    lb_loi.Text = "Hãy điền đầy đủ thông tin.";
                }
                else if (BUS_BoPhan.kiemTraTrungMaKhiThem(txt_mabophan.Text))
                {
                    lb_loi.Text = "Mã bộ phận này đã tồn tại.";
                }
                else
                {   
                    BoPhan boPhan = new BoPhan(
                        txt_mabophan.Text, 
                        txt_tenbophan.Text
                    );
                    if (BUS_BoPhan.insertBoPhan(boPhan))
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
                if (txt_mabophan.Text == "" || txt_tenbophan.Text == "")
                {
                    lb_loi.Text = "Hãy điền đầy đủ thông tin.";
                }
                else if (BUS_BoPhan.kiemTraTrungMaKhiSua(macu, txt_mabophan.Text))
                {
                    lb_loi.Text = "Mã bộ phận này đã tồn tại.";
                } 
                else
                {   
                    BoPhan boPhan = new BoPhan(
                        txt_mabophan.Text, 
                        txt_tenbophan.Text
                    );

                    if (BUS_BoPhan.updateBoPhan(boPhan, macu))
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
            if (BUS_BoPhan.kiemTraTrungMaKhiXoa(txt_mabophan.Text)) 
            {
                MessageBox.Show("Không thể xóa bộ phận này vì vẫn còn nhân viên thuộc bộ phận này.", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else 
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa chức vụ \"{txt_mabophan.Text}\" (Mã: {txt_mabophan.Text}) không?", 
                                                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (BUS_BoPhan.deleteBoPhan(txt_mabophan.Text))
                    {
                        MessageBox.Show("Chức vụ đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadFull();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại! Đã xảy ra lỗi trong quá trình xử lý.", 
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}