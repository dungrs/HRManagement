using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ChucVu
    {
        private string machucvu;

        public string Machucvu
        {
            get { return machucvu; }
            set { machucvu = value; }
        }
        private string tenchucvu;

        public string Tenchucvu
        {
            get { return tenchucvu; }
            set { tenchucvu = value; }
        }
        private float hsl;

        public float Hsl
        {
            get { return hsl; }
            set { hsl = value; }
        }
    }
}
