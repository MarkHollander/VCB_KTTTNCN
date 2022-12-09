(function () {
    $(function () {

        var _$toChucTraThuNhapsTable = $('#ToChucTraThuNhapsTable');
        var _toChucTraThuNhapsService = abp.services.app.toChucTraThuNhaps;
		
        $('.date-picker').datetimepicker({
            locale: abp.localization.currentLanguage.name,
            format: 'L'
        });

        var _permissions = {
            create: abp.auth.hasPermission('Pages.ToChucTraThuNhaps.Create'),
            edit: abp.auth.hasPermission('Pages.ToChucTraThuNhaps.Edit'),
            'delete': abp.auth.hasPermission('Pages.ToChucTraThuNhaps.Delete')
        };

         var _createOrEditModal = new app.ModalManager({
                    viewUrl: abp.appPath + 'App/ToChucTraThuNhaps/CreateOrEditModal',
                    scriptUrl: abp.appPath + 'view-resources/Areas/App/Views/ToChucTraThuNhaps/_CreateOrEditModal.js',
                    modalClass: 'CreateOrEditToChucTraThuNhapModal'
                });
                   

		 var _viewToChucTraThuNhapModal = new app.ModalManager({
            viewUrl: abp.appPath + 'App/ToChucTraThuNhaps/ViewtoChucTraThuNhapModal',
            modalClass: 'ViewToChucTraThuNhapModal'
        });

		
		

        var getDateFilter = function (element) {
            if (element.data("DateTimePicker").date() == null) {
                return null;
            }
            return element.data("DateTimePicker").date().format("YYYY-MM-DDT00:00:00Z"); 
        }
        
        var getMaxDateFilter = function (element) {
            if (element.data("DateTimePicker").date() == null) {
                return null;
            }
            return element.data("DateTimePicker").date().format("YYYY-MM-DDT23:59:59Z"); 
        }

        var dataTable = _$toChucTraThuNhapsTable.DataTable({
            paging: true,
            serverSide: true,
            processing: true,
            listAction: {
                ajaxFunction: _toChucTraThuNhapsService.getAll,
                inputFilter: function () {
                    return {
					filter: $('#ToChucTraThuNhapsTableFilter').val(),
					tenToChucFilter: $('#TenToChucFilterId').val(),
					maSoThueFilter: $('#MaSoThueFilterId').val(),
					diaChiFilter: $('#DiaChiFilterId').val(),
					soDienThoaiFilter: $('#SoDienThoaiFilterId').val(),
					userNhapFilter: $('#UserNhapFilterId').val(),
					minThoiGianNhapFilter:  getDateFilter($('#MinThoiGianNhapFilterId')),
					maxThoiGianNhapFilter:  getMaxDateFilter($('#MaxThoiGianNhapFilterId')),
					trangThaiFilter: $('#TrangThaiFilterId').val()
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
                                    _viewToChucTraThuNhapModal.open({ id: data.record.toChucTraThuNhap.id });
                                }
                        },
						{
                            text: app.localize('Edit'),
                            iconStyle: 'far fa-edit mr-2',
                            visible: function () {
                                return _permissions.edit;
                            },
                            action: function (data) {
                            _createOrEditModal.open({ id: data.record.toChucTraThuNhap.id });                                
                            }
                        }, 
						{
                            text: app.localize('Delete'),
                            iconStyle: 'far fa-trash-alt mr-2',
                            visible: function () {
                                return _permissions.delete;
                            },
                            action: function (data) {
                                deleteToChucTraThuNhap(data.record.toChucTraThuNhap);
                            }
                        }]
                    }
                },
					{
						targets: 2,
						 data: "toChucTraThuNhap.tenToChuc",
						 name: "tenToChuc"   
					},
					{
						targets: 3,
						 data: "toChucTraThuNhap.maSoThue",
						 name: "maSoThue"   
					},
					{
						targets: 4,
						 data: "toChucTraThuNhap.diaChi",
						 name: "diaChi"   
					},
					{
						targets: 5,
						 data: "toChucTraThuNhap.soDienThoai",
						 name: "soDienThoai"   
					},
					{
						targets: 6,
						 data: "toChucTraThuNhap.userNhap",
						 name: "userNhap"   
					},
					{
						targets: 7,
						 data: "toChucTraThuNhap.thoiGianNhap",
						 name: "thoiGianNhap" ,
					render: function (thoiGianNhap) {
						if (thoiGianNhap) {
							return moment(thoiGianNhap).format('L');
						}
						return "";
					}
			  
					},
					{
						targets: 8,
						 data: "toChucTraThuNhap.trangThai",
						 name: "trangThai"   
					}
            ]
        });

        function getToChucTraThuNhaps() {
            dataTable.ajax.reload();
        }

        function deleteToChucTraThuNhap(toChucTraThuNhap) {
            abp.message.confirm(
                '',
                app.localize('AreYouSure'),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _toChucTraThuNhapsService.delete({
                            id: toChucTraThuNhap.id
                        }).done(function () {
                            getToChucTraThuNhaps(true);
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

        $('#CreateNewToChucTraThuNhapButton').click(function () {
            _createOrEditModal.open();
        });        

		$('#ExportToExcelButton').click(function () {
            _toChucTraThuNhapsService
                .getToChucTraThuNhapsToExcel({
				filter : $('#ToChucTraThuNhapsTableFilter').val(),
					tenToChucFilter: $('#TenToChucFilterId').val(),
					maSoThueFilter: $('#MaSoThueFilterId').val(),
					diaChiFilter: $('#DiaChiFilterId').val(),
					soDienThoaiFilter: $('#SoDienThoaiFilterId').val(),
					userNhapFilter: $('#UserNhapFilterId').val(),
					minThoiGianNhapFilter:  getDateFilter($('#MinThoiGianNhapFilterId')),
					maxThoiGianNhapFilter:  getMaxDateFilter($('#MaxThoiGianNhapFilterId')),
					trangThaiFilter: $('#TrangThaiFilterId').val()
				})
                .done(function (result) {
                    app.downloadTempFile(result);
                });
        });

        abp.event.on('app.createOrEditToChucTraThuNhapModalSaved', function () {
            getToChucTraThuNhaps();
        });

		$('#GetToChucTraThuNhapsButton').click(function (e) {
            e.preventDefault();
            getToChucTraThuNhaps();
        });

		$(document).keypress(function(e) {
		  if(e.which === 13) {
			getToChucTraThuNhaps();
		  }
		});
		
		
		
    });
})();
