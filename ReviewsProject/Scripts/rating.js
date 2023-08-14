$(function () {
    $('a[class^="star_0"]').click(function () {
        //Click on rating stars
        if ($(this).is('.hover')) {
            $(this).parent().find('a[class^="star_0"]').removeClass('hover');
            $(this).parent().find('input[type="hidden"]').val(0);
        } else {
            $(this).parent().find('a[class^="star_0"]').removeClass('hover');
            var cl = $(this).attr('class');
            var v = cl.match(/[1-5]+/)[0];
            if (v) {
                $(this).parent().find('input[type="hidden"]').val(v);
                $(this).addClass('hover');
            }
        }
        //Calculate overall rating
        var sum = 0;
        $('.rating input[type="hidden"]').each(function (ind, el) {
            var value = parseInt($(this).val());
            if (value)
                sum += value;
        });
        $('#avgRating').text((sum / 5.0).toFixed(1));
        $('input[name="OverallRating"]').val(sum / 5.0);
    });
});