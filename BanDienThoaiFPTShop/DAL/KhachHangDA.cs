using DAL.Interfaces;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Entity;

namespace DAL
{
    public class KhachHangDA : IKhachHangDA
    {

        public string connectionString;
        public KhachHangDA(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("connect");
        }
        //Thêm khách hàng
        public void InsertKhachHang(string tenKhachHang, bool gioiTinh, string diaChi, string sdt, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_InsertKhachHang", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@TenKH", tenKhachHang));
                    command.Parameters.Add(new SqlParameter("@GioiTinh", gioiTinh));
                    command.Parameters.Add(new SqlParameter("@DiaChi", diaChi));
                    command.Parameters.Add(new SqlParameter("@SDT", sdt));
                    command.Parameters.Add(new SqlParameter("@Email", email));

                    command.ExecuteNonQuery();
                }
            }
        }

        //Tìm kiếm khách hàng theo ID
        public KhachHangModel GetByID(int id)
        {
            KhachHangModel khachhang = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_khachhang_get_by_id", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Kiểm tra xem có dữ liệu hay không
                        {
                            // Đọc dữ liệu từ SqlDataReader và gán vào đối tượng KhachHangModel
                            khachhang = new KhachHangModel
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                TenKh = reader.GetString(reader.GetOrdinal("TenKh")),
                                GioiTinh = reader.GetBoolean(reader.GetOrdinal("GioiTinh")),
                                DiaChi = reader.GetString(reader.GetOrdinal("DiaChi")),
                                Sdt = reader.GetString(reader.GetOrdinal("Sdt")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };
                        }
                    }
                }
            }
            return khachhang;
        }

        //Sủa khách hàng
        public void upDateKhachHang(int id, string tenkh, bool gioitinh, string diachi, string sdt, string email)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_khachhang_update", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Id", id));
                        command.Parameters.Add(new SqlParameter("@TenKH", tenkh));
                        command.Parameters.Add(new SqlParameter("@GioiTinh", gioitinh));
                        command.Parameters.Add(new SqlParameter("@DiaChi", diachi));
                        command.Parameters.Add(new SqlParameter("@SDT", sdt));
                        command.Parameters.Add(new SqlParameter("@Email", email));

                        command.ExecuteNonQuery();
                    }
                }
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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_khachhang_delete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Id", id));
                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Search
        //public List<KhachHangModel> searchKhachHang(int pageIndex, int pageSize, out long total, string tenKhach, string diaChi)
        //{
        //    total = 0;
        //    List<KhachHangModel> khachHangs = new List<KhachHangModel>();

        //    try
        //    {
        //        // Thực hiện truy vấn sử dụng Entity Framework Core
        //        khachHangs = _context.KhachHangs
        //        .FromSqlRaw("sp_khach_search @page_index, @page_size, @ten_khach, @dia_chi",
        //            new SqlParameter("@page_index", pageIndex),
        //            new SqlParameter("@page_size", pageSize),
        //            new SqlParameter("@ten_khach", tenKhach),
        //            new SqlParameter("@dia_chi", diaChi))
        //        .Select(kh => new KhachHangModel
        //        {
        //            Id = kh.Id,
        //            TenKh = kh.TenKh,
        //            GioiTinh = kh.GioiTinh,
        //            DiaChi = kh.DiaChi,
        //            Sdt = kh.Sdt,
        //            Email = kh.Email
        //            // Các thuộc tính khác tương tự
        //        })
        //        .ToList();


        //        // Lấy tổng số lượng bản ghi
        //        total = _context.KhachHangs
        //            .FromSqlRaw("sp_khach_search @page_index, @page_size, @ten_khach, @dia_chi",
        //                new SqlParameter("@page_index", pageIndex),
        //                new SqlParameter("@page_size", pageSize),
        //                new SqlParameter("@ten_khach", tenKhach),
        //                new SqlParameter("@dia_chi", diaChi))
        //            .Count();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Xử lý lỗi
        //        throw ex;
        //    }

        //    return khachHangs;
        //}

    }
}


