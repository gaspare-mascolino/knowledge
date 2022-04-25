let y;
let timer;

let songs = []

let button = false;

const diesisChords = ['C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#', 'A', 'A#', 'B']
const bemolleChords = ['C', 'Db', 'D', 'Eb', 'E', 'F', 'Gb', 'G', 'Ab', 'A', 'Bb', 'B']

const tools = document.getElementById('tools');

const playButton = document.getElementById('play');
const pauseButton = document.getElementById('pause');

const range = document.getElementById('range');
const rangeValue = document.getElementById('rangeValue');

const transpose = document.getElementById('transpose');
const transposeValue = document.getElementById('transposeValue');

const shuffleButton = document.getElementById('shuffle');

function start(start) {

    document.addEventListener('scroll', function (e) {
        let scrollPosition = window.scrollY;

        window.requestAnimationFrame(function () {
            y = scrollPosition
        })
    });

    if (start) {
        playButton.style.visibility = "hidden";
        pauseButton.style.visibility = "visible";
        pauseButton.style.visibility = "visible";
        range.style.visibility = "hidden";
        rangeValue.style.visibility = "hidden";
        transpose.style.visibility = "hidden";
        shuffleButton.style.visibility = "hidden";
        tools.style.backgroundColor="transparent";
        tools.style.boxShadow="0 0 0 white"
        
        timer = setInterval(play, 50);
    } else {
        playButton.style.visibility = "visible";
        pauseButton.style.visibility = "hidden";
        range.style.visibility = "visible";
        rangeValue.style.visibility = "visible";
        transpose.style.visibility = "visible";
        shuffleButton.style.visibility = "visible";
        tools.style.backgroundColor="white";
        tools.style.boxShadow="0 0 0.2rem rgb(0 0 0 / 10%), 0 0.2rem 0.4rem rgb(0 0 0 / 20%)"

        clearInterval(timer);
    }
}

function play() {
    window.scroll(-100, y);
    y += 0.05 * rangeValue.value;
}

function updateRangeInput(val) {
    rangeValue.value = val;
}

function changeKey(value) {

    transposeValue.value = String(Number(transposeValue.value) + value);

    let songChords = document.getElementsByTagName('chord')
    for (let i = 0; i < songChords.length; i++) {

        let chord = songChords[i].innerHTML;

        if (diesisChords.indexOf(chord) === 0 && value < 0) {
            songChords[i].innerHTML = diesisChords[diesisChords.length - 1]
        } else if (diesisChords.indexOf(chord) === diesisChords.length - value && value > 0) {
            songChords[i].innerHTML = diesisChords[0]
        } else if (chord.match('#')) {
            songChords[i].innerHTML = diesisChords[diesisChords.indexOf(chord) + value]
        } else if (chord.match('b')) {
            songChords[i].innerHTML = bemolleChords[bemolleChords.indexOf(chord) + value]
        } else {
            songChords[i].innerHTML = diesisChords[diesisChords.indexOf(chord) + value]
        }
    }
}

window.addEventListener('keydown', function(e) {
    if(e.key === " " && e.target === document.body) {
        e.preventDefault();
    }
});


document.body.onkeyup = function(e) {
    if (e.key === " " ||
        e.code === "Space"
    ) {
        button = !button
        start(button)
    }
}

function shuffleSong() {
    let songNumber = Math.floor(Math.random() * songs.length);
    window.location.href = "../"+songs[songNumber];
}

