$(document).ready(function () {
    ///////////////////Group//////////////////////////////
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


    $("#EditGroup").submit(function (ev) {
        ev.preventDefault();

        var group = {
            Id: $("input[name='Id']").val(),
            Name: $("input[name='Name']").val(),
            //Roles: []
        };
        var roles = [];

        $(this).find(".action").each(function () {

            var role = {
                ActionId: $(this).data("id"),
                GroupId: group.Id,
                CanView: $(this).find("input[name = 'CanView']").is(":checked"),
                CanAdd: $(this).find("input[name = 'CanAdd']").is(":checked"),
                CanEdit: $(this).find("input[name = 'CanEdit']").is(":checked"),
                CanDelete: $(this).find("input[name = 'CanDelete']").is(":checked"),
                Ownerdata: $(this).find("input[name = 'Ownerdata']").is(":checked")
            };

            for (obj in role) {
                if (role[obj] === true) {
                    roles.push(role);
                    break;
                }
            };
        });

        console.log(group, roles);

        $.ajax({

            url: $(this).attr("action"),
            type: $(this).attr("method"),
            dataType: "json",

            data: {
                Group: group,
                Roles: roles
            },

            success: function (response) {
                console.log(response);
                if (response.status === 200) {
                    //$("#AddGroup")[0].reset();
                    Swal.fire({
                        position: 'top-end',
                        type: 'success',
                        title: 'Your Group Update',
                        showConfirmButton: false,
                        timer: 2000
                    });
                    //window.location.href = '/Groups/Index'
                    window.setTimeout(function () { location.href = '/Groups/Index' }, 2000);
                }
                else {
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
    ///////////////////Group//////////////////////////////
    
    ///////////////////Product//////////////////////////////
    $("#AddProduct").submit(function (ev) {
        ev.preventDefault();

        var product = {
            Name: $("input[name='Name']").val(),
            Price: $("input[name='Price']").val(),
            GiftCount: $("input[name='GiftCount']").val(),
            Colors: $("input[name='Colors']").val(),
            Status: $("input[name = 'Status']").is(":checked"),
            TypeId: $("#TypeId option:selected").val()
        };
        //console.log(product);

       


        $.ajax({

            url: $(this).attr("action"),
            type: $(this).attr("method"),
            dataType: "json",

            data: {
                Product: product
            },

            success: function (response) {
                console.log(response);
                if (response.status === 200) {
                    //console.log(response);
                    $("#AddProduct")[0].reset();
                    Swal.fire({
                        position: 'top-end',
                        type: 'success',
                        title: 'Your Product Added',
                        showConfirmButton: false,
                        timer: 2000
                    })
                }
                else {
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
    ///////////////////Product//////////////////////////////

    $('a.delete').confirm({
        title: "Delete",
        content: "Are you sure to delete?",
        buttons: {
            Yes: {
                btnClass: 'btn-danger', // class for the button
                action: function (Yes) {
                    location.href = this.$target.attr("href");
                }
            },
            no: {

                btnClass: 'btn-success',
            }
        }
    });
    //$('a.delete').confirm({
    //    title: "Delete",
    //    content:"Are you sure to delete?",
    //    buttons: {
    //        Yes: {
    //            btnClass: 'btn-danger', // class for the button
    //            hey: function () {
    //                location.href = this.$target.attr("href");
    //            }
    //        },
    //        No: {
    //            btnClass: 'btn-primary', // class for the button
                
    //        }
    //    }
    //});
});