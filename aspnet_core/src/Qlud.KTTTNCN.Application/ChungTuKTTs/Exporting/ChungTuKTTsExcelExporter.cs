using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Qlud.KTTTNCN.DataExporting.Excel.NPOI;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.Dto;
using Qlud.KTTTNCN.Storage;

namespace Qlud.KTTTNCN.ChungTuKTTs.Exporting
{
    public class ChungTuKTTsExcelExporter : NpoiExcelExporterBase, IChungTuKTTsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ChungTuKTTsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetChungTuKTTForViewDto> chungTuKTTs)
        {
            return CreateExcelPackage(
                "ChungTuKTTs.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("ChungTuKTTs"));

                    AddHeader(
                        sheet,
                        L("HoTen"),
                        L("MaSoThue"),
                        L("DiaChi"),
                        L("QuocTich"),
                        L("CuTru"),
                        L("CCCD"),
                        L("NoiCap"),
                        L("NgayCap"),
                        L("KhoanThuNhap"),
                        L("BaoHiemBatBuoc"),
                        L("ThoiDiemTraThuNhapThang"),
                        L("ThoiDiemTraThuNhapNam"),
                        L("TongThuNhapChiuThue"),
                        L("TongThuNhapTinhThue"),
                        L("SoThueTNCNDaKhauTru"),
                        L("SoThuNhapDuocNhan"),
                        L("KhoanDongGop"),
                        L("Email"),
                        L("ThoiGianNhap"),
                        L("ThoiGianDuyet"),
                        L("UserNhap"),
                        L("UserDuyet"),
                        L("TrangThai"),
                        L("MauSo"),
                        L("KyHieu"),
                        L("SoChungTu")
                        );

                    AddObjects(
                        sheet, chungTuKTTs,
                        _ => _.ChungTuKTT.HoTen,
                        _ => _.ChungTuKTT.MaSoThue,
                        _ => _.ChungTuKTT.DiaChi,
                        _ => _.ChungTuKTT.QuocTich,
                        _ => _.ChungTuKTT.CuTru,
                        _ => _.ChungTuKTT.CCCD,
                        _ => _.ChungTuKTT.NoiCap,
                        _ => _timeZoneConverter.Convert(_.ChungTuKTT.NgayCap, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.ChungTuKTT.KhoanThuNhap,
                        _ => _.ChungTuKTT.BaoHiemBatBuoc,
                        _ => _.ChungTuKTT.ThoiDiemTraThuNhapThang,
                        _ => _.ChungTuKTT.ThoiDiemTraThuNhapNam,
                        _ => _.ChungTuKTT.TongThuNhapChiuThue,
                        _ => _.ChungTuKTT.TongThuNhapTinhThue,
                        _ => _.ChungTuKTT.SoThueTNCNDaKhauTru,
                        _ => _.ChungTuKTT.SoThuNhapDuocNhan,
                        _ => _.ChungTuKTT.KhoanDongGop,
                        _ => _.ChungTuKTT.Email,
                        _ => _timeZoneConverter.Convert(_.ChungTuKTT.ThoiGianNhap, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _timeZoneConverter.Convert(_.ChungTuKTT.ThoiGianDuyet, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.ChungTuKTT.UserNhap,
                        _ => _.ChungTuKTT.UserDuyet,
                        _ => _.ChungTuKTT.TrangThai,
                        _ => _.ChungTuKTT.MauSo,
                        _ => _.ChungTuKTT.KyHieu,
                        _ => _.ChungTuKTT.SoChungTu
                        );

                    for (var i = 1; i <= chungTuKTTs.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[8], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(8); for (var i = 1; i <= chungTuKTTs.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[19], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(19); for (var i = 1; i <= chungTuKTTs.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[20], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(20);
                });
        }
    }
}