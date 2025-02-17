using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraTabbedMdi;
using System.Data;
namespace QLNhanSu
{
    public partial class frmMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public delegate void Thoat();
        public Thoat thoat;
        DataTable dt = new DataTable();
        public frmMainForm()
        {
            InitializeComponent();
            InitSkinGallery();
        }
        public frmMainForm(DataTable dt)
        {
            InitializeComponent();
            InitSkinGallery();
            if (dt.Rows[0]["quyen"].ToString().Equals("0"))
            {
                ribbonPage_danhmuc.Visible = false;
                ribbonPage_hethong.Visible = false;
            }
            this.dt = dt;
        }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rb_Skin,true);
        }
        #region Phân quyền
        public void phanquyen()
        {
            if (dt.Rows[0]["quyen"].ToString() == "0")
            {
                //bt_dmBophan.Enabled = false;
                //bt_dmChucvu.Enabled = false;
                //bt_dmLoaicong.Enabled = false;
                //bt_dmPhucap.Enabled = false;
                //bt_dmLoaica.Enabled = false;
                //bt_dmTinh.Enabled = false;
                //barbt_saoluu.Enabled = false;
                //barbt_phuchoi.Enabled = false;
                //barbt_taikhoan.Enabled = false;
                //navBarItem_DMTinh.Enabled = false;
                //navBarItem_DMbophan.Enabled = false;
                //navBarItem_DMChucvu.Enabled = false;
                //navBarItem_DMLoaicong.Enabled = false;
                //navBarItem_DMPhucap.Enabled = false;
                //navBarItem_taikhoan.Enabled = false;
                //navBarItem_phuchoi.Enabled = false;
                //navBarItem_Saoluu.Enabled = false;
            }
            else
            {
                //bt_dmBophan.Enabled = true;
                //bt_dmChucvu.Enabled = true;
                //bt_dmLoaicong.Enabled = true;
                //bt_dmPhucap.Enabled = true;
                //bt_dmLoaica.Enabled = true;
                //bt_dmTinh.Enabled = true;
                //barbt_saoluu.Enabled = true;
                //barbt_phuchoi.Enabled = true;
                //barbt_taikhoan.Enabled = true;
                //navBarItem_DMTinh.Enabled = true;
                //navBarItem_DMbophan.Enabled = true;
                //navBarItem_DMChucvu.Enabled = true;
                //navBarItem_DMLoaicong.Enabled = true;
                //navBarItem_DMPhucap.Enabled = true;
                //navBarItem_taikhoan.Enabled = true;
                //navBarItem_phuchoi.Enabled = true;
                //navBarItem_Saoluu.Enabled = true;
            }
        }
        #endregion
        

        private void btbaocaonhanvien_ItemClick(object sender, ItemClickEventArgs e)
        {
            thaydoigiaodien.LookAndFeel.SkinName = "Whiteprint";
        }
        // private void navBarItemQLSV_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien();
        //     foreach (frmQLNhanvien f in this.MdiChildren)
        //     {
        //         if(f.Name == qlsv.Name)
        //             f.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        
        // private void navBarItemQLSV_LinkClicked_1(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void btQuanlynhanvien_ItemClick_1(object sender, ItemClickEventArgs e)
        // {
            
        //     frmQLNhanvien qlsv = new frmQLNhanvien(0);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        private void btquanlybaocao_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btbaocaoluong_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            thaydoigiaodien.LookAndFeel.SkinName = "Office 2010 Blue";
        }

        // private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmNhapXuatNhanvienExcel nx = new frmNhapXuatNhanvienExcel();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (nx.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     nx.MdiParent = this;
        //     nx.Show();
        // }

        // private void barbt_nvchuakyhopdonglannao_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(1);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void barbt_nvsaphethopdong_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(3);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void barbt_nvdahethopdong_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(2);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void barbt_nvdangconhieuluchopdong_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(4);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void barbt_nvchuacobaohiemlannao_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(5);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void barbt_nvdahethanbaohiem_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(6);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void barbt_nvsaphethanbaohiem_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(7);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void barbt_nvdangconhieulucbaohiem_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(8);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void nvnghiviec_bar_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien qlsv = new frmQLNhanvien(9);
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (qlsv.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     qlsv.MdiParent = this;
        //     qlsv.Show();
        // }

        // private void bt_baocaonhanvien_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmBaocaoNV bcnv = new frmBaocaoNV();
        //     bcnv.Show();
        // }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            XtraTabbedMdiManager mdiManager = new XtraTabbedMdiManager();
            mdiManager.MdiParent = this;
            check_chucnang.Checked = true;
        }

        // private void btThemcong_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmThemcong themcong = new frmThemcong();
        //     themcong.Show();
        // }
        private void btLoaicong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoaicong loaicong = new frmLoaicong();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (loaicong.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            loaicong.MdiParent = this;
            loaicong.Show();
        }

       
        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            radialMenu1.ShowPopup(new Point(100, 100));
        }

        // private void navBarItemNhapxuatTufileExcel_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmNhapXuatNhanvienExcel nx = new frmNhapXuatNhanvienExcel();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (nx.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     nx.MdiParent = this;
        //     nx.Show();
        // }

        // private void navBarItem_BcNvVaolamNgay_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmBaocaoNV bcnv = new frmBaocaoNV();
        //     bcnv.Show();
        // }

    
        private void frmMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            thoat();
        }

        private void btPhucap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPhucap frm = new frmPhucap();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

        private void ribbon_Click_1(object sender, EventArgs e)
        {

        }

        // private void btBangcong_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmBangcong frm = new frmBangcong();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void btNvTangca_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQltangca frm = new frmQltangca();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if(frm.Name==_mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void btThemTangca_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmThemtangca frm = new frmThemtangca();
        //     frm.Show();
        // }

        // private void btNvUngluong_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmUngluong frm = new frmUngluong();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }
       
        // private void btKhautru_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmKhautru frm = new frmKhautru();
        //     frm.Show();
        // }

      

      
        // private void btChitietphucap_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmPhucapNhanvien frm = new frmPhucapNhanvien();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void btBar_DMLoaica_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmDMTangca frm = new frmDMTangca();
        //     frm.Show();
        // }

        // private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmBangluong frm = new frmBangluong();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void navBarItem_Bangcong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmBangcong frm = new frmBangcong();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void navBarItemQLTangca_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmQltangca frm = new frmQltangca();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void navBarItem_NvUngluong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmUngluong frm = new frmUngluong();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void navBarItem_Khautru_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmKhautru frm = new frmKhautru();
        //     frm.Show();
        // }

        private void navBarItem_Loaicong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmLoaicong loaicong = new frmLoaicong();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (loaicong.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            loaicong.MdiParent = this;
            loaicong.Show();
        }

        private void navBar_phucap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmPhucap frm = new frmPhucap();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }


        private void barbt_taikhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTaikhoan frm = new frmTaikhoan(dt.Rows[0]["ten"].ToString(), dt.Rows[0]["quyen"].ToString());
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

        private void bar_ThoatFRM_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bar_DangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            // mo lai frm dang nhap
        }

        private void bar_DoiMatKhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoimatkhau frm = new frmDoimatkhau();
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string ngay = "Ngày: "+DateTime.Now.Day.ToString()+"/";
            ngay += DateTime.Now.Month.ToString() + "/";
            ngay += DateTime.Now.Year.ToString();
            string gio = "Giờ: " + DateTime.Now.Hour.ToString() + ":";
            gio += DateTime.Now.Minute.ToString() + ":";
            gio += DateTime.Now.Second.ToString();
            string nguoidung = "Đăng nhập dưới tên: " + dt.Rows[0]["ten"].ToString();
            bar_user.Caption = nguoidung;
            bar_ngay.Caption = ngay;
            bar_gio.Caption = gio;
        }

        // private void bt_dmNhanvien_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmQLNhanvien frm = new frmQLNhanvien();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void bt_dmBophan_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmBophan frm = new frmBophan();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void bt_dmChucvu_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmChucvu frm = new frmChucvu();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        private void bt_dmLoaicong_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLoaicong frm = new frmLoaicong();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

        private void bt_dmPhucap_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmPhucap frm = new frmPhucap();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

        // private void bt_dmLoaica_ItemClick(object sender, ItemClickEventArgs e)
        // {
        //     frmDMTangca frm = new frmDMTangca();
        //     frm.Show();
        // }

        private void bt_dmTinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTinh frm = new frmTinh();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

        private void bt_dangxuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void bt_doimatkhau_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoimatkhau frm = new frmDoimatkhau(dt);
            frm.Show();
        }

        private void bt_thoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        // private void navBarItem_QlDMLuong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmBangluong frm = new frmBangluong();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        private void navBarItem_DMTinh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTinh frm = new frmTinh();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

        // private void navBarItem_DMNhanvien_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmQLNhanvien frm = new frmQLNhanvien();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void navBarItem_DMbophan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmBophan frm = new frmBophan();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        // private void navBarItem_DMChucvu_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        // {
        //     frmChucvu frm = new frmChucvu();
        //     foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
        //     {
        //         if (frm.Name == _mdi_child.Name)
        //             _mdi_child.Close();
        //     }
        //     frm.MdiParent = this;
        //     frm.Show();
        // }

        private void navBarItem_DMLoaicong_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmLoaicong frm = new frmLoaicong();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

        private void navBarItem_DMPhucap_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmPhucap frm = new frmPhucap();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

       
        private void navBarItem_taikhoan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmTaikhoan frm = new frmTaikhoan();
            foreach (System.Windows.Forms.Form _mdi_child in this.MdiChildren)
            {
                if (frm.Name == _mdi_child.Name)
                    _mdi_child.Close();
            }
            frm.MdiParent = this;
            frm.Show();
        }

    }
}