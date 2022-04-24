let y = 100;
let timer;

const playButton = document.getElementById('play');
const pauseButton = document.getElementById('pause');

function start(start) {
    if(start) {
        playButton.style.visibility = "hidden"
        pauseButton.style.visibility = "visible"
        timer=setInterval(play, 50);
    }
    else {
        playButton.style.visibility = "visible"
        pauseButton.style.visibility = "hidden"
        clearInterval(timer);
    }
}

function play() {
    window.scroll(0, y);
    y += 0.5;
}