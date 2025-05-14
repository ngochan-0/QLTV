using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class KetNoiChung
    {
        private static string chuoiKetNoi = "Data Source=HAN-PHAN\\MSSQLSERVER04;Initial Catalog=QLTV;Integrated Security=True;Encrypt=False";

        public static SqlConnection TaoKetNoi()
        {
            return new SqlConnection(chuoiKetNoi);
        }
    }
}
