using DTO;
using System;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IBaoCaoAdminDA
    {
        decimal GetTotalRevenue();
        decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate);
        // Thêm các phương thức khác để lấy số liệu khác cần thiết cho báo cáo
    }
}
