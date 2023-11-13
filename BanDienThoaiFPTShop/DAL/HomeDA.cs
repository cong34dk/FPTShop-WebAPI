using DAL.Interfaces;
using DAL.Models;
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


    }
}
