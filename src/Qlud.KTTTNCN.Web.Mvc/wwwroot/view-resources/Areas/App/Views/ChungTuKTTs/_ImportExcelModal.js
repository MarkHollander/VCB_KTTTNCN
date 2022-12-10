(function ($) {
    app.modals.CreateOrEditChungTuKTTModal = function () {

        var _$importedChungTuKTTsTable = $('#ImportedChungTuKTTsTable');
        var _chungTuKTTsService = abp.services.app.chungTuKTTs;

        var _modalManager;
        var _$chungTuKTTInformationForm = null;

        var _permissions = {
            create: abp.auth.hasPermission('Pages.ChungTuKTTs.Create'),
            edit: abp.auth.hasPermission('Pages.ChungTuKTTs.Edit'),
            'delete': abp.auth.hasPermission('Pages.ChungTuKTTs.Delete')
        };

        this.init = function (modalManager) {
            _modalManager = modalManager;

            var modal = _modalManager.getModal();
            modal.find('.date-picker').daterangepicker({
                singleDatePicker: true,
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$chungTuKTTInformationForm = _modalManager.getModal().find('form[name=ImportChungTuKTTInformationsForm]');
            _$chungTuKTTInformationForm.validate();
        };

        //var form = $('#ImportChungTuKTT_ChungTuBatch').val();
        //var form1 = document.getElementById('ImportChungTuKTT_ChungTuBatch');
        //console.log(form);
        //var data = new FormData();
        //if (form) {
        //    console.log('im here');
        //    var data = new FormData(form);
        //}

        var data = new FormData();
        jQuery.each(jQuery('#ImportChungTuKTT_ChungTuBatch')[0].files, function (i, file) {
            data.append('file-' + i, file)
        });

        var index = 0;
        var dataTable = _$importedChungTuKTTsTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _chungTuKTTsService.importChungTuKTTsFromExcel,
                contentType: 'multipart/form-data',
                inputFilter: function () {
                    console.log('data: ', data);
                    return {
                        chungTuBatch: data
                    };
                }
            },
            //"ajax": {
            //    "type": "POST",
            //    "enctype": 'multipart/form-data',
            //    "url": "/ChungTuKTTs/ImportChungTuKTTsFromExcel",
            //    data: data,
            //    processData: false,
            //    contentType: false,
            //    cache: false,
            //    timeout: 60000,
            //    success: function (data) {
            //        console.log('success: ', data);
            //    },
            //    error: function (e) {
            //        console.log('Error: ', e)
            //    }
            //},
            columnDefs: [
                {
                    className: 'control responsive',
                    orderable: false,
                    render: function () {
                        return '';
                    },
                    targets: index++,
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
                    data: "chungTuKTT.trangThai",
                    name: "trangThai"
                }
            ]
        });

        function importChungTuKTTs() {
            dataTable.ajax.reload();
        }

        $('#ImportChungTuKTT_ChooseFileButton').click(function () {
            console.log('importFile');
            var importFile = $('#ImportChungTuKTT_ChungTuBatch').val();
            console.log(importFile);
                        
            //form = $('#ImportChungTuKTT_ChungTuBatch').val();
            //form1 = document.getElementById('ImportChungTuKTT_ChungTuBatch');
            //console.log(form);
            //data = new FormData();
            //if (form) {
            //    console.log('im here');
            //    data = new FormData();
            //    data.append("chungTuBatch", form);
            //}

            //_chungTuKTTsService.importChungTuKTTsFromExcel(
            //    importFile
            //).done(function (data) {
            //    console.log('done');
            //    console.log(data);
            //});

            data = new FormData();
            jQuery.each(jQuery('#ImportChungTuKTT_ChungTuBatch')[0].files, function (i, file) {
                data.append('file-' + i, file)
            });

            importChungTuKTTs();
        });

        this.save = function () {
            if (!_$chungTuKTTInformationForm.valid()) {
                return;
            }

            var chungTuKTT = _$chungTuKTTInformationForm.serializeFormToObject();
            _modalManager.setBusy(true);
            _chungTuKTTsService.createOrEdit(
                chungTuKTT
            ).done(function () {
                abp.notify.info(app.localize('SavedSuccessfully'));
                _modalManager.close();
                abp.event.trigger('app.createOrEditChungTuKTTModalSaved');
            }).always(function () {
                _modalManager.setBusy(false);
            });
        };


    };
})(jQuery);