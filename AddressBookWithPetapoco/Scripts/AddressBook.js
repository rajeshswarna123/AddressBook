
$(document).ready(function () {

    GetContacts();

    $("#contactList").on("click", ".contact", function () {
        GetContactDetails(this.id);
    });

    $('#add').on("click", function () {
        document.getElementById("contact-form").reset();
        FormToAddContact();
    });

    $("#contact-form").submit(function (e) {
        e.preventDefault();
        SubmitContact();
    });

    $("#cancel").click(function () {
        document.getElementById("contact-form").reset();
        $('#contact-form').css('visibility', 'hidden');
    });

    $("#edit").click(function () {
        FormToUpdateContact(this.className);
    });


    $("#delete").click(function () {
        DeleteContact(this.className);
        });

});


function GetContacts() {
    $.ajax({

        type: "GET",

        url: "/api/addressbook",

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (data) {
            data.forEach(function (contact) {

                $("#contactList").append("<div class = 'contact border-styles' id=" + contact.Id + " ><h4 class = 'contact-name'>" + contact.Name + "</h4><p class = 'contact-email'>" + contact.Email + "</p><p class = 'contact-mobile'>" + contact.Mobile + "</p></div>");

                $("#" + contact.Id).addClass("border-styles");
            });

        },

        failure: function (response) {

            alert(response.responseText);

        },
    });
}


function GetContactDetails(id) {
    $('#contact-details').css('visibility', 'visible');
    $('#contact-form').css('visibility', 'hidden');

    $.ajax({
        type: "GET",

        url: `/api/AddressBook/GetContact/${id}`,

        contentType: "application/json; charset=utf-8",

        dataType: "json",
        
        success: function (data) {

            $('#display-contat-details').html("<h4 id='contact-name'>" + data.Name + "</h4><p id='contact-email'>Email: " + data.Email + "</p><p id ='contact-mobile'> Mobile: " + data.Mobile + "</p><p id='contact-landline'>Landline: " + data.Landline + "</p><p id='contact-website'>Website:  " + data.Website + "</p> <p id='contact-address'>Address: " + data.Address + "</p>");
            $('#edit').removeClass().addClass(id);
            $('#delete').removeClass().addClass(id);
        },

        failure: function (response) {
            alert(response.responseText);
        },
    });
}


function FormToAddContact() {
    $("#id").val("");
    $('#contact-details').css('visibility', 'hidden');
    $('#contact-form').css('visibility', 'visible');
    $('.btn').text("Add");
}


function FormToUpdateContact(id) {
    $('#id').val(id);
    $('#contact-details').css('visibility', 'hidden');
    $('.btn').text("Update");
    $('#contact-form').css('visibility', 'visible');
    $.ajax({
        type: "GET",

        url: `/api/AddressBook/GetContact/${id}`,

        contentType: "application/json; charset=utf-8",

        dataType: "json",

        success: function (data) {
            
            $("#Name").val(data.Name);
            $("#Email").val(data.Email);
            $("#Mobile").val(data.Mobile);
            $("#Landline").val(data.Landline);
            $("#Website").val(data.Website);
            $("#Address").val(data.Address);
        },

        failure: function (response) {
            alert(response.responseText);
        },
    });
}


function AddContact(contactInfo) {
    $.ajax({
        type: 'POST',

        url: `/api/AddressBook`,

        dataType: 'json',

        data: contactInfo,

        success: function (data) {
            document.getElementById("contact-form").reset();
            $("#cancel").click();
            alert("Saved Successfully");
            $("#contactList").append("<div class = 'contact border-styles' id=" + data.Id + " ><h4 class = 'contact-name'>" + data.Name + "</h4><p class = 'contact-email'>" + data.Email + "</p><p class = 'contact-mobile'>" + data.Mobile + "</p></div>");
        },

        error: function () {
            alert("Error please try again");
        }
    });
}


function UpdateContact(contactInfo) {
    $.ajax({
        type: 'PUT',

        url: `/api/AddressBook`,

        dataType: 'json',

        data: contactInfo,

        success: function (data) {
            $("#cancel").click();
            alert("Updated Successfully");
            $('#' + data.Id).html("<h4 class = 'contact-name'>" + data.Name + "</h4><p class = 'contact-email'>" + data.Email + "</p><p class = 'contact-mobile'>" + data.Mobile + "</p>");
        },

        error: function () {
            alert("Error please try again");
        }
    });
}


function SubmitContact() {
    var contactInfo = {
        Name: $("#Name").val(),
        Email: $("#Email").val(),
        Mobile: $("#Mobile").val(),
        Landline: $("#Landline").val(),
        Website: $("#Website").val(),
        Address: $("#Address").val(),
        Id: $("#id").val(),
    }
    if ($("#id").val() == "") {
        AddContact(contactInfo);
    }
    else {
        UpdateContact(contactInfo);
    }
}


function DeleteContact(id) {
    $.ajax({
        type: 'DELETE',

        url: `/api/AddressBook/Delete/${id}`,

        dataType: 'json',

        success: function (id) {
            $('#contact-details').css('visibility', 'hidden');
            alert("Sucessfully Deleted");
            $('#' + id).remove();
        },
        error: function () {
            alert("Error please try again");
        }
    });
}   