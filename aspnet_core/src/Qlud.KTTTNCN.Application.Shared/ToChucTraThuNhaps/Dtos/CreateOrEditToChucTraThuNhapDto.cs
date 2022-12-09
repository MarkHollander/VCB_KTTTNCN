using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos
{
    public class CreateOrEditToChucTraThuNhapDto : EntityDto<int?>
    {

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxTenToChucLength, MinimumLength = ToChucTraThuNhapConsts.MinTenToChucLength)]
        public string TenToChuc { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxMaSoThueLength, MinimumLength = ToChucTraThuNhapConsts.MinMaSoThueLength)]
        public string MaSoThue { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxDiaChiLength, MinimumLength = ToChucTraThuNhapConsts.MinDiaChiLength)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxSoDienThoaiLength, MinimumLength = ToChucTraThuNhapConsts.MinSoDienThoaiLength)]
        public string SoDienThoai { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxUserNhapLength, MinimumLength = ToChucTraThuNhapConsts.MinUserNhapLength)]
        public string UserNhap { get; set; }

        public DateTime ThoiGianNhap { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxTrangThaiLength, MinimumLength = ToChucTraThuNhapConsts.MinTrangThaiLength)]
        public string TrangThai { get; set; }

    }
}