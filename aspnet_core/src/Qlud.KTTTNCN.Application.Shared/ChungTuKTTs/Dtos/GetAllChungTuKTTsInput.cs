using Abp.Application.Services.Dto;
using System;

namespace Qlud.KTTTNCN.ChungTuKTTs.Dtos
{
    public class GetAllChungTuKTTsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }

        public string HoTenFilter { get; set; }

        public string MaSoThueFilter { get; set; }

        public string DiaChiFilter { get; set; }

        public string QuocTichFilter { get; set; }

        public string CuTruFilter { get; set; }

        public string CCCDFilter { get; set; }

        public string NoiCapFilter { get; set; }

        public DateTime? MaxNgayCapFilter { get; set; }
        public DateTime? MinNgayCapFilter { get; set; }

        public decimal? MaxKhoanThuNhapFilter { get; set; }
        public decimal? MinKhoanThuNhapFilter { get; set; }

        public string BaoHiemBatBuocFilter { get; set; }

        public string ThoiDiemTraThuNhapThangFilter { get; set; }

        public string ThoiDiemTraThuNhapNamFilter { get; set; }

        public decimal? MaxTongThuNhapChiuThueFilter { get; set; }
        public decimal? MinTongThuNhapChiuThueFilter { get; set; }

        public decimal? MaxTongThuNhapTinhThueFilter { get; set; }
        public decimal? MinTongThuNhapTinhThueFilter { get; set; }

        public decimal? MaxSoThueTNCNDaKhauTruFilter { get; set; }
        public decimal? MinSoThueTNCNDaKhauTruFilter { get; set; }

        public decimal? MaxSoThuNhapDuocNhanFilter { get; set; }
        public decimal? MinSoThuNhapDuocNhanFilter { get; set; }

        public decimal? MaxKhoanDongGopFilter { get; set; }
        public decimal? MinKhoanDongGopFilter { get; set; }

        public string EmailFilter { get; set; }

        public DateTime? MaxThoiGianNhapFilter { get; set; }
        public DateTime? MinThoiGianNhapFilter { get; set; }

        public DateTime? MaxThoiGianDuyetFilter { get; set; }
        public DateTime? MinThoiGianDuyetFilter { get; set; }

        public string UserNhapFilter { get; set; }

        public string UserDuyetFilter { get; set; }

        public string TrangThaiFilter { get; set; }

        public string MauSoFilter { get; set; }

        public string KyHieuFilter { get; set; }

        public string SoChungTuFilter { get; set; }

    }
}