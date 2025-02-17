using System;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLNhanSu
{
    public partial class frmThemphucap : DevExpress.XtraEditors.XtraForm
    {
        public frmThemphucap()
        {
            InitializeComponent();
        }
        public delegate void Reload();
        public Reload reload;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void frmThemphucap_Load(object sender, EventArgs e)
        {
            loadthongtin();
        }
        public void loadthongtin()
        {
            image_no_tenloai.Visible = true;
            image_no_maloai.Visible = true;
            image_no_hesoluong.Visible = true;
            image_yes_tenloai.Visible = false;
            image_yes_maloai.Visible = false;
            image_yes_hesoluong.Visible = false;
        }
        public bool kt_Songuyen(string val)
        {
            try
            {
                int s = int.Parse(val);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool kiemtraNhap()
        {
            bool kt = true;
            if (txtMaloaipc.Text == "" || txtMaloaipc.Text == "" || txtMaloaipc.Text == "")
            {
                kt = false;
                MessageBox.Show("Bạn vẫn chưa điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtMaloaipc.Text.Length >= 5)
            {
                kt = false;
                MessageBox.Show("Mã phụ cấp không được quá 4 ký tự, xin bạn hãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTenloaipc.Text.Length >= 76)
            {
                kt = false;
                MessageBox.Show("Tên phụ cấp không được quá 75 ký tự, xin bạn hãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BUS_PhuCap.kiemTraTrungTen(txtTenloaipc.Text))
            {
                kt = false;
                MessageBox.Show("Tên phụ cấp đã tồn tại với một tên khác, xin bạn hãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BUS_LoaiCong.kiemTraTrungMaKhiThem(txtMaloaipc.Text))
            {
                kt = false;
                MessageBox.Show("Mã phụ cấp đã tồn tại, bạn hãy thay đổi mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BUS_LoaiCong.kiemTraTrungMaKhiThem(txtMaloaipc.Text))
            {
                kt = false;
                MessageBox.Show("Lỗi từ hệ thống, vị trí lỗi (DAO_PhuCap), hãy liên hệ với bộ phận kỹ thuật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!kt_Songuyen(txtTien.Text.ToString()))
            {
                kt = false;
                MessageBox.Show("Tiền phụ cấp bạn nhập không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return kt;
        }
        private void _insert()
        {
            PhuCap pc = new PhuCap();
            pc.Maloaipc = txtMaloaipc.Text;
            pc.Tenloai = txtTenloaipc.Text;
            pc.Tien = txtTien.Text;
            if (kiemtraNhap())
            {
                if (BUS_PhuCap.insertPhuCap(pc))
                {
                    MessageBox.Show("Thêm thành công");
                    reload();
                    this.Close();
                }
            }
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            _insert();
        }

        private void txtMaloaipc_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMaloaipc.Text.Length >= 5)
            {
                image_no_maloai.Visible = true;
                image_yes_maloai.Visible = false;
                txtMaloaipc.ToolTip = "Mã phụ cấp không được lớn hơn 4 ký tự";
            }
            else if (txtMaloaipc.Text == "")
            {
                image_no_maloai.Visible = true;
                image_yes_maloai.Visible = false;
                txtMaloaipc.ToolTip = "không được để trống thông tin này";
            }
            else if (BUS_PhuCap.kiemTraTrungMaKhiThem(txtMaloaipc.Text))
            {
                image_no_maloai.Visible = true;
                image_yes_maloai.Visible = false;
                txtMaloaipc.ToolTip = "Mã phụ cấp đã tồn tại";
            }
            else if (BUS_PhuCap.kiemTraTrungMaKhiThem(txtMaloaipc.Text))
            {
                image_no_maloai.Visible = true;
                image_yes_maloai.Visible = false;
                txtMaloaipc.ToolTip = "Lỗi";
            }
            else
            {
                image_no_maloai.Visible = false;
                image_yes_maloai.Visible = true;
                txtMaloaipc.ToolTip = "Nhập mã phụ cấp";
            }
        }

        private void txtTenloaipc_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenloaipc.Text == "")
            {
                image_no_tenloai.Visible = true;
                image_yes_tenloai.Visible = false;
                txtTenloaipc.ToolTip = "Không được để trống nội dung này";
            }
            else if (txtTenloaipc.Text.Length >= 76)
            {
                image_no_tenloai.Visible = true;
                image_yes_tenloai.Visible = false;
                txtTenloaipc.ToolTip = "Không được quá 75 ký tự";
            }
            else if (BUS_PhuCap.kiemTraTrungTen(txtTenloaipc.Text))
            {
                image_no_tenloai.Visible = true;
                image_yes_tenloai.Visible = false;
                txtTenloaipc.ToolTip = "Tên phụ cấp đã tồn tại với một tên khác";
            }
            else
            {
                image_no_tenloai.Visible = false;
                image_yes_tenloai.Visible = true;
                txtTenloaipc.ToolTip = "Nhập tên phụ cấp";
            }
        }

        private void txtTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtTien_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTien.Text == "")
            {
                image_no_hesoluong.Visible = true;
                image_yes_hesoluong.Visible = false;
                txtTien.ToolTip = "Nội dung này không được để trống";
            }
            else
            {
                image_no_hesoluong.Visible = false;
                image_yes_hesoluong.Visible = true;
                txtTien.ToolTip = "Nhập vào số tiền phụ cấp";
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}