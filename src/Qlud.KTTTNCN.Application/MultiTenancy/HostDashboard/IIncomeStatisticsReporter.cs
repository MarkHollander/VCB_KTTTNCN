using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Qlud.KTTTNCN.MultiTenancy.HostDashboard.Dto;

namespace Qlud.KTTTNCN.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}