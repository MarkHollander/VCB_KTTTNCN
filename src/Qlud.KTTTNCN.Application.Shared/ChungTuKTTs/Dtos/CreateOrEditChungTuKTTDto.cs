using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Qlud.KTTTNCN.ChungTuKTTs.Dtos
{
    public class CreateOrEditChungTuKTTDto : EntityDto<long?>
    {

        [Required]
        [StringLength(ChungTuKTTConsts.MaxHoTenLength, MinimumLength = ChungTuKTTConsts.MinHoTenLength)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxMaSoThueLength, MinimumLength = ChungTuKTTConsts.MinMaSoThueLength)]
        public string MaSoThue { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxDiaChiLength, MinimumLength = ChungTuKTTConsts.MinDiaChiLength)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxQuocTichLength, MinimumLength = ChungTuKTTConsts.MinQuocTichLength)]
        public string QuocTich { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxCuTruLength, MinimumLength = ChungTuKTTConsts.MinCuTruLength)]
        public string CuTru { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxCCCDLength, MinimumLength = ChungTuKTTConsts.MinCCCDLength)]
        public string CCCD { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxNoiCapLength, MinimumLength = ChungTuKTTConsts.MinNoiCapLength)]
        public string NoiCap { get; set; }

        public DateTime NgayCap { get; set; }

        public decimal KhoanThuNhap { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxBaoHiemBatBuocLength, MinimumLength = ChungTuKTTConsts.MinBaoHiemBatBuocLength)]
        public string BaoHiemBatBuoc { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxThoiDiemTraThuNhapThangLength, MinimumLength = ChungTuKTTConsts.MinThoiDiemTraThuNhapThangLength)]
        public string ThoiDiemTraThuNhapThang { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxThoiDiemTraThuNhapNamLength, MinimumLength = ChungTuKTTConsts.MinThoiDiemTraThuNhapNamLength)]
        public string ThoiDiemTraThuNhapNam { get; set; }

        public decimal TongThuNhapChiuThue { get; set; }

        public decimal TongThuNhapTinhThue { get; set; }

        public decimal SoThueTNCNDaKhauTru { get; set; }

        public decimal SoThuNhapDuocNhan { get; set; }

        public decimal KhoanDongGop { get; set; }

        [StringLength(ChungTuKTTConsts.MaxEmailLength, MinimumLength = ChungTuKTTConsts.MinEmailLength)]
        public string Email { get; set; }

        public DateTime ThoiGianNhap { get; set; }

        public DateTime ThoiGianDuyet { get; set; }

        [StringLength(ChungTuKTTConsts.MaxUserNhapLength, MinimumLength = ChungTuKTTConsts.MinUserNhapLength)]
        public string UserNhap { get; set; }

        [StringLength(ChungTuKTTConsts.MaxUserDuyetLength, MinimumLength = ChungTuKTTConsts.MinUserDuyetLength)]
        public string UserDuyet { get; set; }

        [Required]
        [StringLength(ChungTuKTTConsts.MaxTrangThaiLength, MinimumLength = ChungTuKTTConsts.MinTrangThaiLength)]
        public string TrangThai { get; set; }

        [StringLength(ChungTuKTTConsts.MaxMauSoLength, MinimumLength = ChungTuKTTConsts.MinMauSoLength)]
        public string MauSo { get; set; }

        [StringLength(ChungTuKTTConsts.MaxKyHieuLength, MinimumLength = ChungTuKTTConsts.MinKyHieuLength)]
        public string KyHieu { get; set; }

        [StringLength(ChungTuKTTConsts.MaxSoChungTuLength, MinimumLength = ChungTuKTTConsts.MinSoChungTuLength)]
        public string SoChungTu { get; set; }

        public string BranchCode { get; set; }
    }
}