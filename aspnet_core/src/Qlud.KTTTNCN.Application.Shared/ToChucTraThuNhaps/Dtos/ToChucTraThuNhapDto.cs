using System;
using Abp.Application.Services.Dto;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos
{
    public class ToChucTraThuNhapDto : EntityDto
    {
        public string TenToChuc { get; set; }

        public string MaSoThue { get; set; }

        public string DiaChi { get; set; }

        public string SoDienThoai { get; set; }

        public string UserNhap { get; set; }

        public DateTime ThoiGianNhap { get; set; }

        public string TrangThai { get; set; }

    }
}