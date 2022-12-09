using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Qlud.KTTTNCN.ChungTuKTTs.Exporting;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.Dto;
using Abp.Application.Services.Dto;
using Qlud.KTTTNCN.Authorization;
using Abp.Extensions;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using Qlud.KTTTNCN.Storage;

namespace Qlud.KTTTNCN.ChungTuKTTs
{
    [AbpAuthorize(AppPermissions.Pages_ChungTuKTTs)]
    public class ChungTuKTTsAppService : KTTTNCNAppServiceBase, IChungTuKTTsAppService
    {
        private readonly IRepository<ChungTuKTT, long> _chungTuKTTRepository;
        private readonly IChungTuKTTsExcelExporter _chungTuKTTsExcelExporter;

        public ChungTuKTTsAppService(IRepository<ChungTuKTT, long> chungTuKTTRepository, IChungTuKTTsExcelExporter chungTuKTTsExcelExporter)
        {
            _chungTuKTTRepository = chungTuKTTRepository;
            _chungTuKTTsExcelExporter = chungTuKTTsExcelExporter;

        }

        public async Task<PagedResultDto<GetChungTuKTTForViewDto>> GetAll(GetAllChungTuKTTsInput input)
        {

            var filteredChungTuKTTs = _chungTuKTTRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.HoTen.Contains(input.Filter) || e.MaSoThue.Contains(input.Filter) || e.DiaChi.Contains(input.Filter) || e.QuocTich.Contains(input.Filter) || e.CuTru.Contains(input.Filter) || e.CCCD.Contains(input.Filter) || e.NoiCap.Contains(input.Filter) || e.BaoHiemBatBuoc.Contains(input.Filter) || e.ThoiDiemTraThuNhapThang.Contains(input.Filter) || e.ThoiDiemTraThuNhapNam.Contains(input.Filter) || e.Email.Contains(input.Filter) || e.UserNhap.Contains(input.Filter) || e.UserDuyet.Contains(input.Filter) || e.TrangThai.Contains(input.Filter) || e.MauSo.Contains(input.Filter) || e.KyHieu.Contains(input.Filter) || e.SoChungTu.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.HoTenFilter), e => e.HoTen == input.HoTenFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MaSoThueFilter), e => e.MaSoThue == input.MaSoThueFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DiaChiFilter), e => e.DiaChi == input.DiaChiFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.QuocTichFilter), e => e.QuocTich == input.QuocTichFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CuTruFilter), e => e.CuTru == input.CuTruFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CCCDFilter), e => e.CCCD == input.CCCDFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NoiCapFilter), e => e.NoiCap == input.NoiCapFilter)
                        .WhereIf(input.MinNgayCapFilter != null, e => e.NgayCap >= input.MinNgayCapFilter)
                        .WhereIf(input.MaxNgayCapFilter != null, e => e.NgayCap <= input.MaxNgayCapFilter)
                        .WhereIf(input.MinKhoanThuNhapFilter != null, e => e.KhoanThuNhap >= input.MinKhoanThuNhapFilter)
                        .WhereIf(input.MaxKhoanThuNhapFilter != null, e => e.KhoanThuNhap <= input.MaxKhoanThuNhapFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BaoHiemBatBuocFilter), e => e.BaoHiemBatBuoc == input.BaoHiemBatBuocFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ThoiDiemTraThuNhapThangFilter), e => e.ThoiDiemTraThuNhapThang == input.ThoiDiemTraThuNhapThangFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ThoiDiemTraThuNhapNamFilter), e => e.ThoiDiemTraThuNhapNam == input.ThoiDiemTraThuNhapNamFilter)
                        .WhereIf(input.MinTongThuNhapChiuThueFilter != null, e => e.TongThuNhapChiuThue >= input.MinTongThuNhapChiuThueFilter)
                        .WhereIf(input.MaxTongThuNhapChiuThueFilter != null, e => e.TongThuNhapChiuThue <= input.MaxTongThuNhapChiuThueFilter)
                        .WhereIf(input.MinTongThuNhapTinhThueFilter != null, e => e.TongThuNhapTinhThue >= input.MinTongThuNhapTinhThueFilter)
                        .WhereIf(input.MaxTongThuNhapTinhThueFilter != null, e => e.TongThuNhapTinhThue <= input.MaxTongThuNhapTinhThueFilter)
                        .WhereIf(input.MinSoThueTNCNDaKhauTruFilter != null, e => e.SoThueTNCNDaKhauTru >= input.MinSoThueTNCNDaKhauTruFilter)
                        .WhereIf(input.MaxSoThueTNCNDaKhauTruFilter != null, e => e.SoThueTNCNDaKhauTru <= input.MaxSoThueTNCNDaKhauTruFilter)
                        .WhereIf(input.MinSoThuNhapDuocNhanFilter != null, e => e.SoThuNhapDuocNhan >= input.MinSoThuNhapDuocNhanFilter)
                        .WhereIf(input.MaxSoThuNhapDuocNhanFilter != null, e => e.SoThuNhapDuocNhan <= input.MaxSoThuNhapDuocNhanFilter)
                        .WhereIf(input.MinKhoanDongGopFilter != null, e => e.KhoanDongGop >= input.MinKhoanDongGopFilter)
                        .WhereIf(input.MaxKhoanDongGopFilter != null, e => e.KhoanDongGop <= input.MaxKhoanDongGopFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter), e => e.Email == input.EmailFilter)
                        .WhereIf(input.MinThoiGianNhapFilter != null, e => e.ThoiGianNhap >= input.MinThoiGianNhapFilter)
                        .WhereIf(input.MaxThoiGianNhapFilter != null, e => e.ThoiGianNhap <= input.MaxThoiGianNhapFilter)
                        .WhereIf(input.MinThoiGianDuyetFilter != null, e => e.ThoiGianDuyet >= input.MinThoiGianDuyetFilter)
                        .WhereIf(input.MaxThoiGianDuyetFilter != null, e => e.ThoiGianDuyet <= input.MaxThoiGianDuyetFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNhapFilter), e => e.UserNhap == input.UserNhapFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserDuyetFilter), e => e.UserDuyet == input.UserDuyetFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TrangThaiFilter), e => e.TrangThai == input.TrangThaiFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MauSoFilter), e => e.MauSo == input.MauSoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.KyHieuFilter), e => e.KyHieu == input.KyHieuFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SoChungTuFilter), e => e.SoChungTu == input.SoChungTuFilter);

            var pagedAndFilteredChungTuKTTs = filteredChungTuKTTs
                .OrderBy(input.Sorting ?? "id asc")
                .PageBy(input);

            var chungTuKTTs = from o in pagedAndFilteredChungTuKTTs
                              select new
                              {

                                  o.HoTen,
                                  o.MaSoThue,
                                  o.DiaChi,
                                  o.QuocTich,
                                  o.CuTru,
                                  o.CCCD,
                                  o.NoiCap,
                                  o.NgayCap,
                                  o.KhoanThuNhap,
                                  o.BaoHiemBatBuoc,
                                  o.ThoiDiemTraThuNhapThang,
                                  o.ThoiDiemTraThuNhapNam,
                                  o.TongThuNhapChiuThue,
                                  o.TongThuNhapTinhThue,
                                  o.SoThueTNCNDaKhauTru,
                                  o.SoThuNhapDuocNhan,
                                  o.KhoanDongGop,
                                  o.Email,
                                  o.ThoiGianNhap,
                                  o.ThoiGianDuyet,
                                  o.UserNhap,
                                  o.UserDuyet,
                                  o.TrangThai,
                                  o.MauSo,
                                  o.KyHieu,
                                  o.SoChungTu,
                                  Id = o.Id
                              };

            var totalCount = await filteredChungTuKTTs.CountAsync();

            var dbList = await chungTuKTTs.ToListAsync();
            var results = new List<GetChungTuKTTForViewDto>();

            foreach (var o in dbList)
            {
                var res = new GetChungTuKTTForViewDto()
                {
                    ChungTuKTT = new ChungTuKTTDto
                    {

                        HoTen = o.HoTen,
                        MaSoThue = o.MaSoThue,
                        DiaChi = o.DiaChi,
                        QuocTich = o.QuocTich,
                        CuTru = o.CuTru,
                        CCCD = o.CCCD,
                        NoiCap = o.NoiCap,
                        NgayCap = o.NgayCap,
                        KhoanThuNhap = o.KhoanThuNhap,
                        BaoHiemBatBuoc = o.BaoHiemBatBuoc,
                        ThoiDiemTraThuNhapThang = o.ThoiDiemTraThuNhapThang,
                        ThoiDiemTraThuNhapNam = o.ThoiDiemTraThuNhapNam,
                        TongThuNhapChiuThue = o.TongThuNhapChiuThue,
                        TongThuNhapTinhThue = o.TongThuNhapTinhThue,
                        SoThueTNCNDaKhauTru = o.SoThueTNCNDaKhauTru,
                        SoThuNhapDuocNhan = o.SoThuNhapDuocNhan,
                        KhoanDongGop = o.KhoanDongGop,
                        Email = o.Email,
                        ThoiGianNhap = o.ThoiGianNhap,
                        ThoiGianDuyet = o.ThoiGianDuyet,
                        UserNhap = o.UserNhap,
                        UserDuyet = o.UserDuyet,
                        TrangThai = o.TrangThai,
                        MauSo = o.MauSo,
                        KyHieu = o.KyHieu,
                        SoChungTu = o.SoChungTu,
                        Id = o.Id,
                    }
                };

                results.Add(res);
            }

            return new PagedResultDto<GetChungTuKTTForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<GetChungTuKTTForViewDto> GetChungTuKTTForView(long id)
        {
            var chungTuKTT = await _chungTuKTTRepository.GetAsync(id);

            var output = new GetChungTuKTTForViewDto { ChungTuKTT = ObjectMapper.Map<ChungTuKTTDto>(chungTuKTT) };

            return output;
        }

        [AbpAuthorize(AppPermissions.Pages_ChungTuKTTs_Edit)]
        public async Task<GetChungTuKTTForEditOutput> GetChungTuKTTForEdit(EntityDto<long> input)
        {
            var chungTuKTT = await _chungTuKTTRepository.FirstOrDefaultAsync(input.Id);

            var output = new GetChungTuKTTForEditOutput { ChungTuKTT = ObjectMapper.Map<CreateOrEditChungTuKTTDto>(chungTuKTT) };

            return output;
        }

        public async Task CreateOrEdit(CreateOrEditChungTuKTTDto input)
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

        [AbpAuthorize(AppPermissions.Pages_ChungTuKTTs_Create)]
        protected virtual async Task Create(CreateOrEditChungTuKTTDto input)
        {
            var chungTuKTT = ObjectMapper.Map<ChungTuKTT>(input);

            await _chungTuKTTRepository.InsertAsync(chungTuKTT);

        }

        [AbpAuthorize(AppPermissions.Pages_ChungTuKTTs_Edit)]
        protected virtual async Task Update(CreateOrEditChungTuKTTDto input)
        {
            var chungTuKTT = await _chungTuKTTRepository.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input, chungTuKTT);

        }

        [AbpAuthorize(AppPermissions.Pages_ChungTuKTTs_Delete)]
        public async Task Delete(EntityDto<long> input)
        {
            await _chungTuKTTRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetChungTuKTTsToExcel(GetAllChungTuKTTsForExcelInput input)
        {

            var filteredChungTuKTTs = _chungTuKTTRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.HoTen.Contains(input.Filter) || e.MaSoThue.Contains(input.Filter) || e.DiaChi.Contains(input.Filter) || e.QuocTich.Contains(input.Filter) || e.CuTru.Contains(input.Filter) || e.CCCD.Contains(input.Filter) || e.NoiCap.Contains(input.Filter) || e.BaoHiemBatBuoc.Contains(input.Filter) || e.ThoiDiemTraThuNhapThang.Contains(input.Filter) || e.ThoiDiemTraThuNhapNam.Contains(input.Filter) || e.Email.Contains(input.Filter) || e.UserNhap.Contains(input.Filter) || e.UserDuyet.Contains(input.Filter) || e.TrangThai.Contains(input.Filter) || e.MauSo.Contains(input.Filter) || e.KyHieu.Contains(input.Filter) || e.SoChungTu.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.HoTenFilter), e => e.HoTen == input.HoTenFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MaSoThueFilter), e => e.MaSoThue == input.MaSoThueFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.DiaChiFilter), e => e.DiaChi == input.DiaChiFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.QuocTichFilter), e => e.QuocTich == input.QuocTichFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CuTruFilter), e => e.CuTru == input.CuTruFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CCCDFilter), e => e.CCCD == input.CCCDFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NoiCapFilter), e => e.NoiCap == input.NoiCapFilter)
                        .WhereIf(input.MinNgayCapFilter != null, e => e.NgayCap >= input.MinNgayCapFilter)
                        .WhereIf(input.MaxNgayCapFilter != null, e => e.NgayCap <= input.MaxNgayCapFilter)
                        .WhereIf(input.MinKhoanThuNhapFilter != null, e => e.KhoanThuNhap >= input.MinKhoanThuNhapFilter)
                        .WhereIf(input.MaxKhoanThuNhapFilter != null, e => e.KhoanThuNhap <= input.MaxKhoanThuNhapFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BaoHiemBatBuocFilter), e => e.BaoHiemBatBuoc == input.BaoHiemBatBuocFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ThoiDiemTraThuNhapThangFilter), e => e.ThoiDiemTraThuNhapThang == input.ThoiDiemTraThuNhapThangFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.ThoiDiemTraThuNhapNamFilter), e => e.ThoiDiemTraThuNhapNam == input.ThoiDiemTraThuNhapNamFilter)
                        .WhereIf(input.MinTongThuNhapChiuThueFilter != null, e => e.TongThuNhapChiuThue >= input.MinTongThuNhapChiuThueFilter)
                        .WhereIf(input.MaxTongThuNhapChiuThueFilter != null, e => e.TongThuNhapChiuThue <= input.MaxTongThuNhapChiuThueFilter)
                        .WhereIf(input.MinTongThuNhapTinhThueFilter != null, e => e.TongThuNhapTinhThue >= input.MinTongThuNhapTinhThueFilter)
                        .WhereIf(input.MaxTongThuNhapTinhThueFilter != null, e => e.TongThuNhapTinhThue <= input.MaxTongThuNhapTinhThueFilter)
                        .WhereIf(input.MinSoThueTNCNDaKhauTruFilter != null, e => e.SoThueTNCNDaKhauTru >= input.MinSoThueTNCNDaKhauTruFilter)
                        .WhereIf(input.MaxSoThueTNCNDaKhauTruFilter != null, e => e.SoThueTNCNDaKhauTru <= input.MaxSoThueTNCNDaKhauTruFilter)
                        .WhereIf(input.MinSoThuNhapDuocNhanFilter != null, e => e.SoThuNhapDuocNhan >= input.MinSoThuNhapDuocNhanFilter)
                        .WhereIf(input.MaxSoThuNhapDuocNhanFilter != null, e => e.SoThuNhapDuocNhan <= input.MaxSoThuNhapDuocNhanFilter)
                        .WhereIf(input.MinKhoanDongGopFilter != null, e => e.KhoanDongGop >= input.MinKhoanDongGopFilter)
                        .WhereIf(input.MaxKhoanDongGopFilter != null, e => e.KhoanDongGop <= input.MaxKhoanDongGopFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.EmailFilter), e => e.Email == input.EmailFilter)
                        .WhereIf(input.MinThoiGianNhapFilter != null, e => e.ThoiGianNhap >= input.MinThoiGianNhapFilter)
                        .WhereIf(input.MaxThoiGianNhapFilter != null, e => e.ThoiGianNhap <= input.MaxThoiGianNhapFilter)
                        .WhereIf(input.MinThoiGianDuyetFilter != null, e => e.ThoiGianDuyet >= input.MinThoiGianDuyetFilter)
                        .WhereIf(input.MaxThoiGianDuyetFilter != null, e => e.ThoiGianDuyet <= input.MaxThoiGianDuyetFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNhapFilter), e => e.UserNhap == input.UserNhapFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserDuyetFilter), e => e.UserDuyet == input.UserDuyetFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TrangThaiFilter), e => e.TrangThai == input.TrangThaiFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.MauSoFilter), e => e.MauSo == input.MauSoFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.KyHieuFilter), e => e.KyHieu == input.KyHieuFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SoChungTuFilter), e => e.SoChungTu == input.SoChungTuFilter);

            var query = (from o in filteredChungTuKTTs
                         select new GetChungTuKTTForViewDto()
                         {
                             ChungTuKTT = new ChungTuKTTDto
                             {
                                 HoTen = o.HoTen,
                                 MaSoThue = o.MaSoThue,
                                 DiaChi = o.DiaChi,
                                 QuocTich = o.QuocTich,
                                 CuTru = o.CuTru,
                                 CCCD = o.CCCD,
                                 NoiCap = o.NoiCap,
                                 NgayCap = o.NgayCap,
                                 KhoanThuNhap = o.KhoanThuNhap,
                                 BaoHiemBatBuoc = o.BaoHiemBatBuoc,
                                 ThoiDiemTraThuNhapThang = o.ThoiDiemTraThuNhapThang,
                                 ThoiDiemTraThuNhapNam = o.ThoiDiemTraThuNhapNam,
                                 TongThuNhapChiuThue = o.TongThuNhapChiuThue,
                                 TongThuNhapTinhThue = o.TongThuNhapTinhThue,
                                 SoThueTNCNDaKhauTru = o.SoThueTNCNDaKhauTru,
                                 SoThuNhapDuocNhan = o.SoThuNhapDuocNhan,
                                 KhoanDongGop = o.KhoanDongGop,
                                 Email = o.Email,
                                 ThoiGianNhap = o.ThoiGianNhap,
                                 ThoiGianDuyet = o.ThoiGianDuyet,
                                 UserNhap = o.UserNhap,
                                 UserDuyet = o.UserDuyet,
                                 TrangThai = o.TrangThai,
                                 MauSo = o.MauSo,
                                 KyHieu = o.KyHieu,
                                 SoChungTu = o.SoChungTu,
                                 Id = o.Id
                             }
                         });

            var chungTuKTTListDtos = await query.ToListAsync();

            return _chungTuKTTsExcelExporter.ExportToFile(chungTuKTTListDtos);
        }

    }
}