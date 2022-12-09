using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Qlud.KTTTNCN.DataExporting.Excel.NPOI;
using Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos;
using Qlud.KTTTNCN.Dto;
using Qlud.KTTTNCN.Storage;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps.Exporting
{
    public class ToChucTraThuNhapsExcelExporter : NpoiExcelExporterBase, IToChucTraThuNhapsExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ToChucTraThuNhapsExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager) :
    base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetToChucTraThuNhapForViewDto> toChucTraThuNhaps)
        {
            return CreateExcelPackage(
                "ToChucTraThuNhaps.xlsx",
                excelPackage =>
                {

                    var sheet = excelPackage.CreateSheet(L("ToChucTraThuNhaps"));

                    AddHeader(
                        sheet,
                        L("TenToChuc"),
                        L("MaSoThue"),
                        L("DiaChi"),
                        L("SoDienThoai"),
                        L("UserNhap"),
                        L("ThoiGianNhap"),
                        L("TrangThai")
                        );

                    AddObjects(
                        sheet, toChucTraThuNhaps,
                        _ => _.ToChucTraThuNhap.TenToChuc,
                        _ => _.ToChucTraThuNhap.MaSoThue,
                        _ => _.ToChucTraThuNhap.DiaChi,
                        _ => _.ToChucTraThuNhap.SoDienThoai,
                        _ => _.ToChucTraThuNhap.UserNhap,
                        _ => _timeZoneConverter.Convert(_.ToChucTraThuNhap.ThoiGianNhap, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.ToChucTraThuNhap.TrangThai
                        );

                    for (var i = 1; i <= toChucTraThuNhaps.Count; i++)
                    {
                        SetCellDataFormat(sheet.GetRow(i).Cells[6], "yyyy-mm-dd");
                    }
                    sheet.AutoSizeColumn(6);
                });
        }
    }
}