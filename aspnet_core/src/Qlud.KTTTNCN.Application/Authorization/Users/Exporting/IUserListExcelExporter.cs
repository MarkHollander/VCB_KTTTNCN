using System.Collections.Generic;
using Qlud.KTTTNCN.Authorization.Users.Dto;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}