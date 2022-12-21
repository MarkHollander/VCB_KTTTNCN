using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qlud.KTTTNCN.BaoCaoChungTus.Dtos
{
    public class BaoCaoQuanLyChungTuDto : EntityDto<long>
    {
        public int SoThuTu { get; set; }
        public string MauSo { get; set; }
        public string KyHieu { get; set; }
        public string SoChungTu { get; set; }
        public string MaSoThue { get; set; }
        public string HoVaTen { get; set; }
        public string Email { get; set; }
        public long Id { get; set; }
        public DateTime ThoiGianNhap { get; set; }
        public DateTime ThoiGianDuyet { get; set; }
        public string TrangThai { get; set; }
    }
}
