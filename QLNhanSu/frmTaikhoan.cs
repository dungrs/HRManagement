using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS;

namespace QLNhanSu
{
    public partial class frmTaikhoan : DevExpress.XtraEditors.XtraForm
    {
        #region Fields
        private bool flag = false; // Thay đổi từ string sang bool
        private int quyen;
        private string ten;
        private string tencu;
        #endregion

        #region Constructors
        public frmTaikhoan()
        {
            InitializeComponent();
        }

        public frmTaikhoan(string ten, string quyen)
        {
            InitializeComponent();
            this.quyen = int.Parse(quyen);
            this.ten = ten;
        }
        #endregion

        #region Initialization and Binding
        private void EnableText(bool flag)
        {
            txt_hoten.Enabled = flag;
            txt_tenTK.Enabled = flag;
            radio_Quyen.Properties.ReadOnly = !flag;
        }

        private void Binding()
        {
            txt_hoten.DataBindings.Clear();
            txt_hoten.DataBindings.Add("Text", grid_Taikhoan.DataSource, "hoten");
            txt_tenTK.DataBindings.Clear();
            txt_tenTK.DataBindings.Add("Text", grid_Taikhoan.DataSource, "ten");
            lb_quyen.DataBindings.Clear();
            lb_quyen.DataBindings.Add("Text", grid_Taikhoan.DataSource, "quyen");
        }

        private void ClearBinding()
        {
            txt_hoten.DataBindings.Clear();
            txt_tenTK.DataBindings.Clear();
            lb_quyen.DataBindings.Clear();
        }

        private void ClearFields()
        {
            txt_hoten.Text = "";
            txt_MK.Text = "";
            txt_tenTK.Text = "";
            txt_xacNhanMK.Text = "";
        }

        private void LoadFull()
        {
            grid_Taikhoan.DataSource = BUS_HeThong.selectTaiKhoan();
            Binding();
            EnableText(false);
            layoutmatkhau.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            layoutxacnhanmk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.OnlyInCustomization;
            bt_them.Enabled = true;
            grid_Taikhoan.Enabled = true;
            bt_luu.Enabled = false;
            bt_restart.Enabled = false;
            lb_loi.Text = "";

            if (grid_Taikhoan.MainView.RowCount > 0)
            {
                bt_sua.Enabled = bt_xoa.Enabled = true;
            }
            else
            {
                bt_sua.Enabled = bt_xoa.Enabled = false;
                ClearFields();
            }
        }
        #endregion

        #region Event Handlers
        private void frmTaikhoan_Load(object sender, EventArgs e)
        {
            LoadFull();
        }

        private void bt_them_Click(object sender, EventArgs e)
        {
            flag = true; // Thay đổi giá trị flag thành true
            ClearFields();
            grid_Taikhoan.Enabled = false;
            ClearBinding();
            EnableText(true);
            layoutmatkhau.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            layoutxacnhanmk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            bt_them.Enabled = bt_xoa.Enabled = bt_sua.Enabled = false;
            bt_luu.Enabled = bt_restart.Enabled = true;
        }

        private void bt_restart_Click(object sender, EventArgs e)
        {
            LoadFull();
        }

        private void bt_luu_Click(object sender, EventArgs e)
        {
            if (flag) // Kiểm tra flag là true (thêm mới)
            {
                if (ValidateInput())
                {
                    int quyen = radio_Quyen.SelectedIndex;

                    if (BUS_HeThong.insertTaiKhoan(txt_hoten.Text, txt_tenTK.Text, txt_MK.Text, quyen))
                    {
                        lb_loi.Text = "Thêm tài khoản thành công.";
                        LoadFull();
                    }
                    else
                    {
                        lb_loi.Text = "Tên tài khoản đã tồn tại.";
                    }
                }
            }
            else // Nếu flag là false (cập nhật)
            {
                UpdateAccount();
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            if ((ten == txt_tenTK.Text) || (quyen > radio_Quyen.SelectedIndex))
            {
                tencu = txt_tenTK.Text;
                flag = false; // Thay đổi giá trị flag thành false (cập nhật)
                grid_Taikhoan.Enabled = false;
                ClearBinding();
                EnableText(true);
                layoutmatkhau.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                layoutxacnhanmk.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                bt_them.Enabled = bt_xoa.Enabled = bt_sua.Enabled = false;
                bt_luu.Enabled = bt_restart.Enabled = true;

                if (quyen == 2 && ten == txt_tenTK.Text)
                {
                    radio_Quyen.Properties.ReadOnly = true;
                }
            }
        }

        private void bt_xoa_Click(object sender, EventArgs e)
        {
            if (quyen > radio_Quyen.SelectedIndex)
            {
                if (ten == txt_tenTK.Text)
                {
                    lb_loi.Text = "Bạn không thể xoá chính bạn";
                }
                else if (MessageBox.Show("Bạn có muốn xóa tài khoản " + txt_tenTK.Text + " hay không?", "thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (BUS_HeThong.deleteTaiKhoan(txt_tenTK.Text))
                    {
                        lb_loi.Text = "Xóa tài khoản thành công.";
                        LoadFull();
                    }
                    else
                    {
                        lb_loi.Text = "Lỗi từ hệ thống";
                    }
                }
            }
            else
            {
                lb_loi.Text = "Bạn không thể xóa tài khoản admin";
            }
        }

        private void lb_quyen_TextChanged(object sender, EventArgs e)
        {
            radio_Quyen.SelectedIndex = lb_quyen.Text == "Admin" ? 1 : 0;
        }

        private void txt_tenTK_EditValueChanged(object sender, EventArgs e)
        {
            if ((ten == txt_tenTK.Text) || (quyen > radio_Quyen.SelectedIndex))
            {
                bt_sua.Enabled = bt_xoa.Enabled = true;
            }
            else
            {
                bt_sua.Enabled = bt_xoa.Enabled = false;
            }

            if (quyen == 2)
            {
                lb_loi.Text = "2";
            }
        }

        private void bt_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Helper Methods
        private bool ValidateInput()
        {
            if (!flag && (string.IsNullOrEmpty(txt_MK.Text) || string.IsNullOrEmpty(txt_xacNhanMK.Text))) // Kiểm tra flag là false (cập nhật)
            {
                lb_loi.Text = "Hãy điền đầy đủ thông tin.";
                return false;
            }

            if (string.IsNullOrEmpty(txt_hoten.Text) || string.IsNullOrEmpty(txt_tenTK.Text))
            {
                lb_loi.Text = "Hãy điền đầy đủ thông tin.";
                return false;
            }

            if (txt_MK.Text != txt_xacNhanMK.Text)
            {
                lb_loi.Text = "Mật khẩu và xác nhận mật khẩu không khớp với nhau.";
                return false;
            }

            lb_loi.Text = "";
            return true;
        }

        private void UpdateAccount()
        {
            if (ValidateInput())
            {
                int q = radio_Quyen.SelectedIndex;

                if (quyen == 2)
                {
                    q = 2;
                }

                if (BUS_HeThong.updateTaiKhoan(txt_hoten.Text, tencu, txt_tenTK.Text, txt_MK.Text, q))
                {
                    lb_loi.Text = "Sửa tài khoản thành công.";
                    LoadFull();
                }
                else
                {
                    lb_loi.Text = "Tên tài khoản đã trùng.";
                }
            }
        }
        #endregion
    }
}