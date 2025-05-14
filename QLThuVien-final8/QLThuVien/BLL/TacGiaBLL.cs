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
    public class TacGiaBLL
    {
        private TacGiaDAL tacGiaDAL = new TacGiaDAL();

        public DataTable LayDanhSachTacGia()
        {
            return tacGiaDAL.LayDanhSachTacGia();
        }

        public bool KiemTraTrungMaTG(string maTG)
        {
            return tacGiaDAL.KiemTraTrungMaTG(maTG);
        }

        public bool ThemTacGia(TacGiaDTO tg)
        {
            return tacGiaDAL.ThemTacGia(tg);
        }

        public bool SuaTacGia(TacGiaDTO tg)
        {
            return tacGiaDAL.SuaTacGia(tg);
        }

        public bool XoaTacGia(string maTacGia)
        {
            return tacGiaDAL.XoaTacGia(maTacGia);
        }

        public DataTable TimKiemTacGia(string tuKhoa)
        {
            return tacGiaDAL.TimKiemTacGia(tuKhoa);
        }
    }
}
