function Register()
{
    var Passport = document.getElementById("Passport");
    var Password = document.getElementById("Password");
    var Mac = document.getElementById("Mac");

    var idata = {};
    idata.passport = Passport.value;
    idata.password = Password.value;
    idata.mac = Mac.value;

    $.ajax("http://localhost:43719/api/register/submit/",{        
            URL: "http://localhost:43719/api/register/submit/",
            method: 'POST',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(idata),
        success: function (data) {
            if(JSON.parse(data))
            {
                alert("Success");
            }
            else {
                alert("Failed due to wrong credentials");
            }
            
        },
        failure: function (error) {
            alert("Failed");
        }
    });
    return false;
}