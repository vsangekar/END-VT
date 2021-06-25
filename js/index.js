var blannkarray = new Array()
$(document).ready(function () {
    Init();

});


function Init() {
    debugger;
    $("#uxlogin").click(function () {
        var savedata = true;
        if ($("#uxusername").val() == "") {
            alertify.error("Email is required.");
            savedata = false
        }
        if ($("#uxpassword").val() == "") {
            alertify.error("Password is required.");
            savedata = false
        }


        if (savedata == true) {
            loginuser();
        }

    });

    $(document).on('keypress', function (e) {
        if (e.which == 13) {
            var savedata = true;
            if ($("#uxusername").val() == "") {
                alertify.error("User Name is required.");
                savedata = false
            }
            if ($("#uxpassword").val() == "") {
                alertify.error("Password is required.");
                savedata = false
            }

            if (savedata == true) {
                loginuser();
            }
        }
    });



}


function loginuser() {
    debugger;
    var model = {};
    model["username"] = $("#uxusername").val();
    model["userpassword"] = $("#uxpassword").val();
    debugger;
    //API to get user list
    ajaxPost("END_VT_api/admin/userlogin"
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





