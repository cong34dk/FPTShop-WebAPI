using BLL.Interfaces;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaoCaoAdminBL : IBaoCaoAdminBL
    {
        private IBaoCaoAdminDA _baoCaoAdminDA;

        public BaoCaoAdminBL(IBaoCaoAdminDA baoCaoAdminDA)
        {
            _baoCaoAdminDA = baoCaoAdminDA;
        }

        public decimal GetTotalRevenue()
        {
            return _baoCaoAdminDA.GetTotalRevenue();
        }

        public decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate)
        {
            return _baoCaoAdminDA.GetTotalRevenueByDateRange(startDate, endDate);
        }
    }
}
