(function ($) {

	'use strict';

	// ------------------------------------------------------- //
	// Auto Hide
	// ------------------------------------------------------ //	

	$(function () {
        $('#sorting-table').DataTable({
            //"aaSorting": [[2, 'asc']], 

			"lengthMenu": [
				[10, 15, 20, -1],
				[10, 15, 20, "All"]
            ] 
            

		});
	});

    $(function () {
        $('#sorting-table1').DataTable({
            "lengthMenu": [
                [10, 15, 20, -1],
                [10, 15, 20, "All"]
            ],
            "footerCallback": function (row, data, start, end, display) {
                var api = this.api(), data;


                //  Remove the formatting to get integer data for summation
                var intVal = function (i) {

                    return typeof i === 'string' ?
                        i.replace(/[\$,]/g, '') * 1 :
                        typeof i === 'number' ?
                            i : 0;
                };

                ////  Total over all pages
                total = api.column(3).data().reduce(function (a, b) {                                   
                    return intVal(a) + intVal(b);
                }, 0);

                

                //  Total over this page
                pageTotal = api
                    .column(3, { page: 'current' })
                    .data()
                    .reduce(function (a, b) {
                        return intVal(a) + intVal(b);
                    }, 0);

                // Update footer
                $(api.column(3).footer()).html(
                    '' + pageTotal + '(' + total + ' total)'
                );
            }

        });

        var total;
        var pageTotal;

    });

	$(function () {
		$('#export-table').DataTable({
			dom: 'Bfrtip',
			buttons: {
				buttons: [{
					extend: 'copy',
					text: 'Copy',
					title: $('h1').text(),
					exportOptions: {
						columns: ':not(.no-print)'
					},
					footer: true
				},{
					extend: 'excel',
					text: 'Excel',
					title: $('h1').text(),
					exportOptions: {
						columns: ':not(.no-print)'
					},
					footer: true
				},{
					extend: 'csv',
					text: 'Csv',
					title: $('h1').text(),
					exportOptions: {
						columns: ':not(.no-print)'
					},
					footer: true
				},{
					extend: 'pdf',
					text: 'Pdf',
					title: $('h1').text(),
					exportOptions: {
						columns: ':not(.no-print)'
					},
					footer: true
				},{
					extend: 'print',
					text: 'Print',
					title: $('h1').text(),
					exportOptions: {
						columns: ':not(.no-print)'
					},
					footer: true,
					autoPrint: true
				}],
				dom: {
					container: {
						className: 'dt-buttons'
					},
					button: {
						className: 'btn btn-primary'
					}
				}
			}
		});
	});

})(jQuery);