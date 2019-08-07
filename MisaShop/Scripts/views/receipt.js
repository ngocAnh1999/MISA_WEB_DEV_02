$(document).ready(function () {
    var ref = new Ref();
    
});



class Ref extends Base {
    constructor() {
        super();
        this.InitEvents();
    }

    InitEvents() {
        $('.main-table tbody').on('click', 'tr', { "jsObject": this }, this.RowOnClick);
        $('.toolbar').on('click', 'button.delete', this.ClickButtonDelete.bind(this));
        $('.main-table tbody').on('click', 'tr .uncheck', this.tickRow);
        $('.toolbar').on('click', 'button.add-new', this.OpenDialogAdd);
        $('#dialog').on('click', 'button.save', this.AddNewRef.bind(this));
        $(document).on('keyup', '#_pageIndex', this.PagingTable.bind(this));
    }

    PagingTable(event) {
        
        var me = this;
       
        if (event.keyCode === 13) {
            me.loadData();
        }
    }

    /**
     * Hàm thực hiện thêm mới phiếu thu
     * Người tạo: Ngọc Ánh
     * Ngày tạo: 26/07/2019
     * */
    AddNewRef() {
        
        var me = this;
        var listInput = $('#dialog [property]');
        var object = {};
        $.each(listInput, function (index, item) {
            var propertyName = item.getAttribute('property');
            var value = $(this).val();
            object[propertyName] = value;
        });
        $.ajax({
            method: 'POST',
            url: '/refs',
            async: false,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(object),
            success: function (res) {
                if (res.Success) {
                    $('#dialog').dialog('close');
                    me.loadData();
                }
                else {
                    alert(res.Message);
                }
            },
            error: function (res) {
                alert("Can't update! The services is error. Please, contact with MISA to work.")
            }

        })
    }

    /**
     * hàm thực hiện mở dialog thêm mới phiếu thu chi
     * Người tạo:; Ngọc Ánh
     * Ngày taojL 26/07/19
     * */

    OpenDialogAdd() {
        $("#dialog").dialog({
            modal: true, // chặn các thao tác bên ngoài khi mở dialog
            height: 300,
            width: 600
        });
    }

    /**
     * Thực hiện chức năng xóa*/

    ClickButtonDelete() {
        var me = this;
        var listRefNo = [];
        var refNo = $('.row-selected .refNo').text();
        listRefNo.push(refNo);
        $.ajax({
            method: 'DELETE',
            url: '/refs',
            contentType: "application/json; charset: utf-8",
            data:JSON.stringify(listRefNo),
            dataType: "json",
            success: function (res) {
                me.loadData();
                me.SetStatusButton();
            },
            error: function (res) {
                alert("Can't delete! The services is error. Please, contact with MISA to work.")
            }
        });
    }

    RowOnClick(event) {
        var me = event.data["jsObject"];
        $('button').removeAttr('disabled');
        
        $('.main-table tbody tr').removeClass('row-selected');
        $(this).addClass('row-selected');
        me.LoadDetailTable();
    }
    /**
     * Hàm thực hiện load dữ liệu xuống bảng detail
     * Người tạo : Ngọc Ánh
     * Ngày tạo: 31/07/2019
     * */

    LoadDetailTable() {
        var me = this;
        var refid = me.GetRowID();
        $.ajax({
            method: 'GET',
            url: '/refdetails/' + refid,
            success: function (res) {
                if (res.Success) {
                    
                }
                else {
                    alert(res.Message);
                }
            }
        })
    }

    /**
     * Hàm thực hiện lấy id của hàng
     * Người tạo : Ngọc Ánh
     * Ngày tạo: 31/07/2019
     * */

    GetRowID() {
        var rowid = $('.row-selected').data('recordID');
        return rowid;
    }

    /**
     * Chức năng hàm: Lấy dữ liệu và in ra HTML
     * Người tạo: vdthang 
     * Ngày tạo: 16/07/2019
     * Người sửa: 
     * Chi tiết sửa
     * Ngày sửa:
     * */
    loadData() {
        super.loadData();
    }
    SetStatusButton() {
        super.SetStatusButton();
    }
}

var ref = new Ref();