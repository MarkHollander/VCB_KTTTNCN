(function () {
    $(async function () {

        var _$baoCaoQuanLyChungTusTable = $('#BaoCaoQuanLyChungTusTable');
        var _baoCaoQuanLyChungTusService = abp.services.app.baoCaoQuanLyChungTus;
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
        }, (start) => $selectedDate.startDate = start);



        var _permissions = {
            create: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Create'),
            edit: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Edit'),
            'delete': abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Delete'),
            view: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.View'),
            pending: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Pending'),
            approve: abp.auth.hasPermission('Pages.BaoCaoQuanLyChungTus.Approve'),
        };

        var _createOrEditModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/ChungTuKTTs/CreateOrEditModal',
            scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/ChungTuKTTs/_CreateOrEditModal.js',
            modalClass: 'CreateOrEditChungTuKTTModal'
        });

        var _pendingOrApproveModal = new app.ModalManager({
            viewUrl: abp.appPath + 'AppAreaName/ChungTuKTTs/PendingOrApproveModal', // controller
            scriptUrl: abp.appPath + 'view-resources/Areas/AppAreaName/Views/ChungTuKTTs/_PendingOrApproveModal.js',
            modalClass: 'PendingOrApproveChungTuKTTModal'
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
        var dataTable = _$baoCaoQuanLyChungTusTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _baoCaoQuanLyChungTusService.GetChungTu,
                inputFilter: function () {
                    return {
                        /*filter: $('#ChungTuKTTsTableFilter').val(),*/
                        hoTenFilter: $('#HoTenFilterId').val(),
                        maSoThueFilter: $('#MaSoThueFilterId').val(),
                        trangThaiFilter: $('#TrangThaiFilterId').val(),
                        mauSoFilter: $('#MauSoFilterId').val(),
                        kyHieuFilter: $('#KyHieuFilterId').val(),
                        soChungTuFilter: $('#SoChungTuFilterId').val()
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
                    'render': function (data, type, row) {
                        return '<input type="hidden" value="' + data.id + '" id="ChungTuIdHidden"/>';
                        //return '';
                    }
                },
                {
                    targets: index++,
                    data: "baoCaoQuanLyChungTuDto.SoThuTu",
                    name: "hoTen"
                },
                {
                    targets: index++,
                    data: "baoCaoQuanLyChungTuDto.mauSo",
                    name: "mauSo"
                },
                {
                    targets: index++,
                    data: "baoCaoQuanLyChungTuDto.kyHieu",
                    name: "kyHieu"
                },
                {
                    targets: index++,
                    data: "baoCaoQuanLyChungTuDto.soChungTu",
                    name: "soChungTu"
                },
                {
                    targets: index++,
                    data: "baoCaoQuanLyChungTuDto.maSoThue",
                    name: "maSoThue"
                },
                {
                    targets: index++,
                    data: "baoCaoQuanLyChungTuDto.HoVaTen",
                    name: "hoTen"
                },
                {
                    targets: index++,
                    data: "baoCaoQuanLyChungTuDto.email",
                    name: "email"
                },
                {
                    targets: index++,
                    data: "baoCaoQuanLyChungTuDto.trangThai",
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



        function getChungTuKTTs() {
            dataTable.ajax.reload();
        }



        function deleteChungTuKTT(chungTuKTT) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _baoCaoQuanLyChungTusService.delete({
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





        $('.inPDF').on('click', 'tr', function () {
            _baoCaoQuanLyChungTusService
                .exportBaoCaoToPDF({

                    chungTuId: $('#ChungTuIdHidden').val()
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
