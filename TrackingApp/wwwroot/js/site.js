// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $('#clientTable').DataTable();
});

$(document).ready(function () {
    $("#employment").change(function () {
        var employmentValue = $(this).val();
        if (employmentValue == "Yes") {
            $("#employed").slideDown();
        } else {
            $("#employed").slideUp();
        }
    });
});

$(document).ready(function () {
    $("#graduate").change(function () {
        var yearGraduated = $(this).val();
        if (yearGraduated == "No") {
            $("#yeargraduated .form-label").html("Last Year Attended<span class='text-danger'>*</span>");
        } else {
            $("#yeargraduated .form-label").html("Year Graduated<span class='text-danger'>*</span>");
        }
    });
});

$(document).ready(function () {
    $('#other').on('change', function () {
        if ($(this).prop('checked')) {
            $('#others').slideDown();
        } else {
            $('#others').slideUp();
            $('#others').val("");
        }
    });
});

$(document).ready(function () {
    const othersCheckbox = $('#other');
    const othersTextarea = $('#others textarea');

    othersCheckbox.on('change', function () {
        if (!othersCheckbox.prop('checked')) {
            othersTextarea.val('');
        }
    });
});

const $othersCheckbox = $('#other');
const $othersTextarea = $('#others-textarea');

$othersCheckbox.on('change', () => {
    if (!$othersCheckbox.prop('checked')) {
        $othersTextarea.val('');
    }
});

