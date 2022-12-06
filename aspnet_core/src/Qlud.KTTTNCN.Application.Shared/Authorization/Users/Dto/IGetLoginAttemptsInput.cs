using Abp.Application.Services.Dto;

namespace Qlud.KTTTNCN.Authorization.Users.Dto
{
    public interface IGetLoginAttemptsInput: ISortedResultRequest
    {
        string Filter { get; set; }
    }
}