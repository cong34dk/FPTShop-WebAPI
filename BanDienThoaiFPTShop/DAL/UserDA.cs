using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data;
using DTO;

namespace DAL
{
    public class UserDA : IUserDA
    {
        private string connectionString;

        public UserDA(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("connect");
        }

        public UserModel Login(string taikhoan, string matkhau)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_login", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@taikhoan", taikhoan));
                        command.Parameters.Add(new SqlParameter("@matkhau", matkhau));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var dt = new UserModel();

                            while (reader.Read())
                            {
                                // Đọc dữ liệu từ SqlDataReader và cài đặt thuộc tính của UserModel
                                dt.MaTaiKhoan = reader.GetInt32(reader.GetOrdinal("MaTaiKhoan"));
                                dt.LoaiTaiKhoan = reader.GetInt32(reader.GetOrdinal("LoaiTaiKhoan"));
                                dt.TenTaiKhoan = reader.GetString(reader.GetOrdinal("TenTaiKhoan"));
                                dt.MatKhau = reader.GetString(reader.GetOrdinal("MatKhau"));
                                dt.Email = reader.GetString(reader.GetOrdinal("Email"));
                            }

                            return dt;
                        }
                    }
                }

                return null; // Trả về null nếu không tìm thấy tài khoản
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UserModel GetUserById(int userId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("sp_get_by_id_user", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@Id", userId));

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var user = new UserModel();

                            while (reader.Read())
                            {
                                user.MaTaiKhoan = reader.GetInt32(reader.GetOrdinal("MaTaiKhoan"));
                                user.LoaiTaiKhoan = reader.GetInt32(reader.GetOrdinal("LoaiTaiKhoan"));
                                user.TenTaiKhoan = reader.GetString(reader.GetOrdinal("TenTaiKhoan"));
                                user.MatKhau = reader.GetString(reader.GetOrdinal("MatKhau"));
                                user.Email = reader.GetString(reader.GetOrdinal("Email"));
                            }

                            return user;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public List<UserModel> GetAllUsers()
        {
            List<UserModel> users = new List<UserModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("sp_get_all_users", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new UserModel
                            {
                                MaTaiKhoan = reader.GetInt32(reader.GetOrdinal("MaTaiKhoan")),
                                LoaiTaiKhoan = reader.GetInt32(reader.GetOrdinal("LoaiTaiKhoan")),
                                TenTaiKhoan = reader.GetString(reader.GetOrdinal("TenTaiKhoan")),
                                MatKhau = reader.GetString(reader.GetOrdinal("MatKhau")),
                                Email = reader.GetString(reader.GetOrdinal("Email"))
                            };
                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public UserModel AddUser(UserModel userModel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("sp_create_user", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@LoaiTaiKhoan", userModel.LoaiTaiKhoan));
                    command.Parameters.Add(new SqlParameter("@TenTaiKhoan", userModel.TenTaiKhoan));
                    command.Parameters.Add(new SqlParameter("@MatKhau", userModel.MatKhau));
                    command.Parameters.Add(new SqlParameter("@Email", userModel.Email));
                    // Thêm các tham số khác nếu cần thiết

                    // Thực hiện thêm và trả về thông tin tài khoản vừa thêm
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var addedUser = new UserModel
                            {
                                MaTaiKhoan = reader.GetInt32(reader.GetOrdinal("MaTaiKhoan")),
                                LoaiTaiKhoan = userModel.LoaiTaiKhoan,
                                TenTaiKhoan = userModel.TenTaiKhoan,
                                MatKhau = userModel.MatKhau,
                                Email = userModel.Email
                            };
                            return addedUser;
                        }
                    }
                }
            }

            return null;
        }

        public UserModel UpdateUser(UserModel userModel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_update_user", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaTaiKhoan", userModel.MaTaiKhoan));
                    command.Parameters.Add(new SqlParameter("@LoaiTaiKhoan", userModel.LoaiTaiKhoan));
                    command.Parameters.Add(new SqlParameter("@TenTaiKhoan", userModel.TenTaiKhoan));
                    command.Parameters.Add(new SqlParameter("@MatKhau", userModel.MatKhau));
                    command.Parameters.Add(new SqlParameter("@Email", userModel.Email));

                    // Thực hiện cập nhật thông tin tài khoản
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return userModel;
                    }
                }
            }
            return null;
        }

        public bool DeleteUser(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("sp_delete_user", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@MaTaiKhoan", userId));

                    // Thực hiện xóa tài khoản
                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
        }
    }
}


