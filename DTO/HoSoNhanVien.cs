using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.IO;


namespace DTO
{
    public class HoSoNhanVien:NhanVien
    {
        #region Properties
        private Image hinhDaiDien;

        public Image HinhDaiDien
        {
            get { return hinhDaiDien; }
            set { hinhDaiDien = value; }
        }


        private string mathe;

        public string Mathe
        {
            get { return mathe; }
            set { mathe = value; }
        }
        private string holot;

        public string Holot
        {
            get { return holot; }
            set { holot = value; }
        }
        private string ten;

        public string Ten
        {
            get { return ten; }
            set { ten = value; }
        }
        private string atm;

        public string Atm
        {
            get { return atm; }
            set { atm = value; }
        }
        private string thoiviec;

        public string Thoiviec
        {
            get { return thoiviec; }
            set { thoiviec = value; }
        }
        private string chucvu;

        public string Chucvu
        {
            get { return chucvu; }
            set { chucvu = value; }
        }

        private string ngaysinh;

        public string Ngaysinh
        {
            get { return ngaysinh; }
            set { ngaysinh = value; }
        }

        private string gioitinh;

        public string Gioitinh
        {
            get { return gioitinh; }
            set { gioitinh = value; }
        }
        private byte[] anh;

        public byte[] Anh
        {
            get { return anh; }
            set { anh = value; }
        }
        private string quequan;

        public string Quequan
        {
            get { return quequan; }
            set { quequan = value; }
        }
        private string hktt;

        public string Hktt
        {
            get { return hktt; }
            set { hktt = value; }
        }
        private string cmnd;

        public string Cmnd
        {
            get { return cmnd; }
            set { cmnd = value; }
        }
        private string ngaylamviec;

        public string Ngaylamviec
        {
            get { return ngaylamviec; }
            set { ngaylamviec = value; }
        }
        private string bangcap;

        public string Bangcap
        {
            get { return bangcap; }
            set { bangcap = value; }
        }
        private string tthonnhan;

        public string Tthonnhan
        {
            get { return tthonnhan; }
            set { tthonnhan = value; }
        }
        private string dantoc;

        public string Dantoc
        {
            get { return dantoc; }
            set { dantoc = value; }
        }
        private string quoctich;

        public string Quoctich
        {
            get { return quoctich; }
            set { quoctich = value; }
        }
        private string sdt;

        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        #endregion

        #region Methods
        public void setImage(byte[] b)
        {
             MemoryStream ms = new MemoryStream(b);
            Image returnImage = Image.FromStream(ms);
            
        }
        #endregion
    }
}
