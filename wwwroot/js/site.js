//import { stat } from "fs";

//import { Number } from "core-js";
//Scaffold - DbContext "Server=DESKTOP-LIJ5HIK\SQLEXPRESS;Initial Catalog=QUANLIXE;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models - force
// Write your JavaScript code.
$(document).ready(function () {
    $('.depatures').change(function () {
        var value = $('.depatures').find(':selected').val();
        $.ajax({
            url: 'Home/GetDestinations',
            type: 'post',
            dataType: 'json',
            data: { IdDeparture: value },
            success: function (result) {
                $des = $('.main-booking .destinations');
                $des.empty();
                $.each(result, function (index, item) {
                    $des.append('<option value=' + item.value + '>' + item.text + '</option>');
                });
            }
        });
    });
});

$(document).ready(function () {
    $('input:radio[name="IsReturn"]').change(function () {
        var val = $(this).val();
        if (this.value == 'true') {
            $('#End')[0].disabled = false;
        }
        else {
            $('#End')[0].disabled = true;
        }

    });
});

//---------------------------
function validateCustomerInfo(obj) {
    if (obj.familyName == '') {
        alert("You must fill the family name");
    }
    if (obj.middleName == '') {
        alert('You must fill the middle name');
    }
    if (obj.address == '') {
        alert('You must fill the address');
    }
    if (obj.city == '') {
        alert('You must fill the city');
    }
    if (obj.region == '') {
        alert('You must fill the region');
    }
    if (obj.province == '') {
        alert('You must fill the province');
    }
    if (!isEmail(obj.email) || hasUnicode(obj.email)) {
        alert('You must fill valid email');
    }
    if (obj.passportNumber == '') {
        alert('You must fill valid passport number');
    }
    if (!isDigit(obj.passportNumber) || obj.passportNumber.length < 10 || obj.passportNumber.length > 11) {
        alert('You must fill valid phone number format');
    }
}

//function isEmail(email) {
//    const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
//    return re.test(email);
//};
//-----------------------------

//------------------------------------
//$(document).ready(function () {
//    $('.control .next').click(function () {
//        var obj = {
//            sex: $('#Sex option:selected').val(),
//            familyName: $('#FamilyName').val(),
//            middleName: $('#MiddleName').val(),
//            address: $('#Address').val(),
//            city: $('#City').val(),
//            region: $('#Region').val(),
//            province: $('#Province').val(),
//            email: $('#Email').val(),
//            day: $('#Day option:selected').val(),
//            month: $('#Month option:selected').val(),
//            year: $('#Year option:selected').val(),
//            passportNumber: $('#PassportNumber').val(),
//            expDay: $('#ExpDay').val(),
//            phone: $('#Phone').val(),
//            nationality: $('#Nationality').val()
//        };
//        validateCustomerInfo(obj);
//        $.ajax({
//            type: 'post',
//            url: 'FillImfomation',
//            data: { model: obj },
//            error: function () {
//                conso.log('Error!!!');
//            }
//        });

//    });
//});
//----------------Form submit---------------------
function submitFormCustom(anchor) {
    if (anchor == 'back') {
        history.go(-1);
    }
    if (anchor == 'continue') {
        var obj = {
            sex: $('#Sex option:selected').val(),
            familyName: $('#FamilyName').val(),
            middleName: $('#MiddleName').val(),
            address: $('#Address').val(),
            city: $('#City').val(),
            region: $('#Region').val(),
            province: $('#Province').val(),
            email: $('#Email').val(),
            day: $('#Day option:selected').val(),
            month: $('#Month option:selected').val(),
            year: $('#Year option:selected').val(),
            passportNumber: $('#PassportNumber').val(),
            expDay: $('#ExpDay').val(),
            phone: $('#Phone').val(),
            nationality: $('#Nationality').val()
        };
        validateCustomerInfo(obj);
        $('#CustomInfo').submit();
    }
}

function addTicket(that) {
    //var depFlight = $('input[name="grid-dep-option"]:checked').val();
    //var retFlight = $('input[name="grid-ret-option"]:checked').val()
    //$.ajax({
    //    type: 'get',
    //    url: 'FillImformation',
    //    //data: { depFlight: depFlight, retFlight: retFlight },
    //    //dataType: 'json',
    //    success: function () {
    //        console.log('successfully!');
    //    },
    //    error: function () {
    //        console.log('Error!!!');
    //    }
    //});
    $(that).parent().next().prop('checked', true);
    $('#choosing-ticket-form').submit();
}

function handleCheckedFlight(that) {
    var time = $(that).parent().siblings('.flight-date').text();
    var money = $(that).next().data('money');
    var adult = $('.is-selected').data('adult');
    var children = $('.is-selected').data('children');
    var tax = $('.is-selected').data('tax');
    if ($(that).data('type') == "deparFlight") {
        $('#booked-depar-flight tr').css('display', 'block');
        $('#dep-booked-date').text(time);
        $('#dep-booked-price').text(money * (adult + children) + ' ' + 'VND');
        $('#dep-booked-tax').text(tax * (adult + children) + ' ' + 'VND');
    }
    if ($(that).data('type') == "returnFlight") {
        $('#booked-return-flight tr').css('display', 'block');
        $('#ret-booked-date').text(time);
        $('#ret-booked-price').text(money * (adult + children) + ' ' + 'VND');
        $('#ret-booked-tax').text(tax * (adult + children) + ' ' + 'VND');
    }
}

function setChair(that) {
    var number = $('.busy-seat').length;
    var status = $(that).attr('class');
    $.ajax({
        url: 'CheckBusySeat',
        type: 'post',
        dataType: 'json',
        async: false,
        success: function (people) {
            if (status.indexOf('busy-seat') >= 0) {//remove chosen seat
                $(that).removeClass('busy-seat').addClass('available-seat');
            }
            else {
                if (number >= people) {
                    alert('You can only choose' + " " + people + " " + 'seats');
                }
                else {
                    if (status.indexOf('available-seat') >= 0) {
                        $(that).removeClass('available-seat').addClass('busy-seat');
                    }

                }
            }
        },
        error: function () {
            console.log('booking error');
        }
    });
    if (status.indexOf('unavailable-seat') >= 0) {
        alert("This seat is not available");
    }
}