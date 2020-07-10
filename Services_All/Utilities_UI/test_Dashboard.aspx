<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test_Dashboard.aspx.cs" Inherits="Services_All.Utilities_UI.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<script src="https://code.jquery.com/jquery-3.1.1.min.js"></script>
<script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <h1>Monitoring</h1>
    
    <h4>TRANSACTIONS PENDING COUNT</h4>
    <div id="chart_div" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    <h4>APPLICATION STATUSES</h4>
    <div id="chart_div2" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    <h4>PBM ERX COUNT</h4>
    <div id="chart_div3" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    <h4>DHPO COUNT</h4>
    <div id="chart_div4" style="min-width: 310px; height: 400px; margin: 0 auto"></div>

    <script id="Google Charts for Transaction Count">

        google.charts.load('current', { packages: ['corechart', 'line'] });
        google.charts.setOnLoadCallback(drawBasic);
        var myVar;
        var arr = null;
        
        function GetDataInArray() {
            var output = [];
            $.ajax({
                type: "Post",
                contentType: "application/json;charset=utf-8",
                async: false,
                url: "test_Dashboard.aspx/GetTransactionsCount",
                success: function (data) {
                    arr = data.d;
                    for (i = 0; i < arr.length; i++) {
                        output.push([new Date(Date.parse(arr[i].TimeStamp)), arr[i].PBM_Count * 1, arr[i].ERX_Count * 1, arr[i].OIC_Count * 1]);
                    }
                },
                error: function (error) {
                    console.log("GetDataInArray ERROR !\n" + error);
                }
            });
            return output;
        }
 
        function drawBasic() {

            var data = new google.visualization.DataTable();
            
            data.addColumn('datetime', 'X');
            data.addColumn('number', 'PBMLink');
            data.addColumn('number', 'ERX');
            data.addColumn('number', 'OIC');
            
            data.addRows(GetDataInArray());

            var options = {
                colors: ['#325C74', '#5995B7', '#A3C4D7'],
                pointSize: 3,
                hAxis: {
                    gridlines: { color: 'none' },
                    title: 'Time'
                },
                vAxis: {
                    title: 'Total Count'
                }
            };
            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);

            myVar = setTimeout(drawBasic, 80000);
        }

        function stopFunction() {
            console.log("StopFunction:\n");
            clearTimeout(myVar);
        }

    </script>

    <script id="Google Charts for Statuses">

        google.charts.load('current', { packages: ['corechart', 'line'] });
        google.charts.setOnLoadCallback(drawStatusGraph);
        var Status_graph;
        var status_array = null;

        function GetStatus() {
            var stat_data = [];
            $.ajax({
                type: "Post",
                contentType: "application/json;charset=utf-8",
                async: false,
                url: "test_Dashboard.aspx/GetAppStatuses",
                success: function (data) {
                    status_array = data.d;
                    for (i = 0; i < status_array.length; i++) {
                        stat_data.push([
                           new Date(Date.parse(status_array[i].TimeStamp)),
							status_array[i].Claims_Count * 1,
							status_array[i].Clinician_Count * 1,
							status_array[i].Clinician_Validate_Count * 1,
							status_array[i].DHPO_Validate_Count * 1,
							status_array[i].Eauthorization_Count * 1,
							status_array[i].ERX_Validate_Count * 1,
							status_array[i].ERX_Pharmacy_Count * 1,
							status_array[i].LMU_Validate_Count * 1,
							status_array[i].Member_Registration_Count * 1,
							status_array[i].PBMLINK_Count * 1,
							status_array[i].PBMSwitch_Dimensions_Count * 1,
							status_array[i].PBMSwitch_Pyaer_Count * 1,
							status_array[i].Shafafiya_Validate_Count * 1
                        ]);
                    }
                },
                error: function (error) {
                    console.log("GETSTATUS ERROR !\n" + error);
                }
            });
            return stat_data;

        }

        function drawStatusGraph() {

            var data = new google.visualization.DataTable();
            data.addColumn('datetime', 'X');
            data.addColumn('number', '1-UI-Claims');
            data.addColumn('number', '2-UI-Clinician');
            data.addColumn('number', '3-WS-Clinician Validate');
            data.addColumn('number', '4-WS-DHPO Validate');
            data.addColumn('number', '5-UI-Eauthorization');
            data.addColumn('number', '6-WS-ERX Validate');
            data.addColumn('number', '7-UI-ERXPharmacy');
            data.addColumn('number', '8-WS-LMU Validate');
            data.addColumn('number', '9-WS-Member Registration');
            data.addColumn('number', '10-UI-PBMLink');
            data.addColumn('number', '11-WS-PBMSwitch Dimensions');
            data.addColumn('number', '12-WS-PBMSwitch Payer');
            data.addColumn('number', '13-WS-Shafafiya Validate');
            
            data.addRows(GetStatus());

            var options = {
                colors: ['#325C74', '#5995B7', '#A3C4D7'],
			chart:{title:'APPLICATION STATUSES'},
			legend: { position: 'bottom' },
                hAxis: {
                    gridlines: { color: 'none' },
                    //title: 'Time'
                },
                vAxis: {
                    title: 'Pass > 0 ; Fail < 0'
                }
            };
            var chart = new google.visualization.LineChart(document.getElementById('chart_div2'));
            chart.draw(data, options);

            Status_graph = setTimeout(drawStatusGraph, 140000);
        }

        function stopFunction() {
            console.log("StopFunction:\n");
            clearTimeout(Status_graph);
        }


    </script>

    <script id ="Google Bar Graph PBM/ERX">

        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawPBMERX);
        var arr_pbmerx = null;
        var myVar3;

        function GetDataPBMERX() {
            var array_pbmerx = [];

            $.ajax({
                type: "Post",
                contentType: "application/json;charset=utf-8",
                async: false,
                url: "test_Dashboard.aspx/GetPBMERXCount",
                success: function (data) {
                    arr_pbmerx = data.d;
                    
                    for (i = 0; i < arr_pbmerx.length; i++)
                    {
                        array_pbmerx.push(['Text', 'Total', { type: 'number', role: 'annotation' }, 'Processed', { type: 'number', role: 'annotation' }, 'Integrated Payer', { type: 'number', role: 'annotation' }])
                        array_pbmerx.push(['ERX', arr_pbmerx[i].ERX_Total_Count, arr_pbmerx[i].ERX_Total_Count, arr_pbmerx[i].ERX_Total_Processed_Count, arr_pbmerx[i].ERX_Total_Processed_Count, arr_pbmerx[i].ERX_Total_OurPayer_Count, arr_pbmerx[i].ERX_Total_OurPayer_Count]);
                        array_pbmerx.push(['PBM', arr_pbmerx[i].PBM_Total_Count, arr_pbmerx[i].PBM_Total_Count, arr_pbmerx[i].PBM_Total_Processed_Count, arr_pbmerx[i].PBM_Total_Processed_Count, arr_pbmerx[i].PBM_Total_OurPayer_Count, arr_pbmerx[i].PBM_Total_OurPayer_Count]);
                    }
                },
                error: function (error) {
                    console.log("GetDataPBMERX ERROR !\n" + error);
                }
            });

            return array_pbmerx;
        }

        function drawPBMERX()
        {
            var data = google.visualization.arrayToDataTable(GetDataPBMERX());
            var options = {
                annotations: {
                    textStyle: {
                        color: 'black',
                        fontSize: 11,
                    },
                    alwaysOutside: true
                },
                title: 'DATA',
                colors: ['#325C74', '#5995B7', '#A3C4D7'],
                bar: { groupWidth: "30%" },
                vAxis: { title: 'Count' },
                hAxis: { title: 'System', gridlines: { color: 'none' } },
                seriesType: 'bars',
                series: { 5: { type: 'line' } }
            };
            var chart = new google.visualization.ComboChart(document.getElementById('chart_div3'));
            chart.draw(data, options);

            myVar3 = setTimeout(drawPBMERX, 100000);
        }

        function stopFunction() {
            console.log("StopFunction:\n");
            clearTimeout(myVar3);
        }

    </script>

    <script id ="Google Bar Graph DHPO">

        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawDHPO);
        var arr_DHPO = null;
        var myVar4;

        function GetDataDHPO() {
            var array_DHPO = [];

            $.ajax({
                type: "Post",
                contentType: "application/json;charset=utf-8",
                async: false,
                url: "test_Dashboard.aspx/GetDHPOCount",
                success: function (data) {
                    arr_DHPO = data.d;
                    console.log(arr_DHPO);
                    for (i = 0; i < arr_DHPO.length; i++)
                    {
                        array_DHPO.push(['Text', 'Total', { type: 'number', role: 'annotation' }, 'Downloaded', { type: 'number', role: 'annotation' }, 'NotDownloaded', { type: 'number', role: 'annotation' }])
                        array_DHPO.push(['Claims', arr_DHPO[i].DHPO_Total_CS, arr_DHPO[i].DHPO_Total_CS, arr_DHPO[i].DHPO_CS_Downloaded, arr_DHPO[i].DHPO_CS_Downloaded, arr_DHPO[i].DHPO_CS_NotDownloaded, arr_DHPO[i].DHPO_CS_NotDownloaded]);
                        array_DHPO.push(['PA', arr_DHPO[i].DHPO_Total_PA, arr_DHPO[i].DHPO_Total_PA, arr_DHPO[i].DHPO_PA_Downloaded, arr_DHPO[i].DHPO_PA_Downloaded, arr_DHPO[i].DHPO_PA_NotDownloaded, arr_DHPO[i].DHPO_PA_NotDownloaded]);
                        array_DHPO.push(['PR', arr_DHPO[i].DHPO_Total_PR, arr_DHPO[i].DHPO_Total_PR, arr_DHPO[i].DHPO_PR_Downloaded, arr_DHPO[i].DHPO_PR_Downloaded, arr_DHPO[i].DHPO_PR_NotDownloaded, arr_DHPO[i].DHPO_PR_NotDownloaded]);

                    }
                },
                error: function (error) {
                    console.log("GetDataPBMERX ERROR !\n" + error);
                }
            });

            return array_DHPO;
        }

        function drawDHPO()
        {
            var data = google.visualization.arrayToDataTable(GetDataDHPO());
            var options = {
                annotations: {
                    textStyle: {
                        color: 'black',
                        fontSize: 11,
                    },
                    alwaysOutside: true
                },
                title: 'DATA',
                colors: ['#325C74', '#5995B7', '#A3C4D7'],
                bar: { groupWidth: "40%" },
                vAxis: { title: 'Count' },
                hAxis: { title: 'System', gridlines: { color: 'none' } },
                seriesType: 'bars',
                //series: { 5: { type: 'line' } }
            };
            var chart = new google.visualization.ComboChart(document.getElementById('chart_div4'));
            chart.draw(data, options);

            myVar4 = setTimeout(drawDHPO, 100000);
        }

        function stopFunction() {
            console.log("StopFunction:\n");
            clearTimeout(myVar4);
        }

    </script>

    <script id="DISCARDED">


        //function GetCount() {
            //    $.ajax({
            //        type: "Post",
            //        contentType: "application/json;charset=utf-8",
            //        async: false,
            //        //url: "Dashboard.aspx/GETRANDOM",
            //        //url: "Dashboard.aspx/GETPBM2COUNT",
            //        success: function (data) {
            //            $("#demo2").text(data.d);
            //            count = data.d;
            //        },
            //        error: function (error) {
            //            console.log("ERROR !\n" + error);
            //        }
            //    });

            //    return count;
            //}

        //Highcharts.setOptions({
        //    global: {
        //        useUTC: false
        //    }
        //});

        //Highcharts.chart('container', {
        //    chart: {
        //        type: 'spline',
        //        animation: Highcharts.svg, // don't animate in old IE
        //        marginRight: 10,
        //        events: {
        //            load: function () {

        //                 set up the updating of the chart each second
        //                var series = this.series[0];
        //                setInterval(function () {
        //                    var x = (new Date()).getTime(), // current time
        //                        y = GetCount() * 1;
        //                    series.addPoint([x, y], true, true);
        //                }, 10000);
        //            }
        //        }
        //    },
        //    title: {
        //        text: 'PBMLink Data',
        //    },
        //    xAxis: {
        //        type: 'datetime',
        //        tickPixelInterval: 500
        //    },
        //    yAxis: {
        //        title: {
        //            text: 'Value'
        //        },
        //        plotLines: [{
        //            value: 0,
        //            width: 1,
        //            color: '#808080'
        //        }]
        //    },
        //    tooltip: {
        //        formatter: function () {
        //            return '<b>' + this.series.name + '</b><br/>' +
        //                Highcharts.dateFormat('%Y-%m-%d %H:%M:%S', this.x) + '<br/>' +
        //                Highcharts.numberFormat(this.y, 2);
        //        }
        //    },
        //    legend: {
        //        enabled: false
        //    },
        //    exporting: {
        //        enabled: false
        //    },
        //    series: [{
        //        name: 'Pending Count',
        //        data: (function () {
        //             generate an array of random data
        //            var data = [],
        //                time = (new Date()).getTime(),
        //                i;

        //            for (i = -5; i <= 0; i += 1) {
        //                data.push({ x: time + i * 1000, y: GetCount() * 1 });
        //            }
        //            data = GetArrayForPBM();
        //            return data;
        //        }())
        //    }]
        //    series: [{
        //        name: 'Pending Count',
        //        data: (function () {
        //            // generate an array of random data
        //            var data = [],
        //                time = (new Date()).getTime(),
        //                i;

        //            for (i = -5; i <= 0; i += 1) {
        //                data.push({
        //                    x: time + i * 1000,
        //                    y: GetCount() * 1
        //                });
        //            }
        //            return data;
        //        }())
        //    }]
        //});




        //function GetArrayForPBM() {
        //    var output = [];
        //    $.ajax({
        //        type: "Post",
        //        contentType: "application/json;charset=utf-8",
        //        async: false,
        //        url: "Dashboard.aspx/GetTransactionsCount",
        //        success: function (data) {
        //            arr = data.d;
        //            for (i = 0; i < arr.length; i++)
        //            {
        //                //data.push({ x: time + i * 1000, y: GetCount() * 1 });
        //                output.push({ x: new Date(Date.parse(arr[i].TimeStamp)), y: arr[i].PBM_Count * 1 });
        //            }
        //        },
        //        error: function (error) {
        //            console.log("GetDataInArray ERROR !\n" + error);
        //        }
        //    });
        //    return output;
        //}

        //$(document).ready(function () {
        //    uganda();
        //});

        //function stopFunction() {
        //    clearTimeout(myVar);
        //}

        //var myVar;
        //function uganda() {
        //    $.ajax({
        //        type: "Post",
        //        contentType: "application/json;charset=utf-8",
        //        url: "Default.aspx/getvalue",
        //        success: function (data) {
        //            console.log("Success !\n" + data.d);
        //            $("#demo").text(data.d);
        //            count = data.d;
        //            myVar = setTimeout(uganda, 5000);
        //        },
        //        error: function (error) {
        //            console.log("ERROR !\n" + error);
        //        }
        //    });
        //}


        //var count;
        ////(new Date()).getTime();
        //function GetCount() { 
        //    $.ajax({
        //        type: "Post",
        //        contentType: "application/json;charset=utf-8",
        //        url: "Dashboard.aspx/getvalue",
        //        success: function (data) {
        //            $("#demo2").text(data.d);
        //            count = data.d;
        //            console.log("VALUE: " + count);
        //        },
        //        error: function (error) {
        //            console.log("ERROR !\n" + error);
        //        }
        //    });

        //    return count;
        //}

        //document.getElementById("demo2").innerHTML = GetCount();

        //$(document).ready(function () {
        //    $("button").click(function () {
        //        $.ajax({
        //            type: "Post",
        //            contentType: "application/json;charset=utf-8",
        //            url: "Default.aspx/getvalue",
        //            success: function (data) {
        //                console.log("SUCCESS !!\n" + data.d);
        //                $("#demo").text(data.d);
        //            },
        //            error: function (error) {
        //                console.log("ERROR !!!\n" + error);
        //                alert(error);
        //            }
        //        });
        //    });
        //});

        //$(document).ready(function () {
        //    $("button").click(function () {
        //        uganda();
        //    });
        //});
    </script>


</asp:Content>
