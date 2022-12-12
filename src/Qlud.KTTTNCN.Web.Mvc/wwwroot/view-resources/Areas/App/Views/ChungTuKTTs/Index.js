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

        var index = 0;
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
                    className: 'dt-body-center control responsive',
                    orderable: false,
                    render: function () {
                        return '<div></div>';
                    },
                    targets: index++
                },
                {
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: index++
                },
                {
                    targets: index++,
                    searchable: false,
                    orderable: false,
                    className: 'dt-body-center select-checkbox',
                    'render': function (data, type, row) {
                        //return '<input type="checkbox" value="' + data + '">';
                        return '';
                    }
                },
                {
                    width: 120,
                    targets: index++,
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
                    targets: index++,
                    data: "chungTuKTT.hoTen",
                    name: "hoTen"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.maSoThue",
                    name: "maSoThue"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.diaChi",
                    name: "diaChi"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.quocTich",
                    name: "quocTich"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.cuTru",
                    name: "cuTru"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.cccd",
                    name: "cccd"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.noiCap",
                    name: "noiCap"
                },
                {
                    targets: index++,
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
                    targets: index++,
                    data: "chungTuKTT.khoanThuNhap",
                    name: "khoanThuNhap"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.baoHiemBatBuoc",
                    name: "baoHiemBatBuoc"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.thoiDiemTraThuNhapThang",
                    name: "thoiDiemTraThuNhapThang"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.thoiDiemTraThuNhapNam",
                    name: "thoiDiemTraThuNhapNam"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.tongThuNhapChiuThue",
                    name: "tongThuNhapChiuThue"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.tongThuNhapTinhThue",
                    name: "tongThuNhapTinhThue"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.soThueTNCNDaKhauTru",
                    name: "soThueTNCNDaKhauTru"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.soThuNhapDuocNhan",
                    name: "soThuNhapDuocNhan"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.khoanDongGop",
                    name: "khoanDongGop"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.email",
                    name: "email"
                },
                {
                    targets: index++,
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
                    targets: index++,
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
                    targets: index++,
                    data: "chungTuKTT.userNhap",
                    name: "userNhap"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.userDuyet",
                    name: "userDuyet"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.trangThai",
                    name: "trangThai"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.mauSo",
                    name: "mauSo"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.kyHieu",
                    name: "kyHieu"
                },
                {
                    targets: index++,
                    data: "chungTuKTT.soChungTu",
                    name: "soChungTu"
                }
            ],
            select: {
                style: 'multi',
                selector: 'tr>td:nth-child(3)'
            },
            order: [[1, 'asc']]
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

        $('#PendingBatchChungTuKTTButton').click(function (e) {
            e.preventDefault();
            var selectedItems = dataTable.rows('.selected').data();
            console.log('selectedItems: ', selectedItems);
            console.log('selectedItems[0]: ', selectedItems[0]);
            console.log('selectedItems.length: ', selectedItems.length);
            
        })

        $('#ApproveBatchChungTuKTTButton').click(function (e) {
            e.preventDefault();
            var selectedItems = dataTable.rows('.selected').data();
        })

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
