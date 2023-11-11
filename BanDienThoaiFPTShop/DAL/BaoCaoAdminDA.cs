using DAL.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class BaoCaoAdminDA : IBaoCaoAdminDA
    {
        private readonly string _connectionString;

        public BaoCaoAdminDA(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("connect");
        }

        public decimal GetTotalRevenue()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_GetTotalRevenue", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    return (decimal)command.ExecuteScalar();
                }
            }
        }

        public decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_GetTotalRevenueByDateRange", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);

                    connection.Open();

                    return (decimal)command.ExecuteScalar();
                }
            }
        }

        // Thêm các phương thức báo cáo khác theo yêu cầu tại đây
    }
}
