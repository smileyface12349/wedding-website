

function onScroll(e) {
    console.log("Scrolled, new offset: " + getOffset());
    document.querySelector('#background').style="background-position: top " + getOffset() + "px left 0px";
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