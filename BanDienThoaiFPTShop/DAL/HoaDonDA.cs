using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using DTO;
using DTO;
using Microsoft.Extensions.Configuration;

public class HoaDonDA
{
    private string connectionString;

    public HoaDonDA(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("connect");
    }

    public HoaDonModel GetHoadonByID(int maHoaDon)
    {
        HoaDonModel hoadon = null;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("sp_hoadon_get_by_id", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@MaHoaDon", maHoaDon));

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string jsonResult = reader.GetString(0);
                        hoadon = JsonSerializer.Deserialize<HoaDonModel>(jsonResult);
                    }
                }
            }
        }

        return hoadon;
    }
}
