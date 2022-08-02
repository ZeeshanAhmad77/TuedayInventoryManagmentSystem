function Validate() {

    var userName = document.getElementById("txtUserName").value;
    var Password = document.getElementById("txtPassword").value;
    try {

        if (userName == "") throw " User Name is Empty";
        // if (userName != "zee") throw " Incorrect User Name";
        if (Password == "") throw " Password is Empty";
        // if (Password != "pass") throw " Incorrect Password ";
        return true;
    }
    catch (err) {
        alert(err);
        return false;
    }
}

    $(document).ready(function () {
        $.ajax({
            url: 'AccountantServices.asmx/AccountantTable',
            method: 'post',
            dataType: 'json',
            success: function (data) {

                $("#AdminTable").dataTable({
                    data: data,
                    columns: [

                        { 'data': 'Id' },
                        { 'data': 'Name' },
                        { 'data': 'Password' },


                    ]
                });
            }

        });



    });


