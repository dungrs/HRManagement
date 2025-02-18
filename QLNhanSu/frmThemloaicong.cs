using System;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLNhanSu
{
    public partial class frmThemloaicong : DevExpress.XtraEditors.XtraForm
    {
        public delegate void reload();
        public reload load;
        public frmThemloaicong()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public bool KT_sothuc(string val)
        {
            try
            {
                float t = float.Parse(val);
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
            if (txtMaloaicong.Text == "" || txtTenloaicong.Text=="" || txtHesoluong.Text=="")
            {
                kt = false;
                MessageBox.Show("Bạn vẫn chưa điền đầy đủ thông tin","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else if (txtMaloaicong.Text.Length >= 5)
            {
                kt = false;
                MessageBox.Show("Mã loại công không được quá 4 ký tự, xin bạn hãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtTenloaicong.Text.Length >= 76)
            {
                kt = false;
                MessageBox.Show("Tên loại công không được quá 75 ký tự, xin bạn hãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!BUS_LoaiCong.kiemTraTrungTen(txtTenloaicong.Text))
            {
                kt = false;
                MessageBox.Show("Tên loại công đã trùng với một tên khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!KT_sothuc(txtHesoluong.Text))
            {
                kt = false;
                MessageBox.Show("Hệ số lương phải là kiểu số, xin bạn hãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BUS_LoaiCong.kiemTraTrungMaKhiThem(txtMaloaicong.Text))
            {
                kt = false;
                MessageBox.Show("Mã loại công đã tồn tại, bạn hãy thay đổi mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BUS_LoaiCong.kiemTraTrungMaKhiThem(txtMaloaicong.Text))
            {
                kt = false;
                MessageBox.Show("Lỗi từ hệ thống, vị trí lỗi (DAO_Loaicong), hãy liên hệ với bộ phận kỹ thuật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return kt;
        }
        private void txtMaloaicong_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMaloaicong.Text.Length >= 5)
            {
                image_no_maloaicong.Visible = true;
                image_yes_maloaicong.Visible = false;
                txtMaloaicong.ToolTip = "Mã loại công không được lớn hơn 4 ký tự";
            }
            else if(txtMaloaicong.Text=="")
            {
                image_no_maloaicong.Visible = true;
                image_yes_maloaicong.Visible = false;
                txtMaloaicong.ToolTip = "không được để trống thông tin này";
            }
            else if (BUS_LoaiCong.kiemTraTrungMaKhiThem(txtMaloaicong.Text))
            {
                image_no_maloaicong.Visible = true;
                image_yes_maloaicong.Visible = false;
                txtMaloaicong.ToolTip = "Mã loại công đã tồn tại";
            }
            else if (BUS_LoaiCong.kiemTraTrungMaKhiThem(txtMaloaicong.Text))
            {
                image_no_maloaicong.Visible = true;
                image_yes_maloaicong.Visible = false;
                txtMaloaicong.ToolTip = "Lỗi";
            }
            else
            {
                image_no_maloaicong.Visible = false;
                image_yes_maloaicong.Visible = true;
                txtMaloaicong.ToolTip = "Nhập mã loại công";
            }
        }
        private void frmThemloaicong_Load(object sender, EventArgs e)
        {

        }

        private void txtTenloaicong_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTenloaicong.Text == "")
            {
                image_no_tenloaicong.Visible = true;
                image_yes_tenloaicong.Visible = false;
                txtTenloaicong.ToolTip = "Không được để trống nội dung này";
            }
            else if (txtTenloaicong.Text.Length >= 76)
            {
                image_no_tenloaicong.Visible = true;
                image_yes_tenloaicong.Visible = false;
                txtTenloaicong.ToolTip = "Không được quá 75 ký tự";
            }
            else if (BUS_LoaiCong.kiemTraTrungTen(txtTenloaicong.Text))
            {
                image_no_tenloaicong.Visible = true;
                image_yes_tenloaicong.Visible = false;
                txtTenloaicong.ToolTip = "Tên loại công đã trùng với một tên khác";
            }
            else
            {
                image_no_tenloaicong.Visible = false;
                image_yes_tenloaicong.Visible = true;
                txtTenloaicong.ToolTip = "Nhập tên loạ công";
            }
        }

        private void txtHesoluong_KeyUp(object sender, KeyEventArgs e)
        {
            if (!KT_sothuc(txtHesoluong.Text))
            {
                image_no_hesoluong.Visible = true;
                image_yes_hesoluong.Visible = false;
                txtHesoluong.ToolTip = "Đây phải là kiểu số";
            }
            else if (txtHesoluong.Text == "")
            {
                image_no_hesoluong.Visible = true;
                image_yes_hesoluong.Visible = false;
                txtHesoluong.ToolTip = "Nội dung này không được để trống";
            }
            else
            {
                image_no_hesoluong.Visible = false;
                image_yes_hesoluong.Visible = true;
                txtHesoluong.ToolTip = "Nhập vào hệ số tiền";
            }
        }
        private void themLoaicong()
        {
            if (kiemtraNhap())
            {
                LoaiCong loaicong = new LoaiCong();
                loaicong.Maloai=txtMaloaicong.Text;
                loaicong.Tenloai=txtTenloaicong.Text;
                loaicong.Heso = txtHesoluong.Text;
                if (BUS_LoaiCong.insertLoaiCong(loaicong))
                {
                    MessageBox.Show("Thêm thành công","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    load();
                    this.Close();
                }
                else
                    MessageBox.Show("lỗi từ hệ thống, hãy liên hệ với bộ phận kỹ thuật để khắc phục lỗi này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            themLoaicong();
        }
    }
}