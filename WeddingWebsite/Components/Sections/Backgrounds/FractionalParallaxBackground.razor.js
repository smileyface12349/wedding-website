

function onScroll(e) {
    document.querySelectorAll('#background').forEach(
        element => element.style.backgroundPosition = "top " + getOffset() + "px left 0px"
    );
}

function getOffset() {
    let percent = parseFloat(document.getElementById("background-scroll-amount").innerHTML);
    let scrollDistance = document.documentElement.scrollTop;
    return scrollDistance * percent;
}

export function onLoad() {
    onScroll();
}

export function onUpdate() {
    onScroll();
}

window.addEventListener('scroll', onScroll);