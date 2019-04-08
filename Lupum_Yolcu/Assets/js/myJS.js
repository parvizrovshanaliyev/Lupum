$(document).ready(function () {



    $("#AddGroup").submit(function (ev) {
        ev.preventDefault();

        var group = {
            Name: $("input[name='Name']").val(),
            Roles: []
        };


        $(this).find(".action").each(function () {

            var role = {
                ActionId: $(this).data("id"),
                CanView: $(this).find("input[name = 'CanView']").is(":checked"),
                CanAdd: $(this).find("input[name = 'CanAdd']").is(":checked"),
                CanEdit: $(this).find("input[name = 'CanEdit']").is(":checked"),
                CanDelete: $(this).find("input[name = 'CanDelete']").is(":checked"),
                Ownerdata: $(this).find("input[name = 'Ownerdata']").is(":checked")
            };

            for (obj in role) {
                if (role[obj] === true) {
                    group.Roles.push(role);
                    break;
                }
            };  
        });


        $.ajax({

            url: $(this).attr("action"),
            type: $(this).attr("method"),
            dataType: "json",

            data: {
                Group: group
            },

            success: function (response) {
                console.log(response);
                if (response.status === 200)
                {
                    $("#AddGroup")[0].reset();
                    Swal.fire({
                        position: 'top-end',
                        type: 'success',
                        title: 'Your Group Added',
                        showConfirmButton: false,
                        timer: 1500
                    })
                }
                else
                {
                    Swal.fire({
                        position: 'top-end',
                        type: 'error',
                        title: response.message,
                        showConfirmButton: false,
                        timer: 1500
                    })

                }
            }



        });

    });


    $('a.delete').confirm({
        title: "Delete",
        content:"Are you sure to delete?",
        buttons: {
            "Yes": {
                btnClass: 'btn-danger', // class for the button
                action: function () {
                    location.href = $(this).attr('href');
                }
            },
            "No": {
                btnClass: 'btn-primary', // class for the button
                
            }
        }
    });
});