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

    }
}
