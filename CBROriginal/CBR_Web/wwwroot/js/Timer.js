﻿var time_in_minutes = 30;
var current_time = Date.parse(new Date());
var deadline = new Date(current_time + time_in_minutes * 60 * 1000);


function time_remaining(endtime) {
    var t = Date.parse(endtime) - Date.parse(new Date());
    var seconds = Math.floor((t / 1000) % 60);
    var minutes = Math.floor((t / 1000 / 60) % 60);
    var hours = Math.floor((t / (1000 * 60 * 60)) % 24);
    var days = Math.floor(t / (1000 * 60 * 60 * 24));
    return { 'total': t, 'days': days, 'hours': hours, 'minutes': minutes, 'seconds': seconds };
}
function run_clock(id, endtime) {
    var clock = document.getElementById(id);
    function update_clock() {
        var t = time_remaining(endtime);
        clock.innerHTML = 'Minutos restantes: ' + t.minutes + '<br>Segundos restantes: ' + t.seconds;
        if (t.total <= 0) { clearInterval(timeinterval); }
    }
    update_clock(); 
    var timeinterval = setInterval(update_clock, 1000);
}
run_clock('clockdiv', deadline);