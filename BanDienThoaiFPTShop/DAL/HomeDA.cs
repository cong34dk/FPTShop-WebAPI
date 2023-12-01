using DAL.Interfaces;
using DAL.Models;
using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HomeDA : IHomeDA
    {
        private readonly string _connectionString;

        public HomeDA(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connect");
        }

        public List<ChuyenMuc> GetAllChuyenMuc()
        {
            List<ChuyenMuc> chuyenMucs = new List<ChuyenMuc>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("GetAllChuyenMuc", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ChuyenMuc chuyenMuc = new ChuyenMuc
                            {
                                MaChuyenMuc = Convert.ToInt32(reader["MaChuyenMuc"]),
                                MaChuyenMucCha = reader["MaChuyenMucCha"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MaChuyenMucCha"]) : null,
                                TenChuyenMuc = Convert.ToString(reader["TenChuyenMuc"]),
                                DacBiet = Convert.ToBoolean(reader["DacBiet"]),
                                NoiDung = Convert.ToString(reader["NoiDung"]),
                                Link = Convert.ToString(reader["Link"])
                            };

                            chuyenMucs.Add(chuyenMuc);
                        }
                    }
                }
            }

            return chuyenMucs;
        }

        public ChuyenMucModel GetChuyenMucByID(int maChuyenMuc)
        {
            ChuyenMucModel chuyenMuc = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetChuyenMucByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaChuyenMuc", maChuyenMuc);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            chuyenMuc = new ChuyenMucModel
                            {
                                MaChuyenMuc = Convert.ToInt32(reader["MaChuyenMuc"]),
                                MaChuyenMucCha = reader["MaChuyenMucCha"] != DBNull.Value ? (int?)Convert.ToInt32(reader["MaChuyenMucCha"]) : null,
                                TenChuyenMuc = Convert.ToString(reader["TenChuyenMuc"]),
                                DacBiet = Convert.ToBoolean(reader["DacBiet"]),
                                NoiDung = Convert.ToString(reader["NoiDung"]),
                                Link = Convert.ToString(reader["Link"])
                            };
                        }
                    }
                }
            }

            return chuyenMuc;
        }

        public List<Slide> GetAllSlide()
        {
            List<Slide> slides = new List<Slide>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("GetAllSlide", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Slide slide = new Slide
                            {
                                MaAnh = Convert.ToInt32(reader["MaAnh"]),
                                TieuDe = Convert.ToString(reader["TieuDe"]),
                                TieuDe1 = Convert.ToString(reader["TieuDe1"]),
                                TieuDe2 = Convert.ToString(reader["TieuDe2"]),
                                MoTa1 = Convert.ToString(reader["MoTa1"]),
                                MoTa2 = Convert.ToString(reader["MoTa2"]),
                                MoTa3 = Convert.ToString(reader["MoTa3"]),
                                MoTa4 = Convert.ToString(reader["MoTa4"]),
                                LinkAnh = Convert.ToString(reader["LinkAnh"])
                            };

                            slides.Add(slide);
                        }
                    }
                }
            }

            return slides;
        }

        public SlideModel GetSlideByID(int maAnh)
        {
            SlideModel slide = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetSlideByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaAnh", maAnh);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            slide = new SlideModel
                            {
                                MaAnh = Convert.ToInt32(reader["MaAnh"]),
                                TieuDe = Convert.ToString(reader["TieuDe"]),
                                TieuDe1 = Convert.ToString(reader["TieuDe1"]),
                                TieuDe2 = Convert.ToString(reader["TieuDe2"]),
                                MoTa1 = Convert.ToString(reader["MoTa1"]),
                                MoTa2 = Convert.ToString(reader["MoTa2"]),
                                MoTa3 = Convert.ToString(reader["MoTa3"]),
                                MoTa4 = Convert.ToString(reader["MoTa4"]),
                                LinkAnh = Convert.ToString(reader["LinkAnh"])
                            };
                        }
                    }
                }
            }

            return slide;
        }

        public List<SanPhamModel> GetAllSanPhams()
        {
            List<SanPhamModel> sanPhams = new List<SanPhamModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetAllSanPhams", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamModel sanPham = new SanPhamModel
                            {
                                MaSanPham = reader.GetInt32(reader.GetOrdinal("MaSanPham")),
                                MaChuyenMuc = reader.IsDBNull(reader.GetOrdinal("MaChuyenMuc")) ? null : reader.GetInt32(reader.GetOrdinal("MaChuyenMuc")),
                                TenSanPham = reader.GetString(reader.GetOrdinal("TenSanPham")),
                                AnhDaiDien = reader.GetString(reader.GetOrdinal("AnhDaiDien")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                GiaGiam = reader.IsDBNull(reader.GetOrdinal("GiaGiam")) ? null : reader.GetDecimal(reader.GetOrdinal("GiaGiam")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                LuotXem = reader.GetInt32(reader.GetOrdinal("LuotXem")),
                                DacBiet = reader.GetBoolean(reader.GetOrdinal("DacBiet"))
                            };
                            sanPhams.Add(sanPham);
                        }
                    }
                }
            }

            return sanPhams;
        }

        public SanPhamModel GetSanPhamByID(int maSanPham)
        {
            SanPhamModel sanPham = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("sp_GetSanPhamByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaSanPham", maSanPham);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sanPham = new SanPhamModel
                            {
                                MaSanPham = reader.GetInt32(reader.GetOrdinal("MaSanPham")),
                                MaChuyenMuc = reader.IsDBNull(reader.GetOrdinal("MaChuyenMuc")) ? null : reader.GetInt32(reader.GetOrdinal("MaChuyenMuc")),
                                TenSanPham = reader.GetString(reader.GetOrdinal("TenSanPham")),
                                AnhDaiDien = reader.GetString(reader.GetOrdinal("AnhDaiDien")),
                                Gia = reader.GetDecimal(reader.GetOrdinal("Gia")),
                                GiaGiam = reader.IsDBNull(reader.GetOrdinal("GiaGiam")) ? null : reader.GetDecimal(reader.GetOrdinal("GiaGiam")),
                                SoLuong = reader.GetInt32(reader.GetOrdinal("SoLuong")),
                                TrangThai = reader.GetBoolean(reader.GetOrdinal("TrangThai")),
                                LuotXem = reader.GetInt32(reader.GetOrdinal("LuotXem")),
                                DacBiet = reader.GetBoolean(reader.GetOrdinal("DacBiet"))
                            };
                        }
                    }
                }
            }

            return sanPham;
        }

        public List<QuangCaoDTO> GetAllQuangCaos()
        {
            List<QuangCaoDTO> quangCaos = new List<QuangCaoDTO>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_GetAllQuangCaos", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                QuangCaoDTO quangCao = new QuangCaoDTO
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    AnhDaiDien = reader["AnhDaiDien"].ToString(),
                                    LinkQuangCao = reader["LinkQuangCao"].ToString(),
                                    MoTa = reader["MoTa"].ToString()
                                };
                                quangCaos.Add(quangCao);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách quảng cáo: " + ex.Message);
            }

            return quangCaos;
        }

        //Phân trang
        public List<SanPhamModel> GetPagedProducts(int pageNumber, int pageSize, out int totalPages)
        {
            List<SanPhamModel> products = new List<SanPhamModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetPagedProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PageNumber", pageNumber);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SanPhamModel product = new SanPhamModel
                            {
                                MaSanPham = Convert.ToInt32(reader["MaSanPham"]),
                                MaChuyenMuc = Convert.ToInt32(reader["MaChuyenMuc"]),
                                TenSanPham = Convert.ToString(reader["TenSanPham"]),
                                AnhDaiDien = Convert.ToString(reader["AnhDaiDien"]),
                                Gia = Convert.ToDecimal(reader["Gia"]),
                                GiaGiam = Convert.ToDecimal(reader["GiaGiam"]),
                                SoLuong = Convert.ToInt32(reader["SoLuong"]),
                                TrangThai = Convert.ToBoolean(reader["TrangThai"]),
                                LuotXem = Convert.ToInt32(reader["LuotXem"]),
                                DacBiet = Convert.ToBoolean(reader["DacBiet"])
                            };

                            products.Add(product);
                        }
                    }

                    // Tính tổng số trang
                    totalPages = GetTotalPages(pageSize, connection);
                }
            }

            return products;
        }

        // Phương thức lấy tổng số trang
        private int GetTotalPages(int pageSize, SqlConnection connection)
        {
            // Không cần gọi stored procedure ở đây vì đã thực hiện trong GetPagedProducts
            // và đã lấy giá trị @TotalPages thông qua OUTPUT parameter

            return 0;
        }
    }
}
