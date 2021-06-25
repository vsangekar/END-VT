var HostAddress = "";
var componantdata = new Array();
if (window.location.href.includes("https")) {
    HostAddress = window.location.href.substr(0, window.location.href.indexOf("/", window.location.href.indexOf("/", 7) + 1));
}
else {
    HostAddress = window.location.href.substr(0, window.location.href.indexOf("/", window.location.href.indexOf("/", 7)));
}
function ajaxPost(url, data, success_callback, error_callback) {
    debugger;
    try {
        $(".LoadingDiv").show();
        $.ajax({
            type: "POST",
            url: HostAddress + "/" + url,
            data: data,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            cache: false,
            success: function (value) {
                if (value.success == -2) {
                    alertify.alert("Your application session has been expired. Please relogin.", function () {
                        window.location.href = "index.html";
                    });
                }
                $(".LoadingDiv").hide();
                success_callback(value);
            },
            error: function (response) {
                $(".LoadingDiv").hide();
                console.log(url);
                console.log(response.responseText);
                error_callback(response.responseText);

            }
        });
    }
    catch (ex) {
        $(".LoadingDiv").hide();
        console.log(url);
        console.log(ex.message);
        error_callback(ex.message);
    }
}



function ajaxPostFile(url, data, success_callback, error_callback) {
    debugger;
    try {
        $(".LoadingDiv").show();
        $.ajax({
            type: "POST",
            url: HostAddress + "/" + url,
            data: data,
            contentType: "multipart/form-data",
            processData: false,
            contentType: false,
            success: function (value) {
                if (value.success == -2) {
                    alertify.alert("Your application session has been expired. Please relogin.", function () {
                        window.location.href = "index.html";
                    });
                }
                $(".LoadingDiv").hide();
                success_callback(value);
            },
            error: function (response) {
                $(".LoadingDiv").hide();
                console.log(url);
                console.log(response.responseText);
                error_callback(response.responseText);

            }
        });
    }
    catch (ex) {
        $(".LoadingDiv").hide();
        console.log(url);
        console.log(ex.message);
        error_callback(ex.message);
    }
}


document.addEventListener("keyup", function (e) {
    var keyCode = e.keyCode ? e.keyCode : e.which;
    if (keyCode == 44) {
        stopPrntScr();
    }
});
function stopPrntScr() {

    var inpFld = document.createElement("input");
    inpFld.setAttribute("value", ".");
    inpFld.setAttribute("width", "0");
    inpFld.style.height = "0px";
    inpFld.style.width = "0px";
    inpFld.style.border = "0px";
    document.body.appendChild(inpFld);
    inpFld.select();
    document.execCommand("copy");
    inpFld.remove(inpFld);
}
function AccessClipboardData() {
    try {
        window.clipboardData.setData('text', "Access   Restricted");
    } catch (err) {
    }
}
setInterval("AccessClipboardData()", 300);



function GetSqlDateformat(obj) {
    try {
        if (obj != undefined && obj != null) {
            SqlDate = obj.toString().split('/')[1] + '/';
            SqlDate += obj.toString().split('/')[0] + '/';
            SqlDate += obj.toString().split('/')[2];
            return SqlDate;
        }
    }
    catch (ex) {
        log(ex);
    }
}



function getUrlVars() {

    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}

function chknumwithDot(e, t, n, r, i) {

    var charCode = (i.which) ? i.which : i.keyCode

    if (charCode != 45 && (charCode != 46 || n.value.indexOf('.') != -1) && (charCode < 48 || charCode > 57)) {
        return false;
    }
    else {
        if (document.getSelection) {
            s = document.getSelection();
            if (s != "") {
                var startPos = n.selectionStart;
                var endPos = n.selectionEnd;
                var str = n.value.slice(startPos, endPos)
                n.value.replace(slicedText, n.value);
            }
        }
        if (t == 0) {
            if (charCode == 46) {
                return false;
            }
            if ((n.value.length + 1) > e) {
                return false;
            }
        }
        else {
            if (charCode != 46) {
                if (n.value.split(".").length == 1) {
                    if ((n.value.split(".")[0].length + 1) > e) {
                        return false;
                    }
                }
                if (n.value.split(".").length > 1) {
                    if ((n.value.split(".")[0].length) > e) {
                        return false;
                    }
                    if (n.value.split(".")[1].length + 1 > t) {
                        return false;
                    }
                }
            }
        }
    }

    return true;
}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}



function mask(Controlid) {
    //    debugger;
    $(Controlid).each(function () {
        $(this).mask('99/99/9999');
    });
}

$(document).ready(function () {

    $('#uxmenuorgname').change(function () {
        getdelegatebyorgid($('#uxmenuorgname').val(), 0);
    })
});



function onlogout() {
    alertify.confirm("Do you want to logout from application.", function () {
        clearsessiononlogout()

    }).set({ "title": "Logout" }).set('labels', { ok: 'Yes', cancel: 'No' })
}



function mask(Controlid) {
    //    debugger;
    $(Controlid).each(function () {
        $(this).mask('99/99/9999');
    });
}


function onlyNumbers(e) {
    debugger;
    var t = event || e;
    var n = t.which || t.keyCode;
    if (n > 31 && (n < 48 || n > 57)) return false;
    return true
}



function clearsessiononlogout() {
    debugger;
    //API to get user list
    ajaxPost("END_VT_api/admin/clearsessiononlogout"
        , ""
        , function (value) {
            if (value.success == "1") {
                window.location.href = "index.html"
            }
            else {

            }

        }
        , function (errorText) {
        }
    );
}



function getdataafterlogin(onsuccess) {
    ajaxPost("END_VT_api/admin/getdataafterlogin"
        , ""
        , function (value) {
            if (value.success == "1") {
                onsuccess(value.userdata[0].userid);
            }
            else {

            }

        }
        , function (errorText) {
        }
    );
}



function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function validateContactno(concatno) {
    if (concatno.length == 12) {

        var re = /\+\d{2}\d{9}/;
        return re.test(concatno);
    } else {
        var re = /\+\d{2}\d{10}/;
        return re.test(concatno);
    }
}

function validatezipcode(zipcode) {
    var re = /^[0-9]{5}(-[0-9]{4})?$/
    return re.test(zipcode);
}



function validateyoutubelink(link) {
    var re = /(.*?)(^|\/|v=)([a-z0-9_-]{11})(.*)?/gim
    return re.test(link);
}


function getMonthNo(monthno) {
    var months = [
        'January',
        'February',
        'March',
        'April',
        'May',
        'June',
        'July',
        'August',
        'September',
        'October',
        'November',
        'December'
    ];
    var month = (months.indexOf(monthno) + 1);
    if (parseInt(month) < 10)
        return "0" + month;
    else
        return month;
}

function is_url(str) {
    regexp = /^(?:(?:https?|ftp):\/\/)?(?:(?!(?:10|127)(?:\.\d{1,3}){3})(?!(?:169\.254|192\.168)(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]-*)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/\S*)?$/;
    if (regexp.test(str)) {
        return true;
    }
    else {
        return false;
    }
}

function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};


function rolefunction(jData) {
    if (jData != "sa") {
        $(".sadmin").hide();
    } else {
        $(".sadmin").show();
    }
}



function ajaxPostFile(url, data, success_callback, error_callback) {
    debugger;
    try {
        $(".LoadingDiv").show();
        $.ajax({
            type: "POST",
            url: HostAddress + "/" + url,
            data: data,
            contentType: "multipart/form-data",
            processData: false,
            contentType: false,
            success: function (value) {
                if (value.success == -2) {
                    alertify.alert("Your application session has been expired. Please relogin.", function () {
                        window.location.href = "index.html";
                    });
                }
                $(".LoadingDiv").hide();
                success_callback(value);
            },
            error: function (response) {
                $(".LoadingDiv").hide();
                console.log(url);
                console.log(response.responseText);
                error_callback(response.responseText);

            }
        });
    }
    catch (ex) {
        $(".LoadingDiv").hide();
        console.log(url);
        console.log(ex.message);
        error_callback(ex.message);
    }
}


function autocomplete(inp, arr) {
    /*the autocomplete function takes two arguments,
    the text field element and an array of possible autocompleted values:*/
    var currentFocus;
    /*execute a function when someone writes in the text field:*/
    inp.addEventListener("input", function (e) {
        var a, b, i, val = this.value;
        /*close any already open lists of autocompleted values*/
        closeAllLists();
        if (!val) { return false; }
        currentFocus = -1;
        /*create a DIV element that will contain the items (values):*/
        a = document.createElement("DIV");
        a.setAttribute("id", this.id + "autocomplete-list");
        a.setAttribute("class", "autocomplete-items");
        /*append the DIV element as a child of the autocomplete container:*/
        this.parentNode.appendChild(a);
        /*for each item in the array...*/
        for (i = 0; i < arr.length; i++) {
            /*check if the item starts with the same letters as the text field value:*/
            if (arr[i].substr(0, val.length).toUpperCase() == val.toUpperCase()) {
                /*create a DIV element for each matching element:*/
                b = document.createElement("DIV");
                /*make the matching letters bold:*/
                b.innerHTML = "<strong>" + arr[i].substr(0, val.length) + "</strong>";
                b.innerHTML += arr[i].substr(val.length);
                /*insert a input field that will hold the current array item's value:*/
                b.innerHTML += "<input type='hidden' value='" + arr[i] + "'>";
                /*execute a function when someone clicks on the item value (DIV element):*/
                b.addEventListener("click", function (e) {
                    /*insert the value for the autocomplete text field:*/
                    inp.value = this.getElementsByTagName("input")[0].value;
                    /*close the list of autocompleted values,
                    (or any other open lists of autocompleted values:*/
                    closeAllLists();
                });
                a.appendChild(b);
            }
        }
    });
    /*execute a function presses a key on the keyboard:*/
    inp.addEventListener("keydown", function (e) {
        var x = document.getElementById(this.id + "autocomplete-list");
        if (x) x = x.getElementsByTagName("div");
        if (e.keyCode == 40) {
            /*If the arrow DOWN key is pressed,
            increase the currentFocus variable:*/
            currentFocus++;
            /*and and make the current item more visible:*/
            addActive(x);
        } else if (e.keyCode == 38) { //up
            /*If the arrow UP key is pressed,
            decrease the currentFocus variable:*/
            currentFocus--;
            /*and and make the current item more visible:*/
            addActive(x);
        } else if (e.keyCode == 13) {
            /*If the ENTER key is pressed, prevent the form from being submitted,*/
            e.preventDefault();
            if (currentFocus > -1) {
                /*and simulate a click on the "active" item:*/
                if (x) x[currentFocus].click();
            }
        }
    });
    function addActive(x) {
        /*a function to classify an item as "active":*/
        if (!x) return false;
        /*start by removing the "active" class on all items:*/
        removeActive(x);
        if (currentFocus >= x.length) currentFocus = 0;
        if (currentFocus < 0) currentFocus = (x.length - 1);
        /*add class "autocomplete-active":*/
        x[currentFocus].classList.add("autocomplete-active");
    }
    function removeActive(x) {
        /*a function to remove the "active" class from all autocomplete items:*/
        for (var i = 0; i < x.length; i++) {
            x[i].classList.remove("autocomplete-active");
        }
    }
    function closeAllLists(elmnt) {
        /*close all autocomplete lists in the document,
        except the one passed as an argument:*/
        var x = document.getElementsByClassName("autocomplete-items");
        for (var i = 0; i < x.length; i++) {
            if (elmnt != x[i] && elmnt != inp) {
                x[i].parentNode.removeChild(x[i]);
            }
        }
    }
    /*execute a function when someone clicks in the document:*/
    document.addEventListener("click", function (e) {
        closeAllLists(e.target);
    });
}