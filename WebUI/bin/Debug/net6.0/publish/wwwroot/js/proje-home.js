

// SMOOTH SCROLL
$(window).scroll(function(){
    if($(document).scrollTop() > 1000)
    {
        $("#backtotop").css('display', 'block');
    } else
    {
        $("#backtotop").css('display', 'none');
    }
})