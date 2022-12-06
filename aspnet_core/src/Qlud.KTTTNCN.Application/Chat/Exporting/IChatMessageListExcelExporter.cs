using System.Collections.Generic;
using Abp;
using Qlud.KTTTNCN.Chat.Dto;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
