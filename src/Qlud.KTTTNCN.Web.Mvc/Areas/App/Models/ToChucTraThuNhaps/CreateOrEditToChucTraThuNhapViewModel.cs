using Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos;

using Abp.Extensions;

namespace Qlud.KTTTNCN.Web.Areas.App.Models.ToChucTraThuNhaps
{
    public class CreateOrEditToChucTraThuNhapModalViewModel
    {
        public CreateOrEditToChucTraThuNhapDto ToChucTraThuNhap { get; set; }

        public bool IsEditMode => ToChucTraThuNhap.Id.HasValue;
    }
}