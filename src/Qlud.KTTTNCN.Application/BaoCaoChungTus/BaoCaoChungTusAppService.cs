using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Qlud.KTTTNCN.BaoCaoChungTus.Dtos;
using Qlud.KTTTNCN.ChungTuKTTs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qlud.KTTTNCN.Dto;
using Abp.Authorization;
using Qlud.KTTTNCN.Authorization;

namespace Qlud.KTTTNCN.BaoCaoChungTus
{
    [AbpAuthorize(AppPermissions.Pages_BaoCaoQuanLyChungTus)]
    public class BaoCaoChungTusAppService: KTTTNCNAppServiceBase, IBaoCaoChungTusAppService
    {
        private readonly IRepository<ChungTuKTT, long> _baoCaoChungTuRepository;
        private readonly IBaoCaoChungTusExporter _baoCaoChungTusExcelExporter;
        public BaoCaoChungTusAppService(IRepository<ChungTuKTT, long> baoCaoChungTuRepository, IBaoCaoChungTusExporter baoCaoChungTusExcelExporter)
        {
            _baoCaoChungTuRepository = baoCaoChungTuRepository;
            _baoCaoChungTusExcelExporter = baoCaoChungTusExcelExporter;
        }

        public FileDto ExportBaoCaoToPDF(long chungTuId)
        {
            return _baoCaoChungTusExcelExporter.ExportToPDF(chungTuId);
        }

        public FileDto ExportBaoCaoToXML(long chungTuId)
        {
            return _baoCaoChungTusExcelExporter.ExportToXML(chungTuId);
        }

        public async Task<PagedResultDto<BaoCaoQuanLyChungTuDto>> GetChungTu(GetChungTuInput input)
        {
            var filteredChungTuKTTs = _baoCaoChungTuRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.SoChungTu), x => String.Compare(x.SoChungTu, input.SoChungTu, StringComparison.OrdinalIgnoreCase) != 0)
                .WhereIf(!string.IsNullOrWhiteSpace(input.MaSoThue), x => String.Compare(x.MaSoThue, input.MaSoThue, StringComparison.OrdinalIgnoreCase) != 0)
                .WhereIf(!string.IsNullOrWhiteSpace(input.HoVaTen), x => String.Compare(x.HoTen, input.HoVaTen, StringComparison.OrdinalIgnoreCase) != 0)
                .WhereIf(!string.IsNullOrWhiteSpace(input.Status), x => String.Compare(x.TrangThai, input.Status, StringComparison.OrdinalIgnoreCase) != 0)
                .WhereIf(input.NgayLap != null, x => x.ThoiGianNhap == input.NgayLap)
                .WhereIf(input.NgayDuyet != null, x => x.ThoiGianDuyet == input.NgayDuyet)
                ;
            var pagedAndFilteredChungTuKTTs = filteredChungTuKTTs
                .OrderBy("id desc")
                .PageBy(input);

            var chungTuKTTs = from o in pagedAndFilteredChungTuKTTs
                              select new BaoCaoQuanLyChungTuDto()
                              {
                                  
                                  HoVaTen = o.HoTen,
                                  MaSoThue = o.MaSoThue,
                                  Email = o.Email,
                                  ThoiGianNhap = o.ThoiGianNhap,
                                  ThoiGianDuyet = o.ThoiGianDuyet,
                                  MauSo = string.IsNullOrEmpty(o.MauSo) ? "" : o.MauSo,
                                  KyHieu = string.IsNullOrEmpty(o.KyHieu) ? "" : o.KyHieu,
                                  SoChungTu = string.IsNullOrEmpty(o.SoChungTu) ? "" : o.SoChungTu,
                                  TrangThai = QludConsts.TrangThai.DisplayList[o.TrangThai],
                                  Id = o.Id
                              };


            int i = 0;
            List<BaoCaoQuanLyChungTuDto> dbList = await chungTuKTTs.ToListAsync<BaoCaoQuanLyChungTuDto>();
            dbList = dbList.Select(o => { o.SoThuTu = i++; return o; }).ToList();
            int totalCount = dbList.Count();
            return new PagedResultDto<BaoCaoQuanLyChungTuDto>(
                totalCount,
                dbList
            );
        }
    }
}
