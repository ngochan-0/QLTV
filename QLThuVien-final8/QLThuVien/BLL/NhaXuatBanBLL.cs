using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhaXuatBanBLL
    {
        private NhaXuatBanDAL NXBdal = new NhaXuatBanDAL();

        public DataTable LayDanhSachNXB()
        {
            return NXBdal.LayDanhSachNXB();
        }

        public bool KiemTraTrungMaNXB(string maNXB)
        {
            return NXBdal.KiemTraTrungMaNXB(maNXB);
        }

        public bool ThemNXB(NhaXuatBanDTO nxb)
        {
            return NXBdal.ThemNXB(nxb);
        }

        public bool CapNhatNXB(NhaXuatBanDTO nxb)
        {
            return NXBdal.CapNhatNXB(nxb);
        }

        public bool XoaNXB(string maXB)
        {
            return NXBdal.XoaNXB(maXB);
        }

        public DataTable TimKiemNXB(string tuKhoa)
        {
            return NXBdal.TimKiemNXB(tuKhoa);
        }
    }
}
