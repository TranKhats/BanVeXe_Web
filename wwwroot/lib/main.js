$(document).ready(function () {
    $('.tablinks').click(this, function () {
        var i, tabcontent, tablinks;
        tabcontent = $(".tabcontent");
        for (i = 0; i < tabcontent.length; i++) {
            tabcontent[i].style.display = "none";
        }
        tablinks = $(".tablinks");
        for (i = 0; i < tablinks.length; i++) {
            tablinks[i].className = tablinks[i].className.replace(" active", "");
        }
        $('#' + $(this).attr('data-val')).css({ 'display': 'block' });
        $(this).addClass(' active');
    });
});