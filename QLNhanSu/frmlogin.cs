using System;
using System.Data;
using System.Windows.Forms;
using BUS;
namespace QLNhanSu
{
    public partial class frmlogin : DevExpress.XtraEditors.XtraForm
    {

        public frmlogin()
        {
            InitializeComponent();
        }

        private void hien()
        {
            this.WindowState = FormWindowState.Normal;
        }


        public void thoat1()
        {

            Show();
            txtUser.Text = "";
            txtPass.Text = "";
        }
        #region dang nhap
        public void Dangnhap()
        {
            DataTable dt = BUS_HeThong.dangNhap(txtUser.Text, txtPass.Text);
            if (dt.Rows.Count > 0)
            {
                frmMainForm frm = new frmMainForm(dt);
                frm.thoat = new frmMainForm.Thoat(thoat1);
                frm.Show();
                Hide();
            }
            else
            {
                lbCanhbao.Visible = true;
                image_canhbao.Visible = true;
            }
        }

        private void bt_Dangnhap_Click(object sender, EventArgs e)
        {
            Dangnhap();
        }
        #endregion
        
        
        #region moveMouse_From
       
            
        #endregion
        private void bt_thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void thoat()
        {
            this.Close();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Dangnhap();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Dangnhap();
            }
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}