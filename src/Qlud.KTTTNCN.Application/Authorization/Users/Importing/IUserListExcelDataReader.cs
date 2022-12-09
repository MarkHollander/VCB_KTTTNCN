using System.Collections.Generic;
using Qlud.KTTTNCN.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Qlud.KTTTNCN.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
