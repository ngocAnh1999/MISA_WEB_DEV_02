﻿$(document).ready(function () {


});

class Base {
    constructor() {
        this.loadData();
        this.InitEventsBase();
        this.SetStatusButton();
    }

    InitEventsBase() {

    }

    getData() {
        
        var fakeData = [];
        var pageIndex = $('#_pageIndex').val();
        var pageSize = $('#_pageSize').val();
        $.ajax({
            method: 'Get',
            url: '/refs/{0}/{1}'.format(pageIndex, pageSize),
            async: false,
            beforeSend: function () {
                $('#load-data').show();
            },
            success: function (res) {
                if (res.Success) {
                    fakeData = res.Data;
                    
                }
                else {
                    alert(res.Message);
                }
            },
            error: function (res) {
                debugger
            }

        })

        return fakeData;
    }

    // Hamf thực hiện lấy dữ liệu ra html
    // Người thực hiện: Ngọc Ánh 25/07/2019

    loadData() {
        var data = this.getData();
        var fields = $('.main-table th[fieldName]');
        $('.main-table tbody').empty();

        $.each(data, function (index, item) {
            var rowHTML = $('<tr></tr>').data("recordID", item["RefId"]);
            $.each(fields, function (fieldIndex, fieldItem) {
                var fieldName = fieldItem.getAttribute('fieldName');
                var value = item[fieldName];
                var cls = 'text-left';
                if (fieldName === "refDate") {
                    value = new Date(value);
                }
                var type = $.type(value);
                switch (type) {
                    case "date": value = value.formatddMMyyyy();
                        cls = 'text-center';
                        break;
                    case "number": value = value.formatMoney();
                        cls = 'text-right';
                        break;
                }
                if (fieldName) {
                    rowHTML.append('<td class = "{1}">{0}</td>'.format(value, cls));
                } else {
                    rowHTML.append('<td class ="uncheck"></td>');
                }
            });
            $('.main-table tbody').append(rowHTML);
        });


        $('#load-data').hide();

        
    }

    SetStatusButton() {
        var sizetable = $('.main-table tbody tr').length;
        if (sizetable === 0) {
            $('button.delete').attr('disabled', 'disabled');
        }
    }
}