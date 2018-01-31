//Підсвітка меню--------------------------------------------
$(function(){
    $('.panel').on('show.bs.collapse', function () {
        $(this).toggleClass("panel-primary");
        $(this).find('span').toggleClass('glyphicon-folder-open');
        $('#firsElementMenu').removeClass("panel-primary")
    });

    $('.panel').on('hide.bs.collapse', function () {
        $(this).toggleClass("panel-primary");
        $('#firsElementMenu').removeClass("panel-primary")
        $(this).find('span').toggleClass('glyphicon-folder-open');

    });
});
//Підсвітка меню--------------------------------------------

//Відкриття вікна з фото------------------------------------
$(function () {
    $('.pop').on('click', function () {
        $('.imagepreview').attr('src', $(this).find('img').attr('src'));
        $('#imagemodal').modal('show');
    });
});
//Відкриття вікна з фото------------------------------------

//Фокус першого поля з стильом error------------------------
$(document).ready(function () {
    var input = $('.input-validation-error:first');

    if (input) {
        input.focus();
    }
});
//Фокус першого поля з стильом error------------------------

//Маска для усіх телефонів----------------------------------
jQuery(function ($) {
    $("#Phone").mask("+38(999)-999-99-99");
});
//Маска для усіх телефонів----------------------------------

//Кошик, виклик POST на перерахунку кількості---------------
function recalc(Id) {
    $("#CartLineForm" + Id).submit();
}
//Кошик, виклик POST на перерахунку кількості---------------

//Google Maps-----------------------------------------------
function initMap() {
    var uluru = { lat: 49.810101, lng: 23.972171 };
    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 16,
        //49.811128, 23.974105
        center: { lat: 49.811128, lng: 23.974105 }
    });
    var marker = new google.maps.Marker({
        position: uluru,
        map: map
    });
}
//Google Maps-----------------------------------------------
