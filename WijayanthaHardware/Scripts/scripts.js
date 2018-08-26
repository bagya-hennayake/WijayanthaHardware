$(document).ready(function () {
    function sliceSize(dataNum, dataTotal) {
        return (dataNum / dataTotal) * 360;
    }
    function addSlice(sliceSize, pieElement, offset, sliceID, color) {
        $(pieElement).append("<div class='slice " + sliceID + "'><span></span></div>");
        var offset = offset - 1;
        var sizeRotation = -179 + sliceSize;
        $("." + sliceID).css({
            "transform": "rotate(" + offset + "deg) translate3d(0,0,0)"
        });
        $("." + sliceID + " span").css({
            "transform": "rotate(" + sizeRotation + "deg) translate3d(0,0,0)",
            "background-color": color
        });
    }
    function iterateSlices(sliceSize, pieElement, offset, dataCount, sliceCount, color) {
        var sliceID = "s" + dataCount + "-" + sliceCount;
        var maxSize = 179;
        if (sliceSize <= maxSize) {
            addSlice(sliceSize, pieElement, offset, sliceID, color);
        } else {
            addSlice(maxSize, pieElement, offset, sliceID, color);
            iterateSlices(sliceSize - maxSize, pieElement, offset + maxSize, dataCount, sliceCount + 1, color);
        }
    }
    function createPie(dataElement, pieElement) {
        var listData = [];
        $(dataElement + " span").each(function () {
            listData.push(Number($(this).html()));
        });
        var listTotal = 0;
        for (var i = 0; i < listData.length; i++) {
            listTotal += listData[i];
        }
        var offset = 0;
        var color = [
            "cornflowerblue",
            "olivedrab",
            "orange",
            "tomato",
            "crimson",
            "purple",
            "turquoise",
            "forestgreen",
            "navy",
            "gray"
        ];
        for (var i = 0; i < listData.length; i++) {
            var size = sliceSize(listData[i], listTotal);
            iterateSlices(size, pieElement, offset, i, 0, color[i]);
            $(dataElement + " li:nth-child(" + (i + 1) + ")").css("border-color", color[i]);
            offset += size;
        }
    }
    createPie(".pieID.legend", ".pieID.pie");



    // Build the chart
    //powertool chart
    Highcharts.chart('container', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: ''
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                showInLegend: true
            }
        },
        series: [{
            name: 'Tools',
            colorByPoint: true,
            data: [{
                name: 'Rivet Gun',
                y: 61.41,
                sliced: true,
                selected: true
            }, {
                name: 'Miller',
                y: 11.84
            }, {
                name: 'Grater',
                y: 10.85
            }, {
                name: 'Drill',
                y: 4.67
            }, {
                name: 'Saw',
                y: 4.18
            }
            , {
                name: 'Grinder',
                y: 4.18
            }, {
            name: 'Other',
            y: 7.05
            }]
        }]
    });

    //paint chart
    Highcharts.chart('paintcontainer', {
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false,
            type: 'pie'
        },
        title: {
            text: ''
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: false
                },
                showInLegend: true
            }
        },
        series: [{
            name: 'Colors',
            colorByPoint: true,
            data: [{
                name: 'Blue',
                y: 61.41,
                sliced: true,
                selected: true
            }, {
                name: 'Black',
                y: 11.84
            }, {
                name: 'Red',
                y: 10.85
            }, {
                name: 'Grey',
                y: 4.67
            }, {
                name: 'Sky blue',
                y: 4.18
            }
                , {
                name: 'pea-cock',
                y: 4.18
            }, {
                name: 'Other',
                y: 7.05
            }]
        }]
    });

});


