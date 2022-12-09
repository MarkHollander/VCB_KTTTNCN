(function ($) {
    app.modals.CreateOrEditToChucTraThuNhapModal = function () {

        var _toChucTraThuNhapsService = abp.services.app.toChucTraThuNhaps;

        var _modalManager;
        var _$toChucTraThuNhapInformationForm = null;

		
		
		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').datetimepicker({
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$toChucTraThuNhapInformationForm = _modalManager.getModal().find('form[name=ToChucTraThuNhapInformationsForm]');
            _$toChucTraThuNhapInformationForm.validate();
        };

		  

        this.save = function () {
            if (!_$toChucTraThuNhapInformationForm.valid()) {
                return;
            }

            

            var toChucTraThuNhap = _$toChucTraThuNhapInformationForm.serializeFormToObject();
            
            
            
			
			 _modalManager.setBusy(true);
			 _toChucTraThuNhapsService.createOrEdit(
				toChucTraThuNhap
			 ).done(function () {
               abp.notify.info(app.localize('SavedSuccessfully'));
               _modalManager.close();
               abp.event.trigger('app.createOrEditToChucTraThuNhapModalSaved');
			 }).always(function () {
               _modalManager.setBusy(false);
			});
        };
        
        
    };
})(jQuery);