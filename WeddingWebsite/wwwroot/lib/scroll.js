window.addEventListener('scroll',function(e) {
    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
        document.querySelector('.top-row').classList.add('scrolled')
    } else {
        document.querySelector('.top-row').classList.remove('scrolled')
    }
});