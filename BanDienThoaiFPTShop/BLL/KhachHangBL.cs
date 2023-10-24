using DTO;
using DAL;
using DAL.Interfaces;
using BLL.Interfaces;
using DTO;

namespace BLL
{
    public class KhachHangBL : IKhachHangBL
    {
        private IKhachHangDA _khachHangDA;

        public KhachHangBL(IKhachHangDA khachhang)
        {
            this._khachHangDA = khachhang;
        }


        public void InsertKhachHang(string tenKhachHang, bool gioiTinh, string diaChi, string sdt, string email)
        {
            _khachHangDA.InsertKhachHang(tenKhachHang, gioiTinh, diaChi, sdt, email);
        }

        public KhachHangModel getById(int id)
        {
            return _khachHangDA.GetByID(id);
        }
        public void upDateKhachHang(int id, string tenkh, bool gioitinh, string diachi, string sdt, string email)
        {
            _khachHangDA.upDateKhachHang(id, tenkh, gioitinh, diachi, sdt, email);
        }

        public void deleteKhachHang(int id)
        {
            _khachHangDA.deleteKhachHang(id);
        }



        //public List<KhachHangModel> searchKhachHang(int pageIndex, int pageSize, out long total, string tenKhach, string diaChi)
        //{
        //   return _khachHangDA.searchKhachHang(pageIndex, pageSize, out total, tenKhach, diaChi);
        //}


    }
}