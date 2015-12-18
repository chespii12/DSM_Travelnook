$('ul.nav li.dropdown').hover(function() {
  $(this).find('.dropdown-menu').stop(true, true).delay(50).fadeIn(200);
}, function() {
  $(this).find('.dropdown-menu').stop(true, true).delay(50).fadeOut(200);
});