(function() {
    function reloadContacts() {
        $.get("/api/PhoneBook/GetContacts").done(function(contacts) {
            var contactsTable = $(".contacts-table").find("tbody");
            contactsTable.empty();

            contacts.forEach(function(c, i) {
                var tr = $("<tr>");
                $("<td>").text(i + 1).appendTo(tr);
                $("<td>").text(c.name).appendTo(tr);
                $("<td>").text(c.phone).appendTo(tr);
                $("<td><button class=\"delete-button\" type=\"button\">X</button></td>")
                    .data("id", c.id)
                    .appendTo(tr);
                contactsTable.append(tr);

                tr.find(".delete-button").click(function() {
                    var id = $(this).parent().data("id");

                    $.ajax({
                        type: "POST",
                        contentType: "application/json",
                        url: "api/PhoneBook/DeleteContact",
                        data: JSON.stringify(id)
                    }).done(function () {
                        reloadContacts();
                    });
                });
            });
        });
    }

    $(document).ready(function() {
        reloadContacts();

        $(".create-contact-button").click(function() {
            var contact = {
                name: $(".contact-name").val(),
                phone: $(".contact-phone").val()
            };

            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "api/PhoneBook/CreateContact",
                data: JSON.stringify(contact)
            }).done(function() {
                reloadContacts();

                $(".contact-name").val("");
                $(".contact-phone").val("");
            });
        });
    });
})();