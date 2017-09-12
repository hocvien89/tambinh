<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="call.aspx.vb" Inherits="NANO_SPA._call" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
    <script src="../Css/highchar/highcharts.js"></script>
    <script src="https://code.highcharts.com/highcharts.js"></script>
<script src="https://code.highcharts.com/modules/exporting.js"></script>
    <script type="text/javascript">
        /**
 * Grid-light theme for Highcharts JS
 * @author Torstein Honsi
 */

        // Load the fonts
        Highcharts.createElement('link', {
            href: '//fonts.googleapis.com/css?family=Dosis:400,600',
            rel: 'stylesheet',
            type: 'text/css'
        }, null, document.getElementsByTagName('head')[0]);

        Highcharts.theme = {
            colors: ["#7cb5ec", "#f7a35c", "#90ee7e", "#7798BF", "#aaeeee", "#ff0066", "#eeaaee",
               "#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
            chart: {
                backgroundColor: null,
                style: {
                    fontFamily: "Dosis, sans-serif"
                }
            },
            title: {
                style: {
                    fontSize: '16px',
                    fontWeight: 'bold',
                    textTransform: 'uppercase'
                }
            },
            tooltip: {
                borderWidth: 0,
                backgroundColor: 'rgba(219,219,216,0.8)',
                shadow: false
            },
            legend: {
                itemStyle: {
                    fontWeight: 'bold',
                    fontSize: '13px'
                }
            },
            xAxis: {
                gridLineWidth: 1,
                labels: {
                    style: {
                        fontSize: '12px'
                    }
                }
            },
            yAxis: {
                minorTickInterval: 'auto',
                title: {
                    style: {
                        textTransform: 'uppercase'
                    }
                },
                labels: {
                    style: {
                        fontSize: '12px'
                    }
                }
            },
            plotOptions: {
                candlestick: {
                    lineColor: '#404048'
                }
            },


            // General
            background2: '#F0F0EA'

        };

        // Apply the theme
        Highcharts.setOptions(Highcharts.theme);
    </script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                type: "POST",
                url: "call.aspx/GetTime",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    var listTenDv = [];
                    var listGia = [];
                    var listDieutri = [];
                    console.log(data.d);
                    for (var i = 0; i < data.d.length ; i++) {
                        listTenDv.push(data.d[i].nv_Tendichvu_vn);
                        listGia.push(data.d[i].f_Gia);
                        listDieutri.push(data.d[i].i_Solan_Dieutri);
                    }
                    $('#container').highcharts({
                        chart: {
                            type: 'line'
                        },
                        title: {
                            text: 'Monthly Average Temperature',
                            x: -20 //center
                        },
                        subtitle: {
                            text: 'Source: WorldClimate.com',
                            x: -20
                        },
                        xAxis: {
                            categories: listTenDv
                        },
                        yAxis: {
                            title: {
                                text: 'Giá/ Số lần'
                            },
                            plotLines: [{
                                value: 0,
                                width: 1,
                                color: '#808080'
                            }]
                        },
                        plotOptions: {
                            line: {
                                dataLabels: {
                                    enabled: true
                                },
                                enableMouseTracking: false
                            }
                        },
                        tooltip: {
                            valueSuffix: 'Giá/lần'
                        },
                        legend: {
                            layout: 'vertical',
                            align: 'right',
                            verticalAlign: 'middle',
                            borderWidth: 0
                        },
                        series: [{
                            name: 'Gia',
                            data: listGia
                        }, {
                            name: 'Dieu tri',
                            data: listDieutri
                        }]
                    });
                    //$(function () {
                        
                    //    var listTenDv = [];
                    //    var listGia = [];
                    //    var listDieutri = [];
                    //    console.log(data.d);
                    //    for (var i = 0; i < data.d.length ; i++) {
                    //        listTenDv.push(data.d[i].nv_Tendichvu_vn);
                    //        listGia.push(data.d[i].f_Gia);
                    //        listDieutri.push(data.d[i].i_Solan_Dieutri);
                    //    }
                    //    var chart = new Highcharts.Chart({
                    //        chart: {
                    //            renderTo: 'container',
                    //            type: 'column',
                    //            margin: 75,
                    //            options3d: {
                    //                enabled: true,
                    //                alpha: 30,
                    //                beta: 30,
                    //                depth: 50,
                    //                viewDistance: 25
                    //            }
                    //        },
                    //        title: {
                    //            text: 'Chart rotation demo'
                    //        },
                    //        subtitle: {
                    //            text: 'Test options by dragging the sliders below'
                    //        },
                    //        plotOptions: {
                    //            column: {
                    //                depth: 25
                    //            }
                    //        },
                    //        series: [{
                    //            data: listGia
                    //        }]
                    //    });

                    //    function showValues() {
                    //        $('#R0-value').html(chart.options.chart.options3d.alpha);
                    //        $('#R1-value').html(chart.options.chart.options3d.beta);
                    //    }

                    //    // Activate the sliders
                    //    $('#R0').on('change', function () {
                    //        chart.options.chart.options3d.alpha = this.value;
                    //        showValues();
                    //        chart.redraw(false);
                    //    });
                    //    $('#R1').on('change', function () {
                    //        chart.options.chart.options3d.beta = this.value;
                    //        showValues();
                    //        chart.redraw(false);
                    //    });

                    //    showValues();
                    //});
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
