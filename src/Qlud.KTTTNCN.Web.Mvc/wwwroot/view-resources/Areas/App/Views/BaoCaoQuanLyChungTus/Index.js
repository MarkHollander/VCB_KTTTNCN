(function () {
    $(async function () {

        var _$baoCaoQuanLyChungTusTable = $('#BaoCaoQuanLyChungTusTable');
        var _baoCaoQuanLyChungTusService = abp.services.app.baoCaoChungTus;
        var _utilsService = abp.services.app.utils;
        var _sessionService = abp.services.app.session;
        var statusDict;
        var userInfo;

        var $selectedDate = {
            startDate: null,
            endDate: null,
        }

        $('.date-picker').daterangepicker({
            singleDatePicker: true,
            autoUpdateInput: false
        }).on('apply.daterangepicker', function (ev, picker) {
            $(this).val(picker.startDate.format('MM/DD/YYYY'));
        }).on('cancel.daterangepicker', function (ev, picker) {
            $(this).val("");
            $selectedDate.startDate = null;
        });





        var _permissions = {
            create: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Create'),
            edit: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Edit'),
            'delete': abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Delete'),
            view: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.View'),
            pending: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Pending'),
            approve: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Approve'),
        };



        await initPage();
        async function initPage() {
            statusDict = await _utilsService.getStatusDict();
            var loginInfo = await _sessionService.getCurrentLoginInformations();
            userInfo = await _utilsService.getUserListDto(loginInfo.user.id);
        }

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
        console.log('JS-StartGetChungTu');
        var dataTable = _$baoCaoQuanLyChungTusTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _baoCaoQuanLyChungTusService.getChungTu,
                inputFilter: function () {
                    return {
                        /*filter: $('#ChungTuKTTsTableFilter').val(),*/
                        hoVaTen: $('#HoTenFilterId').val(),
                        maSoThue: $('#MaSoThueFilterId').val(),
                        trangThai: $('#TrangThaiFilterId').val(),
                        ngayLap: getDateFilter($('#NgayLapFilterId').val()),
                        ngayDuyet: getDateFilter($('#NgayDuyetFilterId').val()),
                        soChungTu: $('#SoChungTuFilterId').val()
                    };
                }
            },
            columnDefs: [
                //{
                //    className: 'dt-body-center control responsive',
                //    orderable: false,
                //    render: function () {
                //        return '<div></div>';
                //    },
                //    targets: index++
                //},
                //{
                //    orderable: false,
                //    render: function () {
                //        return '';
                //    },
                //    targets: index++
                //},
                {
                    targets: index++,
                    searchable: false,
                    orderable: false,
                    className: 'dt-body-center d-none',
                    render: function (data, type, row) {
                        console.log('row-id = ' + row.id);
                        return '<input type="hidden" value="' + row.id + '" id="ChungTuIdHidden"/>';
                        //return '';
                    }
                },
                {
                    targets: index++,
                    data: "soThuTu",
                    name: "soThuTu"
                },
                {
                    targets: index++,
                    data: "mauSo",
                    name: "mauSo"
                },
                {
                    targets: index++,
                    data: "kyHieu",
                    name: "kyHieu"
                },
                {
                    targets: index++,
                    data: "soChungTu",
                    name: "soChungTu"
                },
                {
                    targets: index++,
                    data: "maSoThue",
                    name: "maSoThue"
                },
                {
                    targets: index++,
                    data: "hoVaTen",
                    name: "hoTen"
                },
                {
                    targets: index++,
                    data: "email",
                    name: "email"
                },
                {
                    targets: index++,
                    data: "trangThai",
                    name: "trangThai"
                },
                {
                    targets: index++,
                    name: "InPDF",
                    render: function () {
                        return '<button type="button" class = "btn btn-primary inPDF">In PDF</button>';
                    }

                },
                {
                    targets: index++,
                    name: "XuatXML",
                    render: function () {
                        return '<button type="button" class = "btn btn-success xuatXML">Xuat XML</button>';
                    }

                },
                {
                    targets: index++,
                    name: "PhimChucNang",
                    render: function () {
                        return '<div></div>';
                    }
                }
            ],
            select: {
                style: 'multi',
                selector: 'tr>td:nth-child(3)'
            },
            order: [[1, 'asc']]
        });
        console.log('JS-EndGetChungTu');


        function getChungTuKTTs() {
            dataTable.ajax.reload();
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





        $('.inPDF').on('click', 'tr', function () {
            _baoCaoQuanLyChungTusService
                .exportBaoCaoToPDF({

                    chungTuId: $('#ChungTuIdHidden').val()
                })
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });



        $('#GetChungTuKTTsButton').click(function (e) {
            e.preventDefault();
            console.log('Ho va ten: ' + $('#HoTenFilterId').val());
            console.log('Ma so thue: ' + $('#MaSoThueFilterId').val());
            console.log('Trang thai: ' + $('#TrangThaiFilterId').val());
            console.log('Ngay lap: ' + getDateFilter($('#NgayLapFilterId').val()));
            console.log('Ngay Duyet: ' + getDateFilter($('#NgayDuyetFilterId').val()));
            console.log('So Chung Tu: ' + $('#SoChungTuFilterId').val());
            getChungTuKTTs();
        });

        $(document).keypress(function (e) {
            if (e.which === 13) {
                getChungTuKTTs();
            }
        });



    });
})();
