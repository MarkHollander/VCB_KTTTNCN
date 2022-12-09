using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Qlud.KTTTNCN.ChungTuKTTs
{
    [Table("ChungTuKTTs")]
    public class ChungTuKTT : Entity<long>
    {

        [Required]
        [StringLength(ChungTuKTTConsts.MaxHoTenLength, MinimumLength = ChungTuKTTConsts.MinHoTenLength)]
        public virtual string HoTen { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxMaSoThueLength, MinimumLength = ChungTuKTTConsts.MinMaSoThueLength)]
        public virtual string MaSoThue { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxDiaChiLength, MinimumLength = ChungTuKTTConsts.MinDiaChiLength)]
        public virtual string DiaChi { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxQuocTichLength, MinimumLength = ChungTuKTTConsts.MinQuocTichLength)]
        public virtual string QuocTich { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxCuTruLength, MinimumLength = ChungTuKTTConsts.MinCuTruLength)]
        public virtual string CuTru { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxCCCDLength, MinimumLength = ChungTuKTTConsts.MinCCCDLength)]
        public virtual string CCCD { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxNoiCapLength, MinimumLength = ChungTuKTTConsts.MinNoiCapLength)]
        public virtual string NoiCap { get; set; }

        public virtual DateTime NgayCap { get; set; }

        public virtual decimal KhoanThuNhap { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxBaoHiemBatBuocLength, MinimumLength = ChungTuKTTConsts.MinBaoHiemBatBuocLength)]
        public virtual string BaoHiemBatBuoc { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxThoiDiemTraThuNhapThangLength, MinimumLength = ChungTuKTTConsts.MinThoiDiemTraThuNhapThangLength)]
        public virtual string ThoiDiemTraThuNhapThang { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxThoiDiemTraThuNhapNamLength, MinimumLength = ChungTuKTTConsts.MinThoiDiemTraThuNhapNamLength)]
        public virtual string ThoiDiemTraThuNhapNam { get; set; }

        public virtual decimal TongThuNhapChiuThue { get; set; }

        public virtual decimal TongThuNhapTinhThue { get; set; }

        public virtual decimal SoThueTNCNDaKhauTru { get; set; }

        public virtual decimal SoThuNhapDuocNhan { get; set; }

        public virtual decimal KhoanDongGop { get; set; }

        [StringLength(ChungTuKTTConsts.MaxEmailLength, MinimumLength = ChungTuKTTConsts.MinEmailLength)]
        public virtual string Email { get; set; }

        public virtual DateTime ThoiGianNhap { get; set; }

        public virtual DateTime ThoiGianDuyet { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxUserNhapLength, MinimumLength = ChungTuKTTConsts.MinUserNhapLength)]
        public virtual string UserNhap { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxUserDuyetLength, MinimumLength = ChungTuKTTConsts.MinUserDuyetLength)]
        public virtual string UserDuyet { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxTrangThaiLength, MinimumLength = ChungTuKTTConsts.MinTrangThaiLength)]
        public virtual string TrangThai { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxMauSoLength, MinimumLength = ChungTuKTTConsts.MinMauSoLength)]
        public virtual string MauSo { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxKyHieuLength, MinimumLength = ChungTuKTTConsts.MinKyHieuLength)]
        public virtual string KyHieu { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxSoChungTuLength, MinimumLength = ChungTuKTTConsts.MinSoChungTuLength)]
        public virtual string SoChungTu { get; set; }

    }
}