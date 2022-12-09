using System;
using Abp.Application.Services.Dto;

namespace Qlud.KTTTNCN.ChungTuKTTs.Dtos
{
    public class ChungTuKTTDto : EntityDto<long>
    {
        public string HoTen { get; set; }

        public string MaSoThue { get; set; }

        public string DiaChi { get; set; }

        public string QuocTich { get; set; }

        public string CuTru { get; set; }

        public string CCCD { get; set; }

        public string NoiCap { get; set; }

        public DateTime NgayCap { get; set; }

        public decimal KhoanThuNhap { get; set; }

        public string BaoHiemBatBuoc { get; set; }

        public string ThoiDiemTraThuNhapThang { get; set; }

        public string ThoiDiemTraThuNhapNam { get; set; }

        public decimal TongThuNhapChiuThue { get; set; }

        public decimal TongThuNhapTinhThue { get; set; }

        public decimal SoThueTNCNDaKhauTru { get; set; }

        public decimal SoThuNhapDuocNhan { get; set; }

        public decimal KhoanDongGop { get; set; }

        public string Email { get; set; }

        public DateTime ThoiGianNhap { get; set; }

        public DateTime ThoiGianDuyet { get; set; }

        public string UserNhap { get; set; }

        public string UserDuyet { get; set; }

        public string TrangThai { get; set; }

        public string MauSo { get; set; }

        public string KyHieu { get; set; }

        public string SoChungTu { get; set; }

    }
}