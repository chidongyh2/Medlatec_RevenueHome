
(function( $ ) {

	'use strict';

	var datatableInit = function() {
		var $table = $('#datatable-details');

		// format function for row details
		var fnFormatDetails = function( datatable, tr ) {
            var data = datatable.fnGetData(tr);           

            //var dataview = '<table class="table mb-none">';

            //$.getJSON("/TotalWarehouse/TongHopNhapHangBySoPhieu?sophieu=" + data[1], function (dataValue) {
                              
            //    $.each(dataValue, function (i, datas) {
            //        dataview += '<tr class="b-top-none">';
            //        dataview += "<td><label class='mb - none'>Số hóa đơn:" + datas.sohd + "</label></td></tr>" ;
            //    });
            //    dataview += "</div>";   
            //});

           
            //return [dataview].join('');

			return [
				'<table class="table mb-none">',
					'<tr class="b-top-none">',
						'<td><label class="mb-none">Rendering engine:</label></td>',
						'<td>' + data[1]+ ' ' + data[4] + '</td>',
					'</tr>',
					'<tr>',
						'<td><label class="mb-none">Link to source:</label></td>',
						'<td>Could provide a link here</td>',
					'</tr>',
					'<tr>',
						'<td><label class="mb-none">Extra info:</label></td>',
						'<td>And any further details here (images etc)</td>',
					'</tr>',
				'</div>'
			].join('');
        };






		// insert the expand/collapse column
		var th = document.createElement( 'th' );
		var td = document.createElement( 'td' );
		td.innerHTML = '<i data-toggle class="fa fa-plus-square-o text-primary h5 m-none" style="cursor: pointer;"></i>';
        td.className = "text-center text-center1";

		$table
			.find( 'thead tr' ).each(function() {
				this.insertBefore( th, this.childNodes[0] );
			});

		$table
			.find( 'tbody tr' ).each(function() {
				this.insertBefore(  td.cloneNode( true ), this.childNodes[0] );
			});

		// initialize
		var datatable = $table.dataTable({
			aoColumnDefs: [{
				bSortable: false,
				aTargets: [ 0 ]
			}],
			aaSorting: [
				[1, 'asc']
			]
		});

		// add a listener
		$table.on('click', 'i[data-toggle]', function() {
			var $this = $(this),
				tr = $(this).closest( 'tr' ).get(0);

			if ( datatable.fnIsOpen(tr) ) {
				$this.removeClass( 'fa-minus-square-o' ).addClass( 'fa-plus-square-o' );
				datatable.fnClose( tr );
			} else {
				$this.removeClass( 'fa-plus-square-o' ).addClass( 'fa-minus-square-o' );
				datatable.fnOpen( tr, fnFormatDetails( datatable, tr), 'details' );
			}
		});
	};

	$(function() {
		datatableInit();
	});

}).apply( this, [ jQuery ]);