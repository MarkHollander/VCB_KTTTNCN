using System.Collections.Generic;
using Qlud.KTTTNCN.Authorization.Users.Importing.Dto;
using Qlud.KTTTNCN.Dto;

namespace Qlud.KTTTNCN.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
