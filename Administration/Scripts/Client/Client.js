﻿function getClientParameters(importTypeId, action) {
    $.ajax({
        url: action + '?' + $('form').serialize(),
        dataType: "html",
        success: function (result) {
            $('#clientParameters').empty();
            $('#clientParameters').append(result);
        }
    });
}
$(document).ready(function () {

    //$('form').validate();
    //$('#ImportTypeId').rules("add", { required: true });


    //$('#ImportTypeId').validate({ required: true });
    $('#ImportTypeId').live ('change',function () {
        getClientParameters($('#ImportTypeId').val(), '/Client/ClientParametersView');
    });

});