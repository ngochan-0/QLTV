using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaoCaoBLL
    {
        BaoCaoDAL baoCaoDAL = new BaoCaoDAL();

        public DataTable LayDanhSachDangMuon() => baoCaoDAL.LayDanhSachDangMuon();

        public DataTable LayDanhSachQuaHan() => baoCaoDAL.LayDanhSachQuaHan();

        public DataTable LayDanhSachDaTra() => baoCaoDAL.LayDanhSachDaTra();

        public int DemSoLuong(string tenBang) => baoCaoDAL.DemSoLuong(tenBang);
    }
}
