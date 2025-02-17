using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNhanSu
{
    public class clConver
    {
        #region Chuyen ngay/thang/nam sang thang/ngay/nam
        public static string ConverDMY_MDY(DateTime dt)
        {
            string ngay = dt.Day.ToString();
            string thang = dt.Month.ToString();
            string nam = dt.Year.ToString();
            return thang + "/" + ngay + "/" + nam;
        }
        #endregion

        #region Kiem tra dieu kien Hop Dong
        public static bool KT(DTO.DMHopdong hd)
        {
            if (hd.Loaihd == "")
            {
                MessageBox.Show("Lỗi !!! Bạn vẫn chưa chọn loại hợp đồng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hd.Kilanthu == "")
            {
                MessageBox.Show("Lỗi !!! Bạn vẫn chưa chọn Lần ký", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (hd.Ngaykihd == "" || hd.Ngayhd == "")
            {
                MessageBox.Show("Lỗi !!! bạn chưa chọn ngày hợp đồng hoặc ngày ký", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DateTime dt = DateTime.Parse(hd.Ngaykihd);
            if (dt > DateTime.Now)
            {
                MessageBox.Show("Lỗi !!! Ngày kí phải nhỏ hơn ngày hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Parse(hd.Ngayhd) < DateTime.Parse(hd.Ngaykihd))
            {
                
                MessageBox.Show("Lỗi !!! Ngày hợp đồng không được nhỏ hơn ngày ký hợp đồng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //else
            //{
            //    if (BUS.BUS_DMHopdong.NgayHopDong(hd.Ngayhd, hd.Manv,hd.Sohd) == 0)
            //    {
            //        MessageBox.Show("Lỗi !!! Có 1 hợp đồng của nhân viên " + hd.Manv + " đang còn hiệu lực trong thời gian này", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}
            return true;
        }
        #endregion
    }
}
