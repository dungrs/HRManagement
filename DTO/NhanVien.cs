using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NhanVien
    {
        private string manv;
        public string Manv
        {
            get { return manv; }
            set { manv = value; }
        }
        private string hoten;

        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }
        private string bophan;

        public string Bophan
        {
            get { return bophan; }
            set { bophan = value; }
        }
    }
}
