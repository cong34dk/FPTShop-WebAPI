using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IBaoCaoAdminBL
    {
        decimal GetTotalRevenue();
        decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate);
        // Thêm các phương thức khác để lấy số liệu khác cần thiết cho báo cáo
    }
}
