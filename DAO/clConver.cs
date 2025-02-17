using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
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
    }
}
