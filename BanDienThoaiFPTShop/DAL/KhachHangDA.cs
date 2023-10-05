using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DAL
{
    public class KhachHangDA : IKhachHangDA
    {
        private readonly BanDienThoai_NguyenDinhCongContext _context;

        public KhachHangDA(BanDienThoai_NguyenDinhCongContext dbcontext)
        {
            _context = dbcontext;
        }
        //Thêm khách hàng
        public void InsertKhachHang(string tenKhachHang, bool gioiTinh, string diaChi, string sdt, string email)
        {
            try
            {
                var parameters = new SqlParameter[]
                {
                new SqlParameter("@TenKH", tenKhachHang),
                new SqlParameter("@GioiTinh", gioiTinh),
                new SqlParameter("@DiaChi", diaChi),
                new SqlParameter("@SDT", sdt),
                new SqlParameter("@Email", email)
                };

                _context.Database.ExecuteSqlRaw("EXEC sp_InsertKhachHang @TenKH, @GioiTinh, @DiaChi, @SDT, @Email", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Tìm kiếm khách hàng theo ID
        public KhachHangModel getByID(int id)
        {
            try
            {
                // Sử dụng FromSqlRaw để gọi procedure và truyền tham số @Id
                var result = _context.KhachHangs.FirstOrDefault(x => x.Id == id);

                if (result == null)
                {
                    return null;
                }

                // Tạo một đối tượng KhachHangModel và gán giá trị từ result
                var khmodel = new KhachHangModel
                {
                    Id = result.Id,
                    TenKh = result.TenKh,
                    GioiTinh = result.GioiTinh,
                    DiaChi = result.DiaChi,
                    Sdt = result.Sdt,
                    Email = result.Email
                };

                return khmodel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Sủa khách hàng
        public void upDateKhachHang(int id, string tenkh, bool gioitinh, string diachi, string sdt, string email)
        {
            try
            {
                var dt = new SqlParameter[]
                {
                    new SqlParameter("@Id", id),
                    new SqlParameter("@TenKH", tenkh),
                    new SqlParameter("@GioiTinh", gioitinh),
                    new SqlParameter("@DiaChi", diachi),
                    new SqlParameter("@SDT", sdt),
                    new SqlParameter("@Email", email)

                };
                _context.Database.ExecuteSqlRaw("EXEC sp_khachhang_update @Id, @TenKH, @GioiTinh, @DiaChi, @SDT, @Email", dt);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Xóa Khách Hàng
        public void deleteKhachHang(int id)
        {
            try
            {
                var parameter = new SqlParameter("@Id", id);
                _context.Database.ExecuteSqlRaw("EXEC sp_khachhang_delete @Id", parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Search
        public List<KhachHangModel> searchKhachHang(int pageIndex, int pageSize, out long total, string tenKhach, string diaChi)
        {
            total = 0;
            List<KhachHangModel> khachHangs = new List<KhachHangModel>();

            try
            {
                // Thực hiện truy vấn sử dụng Entity Framework Core
                khachHangs = _context.KhachHangs
                .FromSqlRaw("sp_khach_search @page_index, @page_size, @ten_khach, @dia_chi",
                    new SqlParameter("@page_index", pageIndex),
                    new SqlParameter("@page_size", pageSize),
                    new SqlParameter("@ten_khach", tenKhach),
                    new SqlParameter("@dia_chi", diaChi))
                .Select(kh => new KhachHangModel
                {
                    Id = kh.Id,
                    TenKh = kh.TenKh,
                    GioiTinh = kh.GioiTinh,
                    DiaChi = kh.DiaChi,
                    Sdt = kh.Sdt,
                    Email = kh.Email
                    // Các thuộc tính khác tương tự
                })
                .ToList();


                // Lấy tổng số lượng bản ghi
                total = _context.KhachHangs
                    .FromSqlRaw("sp_khach_search @page_index, @page_size, @ten_khach, @dia_chi",
                        new SqlParameter("@page_index", pageIndex),
                        new SqlParameter("@page_size", pageSize),
                        new SqlParameter("@ten_khach", tenKhach),
                        new SqlParameter("@dia_chi", diaChi))
                    .Count();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                throw ex;
            }

            return khachHangs;
        }

    }
}