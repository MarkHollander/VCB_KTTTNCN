using System.Collections.Generic;
using Qlud.KTTTNCN.Auditing.Dto;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
