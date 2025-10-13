// When parent in view, trigger all child animations
const observer = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        console.log(entry);
        Array.from(entry.target.getElementsByClassName('animate-on-scroll-child')).forEach(
            element => {
                if (entry.isIntersecting || entry.boundingClientRect.top < 0) {
                    playAnimation(element);
                } else {
                    stopAnimation(element);
                }
            }
        )
    });
});

const simpleObserver = new IntersectionObserver(entries => {
    entries.forEach(entry => {
        let element = entry.target;
        if (entry.isIntersecting || entry.boundingClientRect.top < 0) {
            playAnimation(element);
        } else {
            stopAnimation(element);
        }
    })
})

function playAnimation(element) {
    element.classList.forEach(className => {
        if (className.startsWith('animation-')) {
            let animationClass = className.substring(10);
            element.classList.add(animationClass)
        }
    })
    element.classList.remove('off-screen');
}

function stopAnimation(element) {
    element.classList.forEach(className => {
        if (className.startsWith('animation-')) {
            let animationClass = className.substring(10);
            element.classList.remove(animationClass)
        }
    })
    element.classList.add('off-screen');
}

window.onload = function () {
    Array.from(document.getElementsByClassName('animate-on-scroll-parent')).forEach(
        function (element, index) {
            observer.observe(element);
        }
    )
    Array.from(document.getElementsByClassName('animate-on-scroll')).forEach(
        function (element, index) {
            simpleObserver.observe(element);
        }
    )
}