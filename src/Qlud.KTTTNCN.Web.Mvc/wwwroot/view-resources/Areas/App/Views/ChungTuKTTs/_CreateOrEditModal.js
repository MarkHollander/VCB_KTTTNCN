(function ($) {
    app.modals.CreateOrEditChungTuKTTModal = function () {

        var _chungTuKTTsService = abp.services.app.chungTuKTTs;

        var _modalManager;
        var _$chungTuKTTInformationForm = null;

		
		
		

        this.init = function (modalManager) {
            _modalManager = modalManager;

			var modal = _modalManager.getModal();
            modal.find('.date-picker').daterangepicker({
                singleDatePicker: true,
                locale: abp.localization.currentLanguage.name,
                format: 'L'
            });

            _$chungTuKTTInformationForm = _modalManager.getModal().find('form[name=ChungTuKTTInformationsForm]');
            _$chungTuKTTInformationForm.validate();
        };

		  

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