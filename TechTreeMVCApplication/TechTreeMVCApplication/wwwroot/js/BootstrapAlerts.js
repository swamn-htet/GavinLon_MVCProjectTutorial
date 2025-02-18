﻿function PresentClosableBootstrapAlert(placeHolderElementId, alertType, alertHeading, alertMessage) {

    if (alertType == "") {
        alertType == "info";
    }
    var alertHtml = '<div class="alert alert-' + alertType + ' alert-dismissible fade show" role="alert">' +
        '<strong>' + alertHeading + '</strong><br>' + alertMessage +
        '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
        '<span aria-hidden="true">&times;</span>' +
        '</button>' +
        '</div>';

    $(placeHolderElementId).html(alertHtml);
}

function CloseAlert(placeHolderElementId) {
    $(placeHolderElementId).html(alertHtml);
}