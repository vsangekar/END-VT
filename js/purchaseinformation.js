var blankarray = new Array();
var dskeydocument = new Array();

$(document).ready(function () {
    Init();
   

});

function Init() {
    getallpurchaselist();

    $(".step1").show();
    $(".step2").hide();
    $("#uxsave").click(function () {
        var savedata = true;
        if ($("#uxremark").val() == "") {
            alertify.error("Remarks is required.");
            savedata = false
        }
        if ($("#uxdate").val() == "") {
            alertify.error("Date is required.");
            savedata = false
        }
        if ($("#uxname").val() == "") {
            alertify.error("Product name is required.");
            savedata = false
        }
        if ($("#uxdname").val() == "") {
            alertify.error("Document name is required.");
            savedata = false
        }
        if ($("#uxcname").val() == "") {
            alertify.error("Customer name is required.");
            savedata = false
        }
        if (savedata == true) {
            insertproduct();
        }

    });
    $("#uxupdate").click(function () {
        var savedata = true;
        if ($("#uxdate").val() == "") {
            alertify.error("Date is required.");
            savedata = false
        }
        if ($("#uxremark").val() == "") {
            alertify.error("Remark is required.");
            savedata = false
        }
        if ($("#uxname").val() == "") {
            alertify.error("Product name is required.");
            savedata = false
        }
        if ($("#uxdname").val() == "") {
            alertify.error("Document name is required.");
            savedata = false
        }
        if ($("#uxcname").val() == "") {
            alertify.error("Customer name is required.");
            savedata = false
        }
        if (savedata == true) {
            insertproduct();
        }

    });
    $("#uxclear").click(function () {
        $("#uxname").val("");
        $("#uxremark").val("");
        $("#uxcname").val("");
        $("#uxdname").val("");
    });
    $("#uxback").click(function () {
        debugger;
        $(".step2").hide();
        $(".step1").show();
        $("#uxaddproduct").show();
        getallpurchaselist();
    });
    $("#uxaddproduct").click(function () {
        debugger;
        $(".step1").hide();
        $(".step2").show();
        $("#uxsave").show();
        $("#uxupdate").hide();
        $("#uxaddproduct").hide();
        //getcustcollist();
    });
    $("#uxupdate").click(function () {
        debugger;
        updateproduct();
        $(".step2").hide();
        $(".step1").show();
        getallpurchaselist();
    });
    
}

//function getdocumentupload(evt) {
//    // dskeydocument = new Array();
//    var files = evt.target.files;
//    var file = files[0];
//    uploadpurchasedoc(file);

//}

//function uploadpurchasedoc(fileinfo) {
//    debugger;
//    var formData = new FormData();
//    if (fileinfo.name != undefined) {
//        formData.append("filename", fileinfo.name);
//        formData.append("filedata", fileinfo);
//        ajaxPostFile("END_VT_api/admin/uploadpurchasedoc"
//            , formData
//            , function (value) {
//                if (value.success == "1") {
//                    for (var i = 0; i < value.filedata.length; i++) {
//                        var model = {}
//                        model["docid"] = "0";
//                        model["doctype"] = "noturl";
//                        model["docdata"] = value.filedata[i].filedata;
//                        model["docext"] = value.filedata[i].fileext;
//                        model["filename"] = value.filedata[i].filename;
//                        dskeydocument.push(model);
//                        $("#uxdocumentfile").val("");
//                    }
//                }
//                else {
//                }
//            }
//            , function (errorText) {
//            }
//        );
//    }
//}


function insertproduct() {
    debugger;
    var model = {};
    model["pdate"] = $("#uxdate").val();
    model["pcname"] = $("#uxcname").val();
    model["pname"] = $("#uxname").val();
    model["premarks"] = $("#uxremark").val();
    model["pupload"] = $("#uxdocumentfile").val();
    model["pdname"] = $("#uxdname").val();

    var dsselect = jQuery.grep(dskeydocument, function (element, index) {
        return element.doctype == "noturl" // retain appropriate elements
    });

    if (dsselect.length > 0) {
        model["filetype"] = dsselect[0].doctype;
        model["filedata"] = dsselect[0].docdata;
        model["fileext"] = dsselect[0].docext;
    }
    ajaxPost("END_VT_api/auth/insertprodinfo"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                alertify.success("Product Information registered successfully.");
            }
            else {
                alertify.success(value.error);
            }

        }
        , function (errorText) {
        }
    );
}

function updateproduct() {
    debugger;
    var model = {};
    model["prodid"] = $("#uxprodid").val();
    model["pdate"] = $("#uxdate").val();
    model["pcname"] = $("#uxcname").val();
    model["pname"] = $("#uxname").val();
    model["premarks"] = $("#uxremark").val();
    model["pupload"] = $("#uxdocumentfile").val();
    model["pdname"] = $("#uxdname").val();
    var dsselect = jQuery.grep(dskeydocument, function (element, index) {
        return element.doctype == "noturl" // retain appropriate elements
    });

    if (dsselect.length > 0) {
        model["filetype"] = dsselect[0].doctype;
        model["filedata"] = dsselect[0].docdata;
        model["fileext"] = dsselect[0].docext;
    }
    ajaxPost("END_VT_api/auth/updateproductdata"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                alertify.success("Product Data Updated successfully.");
            }
            else {
                alertify.success(value.error);
            }

        }
        , function (errorText) {
        }
    );
}


function getallpurchaselist() {
    debugger;
    ajaxPost("END_VT_api/admin/getallpurchaselist"
        , ""
        , function (value) {
            if (value.success == "1") {
                bindpurchaselist(value.purchasedata)
            }
            else {
                bindpurchaselist(blankarray)
            }

        }
        , function (errorText) {
        }
    );
}


//function getcustcollist() {
//    debugger;
//    ajaxPost("END_VT_api/admin/getcustcollist"
//        , ""
//        , function (value) {
//            var optionss;
//            if (value.success == "1") {
//                bindcustomerlist(value.customerdata)
//            }
//            else {

//            }
//        }
//        , function (errorText) {
//        }
//    );
//}

//function bindcustomerlist(jcustomerdata) {
//    debugger;
//    var $select = $('#uxcname');
//    $select.find('option').remove();
//    $select.append('<option value="0">Select One</option>');
//    $.each(jcustomerdata, function (key, value) {
//        $select.append('<option value=' + this.cust_id + '>' + this.name + '</option>');
//        //$("#uxcname").append($("<option></option>").val(this.cust_id).html(this.name));
//    });

//    //{
//    //    $.each(data.d, function () {
//    //        $("#uxcname").append($("<option     />").val(this.KeyName).text(this.ValueName));
//    //    });
//    //}

//    //$(jcustomerdata.d).find('Table1').each(function () {
//    //    var OptionValue = $(this).find('cust_id').text();
//    //    var OptionText = $(this).find('nameq').text();
//    //    var option = $("<option>" + OptionText + "</option>");
//    //    option.attr("value", OptionValue);

//    //    $("#uxcname").append(option);
//    //});
//}


function bindpurchaselist(jpurchaselist) {
    debugger;
    $("#uxpurchaselist").DataTable({
        "bDestroy": true,
        "searching": true,
        data: jpurchaselist,
        "ordering": false,
        "info": false,
        columns: [
            {
                title: "Sr No", data: "srno", bSortable: false, className: 'text-center', render: function (data, type, row, meta) {
                    return data
                }
            },
            { title: "Date", data: "pdate", bSortable: false },
            { title: "Customer Name", data: "pcname", bSortable: false },
            { title: "Product name", data: "pname", bSortable: false },
            { title: "Remarks", data: "premarks", bSortable: false },
            { title: "Document Name", data: "pdname", bSortable: false },
            { title: "Document extension", data: "pupload", bSortable: false },
            {
                title: "Action", data: "prodid", width: "10%", bSortable: false, render: function (data, type, row, meta) {
                    return '<a data-type="sub" style="margin-right:5px;" data-prodid="' + data + '" data-changepage="1" href="#" onclick="oneditproductdata(this)"><i class="fa fa-pencil"></i> </a> ' +
                           '<a data-type="sub"  data-prodid="' + data + '" data-changepage="1" href="#" onclick="ondeleteproductdata(this)"><i class="fa fa-trash"></i> </a> '
                }, className: 'text-center'
            },
         
        ]
    });

}

function oneditproductdata(cname) {
    debugger;
    var prodid = $(cname).attr("data-prodid");
    var changepage = $(cname).attr("data-changepage");
    $("#uxprodid").val(prodid)
    var model = {}
    model["prodid"] = prodid
    ajaxPost("END_VT_api/auth/getproductdatabyid"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                if (changepage == 1) {
                    $(".step1").hide();
                    $(".step2").show();
                }
                $("#uxprodid").val(value.productdata[0].prodid);
                $("#uxdate").val(value.productdata[0].pdate);
                $("#uxcname").val(value.productdata[0].pcname);
                $("#uxname").val(value.productdata[0].pname);
                $("#uxremark").val(value.productdata[0].premarks);
                $("#uxdname").val(value.productdata[0].pdname);
                $(".dplay").attr("src", "../uploaddoc/" + value.productdata[0].pupload);
                $("#uxsave").hide();
                $("#uxupdate").show();
                $("#uxdocumentfile").val(value.productdata[0].filename);
            }
            else {

            }

        }
        , function (errorText) {
            ``
        }
    );
}

function ondeleteproductdata(cname) {
    debugger;
    var prodid = $(cname).attr("data-prodid");
    var model = {}
    model["prodid"] = prodid
    ajaxPost("END_VT_api/auth/deleteproductdatabyid"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                alertify.success("product data deleted successfully.");
                getallpurchaselist();
            }
            else {
                alertify.success(value.error);
                getallpurchaselist();
            }

        }
        , function (errorText) {

            ``
        }
    );
}

function getkeydocumentfiledata(evt) {
    debugger;
    // dskeydocument = new Array();
    var files = evt.target.files;
    var file = files[0];
    updatefiledata(file);

}

function updatefiledata(fileinfo) {
    var formData = new FormData();
    if (fileinfo.name != undefined) {
        formData.append("filename", fileinfo.name);
        formData.append("filedata", fileinfo);
        ajaxPostFile("END_VT_api/auth/updatefiledata"
            , formData
            , function (value) {
                if (value.success == "1") {
                    for (var i = 0; i < value.filedata.length; i++) {
                        var model = {}
                        model["srno"] = (dskeydocument.length + 1);
                        model["docid"] = "0";
                        model["doctype"] = "noturl";
                        model["copyfile"] = "0";
                        model["docdata"] = value.filedata[i].filedata;
                        model["docext"] = value.filedata[i].fileext;
                        model["filename"] = value.filedata[i].filename;
                        model["copyfrom"] = "";
                        dskeydocument.push(model);
                       // $("#uxdownload").attr("src", "data:image/jpeg;base64," + value.filedata[i].filedata);
                        $("#uxdocumentfile").val("");
                    }
                    printdocumentdata();
                   
                }
                else {

                }

            }
            , function (errorText) {
            }
        );
    }
}

function printdocumentdata() {
    debugger;
    var docstr = "";
    for (var i = 0; i < dskeydocument.length; i++) {
        docstr = docstr + "<div class='col-md-12' style='margin-top: 5px;'>"
        if (dskeydocument[i].doctype == "noturl") {
            var fileurl = "";
            if (dskeydocument[i].docext == ".pdf") {
                fileurl = "data:application/pdf;base64," + dskeydocument[i].docdata;
                docstr = docstr + dskeydocument[i].filename + "(new) <a href='#' style='float:right;margin-left:5px;' data-srno=" + dskeydocument[i].srno + " onclick='ondeletetempdocument(this)' class='ishideread'> <i class='fa fa-trash'/></a> <a href='" + fileurl + "' onclick='onviewpdfdocumentbase64(this, event)'  style='float:right;'> <i class='fa fa-eye'/></a>"

            } else if (dskeydocument[i].docext == ".png") {
                fileurl = "data:application/png;base64," + dskeydocument[i].docdata;
                docstr = docstr + dskeydocument[i].filename + "(new) <a href='#' style='float:right;margin-left:5px;' data-srno=" + dskeydocument[i].srno + " onclick='ondeletetempdocument(this)' class='ishideread'> <i class='fa fa-trash'/></a> <a href='" + fileurl + "' onclick='onviewimagedocumentbase64(this, event)'  style='float:right;'> <i class='fa fa-eye'/></a>"
            } else if (dskeydocument[i].docext == ".jpeg" || dskeydocument[i].docext == ".jpg") {
                fileurl = "data:application/jpeg;base64," + dskeydocument[i].docdata;
                docstr = docstr + dskeydocument[i].filename + "(new) <a href='#' style='float:right;margin-left:5px;' data-srno=" + dskeydocument[i].srno + " onclick='ondeletetempdocument(this)' class='ishideread'> <i class='fa fa-trash'/></a> <a href='" + fileurl + "' onclick='onviewimagedocumentbase64(this, event)'  style='float:right;'> <i class='fa fa-eye'/></a>"
            }
            else {
                fileurl = "data:application/octet-stream;base64," + dskeydocument[i].docdata;
                docstr = docstr + dskeydocument[i].filename + "(new) <a href='#' style='float:right;margin-left:5px;' data-srno=" + dskeydocument[i].srno + " onclick='ondeletetempdocument(this)' class='ishideread'> <i class='fa fa-trash'/></a> <a href='" + fileurl + "' download='" + dskeydocument[i].filename + "' style='float:right;'> <i class='fa fa-download'/></a>"
            }
        } else {
            if (dskeydocument[i].copyfile == 1) {
                if (dskeydocument[i].docext == ".pdf" || dskeydocument[i].docext == ".png" || dskeydocument[i].docext == ".jpeg" || dskeydocument[i].docext == ".jpg") {
                    docstr = docstr + dskeydocument[i].filename + " <a href='#' style='float:right;margin-left:5px;' data-srno=" + dskeydocument[i].srno + " onclick='ondeletetempdocument(this)' class='ishideread'> <i class='fa fa-trash'/></a> <a href='../delegatedocument/" + dskeydocument[i].copyfrom + "' onclick='onviewdocumenturl(this, event)'  style='float:right;'> <i class='fa fa-eye'/></a>"

                } else {
                    docstr = docstr + dskeydocument[i].filename + " <a href='#' style='float:right;margin-left:5px;' data-srno=" + dskeydocument[i].srno + " onclick='ondeletetempdocument(this)' class='ishideread'> <i class='fa fa-trash'/></a> <a href='../delegatedocument/" + dskeydocument[i].copyfrom + "' download='" + dskeydocument[i].filename + "' style='float:right;'> <i class='fa fa-download'/></a>"

                }
            } else {
                if (dskeydocument[i].docext == ".pdf" || dskeydocument[i].docext == ".png" || dskeydocument[i].docext == ".jpeg" || dskeydocument[i].docext == ".jpg") {
                    docstr = docstr + dskeydocument[i].filename + " <a href='#' style='float:right;margin-left:5px;' data-srno=" + dskeydocument[i].srno + " onclick='ondeletetempdocument(this)' class='ishideread'> <i class='fa fa-trash'/></a> <a href='../delegatedocument/" + dskeydocument[i].filename + "' onclick='onviewdocumenturl(this, event)'  style='float:right;'> <i class='fa fa-eye'/></a>"

                } else {
                    docstr = docstr + dskeydocument[i].filename + " <a href='#' style='float:right;margin-left:5px;' data-srno=" + dskeydocument[i].srno + " onclick='ondeletetempdocument(this)' class='ishideread'> <i class='fa fa-trash'/></a> <a href='../delegatedocument/" + dskeydocument[i].filename + "' download='" + dskeydocument[i].filename + "' style='float:right;'> <i class='fa fa-download'/></a>"

                }
            }
        }
        docstr = docstr + "</div>"
    }


    $(".filedatadisplay").html(docstr);

    if (dskeydocument.length > 0) {
        $(".filedatadisplay").find("div").addClass("alert");
        $(".filedatadisplay").find("div").addClass("alert-success");
    } else {
        $(".filedatadisplay").find("div").removeClass("alert");
        $(".filedatadisplay").find("div").removeClass("alert-success");
    }
}

function ondeletetempdocument(cname) {
    debugger;
    var srno = $(cname).attr("data-srno");
    alertify.confirm("Do you want to delete selected document.", function () {

        dskeydocument = jQuery.grep(dskeydocument, function (element, index) {
            return element.srno != srno  // retain appropriate elements
        });

        var k = 1;
        for (var i = 0; i < dskeydocument.length; i++) {
            dskeydocument[i].srno = k;
            k = k + 1;
        }
        printdocumentdata();

    }, function () {


    }).set({ "title": "Delete Confirmation" }).set('labels', { ok: 'Yes', cancel: 'No' });

}

