using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Qlud.KTTTNCN.ToChucTraThuNhaps.Exporting;
using Qlud.KTTTNCN.ToChucTraThuNhaps.Dtos;
using Qlud.KTTTNCN.Dto;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using Qlud.KTTTNCN.Storage;

namespace Qlud.KTTTNCN.ToChucTraThuNhaps
{
    [AbpAuthorize(AppPermissions.Pages_ToChucTraThuNhaps)]
    public class ToChucTraThuNhapsAppService : KTTTNCNAppServiceBase, IToChucTraThuNhapsAppService
    {
        private readonly IRepository<ToChucTraThuNhap> _toChucTraThuNhapRepository;
        private readonly IToChucTraThuNhapsExcelExporter _toChucTraThuNhapsExcelExporter;

        public ToChucTraThuNhapsAppService(IRepository<ToChucTraThuNhap> toChucTraThuNhapRepository, IToChucTraThuNhapsExcelExporter toChucTraThuNhapsExcelExporter)
        {
            _toChucTraThuNhapRepository = toChucTraThuNhapRepository;
            _toChucTraThuNhapsExcelExporter = toChucTraThuNhapsExcelExporter;

        }

        public async Task<PagedResultDto<GetToChucTraThuNhapForViewDto>> GetAll(GetAllToChucTraThuNhapsInput input)
        {

            var filteredToChucTraThuNhaps = _toChucTraThuNhapRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.TenToChuc.Contains(input.Filter) || e.MaSoThue.Contains(input.Filter) || e.DiaChi.Contains(input.Filter) || e.SoDienThoai.Contains(input.Filter) || e.UserNhap.Contains(input.Filter) || e.TrangThai.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TenToChucFilter), e => e.TenToChuc == input.TenToChucFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MaSoThueFilter), e => e.MaSoThue == input.MaSoThueFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DiaChiFilter), e => e.DiaChi == input.DiaChiFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SoDienThoaiFilter), e => e.SoDienThoai == input.SoDienThoaiFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNhapFilter), e => e.UserNhap == input.UserNhapFilter)
                        .WhereIf(input.MinThoiGianNhapFilter != null, e => e.ThoiGianNhap >= input.MinThoiGianNhapFilter)
                        .WhereIf(input.MaxThoiGianNhapFilter != null, e => e.ThoiGianNhap <= input.MaxThoiGianNhapFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TrangThaiFilter), e => e.TrangThai == input.TrangThaiFilter);

            var pagedAndFilteredToChucTraThuNhaps = filteredToChucTraThuNhaps
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var toChucTraThuNhaps = from o in pagedAndFilteredToChucTraThuNhaps
                                    select new
                                    {

                                        o.TenToChuc,
                                        o.MaSoThue,
                                        o.DiaChi,
                                        o.SoDienThoai,
                                        o.UserNhap,
                                        o.ThoiGianNhap,
                                        o.TrangThai,
                                        Id = o.Id
                                    };

            var totalCount = await filteredToChucTraThuNhaps.CountAsync();

            var dbList = await toChucTraThuNhaps.ToListAsync();
            var results = new List<GetToChucTraThuNhapForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetToChucTraThuNhapForViewDto()
                {
                    ToChucTraThuNhap = new ToChucTraThuNhapDto
                    {

                        TenToChuc = o.TenToChuc,
                        MaSoThue = o.MaSoThue,
                        DiaChi = o.DiaChi,
                        SoDienThoai = o.SoDienThoai,
                        UserNhap = o.UserNhap,
                        ThoiGianNhap = o.ThoiGianNhap,
                        TrangThai = o.TrangThai,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetToChucTraThuNhapForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetToChucTraThuNhapForViewDto> GetToChucTraThuNhapForView(int id)
        {
            var toChucTraThuNhap = await _toChucTraThuNhapRepository.GetAsync(id);

            var output = new GetToChucTraThuNhapForViewDto { ToChucTraThuNhap = ObjectMapper.Map<ToChucTraThuNhapDto>(toChucTraThuNhap) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_ToChucTraThuNhaps_Edit)]
        public async Task<GetToChucTraThuNhapForEditOutput> GetToChucTraThuNhapForEdit(EntityDto input)
        {
            var toChucTraThuNhap = await _toChucTraThuNhapRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetToChucTraThuNhapForEditOutput { ToChucTraThuNhap = ObjectMapper.Map<CreateOrEditToChucTraThuNhapDto>(toChucTraThuNhap) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditToChucTraThuNhapDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_ToChucTraThuNhaps_Create)]
        protected virtual async Task Create(CreateOrEditToChucTraThuNhapDto input)
        {
            var toChucTraThuNhap = ObjectMapper.Map<ToChucTraThuNhap>(input);

            await _toChucTraThuNhapRepository.InsertAsync(toChucTraThuNhap);

        }

        [AbpAuthorize(AppPermissions.Pages_ToChucTraThuNhaps_Edit)]
        protected virtual async Task Update(CreateOrEditToChucTraThuNhapDto input)
        {
            var toChucTraThuNhap = await _toChucTraThuNhapRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, toChucTraThuNhap);

        }

        [AbpAuthorize(AppPermissions.Pages_ToChucTraThuNhaps_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _toChucTraThuNhapRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetToChucTraThuNhapsToExcel(GetAllToChucTraThuNhapsForExcelInput input)
        {

            var filteredToChucTraThuNhaps = _toChucTraThuNhapRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.TenToChuc.Contains(input.Filter) || e.MaSoThue.Contains(input.Filter) || e.DiaChi.Contains(input.Filter) || e.SoDienThoai.Contains(input.Filter) || e.UserNhap.Contains(input.Filter) || e.TrangThai.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TenToChucFilter), e => e.TenToChuc == input.TenToChucFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MaSoThueFilter), e => e.MaSoThue == input.MaSoThueFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DiaChiFilter), e => e.DiaChi == input.DiaChiFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SoDienThoaiFilter), e => e.SoDienThoai == input.SoDienThoaiFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNhapFilter), e => e.UserNhap == input.UserNhapFilter)
                        .WhereIf(input.MinThoiGianNhapFilter != null, e => e.ThoiGianNhap >= input.MinThoiGianNhapFilter)
                        .WhereIf(input.MaxThoiGianNhapFilter != null, e => e.ThoiGianNhap <= input.MaxThoiGianNhapFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TrangThaiFilter), e => e.TrangThai == input.TrangThaiFilter);

            var query = (from o in filteredToChucTraThuNhaps
                         select new GetToChucTraThuNhapForViewDto()
                         {
                             ToChucTraThuNhap = new ToChucTraThuNhapDto
                             {
                                 TenToChuc = o.TenToChuc,
                                 MaSoThue = o.MaSoThue,
                                 DiaChi = o.DiaChi,
                                 SoDienThoai = o.SoDienThoai,
                                 UserNhap = o.UserNhap,
                                 ThoiGianNhap = o.ThoiGianNhap,
                                 TrangThai = o.TrangThai,
                                 Id = o.Id
                             }
                         });

            var toChucTraThuNhapListDtos = await query.ToListAsync();

            return _toChucTraThuNhapsExcelExporter.ExportToFile(toChucTraThuNhapListDtos);
        }

    }
}