function onScroll(e) {
    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
        document.querySelector('.top-row').classList.add('scrolled')
    } else {
        document.querySelector('.top-row').classList.remove('scrolled')
    }
}

function delayScroll(e) {
    // TODO: This is to combat blazor refreshing the component server-side, sending an incorrect version back. Need to work through a better solution.
    setTimeout(onScroll, 250);
}

window.addEventListener('scroll', onScroll);
window.addEventListener('load', delayScroll);