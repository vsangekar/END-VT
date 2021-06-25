var blankarray = new Array();

$(document).ready(function () {
    Init();
});

function Init() {
    debugger;
    getallcustomerlist();
    $(".step1").show();
    $(".step2").hide();
    $(".dp").click(function () {
        $(this).find("input").focus();
    })   
    $("#uxsave").click(function () {
        debugger;
        var mobile = $("#uxmobileno").val();
        var reg = new RegExp("^[7-9][0-9]{9}$");
        var email = $("#uxemail").val();
        var regx = new RegExp("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");
        var savedata = true;
        if ($("#uxcustomername").val() == "") {
            alertify.error("Customer name is required.");
            savedata = false;
        }
        if ($("#uxcompanyname").val() == "") {
            alertify.error("Company name is required.");
            savedata = false;
        }
        if ($("#uxpassword").val() == "") {
            alertify.error("Password is required.");
            savedata = false;
        }
        if ($("#uxconfrim").val() == "") {
            alertify.error("confrim Password is required.");
            savedata = false
        }
        if ($("#uxconfrim").val() != $("#uxpassword").val()) {     
            alertify.error("Password and confrim password must be same");
            savedata = false;
        }
        if ($("#uxmobileno").val() == "") {
            alertify.error("mobile is required.");
            savedata = false;           
        }
        else if (reg.test(mobile)) {
        }
        else {
               alertify.error("Invalid mobile number");
               savedata = false;
             }
        if ($("#uxemail").val() == "") {
            alertify.error("email id is required.");
            savedata = false;
        } else if (regx.test(email)) {
        }
               else {
                alertify.error("Invalid Email address");
                savedata = false;
               }                
        if (savedata == true) {
            insertcustomer();           
        }
    });
    $("#uxupdate").click(function () {
        debugger;
        var mobile = $("#uxmobileno").val();
        var reg = new RegExp("^[7-9][0-9]{9}$");
        var email = $("#uxemail").val();
        var regx = new RegExp("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");
        var savedata = true;
        if ($("#uxcustomername").val() == "") {
            alertify.error("Customer name is required.");
            savedata = false;
        }
        if ($("#uxcompanyname").val() == "") {
            alertify.error("Company name is required.");
            savedata = false;
        }
        if ($("#uxemail").val() == "") {
            alertify.error("Email id is required.");
            savedata = false;
        } else if (regx.test(email)) {
        }
               else {
                alertify.error("Invalid Email address");
                savedata = false;
               }
        if ($("#uxmobileno").val() == "") {
            alertify.error("Mobile no. is required.");
            savedata = false;
        }
        else if (reg.test(mobile)) {
        }
        else {
              alertify.error("Invalid mobile number");
              savedata = false;
             }
        
        if (savedata == true) {
            updatecustomer();
        }

    });
    $("#uxclear").click(function () {
        debugger;
        $("#uxcustomername").val("");
        $("#uxemail").val("");
        $("#uxpassword").val("");
        $("#uxconfrim").val("");
        $("#uxmobileno").val("");
        $("#uxcompanyname").val("");
        $('#uxstatus').prop('selectedIndex', 0).trigger("change");

    });
    $("#uxaddcustomer").click(function () {
        debugger;
        $(".step1").hide();
        $(".step2").show();
        $("#uxaddcustomer").hide();
        $("#uxsave").show();
        $("#uxupdate").hide();
        $("#uxpassword").show();
        $("#uxconfrim").show();
        $("#ulpassword").show();
        $("#ulconfrim").show();
        $("#uxclear").show();
        $('#uxstatus').prop('selectedIndex', 0).trigger("change");
    });
    $("#uxback").click(function () {
        debugger;
        $("#uxcustomername").val("");
        $("#uxemail").val("");
        $("#uxpassword").val("");
        $("#uxconfrim").val("");
        $("#uxmobileno").val("");
        $("#uxcompanyname").val("");
        $(".step2").hide();
        $(".step1").show();
        getallcustomerlist();
        $("#uxaddcustomer").show();

    });


}

function insertcustomer() {
    debugger;   
    var model = {};
    model["isactive"] = $("#uxstatus").val();
    model["name"] = $("#uxcustomername").val();
    model["email"] = $("#uxemail").val();
    model["password"] = $("#uxpassword").val();
    model["cpassword"] = $("#uxconfrim").val();
    model["mobileno"] = $("#uxmobileno").val();
    model["cname"] = $("#uxcompanyname").val();
    ajaxPost("END_VT_api/auth/insertcustomerprofile"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                alertify.success("Customer Profile registered successfully.");
                onaddanothercustormer();
            }
            else {
                alertify.error(value.error);               
            }
        }
        , function (errorText) {
        }
    );
}
function updatecustomer() {
    debugger;
    var model = {};
    model["cust_id"] = $("#uxcustid").val();
    model["isactive"] = $("#uxstatus").val();
    model["name"] = $("#uxcustomername").val();
    model["email"] = $("#uxemail").val();
    model["mobileno"] = $("#uxmobileno").val();
    model["cname"] = $("#uxcompanyname").val();
    ajaxPost("END_VT_api/auth/updatecustomerprofile"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                alertify.success("Customer Profile updated successfully.");      
                $(".step2").hide();
                $(".step1").show();
                getallcustomerlist();
                $("#uxaddcustomer").show();
            }
            else {
                alertify.error(value.error);
            }
        }
        , function (errorText) {
        }
    );
}

function getallcustomerlist() {
    debugger;
    ajaxPost("END_VT_api/admin/getallcustomerlist"
        , ""
        , function (value) {
            if (value.success == "1") {
                bindcustomerlist(value.customerdata)
            }
            else {
                bindcustomerlist(blankarray)
            }
        }
        , function (errorText) {
        }
    );
}

function bindcustomerlist(jcustomerlist) {
    debugger;
    $("#uxcustomerlist").DataTable({
        "bDestroy": true,
        "searching": true,
        data: jcustomerlist,
        "ordering": false,
        "info": false,
        columns: [           
            {
                title: "Sr No", data: "srno", bSortable: false, className: 'text-center', render: function (data, type, row, meta) {
                    return data
                }
            },
            { title: "Customer Name", data: "name", bSortable: false },
            { title: "Company Name", data: "cname", bSortable: false },
            { title: "Email", data: "email", bSortable: false },
            { title: "Mobile No", data: "mobileno", bSortable: false },         
            { title: "Status", data: "isactive", bSortable: false },
            {
                title: "Action", data: "cust_id", width: "10%", bSortable: false, render: function (data, type, row, meta) {
                    return '<a data-type="sub" style="margin-right:5px;"  data-custid="' + data + '" data-changepage="1" href="#" onclick="oneditcustormerprofile(this)"><i class="fa fa-pencil"></i> </a> '+
                    '<a data-type="sub"  data-custid="' + data + '" data-changepage="1" href="#" onclick="ondeletecustormer(this)"><i class="fa fa-trash"></i> </a> '                    
                }, className: 'text-center'
            }
        ]
    });

}

function oneditcustormerprofile(cname) {
    debugger;
    var custdid = $(cname).attr("data-custid");
    var changepage = $(cname).attr("data-changepage");
    var model = {}
    model["cust_id"] = custdid
    ajaxPost("END_VT_api/auth/getcustomerdatabyid"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                if (changepage == 1) {
                    $(".step1").hide();
                    $(".step2").show();
                }
                $("#uxcustid").val(value.customerdata[0].cust_id);
                $("#uxcustomername").val(value.customerdata[0].name);
                $("#uxcompanyname").val(value.customerdata[0].cname);
                $("#uxemail").val(value.customerdata[0].email);
                $("#uxmobileno").val(value.customerdata[0].mobileno);
                $("#uxstatus").val(value.customerdata[0].isactive);
                $('#uxstatus').trigger('change');
                $("#uxsave").hide();
                $("#uxupdate").show();
                $("#uxaddcustomer").hide();
                $("#uxpassword").hide();
                $("#uxconfrim").hide();
                $("#ulpassword").hide();
                $("#ulconfrim").hide();
                $("#uxclear").hide();
            }
            else {

            }
        }
        , function (errorText) {
            ``
        }
    );
}

function ondeletecustormer(cname) {
    alertify.confirm("Do you want to delete the record.", function () {
        ondeletecustormerprofile(cname)
    }).set({ "title": "delete" }).set('labels', { ok: 'Yes', cancel: 'No' })
}

function onaddanothercustormer() {
    alertify.confirm("Do you want to another the customer.",
        function () {
            $("#uxcustomername").val("");
            $("#uxemail").val("");
            $("#uxpassword").val("");
            $("#uxconfrim").val("");
            $("#uxmobileno").val("");
            $("#uxcompanyname").val("");
            $('#uxstatus').prop('selectedIndex', 0).trigger("change");
        },
        function () {
            $(".step2").hide();
            $(".step1").show();
            getallcustomerlist();
            $("#uxaddcustomer").show();
            $("#uxcustomername").val("");
            $("#uxemail").val("");
            $("#uxpassword").val("");
            $("#uxconfrim").val("");
            $("#uxmobileno").val("");
            $("#uxcompanyname").val("");
            $('#uxstatus').prop('selectedIndex', 0).trigger("change");
        }).set({ "title": "addcustomer" }).set('labels', { ok: 'Yes', cancel: 'No' })
}



function ondeletecustormerprofile(cname) {
    debugger;

    var custdid = $(cname).attr("data-custid");
    var changepage = $(cname).attr("data-changepage");
    $("#uxcustid").val(custdid)
    var model = {}
    model["cust_id"] = custdid
    ajaxPost("END_VT_api/auth/deletecustomerdatabyid"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                alertify.success("Customer Profile deleted successfully.");
            }
            else {
                alertify.success(value.error);
                getallcustomerlist();
            }

        }
        , function (errorText) {
            alertify.success(value.error);``
        }
    );
}

function customerlogin() {
    debugger;
    var model = {};
    model["email"] = $("#uxemail").val();
    model["password"] = $("#uxpassword").val();
    debugger;
    ajaxPost("END_VT_api/auth/customerlogin"
        , JSON.stringify(model)
        , function (value) {
            if (value.success == "1") {
                window.location.href = "admin.html";
            }
            else {
                alertify.error(value.error);
            }

        }
        , function (errorText) {
        }
    );
}
