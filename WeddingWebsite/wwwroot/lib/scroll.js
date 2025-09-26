const scrollThreshold = 30;

function onScroll(e) {
    if (document.body.scrollTop > scrollThreshold || document.documentElement.scrollTop > scrollThreshold) {
        document.querySelectorAll('.top-row').forEach(el => el.classList.add('scrolled'));
    } else {
        if (mobileNavbarOpen()) return; // Don't remove the class if the mobile nav is open
        document.querySelectorAll('.top-row').forEach(el => el.classList.remove('scrolled'));
    }
}

function delayScroll(e) {
    // TODO: This is to combat blazor refreshing the component server-side, sending an incorrect version back. Need to work through a better solution.
    setTimeout(onScroll, 250);
    setTimeout(onScroll, 500);
    setTimeout(onScroll, 1000);
}

function mobileNavbarOpen() {
    let burgerMenu = document.querySelector('.burger-menu');
    return burgerMenu && burgerMenu.classList.contains('change');
}

window.addEventListener('scroll', onScroll);
window.addEventListener('load', delayScroll);