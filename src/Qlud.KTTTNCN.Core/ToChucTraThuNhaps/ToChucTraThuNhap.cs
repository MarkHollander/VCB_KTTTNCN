using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps
{
    [Table("ToChucTraThuNhaps")]
    public class ToChucTraThuNhap : Entity
    {

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxTenToChucLength, MinimumLength = ToChucTraThuNhapConsts.MinTenToChucLength)]
        public virtual string TenToChuc { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxMaSoThueLength, MinimumLength = ToChucTraThuNhapConsts.MinMaSoThueLength)]
        public virtual string MaSoThue { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxDiaChiLength, MinimumLength = ToChucTraThuNhapConsts.MinDiaChiLength)]
        public virtual string DiaChi { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxSoDienThoaiLength, MinimumLength = ToChucTraThuNhapConsts.MinSoDienThoaiLength)]
        public virtual string SoDienThoai { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxUserNhapLength, MinimumLength = ToChucTraThuNhapConsts.MinUserNhapLength)]
        public virtual string UserNhap { get; set; }

        public virtual DateTime ThoiGianNhap { get; set; }

        [Required]
        [StringLength(ToChucTraThuNhapConsts.MaxTrangThaiLength, MinimumLength = ToChucTraThuNhapConsts.MinTrangThaiLength)]
        public virtual string TrangThai { get; set; }

    }
}