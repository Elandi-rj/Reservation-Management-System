$(function () {
	$.get("Reports/GetReservations",
		function (data, status) {
			if (status == "success") {
				$.plot("#placeholder", [data], {
					series: {
						bars: {
							show: true,
							barWidth: 0.6,
							align: "center"
						}
					},
					xaxis: {
						mode: "categories",
						showTicks: false,
						gridLines: false
					}
				});
				// Add the Flot version string to the footer

				$("#footer").prepend("Flot " + $.plot.version + " &ndash; ");
			}

		});

	$.get("Reports/GetReservationsStatus",
        function (data, status) {
            var plotdata = data;
            // Load the Visualization API and the corechart package.
            google.charts.load('current', { 'packages': ['corechart'] });

            // Set a callback to run when the Google Visualization API is loaded.
            google.charts.setOnLoadCallback(drawChart);

            // Callback that creates and populates a data table,
            // instantiates the pie chart, passes in the data and
            // draws it.
            function drawChart() {

                // Create the data table.
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Confirmed');
                data.addColumn('number', 'Pending');
                data.addRows(plotdata);

                // Set chart options
                var options = {
                    'title': 'Reservations status',
                    'width': '100%',
                    'height': 500
                };

                // Instantiate and draw our chart, passing in some options.
                var chart = new google.visualization.PieChart(document.getElementById('chart_statuses'));
                chart.draw(data, options);
            }
		});
    $.get("Reports/GetReservationsTypes",
        function (data, status) {
            var plotdata = data;
            google.charts.load('current', { 'packages': ['corechart'] });
            google.charts.setOnLoadCallback(drawChart);

            function drawChart() {
                var data = new google.visualization.DataTable();
                data.addColumn('string', 'Confirmed');
                data.addColumn('number', 'Pending');
                data.addRows(plotdata);

                var options = {
                    'title': 'Reservations source',
                    'width': '100%',
                    'height': 500
                };

                var chart = new google.visualization.PieChart(document.getElementById('chart_types'));
                chart.draw(data, options);
            }
		});
});