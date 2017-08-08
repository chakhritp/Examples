$(document).ready(function () {

    GetAllUsersAndFillTable();


    $(".table tbody").on("click", "tr", function () {
        $("#id").val($(this).find('td:nth-child(1)').text());
        $("#name").val($(this).find('td:nth-child(2)').text());
        $("#email").val($(this).find('td:nth-child(3)').text());
        $("#city").val($(this).find('td:nth-child(4)').text());
        $("#country").val($(this).find('td:nth-child(5)').text());

        if ($(this).hasClass("selected")) {
            $(this).removeClass("selected");
            $("#id").val("");
            $("#name").val("");
            $("#email").val("");
            $("#city").val("");
            $("#country").val("");
            $("#update").prop("disabled", true);
            $("#delete").prop("disabled", true);
        } else {
            $(this).addClass("selected").siblings().removeClass("selected");
            $("input[type='button']").prop("disabled", false);
        }
    });


    function GetAllUsersAndFillTable() {

        var url = $("#url").val();

        $.ajax({
            type: "GET",
            url: url + "/GetAllUsers",
            dataType: "json",
            success: function (data) {
                console.log(data);
                if (data.length) {
                    $(data).each(function (i) {

                        if ($("#removable_no_data_tr").length) {
                            $("#removable_no_data_tr").remove();
                        }

                        $("#content_div table tbody").append("<tr>" +
                                                            "<td style='display:none'>" + data[i].Id + "</td>" +
                                                            "<td>" + data[i].Name + "</td>" +
                                                            "<td>" + data[i].Email + "</td>" +
                                                            "<td>" + data[i].Address.City + "</td>" +
                                                            "<td>" + data[i].Address.Country + "</td>" +
                                                         "</tr>");
                    });
                } else {
                    if (!$("#removable_no_data_tr").length) {
                        $("#content_div table tbody").append("<tr id='removable_no_data_tr'>" +
                                                                  "<td colspan='4'>no data yet.</td>" +
                                                              "</tr>");
                    }
                }
            },
            error: function (xhr) {
                //implementar erro
                console.log(xhr.responseText);
                alert("some shit happen!, check the console.");
            }
        });
    }

    $("#insert").click(function () {

        var url = $("#url").val();

        if ($("#country").val().length == 0 || $("#city").val().length == 0 ||
            $("#name").val().length == 0 || $("#email").val().length == 0 || url.length == 0) {
            alert("fill all the inputs.");
        } else {

            var address = {
                "Country": $("#country").val(),
                "City": $("#city").val(),
            }

            var user = {
                "Name": $("#name").val(),
                "Email": $("#email").val(),
                "Address": address
            }

            $.ajax({
                type: "POST",
                url: url + "/InsertUser",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(user),
                success: function () {
                    //implementar sucesso *adicionar usuario numa tabela e apresentar na tela
                    alert("congratz, your data has been saved.");

                    GetLastRecordedUserAndInsertOnTable(url);
                },
                error: function (xhr) {
                    //implementar erro
                    console.log(xhr.responseText);
                    alert("some shit happen!, check the console.");
                }
            });
        }
    });

    function GetLastRecordedUserAndInsertOnTable(url) {
        $.ajax({
            type: "GET",
            url: url + "/GetLastRecordedUser",
            dataType: "json",
            success: function (data) {

                if ($("#removable_no_data_tr").length) {
                    $("#removable_no_data_tr").remove();
                }

                $("#content_div table tbody").append("<tr>" +
                                                        "<td style='display: none'>" + data.Id + "</td>" +
                                                        "<td>" + data.Name + "</td>" +
                                                        "<td>" + data.Email + "</td>" +
                                                        "<td>" + data.Address.City + "</td>" +
                                                        "<td>" + data.Address.Country + "</td>" +
                                                     "</tr>");
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            },
            complete: function () {
                $("#country").val("");
                $("#city").val("");
                $("#name").val("");
                $("#email").val("");
            }
        });
    }

    $("#update").click(function () {

        var url = $("#url").val();

        var address = {
            "Country": $("#country").val(),
            "City": $("#city").val(),
        }

        var user = {
            "Id": $("#id").val(),
            "Name": $("#name").val(),
            "Email": $("#email").val(),
            "Address": address
        }

        $.ajax({
            type: "PUT",
            url: url + "/UpdateUser",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(user),
            success: function () {
                //implementar sucesso *adicionar usuario numa tabela e apresentar na tela
                alert("congratz, your data has been Updated.")
                window.location.reload();
            },
            error: function (xhr) {
                //implementar erro
                console.log(xhr.responseText);
                alert("some shit happen!, check the console.");
            }
        });
    });


    $("#delete").click(function () {

        var url = $("#url").val();

        var address = {
            "Country": $("#country").val(),
            "City": $("#city").val(),
        }

        var user = {
            "Id": $("#id").val(),
            "Name": $("#name").val(),
            "Email": $("#email").val(),
            "Address": address
        }

        console.log(user);

        $.ajax({
            type: "DELETE",
            url: url + "/DeleteUser",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(user),
            success: function () {
                //implementar sucesso *adicionar usuario numa tabela e apresentar na tela
                alert("congratz, your data has been removed.");
                window.location.reload();
            },
            error: function (xhr) {
                //implementar erro
                console.log(xhr.responseText);
                alert("some shit happen!, check the console.");
            }
        });
    });
});