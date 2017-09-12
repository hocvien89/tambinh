<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Hight_Chart.aspx.vb" Inherits="NANO_SPA.Hight_Chart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #container {
    height: 400px; 
    min-width: 310px; 
    max-width: 1390px;
    margin: 0 auto;
}
    </style>
     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="../Css/highchar/highcharts.js"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/highcharts-3d.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "Hight_Chart.aspx/GetTime",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var listTenDv = [];
                    var listGia = [];
                    var listDieutri = [];
                    console.log(data.d);
                    for (var i = 0; i < data.d.length ; i++) {
                        listTenDv.push(data.d[i].d_NgaydenB);
                        listGia.push(data.d[i].f_Soluong);
                       
                    }
                    $(function () {
                        // Set up the chart
                        var chart = new Highcharts.Chart({
                            chart: {
                                renderTo: 'container',
                                type: 'column',
                                margin: 75,
                                options3d: {
                                    enabled: true,
                                    alpha: 15,
                                    beta: 15,
                                    depth: 10,
                                    viewDistance: 30
                                }
                            },
                            xAxis: {
                                categories: listTenDv
                            },
                            title: {
                                text: 'BÁO CÁO THỐNG KÊ SỐ LƯỢNG DỊCH VỤ THEO THÁNG'
                            },
                            subtitle: {
                                text: 'Chi tiết doanh thu'
                            },
                            plotOptions: {
                                column: {
                                    depth: 25
                                }
                            },
                            series: [{
                                data: listGia
                            }]
                        });

                        function showValues() {
                            $('#R0-value').html(chart.options.chart.options3d.alpha);
                            $('#R1-value').html(chart.options.chart.options3d.beta);
                        }

                        // Activate the sliders
                        $('#R0').on('change', function () {
                            chart.options.chart.options3d.alpha = this.value;
                            showValues();
                            chart.redraw(false);
                        });
                        $('#R1').on('change', function () {
                            chart.options.chart.options3d.beta = this.value;
                            showValues();
                            chart.redraw(false);
                        });

                        showValues();
                    });
                },
                error: function () { alert('False!'); }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="container" style="min-width: 310px; height: 400px; margin: 0 auto"></div>
    </div>
    </form>
</body>
</html>
