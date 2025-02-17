using System;
using System.Data;
using System.Windows.Forms;
using BUS;

namespace QLNhanSu
{
    public partial class frmDoimatkhau : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt = new DataTable();

        #region Constructor
        public frmDoimatkhau()
        {
            InitializeComponent();
        }

        public frmDoimatkhau(DataTable dt)
        {
            InitializeComponent();
            this.dt = dt;
        }
        #endregion

        #region Load
        private void frmDoimatkhau_Load(object sender, EventArgs e)
        {
            // Có thể thêm các thiết lập ban đầu ở đây nếu cần
        }
        #endregion

        #region Kiểm tra trước khi thực thi
        private bool kiemtra()
        {
            if (txt_passCu.Text == "" || txt_passMoi.Text == "" || txt_xacNhan.Text == "")
            {
                lb_loi.Text = "Hãy nhập đầy đủ thông tin.";
                return false;
            }
            else if (txt_passCu.Text != dt.Rows[0]["matkhau"].ToString())
            {
                lb_loi.Text = "Mật khẩu hiện tại không chính xác.";
                return false;
            }
            else if (txt_passMoi.Text != txt_xacNhan.Text)
            {
                lb_loi.Text = "Mật khẩu xác nhận không khớp.";
                return false;
            }
            lb_loi.Text = "";
            return true;
        }
        #endregion

        #region Cập nhật mật khẩu
        private void capnhat()
        {
            if (kiemtra())
            {
                string tenCu = dt.Rows[0]["ten"].ToString();
                string tenMoi = dt.Rows[0]["ten"].ToString(); // Giữ nguyên tên tài khoản
                string matKhauMoi = txt_passMoi.Text;
                int quyen = Convert.ToInt32(dt.Rows[0]["quyen"]);

                if (BUS_HeThong.updateTaiKhoan("", tenCu, tenMoi, matKhauMoi, quyen))
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công.");
                    this.Close();
                }
                else
                {
                    lb_loi.Text = "Cập nhật mật khẩu thất bại.";
                }
            }
        }

        private void bt_capNhat_Click(object sender, EventArgs e)
        {
            capnhat();
        }
        #endregion

        #region Các sự kiện
        private void bt_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_passCu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                capnhat();
            }
        }

        private void txt_passMoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                capnhat();
            }
        }

        private void txt_xacNhan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                capnhat();
            }
        }
        #endregion
    }
}