using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Qlud.KTTTNCN.BaoCaoChungTus.Dtos;
using Qlud.KTTTNCN.ChungTuKTTs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Json;
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
            Logger.Info("BaoCaoChungTus - GetChungTu: Start");
            Logger.Info("BaoCaoChungTus - GetChungTu: input = " + JsonSerializer.Serialize(input));
            int i = 1;
            var filteredChungTuKTTs = _baoCaoChungTuRepository.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.SoChungTu), x => string.Equals(x.SoChungTu, input.SoChungTu))
                .WhereIf(!string.IsNullOrWhiteSpace(input.MaSoThue), x => String.Equals(x.MaSoThue, input.MaSoThue))
                .WhereIf(!string.IsNullOrWhiteSpace(input.HoVaTen), x => string.Equals(x.HoTen, input.HoVaTen))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Status), x => string.Equals(x.TrangThai, input.Status))
                .WhereIf(input.NgayLap != null, x => x.ThoiGianNhap == input.NgayLap)
                .WhereIf(input.NgayDuyet != null, x => x.ThoiGianDuyet == input.NgayDuyet)
                ;
            //Logger.Info("BaoCaoChungTus - GetChungTu: filteredChungTuKTTsCount = " + filteredChungTuKTTs.ToList().Count);
            

            var chungTuKTTs = from o in filteredChungTuKTTs
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
            
            var pagedAndFilteredChungTuKTTs = chungTuKTTs                            
                            .PageBy(input);

            
            List<BaoCaoQuanLyChungTuDto> baoCaoQuanLyChungTu = await pagedAndFilteredChungTuKTTs.ToListAsync<BaoCaoQuanLyChungTuDto>();
            baoCaoQuanLyChungTu = baoCaoQuanLyChungTu.Select(x => { x.SoThuTu = input.SkipCount + i++; return x; })                
                .ToList();
            int totalCount = await filteredChungTuKTTs.CountAsync();
            Logger.Info("BaoCaoChungTus - totalCount: " + totalCount);
            Logger.Info("BaoCaoChungTus - GetChungTu: End");
            return new PagedResultDto<BaoCaoQuanLyChungTuDto>(
                totalCount,
                baoCaoQuanLyChungTu
            );
        }
    }
}
