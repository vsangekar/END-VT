//Location start//
$(document).ready(function () {
    var max_fields = 5; 
    var wrapper = $(".location"); 
    var add_button = $(".add_location"); 

    var x = 1; 
    $(add_button).click(function (e) { 
        e.preventDefault();
        if (x < max_fields) { 
            x++; 
            $(wrapper).append(' <div class="row"> <div class="col-lg-12"><label style="font-weight: 700;">Location ' + x + ' </label>  </div> \
             <div class="col-lg-2"> <div class="form-group">     <input type="text" class="form-control" name="mytext1[' + x + ']">  </div> </div> \
                <div class="col-lg-2"> <div class="form-group"> <input type="text" class="form-control" name="mytext2[' + x + ']"> </div>  </div>\
                 <div class="col-lg-4"> <div class="form-group">  <input type="text" class="form-control" name="mytext3[' + x + ']">  </div>  </div>\
                  <div class="col-lg-3"><div class="form-group"><input type="text" class="form-control" name="mytext4[' + x + ']"> </div> </div> \
                   <button class="btn btn-primary btn-icon  btn-icon-mini btn-round remove_field" style="margin-left: 15px;background: #d45d5d;margin-top: -20px;"> <i class="material-icons" style="line-height: 30px;">remove</i>   </button> </div>'); // add input boxes.
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { 
        e.preventDefault(); $(this).parent('div').remove(); x--;
    })
});
//Location END//

//Contacts start//
$(document).ready(function () {
    var max_fields = 5; 
    var wrapper = $(".contacts"); 
    var add_button = $(".add_contacts"); 

    var x = 1; 
    $(add_button).click(function (e) { 
        e.preventDefault();
        if (x < max_fields) { 
            x++; 
            $(wrapper).append(' <div class="row"> <div class="col-lg-12"><label style="font-weight: 700;">Contact ' + x + ' </label>  </div>\
              <div class="col-lg-3">  <select class="form-control show-tick" name="mytext1[' + x + ']">  <option value="Relationship Manager">Relationship Manager   </option>  <option value="SME">SME</option> <option value="Delegation Lead">Delegation Lead</option> <option value="Delegation Executive"> Delegation Executive</option>   <option value="Primary Contact (Delegate)">Primary Contact (Delegate) </option>  <option value="Secondary Contact (Delegate)"> Secondary Contact (Delegate)</option>  </select>  </div>   \
                <div class="col-lg-2"> <div class="form-group">  <input type="text" class="form-control" name="mytext2[' + x + ']"> </div>  </div> \
                <div class="col-lg-3"> <div class="form-group">  <input type="text" class="form-control" name="mytext3[' + x + ']">  </div>  </div>\
                 <div class="col-lg-2"><div class="form-group"> <input type="text" class="form-control" name="mytext4[' + x + ']"> </div> </div>\
                 <div class="col-lg-1">  <div class="form-group">   <input type="checkbox" class="form-control" name="mytext5[' + x + ']"  style="margin-top: 10px;"> </div> </div>\
                 <button class="btn btn-primary btn-icon  btn-icon-mini btn-round remove_field" style="margin-left: 15px;background: #d45d5d;margin-top: -20px;"> <i class="material-icons" style="line-height: 30px;">remove</i>   </button> </div>'); // add input boxes.
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { 
        e.preventDefault(); $(this).parent('div').remove(); x--;
    })
});
 //Contacts END//


 //Licenses start//
$(document).ready(function () {
    var max_fields = 5; 
    var wrapper = $(".Licenses"); 
    var add_button = $(".add_licenses"); 

    var x = 1; 
    $(add_button).click(function (e) { 
        e.preventDefault();
        if (x < max_fields) { 
            x++; 
            $(wrapper).append(' <div class="row"> <div class="col-lg-12"><label style="font-weight: 700;">Licenses ' + x + ' </label>  </div>\
              <div class="col-lg-3">  <select class="form-control show-tick" name="mytext1[' + x + ']">  <option value="Utilization Management">Utilization Management   </option> <option value="Case Management">Case Management</option>  <option value="Claims Processing">Claims Processing</option> <option value="Appeals & Grievances"> Appeals & Grievances</option> <option value="Credentialing">Credentialing </option>  <option value="Disease Management"> Disease Management</option> </select>  </div>   \
                <div class="col-lg-3">  <select class="form-control show-tick ms select2" multiple data-placeholder="Select" name="mytext2[' + x + ']">  <option value="AL">AL   </option>  <option value="AR">AR</option>   <option value=" NJ"> NJ</option> <option value=" NY">  NY</option>  </select>   </div> \
                <div class="col-lg-3"> <div class="form-group">  <input type="text" class="form-control" name="mytext3[' + x + ']">  </div>  </div>\
                 <div class="col-lg-2"><div class="form-group"> <input type="date" class="form-control" name="mytext4[' + x + ']"> </div> </div>\
                 <button class="btn btn-primary btn-icon  btn-icon-mini btn-round remove_field" style="margin-left: 15px;background: #d45d5d;margin-top: -20px;"> <i class="material-icons" style="line-height: 30px;">remove</i>   </button> </div>'); // add input boxes.
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { 
        e.preventDefault(); $(this).parent('div').remove(); x--;
    })
});
 //Licenses END//


 //Accreditation start//
$(document).ready(function () {
    var max_fields = 5; 
    var wrapper = $(".Accreditation"); 
    var add_button = $(".add_Accreditation"); 

    var x = 1; 
    $(add_button).click(function (e) { 
        e.preventDefault();
        if (x < max_fields) { 
            x++; 
            $(wrapper).append(' <div class="row"> <div class="col-lg-12"><label style="font-weight: 700;">Licenses ' + x + ' </label>  </div>\
              <div class="col-lg-3">  <select class="form-control show-tick" name="mytext1[' + x + ']">   <option value="NCQA">NCQA </option>  <option value="URAC">URAC</option>   <option value="DOH">DOH</option> <option value="Other"> Other</option></select>  </div>   \
                <div class="col-lg-3">  <select class="form-control show-tick" name="mytext2[' + x + ']">  <option value="Accreditation">Accreditation  </option>  <option value="Certification">Certification</option>  <option value=" Recognition"> Recognition</option> <option value=" Other">  Other</option> <option value=" N/A">  N/A</option> </select>   </div> \
                <div class="col-lg-3"> <div class="form-group">  <input type="text" class="form-control" name="mytext3[' + x + ']">  </div>  </div>\
                 <div class="col-lg-2"><div class="form-group"> <input type="date" class="form-control" name="mytext4[' + x + ']"> </div> </div>\
                 <button class="btn btn-primary btn-icon  btn-icon-mini btn-round remove_field" style="margin-left: 15px;background: #d45d5d;margin-top: -20px;"> <i class="material-icons" style="line-height: 30px;">remove</i>   </button> </div>'); // add input boxes.
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { 
        e.preventDefault(); $(this).parent('div').remove(); x--;
    })
});
 //Accreditation END//

 //Delegate start//
$(document).ready(function () {
    var max_fields = 5; 
    var wrapper = $(".Delegate"); 
    var add_button = $(".add_Delegate"); 

    var x = 1; 
    $(add_button).click(function (e) { 
        e.preventDefault();
        if (x < max_fields) { 
            x++; 
            $(wrapper).append(' <div class="row"> <div class="col-lg-12"><label style="font-weight: 700;">Delegate ' + x + ' </label>  </div>\
              <div class="col-lg-3">  <label>Delegated Functions   </label> <select class="form-control show-tick" name="mytext1[' + x + ']">  \
                <option value="Utilization Management">Utilization Management </option>\
                 <option value="Case Management">Case Management</option>\
                  <option value="Claims Processing">Claims Processing</option>\
                   <option value="Appeals & Grievances"> Appeals & Grievances</option>\
                    <option value="Credentialing">Credentialing</option>\
                    <option value="Disease Management">Disease Management</option>\
                    <option value="Benefits Management">Benefits Management</option>\
                    <option value="Customer Service">Customer Service</option>\
                    <option value="Network Adequacy">Network Adequacy</option>\
                    <option value="Quality Management">Quality Management</option>\
                    <option value="Enrollment/Disenrollment">Enrollment/Disenrollment</option>\
                    <option value="Health Education">Health Education</option></select>  </div>   \
                <div class="col-lg-3">    <label>Products </label> <select class="form-control show-tick" name="mytext2[' + x + ']">  \
                <option value="Medicare HMO">Medicare HMO  </option>\
                <option value="Medicare PPO">Medicare PPO</option>\
                <option value=" Medicaid HMO"> Medicaid HMO</option>\
                <option value=" Commerical HMO">  Commerical HMO</option>\
                <option value=" Commercial PPO">  Commercial PPO</option>\
                <option value=" Commercial POS">  Commercial POS</option>\
                <option value="Exchange HMO"> Exchange HMO</option>\
                <option value=" Exchange PPO">  Exchange PPO</option>\
                <option value=" Exchange POS">  Exchange POS</option> </select>   </div> \
                <div class="col-lg-2"> <div class="form-group"> <label>Effective Date </label> <input type="date" class="form-control" name="mytext3[' + x + ']">  </div>  </div>\
                 <div class="col-lg-2"><div class="form-group"> <label>End Date</label><input type="date" class="form-control" name="mytext4[' + x + ']"> </div> </div>\
                 <div class="col-lg-2"> <div class="form-group"> <label>Approval Date </label>  <input type="date" class="form-control" name="mytext5[' + x + ']">  </div>   </div>\
                 <div class="col-lg-3"> <label>Regulatory Approval  </label> <select class="form-control show-tick" name="mytext6[' + x + ']">\
                    <option value="CMS">CMS  </option>\
                    <option value="DOH">DOH</option>\
                    <option value="DFS">DFS</option>\
                    <option value="AG"> AG</option>\
                    <option value="DOI"> DOI</option>\
                    <option value="Other"> Other</option>\
                    <option value="N/A"> N/A</option>\ </select> </div>\
                    <div class="col-lg-2">  <label> Sub-Delegation</label> <div class="form-group">   <div class="radio inlineblock m-r-20">\
                        <input type="radio" name="gender" id="Active" class="with-gap" value="option1" checked="" name="mytext7[' + x + ']">  <label for="Active">Yes</label>\
                    </div> \     <div class="radio inlineblock">  <input type="radio" name="gender" id="Inactive" class="with-gap" value="option2" name="mytext8[' + x + ']">  <label for="Inactive">No</label> </div>  </div>  </div>\
                    <div class="col-lg-3">   <div class="form-group">   <label>Sub-Delegate Name </label>  <input type="text" class="form-control" name="mytext9[' + x + ']">  </div>\  </div>\
                    <div class="col-lg-3">  <div class="form-group">   <label>Performance Standard </label> <input type="text" class="form-control" name="mytext10[' + x + ']"> </div>  </div>\
                 <button class="btn btn-primary btn-icon  btn-icon-mini btn-round remove_field" style="margin-left: 15px;background: #d45d5d;"> <i class="material-icons" style="line-height: 30px;">remove</i>   </button> </div>'); // add input boxes.
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { 
        e.preventDefault(); $(this).parent('div').remove(); x--;
    })
});
 //Delegate END//

//Off-Shore start//
$(document).ready(function () {
    var max_fields = 5; 
    var wrapper = $(".Off-Shore"); 
    var add_button = $(".add_Off-Shore"); 

    var x = 1; 
    $(add_button).click(function (e) { 
        e.preventDefault();
        if (x < max_fields) { 
            x++; 
            $(wrapper).append(' <div class="row"> <div class="col-lg-12"><label style="font-weight: 700;">Off-Shore Location ' + x + ' </label>  </div>\
              <div class="col-lg-4">  <div class="form-group"> <input type="text" class="form-control" name="mytext2[' + x + ']"> </div> </div> \
                <div class="col-lg-3">  <select class="form-control show-tick" name="mytext3[' + x + ']">  <option value="IN">IN   </option><option value=" PI"> PI</option>  </select> </div>\
                <div class="col-lg-4">  <select class="form-control show-tick" name="mytext4[' + x + ']"> <option value="Utilization Management">Utilization Management </option>\
                <option value="Case Management">Case Management</option>\
                <option value="Claims Processing">Claims Processing</option>\
                <option value="Appeals & Grievances"> Appeals & Grievances</option>\
                <option value="Credentialing">Credentialing</option>\
                <option value="Disease Management">Disease Management</option>\
                <option value="Benefits Management">Benefits Management</option>\
                <option value="Customer Service">Customer Service</option>\
                <option value="Network Adequacy">Network Adequacy</option>\
                <option value="Quality Management">Quality Management</option>\
                <option value="Enrollment/Disenrollment">Enrollment/Disenrollment</option>\
                <option value="Health Education">Health Education</option> </select> </div>\
                 <button class="btn btn-primary btn-icon  btn-icon-mini btn-round remove_field" style="margin-left: 15px;background: #d45d5d;margin-top: -20px;"> <i class="material-icons" style="line-height: 30px;">remove</i>   </button> </div>'); // add input boxes.
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { 
        e.preventDefault(); $(this).parent('div').remove(); x--;
    })
});
 //Off-Shore END//

 $(document).on('change', ".fileUploadWrap input[type='file']",function(){
    if ($(this).val()) {

        var filename = $(this).val().split("\\");
     
        filename = filename[filename.length-1];

        $('.fileName').text(filename);
    }
});

 //Show HIDE//
$(document).ready(function(){
    $("#key_report").show();
    $("#key_form").hide();
    $("#key_btn1").click(function(){
      $("#key_report").hide();
      $("#key_form").show();
    });
    $("#key_btn2").click(function(){
      $("#key_report").show();
      $("#key_form").hide();
    });
  });


  $(document).ready(function(){
    $("#Monitoring_report").show();
    $("#Monitoring_form").hide();
    $("#Monitoring_btn1").click(function(){
      $("#Monitoring_report").hide();
      $("#Monitoring_form").show();
    });
    $("#Monitoring_btn2").click(function(){
      $("#Monitoring_report").show();
      $("#Monitoring_form").hide();
    });
  });

  $(document).ready(function(){
    $("#Regulatory_report").show();
    $("#Regulatory_form").hide();
    $("#Regulatory_btn1").click(function(){
      $("#Regulatory_report").hide();
      $("#Regulatory_form").show();
    });
    $("#Regulatory_btn2").click(function(){
      $("#Regulatory_report").show();
      $("#Regulatory_form").hide();
    });
  });

  $(document).ready(function(){
    $("#Review_report").show();
    $("#Review_form").hide();
    $("#Review_btn1").click(function(){
      $("#Review_report").hide();
      $("#Review_form").show();
    });
    $("#Review_btn2").click(function(){
      $("#Review_report").show();
      $("#Review_form").hide();
    });
  });


  $(document).ready(function(){
    $("#Corrective_report").show();
    $("#Corrective_form").hide();
    $("#Corrective_btn1").click(function(){
      $("#Corrective_report").hide();
      $("#Corrective_form").show();
    });
    $("#Corrective_btn2").click(function(){
      $("#Corrective_report").show();
      $("#Corrective_form").hide();
    });
  });

  $(document).ready(function(){
    $("#organization_report").show();
    $("#organization_form").hide();
    $("#organization_btn1").click(function(){
      $("#organization_report").hide();
      $("#organization_form").show();
    });
    $("#organization_btn2").click(function(){
      $("#organization_report").show();
      $("#organization_form").hide();
    });
  });

  $(document).ready(function(){
    $("#users_report").show();
    $("#users_form").hide();
    $("#users_btn1").click(function(){
      $("#users_report").hide();
      $("#users_form").show();
    });
    $("#users_btn2").click(function(){
      $("#users_report").show();
      $("#users_form").hide();
    });
  });

  $(document).ready(function(){
    $("#release_report").show();
    $("#release_form").hide();
    $("#release_btn1").click(function(){
      $("#release_report").hide();
      $("#release_form").show();
    });
    $("#release_btn2").click(function(){
      $("#release_report").show();
      $("#release_form").hide();
    });
  });
  //Show HIDE//


  //Roles start//
$(document).ready(function () {
  var max_fields = 5; 
  var wrapper = $(".roles"); 
  var add_button = $(".add_roles"); 

  var x = 1; 
  $(add_button).click(function (e) { 
      e.preventDefault();
      if (x < max_fields) { 
          x++; 
          $(wrapper).append('<tr><tr>\
          <td>\
              <div class="form-group">\
                  <div class="form-line">\
                      <input type="text" class="form-control" name="mytext1[' + x + ']">\
                  </div>\
              </div>\
          </td>\
          <td>\
              <div class="form-line">\
                  <select class="form-control show-tick" name="mytext2[' + x + ']">\
                      <option value="Responsible">Responsible </option>\
                      <option value="Accountable">Accountable</option>\
                      <option value="Consultant">Consultant</option>\
                      <option value="Informed"> Informed</option>\
                  </select>\
              </div>\
          </td>\
          <td>\
              <div class="form-line">\
                  <select class="form-control show-tick" name="mytext3[' + x + ']">\
                      <option value="Responsible">Responsible </option>\
                      <option value="Accountable">Accountable</option>\
                      <option value="Consultant">Consultant</option>\
                      <option value="Informed"> Informed</option>\
                  </select>\
              </div>\
          </td>\
          <td>\
              <div class="form-line">\
                  <select class="form-control show-tick" name="mytext4[' + x + ']">\
                      <option value="Responsible">Responsible </option>\
                      <option value="Accountable">Accountable</option>\
                      <option value="Consultant">Consultant</option>\
                      <option value="Informed"> Informed</option>\
                  </select>\
              </div>\
          </td>\
          <td>\
              <div class="form-line">\
                  <select class="form-control show-tick" name="mytext5[' + x + ']">\
                      <option value="Responsible">Responsible </option>\
                      <option value="Accountable">Accountable</option>\
                      <option value="Consultant">Consultant</option>\
                      <option value="Informed"> Informed</option>\
                  </select>\
              </div>\
          </td>\
          <td>\
              <div class="form-line">\
                  <select class="form-control show-tick" name="mytext6[' + x + ']">\
                      <option value="Responsible">Responsible </option>\
                      <option value="Accountable">Accountable</option>\
                      <option value="Consultant">Consultant</option>\
                      <option value="Informed"> Informed</option>\
                  </select>\
              </div>\
          </td>\
          <td>\
              <div class="form-line">\
                  <select class="form-control show-tick" name="mytext7[' + x + ']">\
                      <option value="Responsible">Responsible </option>\
                      <option value="Accountable">Accountable</option>\
                      <option value="Consultant">Consultant</option>\
                      <option value="Informed"> Informed</option>\
                  </select>\
              </div> </td>\
              <td><button class="btn btn-primary btn-icon  btn-icon-mini btn-round remove_field" style="background: #d45d5d;margin-top: -20px;"> <i class="material-icons" style="line-height: 30px;">remove</i> </button></tr> </tr></span>'); // add input boxes.
      }
  });

  $(wrapper).on("click", ".remove_field", function (e) { 
      e.preventDefault(); $(this).parent('tr').remove(); x--;
  })
});
//Roles END//

$(function () {
  $("[rel='tooltip']").tooltip();
});

 