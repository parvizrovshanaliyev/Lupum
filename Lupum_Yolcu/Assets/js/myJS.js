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
            dataType: "jshon",

            data: {
                Group: group
            },

            success: function (response) {
                console.log(response);
                if (response.status == 200)
                {

                }
                else
                {

                }
            }



        });

    });
});