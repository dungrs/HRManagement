using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class LoaiHD
    {
        private int loaihd;

        public int Loaihd
        {
            get { return loaihd; }
            set { loaihd = value; }
        }
        private string tenloai;

        public string Tenloai
        {
            get { return tenloai; }
            set { tenloai = value; }
        }
        private int thoihan;

        public int Thoihan
        {
            get { return thoihan; }
            set { thoihan = value; }
        }
        private float hsl;

        public float Hsl
        {
            get { return hsl; }
            set { hsl = value; }
        }
    }
}
