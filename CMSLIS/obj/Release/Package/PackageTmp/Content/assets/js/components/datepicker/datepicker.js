(function ($) {

    'use strict';
	
    // ------------------------------------------------------- //
    // Datepicker
    // ------------------------------------------------------ //	
	$(function () {
		//default date range picker
		$('#daterange').daterangepicker({
			autoApply:true
		});

		//date time picker
		$('#datetime').daterangepicker({
			timePicker: true,
			timePickerIncrement: 30,
			locale: {
				format: 'MM/DD/YYYY h:mm A'
			}
		});

		//single date
		$('#date').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD/MM/YYYY'
            }
        });
        //single date
        $('#dateDenngay').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD/MM/YYYY'
            }
        });

        //single date
        $('#dateCMT').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD/MM/YYYY'
            }
        });

        //single date
        $('#datePassport').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD/MM/YYYY'
            }
        });

        //single date
        $('#INSURANCE_CARD_START').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD/MM/YYYY'
            }
        });

        //single date
        $('#INSURANCE_CARD_END').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD/MM/YYYY'
            }
        });

        //single date
        $('#nsx').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD/MM/YYYY'
            }
        });
        //single date
        $('#hsd').daterangepicker({
            singleDatePicker: true,
            locale: {
                format: 'DD/MM/YYYY'
            }
        });


	});
	
})(jQuery);