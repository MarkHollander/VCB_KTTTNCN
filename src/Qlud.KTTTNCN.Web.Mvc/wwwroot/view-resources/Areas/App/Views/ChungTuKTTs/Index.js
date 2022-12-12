(function () {
    $(function () {

        var _$chungTuKTTsTable = $('#ChungTuKTTsTable');
        var _chungTuKTTsService = abp.services.app.chungTuKTTs;

        var $selectedDate = {
            startDate: null,
            endDate: null,
        }

        $('.date-picker').on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('MM/DD/YYYY'));
        });

        $('.startDate').daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L',
        }, (date) => {
            $selectedDate.startDate = date;
        }).on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.startDate = null;
        });

        $('.endDate').daterangepicker({
            autoUpdateInput: false,
            singleDatePicker: true,
            locale: abp.localization.currentLanguage.name,
            format: 'L',
        }, (date) => {
            $selectedDate.endDate = date;
        }).on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.endDate = null;
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.ChungTuKTTs.Create'),
            edit: abp.auth.hasPermission('Pages.ChungTuKTTs.Edit'),
            'delete': abp.auth.hasPermission('Pages.ChungTuKTTs.Delete')
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/ChungTuKTTs/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/ChungTuKTTs/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditChungTuKTTModal'
        });


        var _viewChungTuKTTModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/ChungTuKTTs/ViewchungTuKTTModal',
            modalClass: 'ViewChungTuKTTModal'
        });


        var _importChungTuKTTModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/ChungTuKTTs/ImportExcelModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/ChungTuKTTs/_ImportExcelModal.js',
            modalClass: 'CreateOrEditChungTuKTTModal'
        });


        var getDateFilter = function (element) {
            if ($selectedDate.startDate == null) {
                return null;
            }
            return $selectedDate.startDate.format("YYYY-MM-DDT00:00:00Z");
        }

        var getMaxDateFilter = function (element) {
            if ($selectedDate.endDate == null) {
                return null;
            }
            return $selectedDate.endDate.format("YYYY-MM-DDT23:59:59Z");
        }

        var dataTable = _$chungTuKTTsTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _chungTuKTTsService.getAll,
                inputFilter: function () {
                    return {
                        filter: $('#ChungTuKTTsTableFilter').val(),
                        hoTenFilter: $('#HoTenFilterId').val(),
                        maSoThueFilter: $('#MaSoThueFilterId').val(),
                        diaChiFilter: $('#DiaChiFilterId').val(),
                        quocTichFilter: $('#QuocTichFilterId').val(),
                        cuTruFilter: $('#CuTruFilterId').val(),
                        cCCDFilter: $('#CCCDFilterId').val(),
                        noiCapFilter: $('#NoiCapFilterId').val(),
                        minNgayCapFilter: getDateFilter($('#MinNgayCapFilterId')),
                        maxNgayCapFilter: getMaxDateFilter($('#MaxNgayCapFilterId')),
                        minKhoanThuNhapFilter: $('#MinKhoanThuNhapFilterId').val(),
                        maxKhoanThuNhapFilter: $('#MaxKhoanThuNhapFilterId').val(),
                        baoHiemBatBuocFilter: $('#BaoHiemBatBuocFilterId').val(),
                        thoiDiemTraThuNhapThangFilter: $('#ThoiDiemTraThuNhapThangFilterId').val(),
                        thoiDiemTraThuNhapNamFilter: $('#ThoiDiemTraThuNhapNamFilterId').val(),
                        minTongThuNhapChiuThueFilter: $('#MinTongThuNhapChiuThueFilterId').val(),
                        maxTongThuNhapChiuThueFilter: $('#MaxTongThuNhapChiuThueFilterId').val(),
                        minTongThuNhapTinhThueFilter: $('#MinTongThuNhapTinhThueFilterId').val(),
                        maxTongThuNhapTinhThueFilter: $('#MaxTongThuNhapTinhThueFilterId').val(),
                        minSoThueTNCNDaKhauTruFilter: $('#MinSoThueTNCNDaKhauTruFilterId').val(),
                        maxSoThueTNCNDaKhauTruFilter: $('#MaxSoThueTNCNDaKhauTruFilterId').val(),
                        minSoThuNhapDuocNhanFilter: $('#MinSoThuNhapDuocNhanFilterId').val(),
                        maxSoThuNhapDuocNhanFilter: $('#MaxSoThuNhapDuocNhanFilterId').val(),
                        minKhoanDongGopFilter: $('#MinKhoanDongGopFilterId').val(),
                        maxKhoanDongGopFilter: $('#MaxKhoanDongGopFilterId').val(),
                        emailFilter: $('#EmailFilterId').val(),
                        minThoiGianNhapFilter: getDateFilter($('#MinThoiGianNhapFilterId')),
                        maxThoiGianNhapFilter: getMaxDateFilter($('#MaxThoiGianNhapFilterId')),
                        minThoiGianDuyetFilter: getDateFilter($('#MinThoiGianDuyetFilterId')),
                        maxThoiGianDuyetFilter: getMaxDateFilter($('#MaxThoiGianDuyetFilterId')),
                        userNhapFilter: $('#UserNhapFilterId').val(),
                        userDuyetFilter: $('#UserDuyetFilterId').val(),
                        trangThaiFilter: $('#TrangThaiFilterId').val(),
                        mauSoFilter: $('#MauSoFilterId').val(),
                        kyHieuFilter: $('#KyHieuFilterId').val(),
                        soChungTuFilter: $('#SoChungTuFilterId').val()
                    };
                }
            },
            columnDefs: [
                {
                    className: 'control responsive',
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: 0
                },
                {
                    width: 120,
                    targets: 1,
                    data: null,
                    orderable: false,
                    autoWidth: false,
                    defaultContent: '',
                    rowAction: {
                        cssClass: 'btn btn-brand dropdown-toggle',
                        text: '<i class="fa fa-cog"></i> ' + app.localize('Actions') + ' <span class="caret"></span>',
                        items: [
                            {
                                text: app.localize('View'),
                                iconStyle: 'far fa-eye mr-2',
                                action: function (data) {
                                    _viewChungTuKTTModal.open({ id: data.record.chungTuKTT.id });
                                }
                            },
                            {
                                text: app.localize('Edit'),
                                iconStyle: 'far fa-edit mr-2',
                                visible: function () {
                                    return _permissions.edit;
                                },
                                action: function (data) {
                                    _createOrEditModal.open({ id: data.record.chungTuKTT.id });
                                }
                            },
                            {
                                text: app.localize('Delete'),
                                iconStyle: 'far fa-trash-alt mr-2',
                                visible: function () {
                                    return _permissions.delete;
                                },
                                action: function (data) {
                                    deleteChungTuKTT(data.record.chungTuKTT);
                                }
                            }]
                    }
                },
                {
                    targets: 2,
                    data: "chungTuKTT.hoTen",
                    name: "hoTen"
                },
                {
                    targets: 3,
                    data: "chungTuKTT.maSoThue",
                    name: "maSoThue"
                },
                {
                    targets: 4,
                    data: "chungTuKTT.diaChi",
                    name: "diaChi"
                },
                {
                    targets: 5,
                    data: "chungTuKTT.quocTich",
                    name: "quocTich"
                },
                {
                    targets: 6,
                    data: "chungTuKTT.cuTru",
                    name: "cuTru"
                },
                {
                    targets: 7,
                    data: "chungTuKTT.cccd",
                    name: "cccd"
                },
                {
                    targets: 8,
                    data: "chungTuKTT.noiCap",
                    name: "noiCap"
                },
                {
                    targets: 9,
                    data: "chungTuKTT.ngayCap",
                    name: "ngayCap",
                    render: function (ngayCap) {
                        if (ngayCap) {
                            return moment(ngayCap).format('L');
                        }
                        return "";
                    }

                },
                {
                    targets: 10,
                    data: "chungTuKTT.khoanThuNhap",
                    name: "khoanThuNhap"
                },
                {
                    targets: 11,
                    data: "chungTuKTT.baoHiemBatBuoc",
                    name: "baoHiemBatBuoc"
                },
                {
                    targets: 12,
                    data: "chungTuKTT.thoiDiemTraThuNhapThang",
                    name: "thoiDiemTraThuNhapThang"
                },
                {
                    targets: 13,
                    data: "chungTuKTT.thoiDiemTraThuNhapNam",
                    name: "thoiDiemTraThuNhapNam"
                },
                {
                    targets: 14,
                    data: "chungTuKTT.tongThuNhapChiuThue",
                    name: "tongThuNhapChiuThue"
                },
                {
                    targets: 15,
                    data: "chungTuKTT.tongThuNhapTinhThue",
                    name: "tongThuNhapTinhThue"
                },
                {
                    targets: 16,
                    data: "chungTuKTT.soThueTNCNDaKhauTru",
                    name: "soThueTNCNDaKhauTru"
                },
                {
                    targets: 17,
                    data: "chungTuKTT.soThuNhapDuocNhan",
                    name: "soThuNhapDuocNhan"
                },
                {
                    targets: 18,
                    data: "chungTuKTT.khoanDongGop",
                    name: "khoanDongGop"
                },
                {
                    targets: 19,
                    data: "chungTuKTT.email",
                    name: "email"
                },
                {
                    targets: 20,
                    data: "chungTuKTT.thoiGianNhap",
                    name: "thoiGianNhap",
                    render: function (thoiGianNhap) {
                        if (thoiGianNhap) {
                            return moment(thoiGianNhap).format('L');
                        }
                        return "";
                    }

                },
                {
                    targets: 21,
                    data: "chungTuKTT.thoiGianDuyet",
                    name: "thoiGianDuyet",
                    render: function (thoiGianDuyet) {
                        if (thoiGianDuyet) {
                            return moment(thoiGianDuyet).format('L');
                        }
                        return "";
                    }

                },
                {
                    targets: 22,
                    data: "chungTuKTT.userNhap",
                    name: "userNhap"
                },
                {
                    targets: 23,
                    data: "chungTuKTT.userDuyet",
                    name: "userDuyet"
                },
                {
                    targets: 24,
                    data: "chungTuKTT.trangThai",
                    name: "trangThai"
                },
                {
                    targets: 25,
                    data: "chungTuKTT.mauSo",
                    name: "mauSo"
                },
                {
                    targets: 26,
                    data: "chungTuKTT.kyHieu",
                    name: "kyHieu"
                },
                {
                    targets: 27,
                    data: "chungTuKTT.soChungTu",
                    name: "soChungTu"
                }
            ]
        });

        function getChungTuKTTs() {
            dataTable.ajax.reload();
        }

        function deleteChungTuKTT(chungTuKTT) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _chungTuKTTsService.delete({
                            id: chungTuKTT.id
                        }).done(function () {
                            getChungTuKTTs(true);
                            abp.notify.success(app.localize('SuccessfullyDeleted'));
                        });
                    }
                }
            );
        }

        $('#ShowAdvancedFiltersSpan').click(function () {
            $('#ShowAdvancedFiltersSpan').hide();
            $('#HideAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideDown();
        });

        $('#HideAdvancedFiltersSpan').click(function () {
            $('#HideAdvancedFiltersSpan').hide();
            $('#ShowAdvancedFiltersSpan').show();
            $('#AdvacedAuditFiltersArea').slideUp();
        });

        $('#CreateNewChungTuKTTButton').click(function () {
            _createOrEditModal.open();
        });

        $('#ImportExcelButton').click(function () {
            _importChungTuKTTModal.open();
        });

        $('#ExportToExcelButton').click(function () {
            _chungTuKTTsService
                .getChungTuKTTsToExcel({
                    filter: $('#ChungTuKTTsTableFilter').val(),
                    hoTenFilter: $('#HoTenFilterId').val(),
                    maSoThueFilter: $('#MaSoThueFilterId').val(),
                    diaChiFilter: $('#DiaChiFilterId').val(),
                    quocTichFilter: $('#QuocTichFilterId').val(),
                    cuTruFilter: $('#CuTruFilterId').val(),
                    cCCDFilter: $('#CCCDFilterId').val(),
                    noiCapFilter: $('#NoiCapFilterId').val(),
                    minNgayCapFilter: getDateFilter($('#MinNgayCapFilterId')),
                    maxNgayCapFilter: getMaxDateFilter($('#MaxNgayCapFilterId')),
                    minKhoanThuNhapFilter: $('#MinKhoanThuNhapFilterId').val(),
                    maxKhoanThuNhapFilter: $('#MaxKhoanThuNhapFilterId').val(),
                    baoHiemBatBuocFilter: $('#BaoHiemBatBuocFilterId').val(),
                    thoiDiemTraThuNhapThangFilter: $('#ThoiDiemTraThuNhapThangFilterId').val(),
                    thoiDiemTraThuNhapNamFilter: $('#ThoiDiemTraThuNhapNamFilterId').val(),
                    minTongThuNhapChiuThueFilter: $('#MinTongThuNhapChiuThueFilterId').val(),
                    maxTongThuNhapChiuThueFilter: $('#MaxTongThuNhapChiuThueFilterId').val(),
                    minTongThuNhapTinhThueFilter: $('#MinTongThuNhapTinhThueFilterId').val(),
                    maxTongThuNhapTinhThueFilter: $('#MaxTongThuNhapTinhThueFilterId').val(),
                    minSoThueTNCNDaKhauTruFilter: $('#MinSoThueTNCNDaKhauTruFilterId').val(),
                    maxSoThueTNCNDaKhauTruFilter: $('#MaxSoThueTNCNDaKhauTruFilterId').val(),
                    minSoThuNhapDuocNhanFilter: $('#MinSoThuNhapDuocNhanFilterId').val(),
                    maxSoThuNhapDuocNhanFilter: $('#MaxSoThuNhapDuocNhanFilterId').val(),
                    minKhoanDongGopFilter: $('#MinKhoanDongGopFilterId').val(),
                    maxKhoanDongGopFilter: $('#MaxKhoanDongGopFilterId').val(),
                    emailFilter: $('#EmailFilterId').val(),
                    minThoiGianNhapFilter: getDateFilter($('#MinThoiGianNhapFilterId')),
                    maxThoiGianNhapFilter: getMaxDateFilter($('#MaxThoiGianNhapFilterId')),
                    minThoiGianDuyetFilter: getDateFilter($('#MinThoiGianDuyetFilterId')),
                    maxThoiGianDuyetFilter: getMaxDateFilter($('#MaxThoiGianDuyetFilterId')),
                    userNhapFilter: $('#UserNhapFilterId').val(),
                    userDuyetFilter: $('#UserDuyetFilterId').val(),
                    trangThaiFilter: $('#TrangThaiFilterId').val(),
                    mauSoFilter: $('#MauSoFilterId').val(),
                    kyHieuFilter: $('#KyHieuFilterId').val(),
                    soChungTuFilter: $('#SoChungTuFilterId').val()
                })
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditChungTuKTTModalSaved', function () {
            getChungTuKTTs();
        });

        $('#GetChungTuKTTsButton').click(function (e) {
            e.preventDefault();
            getChungTuKTTs();
        });

        $(document).keypress(function (e) {
            if (e.which === 13) {
                getChungTuKTTs();
            }
        });



    });
})();
