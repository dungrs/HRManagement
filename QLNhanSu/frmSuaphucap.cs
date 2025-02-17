using System;
using System.Windows.Forms;

using DTO;
using BUS;
namespace QLNhanSu
{
    public partial class frmSuaphucap : DevExpress.XtraEditors.XtraForm
    {
        PhuCap phucap = new PhuCap();
        public delegate void Reload();
        public Reload reload;
        public frmSuaphucap()
        {
            InitializeComponent();
        }
        public frmSuaphucap(PhuCap pc)
        {
            InitializeComponent();
            this.phucap = pc;
        }
        private void frmSuaphucap_Load(object sender, EventArgs e)
        {
            loadThongtin();
        }
        public void loadThongtin()
        {
            txtMaloaipc.Text = phucap.Maloaipc;
            txtTenloaipc.Text = phucap.Tenloai;
            txtTien.Text = phucap.Tien;
            image_no_hesoluong.Visible = false;
            image_no_maloai.Visible = false;
            image_no_tenloai.Visible = false;
            image_yes_hesoluong.Visible = true;
            image_yes_maloai.Visible = true;
            image_yes_tenloai.Visible = true;
        }
        public bool KT_songuyen(string val)
        {
            try
            {
                float t = long.Parse(val);
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
            if (txtMaloaipc.Text == "" || txtTenloaipc.Text == "" || txtTien.Text == "")
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
            else if (!KT_songuyen(txtTien.Text))
            {
                kt = false;
                MessageBox.Show("Số tiền phụ cấp phải là kiểu số, xin bạn hãy chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (BUS_PhuCap.kiemTraTrungMaKhiSua(phucap.Maloaipc, txtMaloaipc.Text))
            {
                kt = false;
                MessageBox.Show("Mã phụ cấp đã tồn tại, bạn hãy thay đổi mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return kt;
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
            else if (BUS_PhuCap.kiemTraTrungMaKhiSua(phucap.Maloaipc, txtMaloaipc.Text))
            {
                image_no_maloai.Visible = true;
                image_yes_maloai.Visible = false;
                txtMaloaipc.ToolTip = "Mã phụ cấp đã tồn tại";
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
            else
            {
                image_no_tenloai.Visible = false;
                image_yes_tenloai.Visible = true;
                txtTenloaipc.ToolTip = "Nhập tên loạ công";
            }
        }

        private void txtTien_KeyUp(object sender, KeyEventArgs e)
        {
            if (!KT_songuyen(txtTien.Text))
            {
                image_no_hesoluong.Visible = true;
                image_yes_hesoluong.Visible = false;
                txtTien.ToolTip = "Đây phải là kiểu số";
            }
            else if (txtTien.Text == "")
            {
                image_no_hesoluong.Visible = true;
                image_yes_hesoluong.Visible = false;
                txtTien.ToolTip = "Nội dung này không được để trống";
            }
            else
            {
                image_no_hesoluong.Visible = false;
                image_yes_hesoluong.Visible = true;
                txtTien.ToolTip = "Nhập vào hệ số tiền";
            }
        }
        public void Capnhat()
        {
            if (kiemtraNhap())
            {
                PhuCap pc = new PhuCap();
                pc.Maloaipc = txtMaloaipc.Text;
                pc.Tenloai = txtTenloaipc.Text;
                pc.Tien = txtTien.Text;
                if (BUS_PhuCap.updatePhuCap(pc, phucap.Maloaipc))
                {
                    MessageBox.Show("Sửa thành công phụ cấp có mã " + txtMaloaipc.Text + "", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reload();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Có lỗi từ hệ thống, hãy liên hệ với bộ phận kỹ thuật", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btCapnhat_Click(object sender, EventArgs e)
        {
            Capnhat();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}