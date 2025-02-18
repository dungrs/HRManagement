using System;
using System.Windows.Forms;

using BUS;
using DTO;
namespace QLNhanSu
{
    public partial class frmChucvu : DevExpress.XtraEditors.XtraForm
    {
        bool flag = true;
        string macu = "";
        public frmChucvu()
        {
            InitializeComponent();
        }
        public void binding()
        {
            txt_machucvu.DataBindings.Clear();
            txt_machucvu.DataBindings.Add("Text", grid_chucvu.DataSource, "Machucvu");
            txt_tenchucvu.DataBindings.Clear();
            txt_tenchucvu.DataBindings.Add("Text", grid_chucvu.DataSource, "Tenchucvu");
            txt_hsl.DataBindings.Clear();
            txt_hsl.DataBindings.Add("Text", grid_chucvu.DataSource, "hsl");
        }
        public void loadFull()
        {
            txt_machucvu.Text = txt_tenchucvu.Text = "";
            txt_machucvu.Enabled = txt_tenchucvu.Enabled = txt_hsl.Enabled = false;
            grid_chucvu.Enabled = bt_them.Enabled = true;
            bt_restart.Enabled = bt_capnhat.Enabled = false;
            lb_loi.Text = "";
            grid_chucvu.DataSource = BUS_ChucVu.getDanhSachChucVu();
            binding();
            if (grid_chucvu.MainView.RowCount > 0)
            {
                bt_sua.Enabled = bt_xoa.Enabled = true;
            }
            else
            {
                bt_xoa.Enabled = bt_sua.Enabled = false;
            }
        }
        private void frmChucvu_Load(object sender, EventArgs e)
        {
            loadFull();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            flag = true;
            txt_machucvu.DataBindings.Clear();
            txt_tenchucvu.DataBindings.Clear();
            txt_hsl.DataBindings.Clear();
            txt_machucvu.Text = txt_tenchucvu.Text = txt_hsl.Text = "";
            txt_machucvu.Enabled = txt_tenchucvu.Enabled = txt_hsl.Enabled = true;
            bt_capnhat.Enabled = bt_restart.Enabled = true;
            bt_them.Enabled = bt_xoa.Enabled = bt_sua.Enabled = false;
            grid_chucvu.Enabled = false;
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            flag = false;
            macu = txt_machucvu.Text;
            txt_machucvu.DataBindings.Clear();
            txt_tenchucvu.DataBindings.Clear();
            txt_machucvu.Enabled = txt_tenchucvu.Enabled = txt_hsl.Enabled = true;
            bt_capnhat.Enabled = bt_restart.Enabled = true;
            bt_them.Enabled = bt_xoa.Enabled = bt_sua.Enabled = false;
            grid_chucvu.Enabled = false;
        }

        private void bt_restart_Click(object sender, EventArgs e)
        {
            loadFull();
        }

        private void bt_capnhat_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                if (string.IsNullOrWhiteSpace(txt_machucvu.Text) || 
                    string.IsNullOrWhiteSpace(txt_tenchucvu.Text) || 
                    string.IsNullOrWhiteSpace(txt_hsl.Text))
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (BUS_ChucVu.kiemTraTrungMaKhiThem(txt_machucvu.Text))
                {
                    MessageBox.Show("Mã chức vụ này đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        ChucVu chucVu = new ChucVu(
                            txt_machucvu.Text,
                            txt_tenchucvu.Text,
                            float.Parse(txt_hsl.Text)
                        );

                        if (BUS_ChucVu.insertChucVu(chucVu))
                        {
                            MessageBox.Show("Thêm chức vụ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadFull();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi hệ thống! Hãy liên hệ với bộ phận kỹ thuật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Hệ số lương không hợp lệ. Vui lòng nhập số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txt_machucvu.Text) || string.IsNullOrWhiteSpace(txt_tenchucvu.Text))
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (BUS_ChucVu.kiemTraTrungMaKhiSua(macu, txt_machucvu.Text))
                {
                    MessageBox.Show("Mã chức vụ này đã tồn tại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        ChucVu chucVu = new ChucVu(
                            txt_machucvu.Text,
                            txt_tenchucvu.Text,
                            float.Parse(txt_hsl.Text)
                        );

                        if (BUS_ChucVu.updateChucVu(chucVu, macu))
                        {
                            MessageBox.Show("Cập nhật chức vụ thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadFull();
                        }
                        else
                        {
                            MessageBox.Show("Lỗi hệ thống! Hãy liên hệ với bộ phận kỹ thuật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Hệ số lương không hợp lệ. Vui lòng nhập số.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (BUS_ChucVu.kiemTraTrungMaKhiXoa(txt_machucvu.Text)) 
            {
                MessageBox.Show("Không thể xóa chức vụ này vì vẫn còn nhân viên thuộc chức vụ này.", 
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else 
            {
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa chức vụ \"{txt_tenchucvu.Text}\" (Mã: {txt_machucvu.Text}) không?", 
                                                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (BUS_ChucVu.deleteChucVu(txt_machucvu.Text))
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