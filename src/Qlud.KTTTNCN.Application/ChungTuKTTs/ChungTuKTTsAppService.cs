using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using Qlud.KTTTNCN.Authorization;
using Qlud.KTTTNCN.ChungTuKTTs.Dtos;
using Qlud.KTTTNCN.ChungTuKTTs.Exporting;
using Qlud.KTTTNCN.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

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
                        .WhereIf(!string.IsNullOrWhiteSpace(input.SoChungTuFilter), e => e.SoChungTu == input.SoChungTuFilter)
                        .WhereIf(!string.IsNullOrWhiteSpace(input.BranchCodeFilter), e => e.BranchCode == input.BranchCodeFilter);

            var pagedAndFilteredChungTuKTTs = filteredChungTuKTTs
                .OrderBy(input.Sorting ?? "id desc")
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
                                  o.BranchCode,
                                  UserNhap = string.IsNullOrEmpty(o.UserNhap) ? "" : o.UserNhap,
                                  UserDuyet = string.IsNullOrEmpty(o.UserDuyet) ? "" : o.UserDuyet,
                                  MauSo = string.IsNullOrEmpty(o.MauSo) ? "" : o.MauSo,
                                  KyHieu = string.IsNullOrEmpty(o.KyHieu) ? "" : o.KyHieu,
                                  SoChungTu = string.IsNullOrEmpty(o.SoChungTu) ? "" : o.SoChungTu,

                                  o.TrangThai,
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
                        TrangThai = o.TrangThai,
                        Id = o.Id,

                        // được nhập sau
                        ThoiGianNhap = o.ThoiGianNhap,
                        ThoiGianDuyet = o.ThoiGianDuyet,
                        BranchCode = o.BranchCode,
                        UserNhap = o.UserNhap,
                        UserDuyet = o.UserDuyet,
                        MauSo = o.MauSo,
                        KyHieu = o.KyHieu,
                        SoChungTu = o.SoChungTu,
                    },

                    TrangThai = QludConsts.TrangThai.DisplayList[o.TrangThai]
                };

                results.Add(res);
            }

            return new PagedResultDto<GetChungTuKTTForViewDto>(
                totalCount,
                results
            );

        }

        public async Task<PagedResultDto<GetChungTuKTTForViewDto>> GetByIdList(GetAllChungTuKTTsInput input)
        {
            var results = new List<GetChungTuKTTForViewDto>();
            if (input.IdListFilter == null || input.IdListFilter.Count == 0)
            {
                return new PagedResultDto<GetChungTuKTTForViewDto>(0, results);
            }

            var filteredChungTuKTTs = _chungTuKTTRepository.GetAll().Where(x => input.IdListFilter.Contains(x.Id));

            var pagedAndFilteredChungTuKTTs = filteredChungTuKTTs
                .OrderBy("id desc")
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
                                  o.BranchCode,
                                  o.TrangThai,
                                  Id = o.Id
                              };

            var totalCount = await filteredChungTuKTTs.CountAsync();

            var dbList = await chungTuKTTs.ToListAsync();

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
                        BranchCode = o.BranchCode,
                        TrangThai = o.TrangThai,
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
            var chungTuKTT = await _chungTuKTTRepository.FirstOrDefaultAsync((int)input.Id);
            chungTuKTT.TrangThai = QludConsts.TrangThai.DELETED;
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

        public async Task<List<long>> ImportChungTuKTTsFromExcel(IFormFile ChungTuBatch)
        {
            List<long> importedIdList = new List<long>();

            if (ChungTuBatch?.Length > 0)
            {
                var stream = ChungTuBatch.OpenReadStream();
                try
                {
                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.First();
                        var rowCount = worksheet.Dimension.Rows;
                        for (var row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                int index = 1;
                                var hoTen = worksheet.Cells[row, index++].Value?.ToString();
                                var maSoThue = worksheet.Cells[row, index++].Value?.ToString();
                                var diaChi = worksheet.Cells[row, index++].Value?.ToString();
                                var quocTich = worksheet.Cells[row, index++].Value?.ToString();
                                var cuTru = worksheet.Cells[row, index++].Value?.ToString();
                                var cccd = worksheet.Cells[row, index++].Value?.ToString();
                                var noiCap = worksheet.Cells[row, index++].Value?.ToString();
                                var ngayCap = worksheet.Cells[row, index++].Value?.ToString();
                                var khoanThuNhap = worksheet.Cells[row, index++].Value?.ToString();
                                var baoHiemBatBuoc = worksheet.Cells[row, index++].Value?.ToString();
                                var thoiDiemTraThuNhapThang = worksheet.Cells[row, index++].Value?.ToString();
                                var thoiDiemTraThuNhapNam = worksheet.Cells[row, index++].Value?.ToString();
                                var tongThuNhapChiuThue = worksheet.Cells[row, index++].Value?.ToString();
                                var tongThuNhapTinhThue = worksheet.Cells[row, index++].Value?.ToString();
                                var soThueTNCNDaKhauTru = worksheet.Cells[row, index++].Value?.ToString();
                                var soThuNhapDuocNhan = worksheet.Cells[row, index++].Value?.ToString();
                                var khoanDongGop = worksheet.Cells[row, index++].Value?.ToString();
                                var email = worksheet.Cells[row, index++].Value?.ToString();

                                decimal khoanThuNhapDecimal = 0;
                                decimal tongThuNhapChiuThueDecimal = 0;
                                decimal tongThuNhapTinhThueDecimal = 0;
                                decimal soThueTNCNDaKhauTruDecimal = 0;
                                decimal soThuNhapDuocNhanDecimal = 0;
                                decimal khoanDongGopDecimal = 0;
                                Decimal.TryParse(khoanThuNhap, out khoanThuNhapDecimal);
                                Decimal.TryParse(tongThuNhapChiuThue, out tongThuNhapChiuThueDecimal);
                                Decimal.TryParse(tongThuNhapTinhThue, out tongThuNhapTinhThueDecimal);
                                Decimal.TryParse(soThueTNCNDaKhauTru, out soThueTNCNDaKhauTruDecimal);
                                Decimal.TryParse(soThuNhapDuocNhan, out soThuNhapDuocNhanDecimal);
                                Decimal.TryParse(khoanDongGop, out khoanDongGopDecimal);

                                CreateOrEditChungTuKTTDto createDtoTmp = new CreateOrEditChungTuKTTDto()
                                {
                                    HoTen = hoTen,
                                    MaSoThue = maSoThue,
                                    DiaChi = diaChi,
                                    QuocTich = quocTich,
                                    CuTru = cuTru,
                                    CCCD = cccd,
                                    NoiCap = noiCap,
                                    //NgayCap = // DateTime.ParseExact(ngayCap, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                                    NgayCap = DateTime.Now,
                                    KhoanThuNhap = khoanThuNhapDecimal,
                                    BaoHiemBatBuoc = baoHiemBatBuoc,
                                    ThoiDiemTraThuNhapThang = thoiDiemTraThuNhapThang,
                                    ThoiDiemTraThuNhapNam = thoiDiemTraThuNhapNam,
                                    TongThuNhapChiuThue = tongThuNhapChiuThueDecimal,
                                    TongThuNhapTinhThue = tongThuNhapTinhThueDecimal,
                                    SoThueTNCNDaKhauTru = soThueTNCNDaKhauTruDecimal,
                                    SoThuNhapDuocNhan = soThuNhapDuocNhanDecimal,
                                    KhoanDongGop = khoanDongGopDecimal,
                                    Email = email,
                                    TrangThai = QludConsts.TrangThai.INIT,

                                    UserNhap = "",
                                    UserDuyet = "",
                                    MauSo = "",
                                    KyHieu = "",
                                    SoChungTu = "",
                                };
                                
                                var chungTuKTT = ObjectMapper.Map<ChungTuKTT>(createDtoTmp);
                                var newId = await _chungTuKTTRepository.InsertAndGetIdAsync(chungTuKTT);
                                //importedIdList.Add(newId);
                            }
                            catch (Exception ex)
                            {
                                throw;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
                importedIdList.Add(4);
                importedIdList.Add(5);
            }

            return importedIdList;
        }

        
    }
}