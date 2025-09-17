

function updateCountdown() {
    let currentDate = new Date();
    let countdownTo = new Date(document.getElementById('countdown-date').innerText);

    // repeatedly add months onto current time until overshooting the target
    let months = 0;
    while (addMonth(currentDate) < countdownTo) {
        currentDate = addMonth(currentDate);
        months++;
    }
    
    // the rest is simpler
    let weeks = Math.floor((countdownTo - currentDate) / (1000 * 86400 * 7));
    currentDate.setDate(currentDate.getDate() + weeks * 7);
    let days = Math.floor((countdownTo - currentDate) / (1000 * 86400));
    currentDate.setDate(currentDate.getDate() + days);
    let hours = Math.floor((countdownTo - currentDate) / (1000 * 3600));
    currentDate.setHours(currentDate.getHours() + hours);
    let minutes = Math.floor((countdownTo - currentDate) / (1000 * 60));
    currentDate.setMinutes(currentDate.getMinutes() + minutes);
    let seconds = Math.floor((countdownTo - currentDate) / 1000);

    document.getElementById('value-Month').innerText = months;
    document.getElementById('value-Week').innerText = weeks;
    document.getElementById('value-Day').innerText = days;
    document.getElementById('value-Hour').innerText = hours;
    document.getElementById('value-Minute').innerText = minutes;
    document.getElementById('value-Second').innerText = seconds;

}

function addMonth(date) {
    let newDate = new Date(date);
    if (date.getMonth() === 11) {
        newDate.setFullYear(date.getFullYear() + 1);
        newDate.setMonth(0);
        return newDate;
    } else {
        newDate.setMonth(newDate.getMonth() + 1);
        return newDate;
    }
}

let intervalId = 0;

export function onLoad() {
    updateCountdown();
    intervalId = setInterval(updateCountdown, 1000);
}

export function onUpdate() {
    updateCountdown();
}

export function onDispose() {
    console.log("Countdown disposed");
    clearInterval(intervalId);
}