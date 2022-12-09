using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.MultiTenancy.Accounting.Dto;

namespace Qlud.KTTTNCN.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
