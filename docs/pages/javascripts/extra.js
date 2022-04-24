let y;
let timer;

const diesisChords = ['C', 'C#', 'D', 'D#', 'E', 'F', 'F#', 'G', 'G#', 'A', 'A#', 'B']
const bemolleChords = ['C', 'Db', 'D', 'Eb', 'E', 'F', 'Gb', 'G', 'Ab', 'A', 'Bb', 'B']

const playButton = document.getElementById('play');
const pauseButton = document.getElementById('pause');

const range = document.getElementById('range');
const rangeValue = document.getElementById('rangeValue');

const transpose = document.getElementById('transpose');
const transposeValue = document.getElementById('transposeValue');

function start(start) {
    if (start) {
        playButton.style.visibility = "hidden";
        pauseButton.style.visibility = "visible";
        pauseButton.style.visibility = "visible";
        range.style.visibility = "hidden";
        rangeValue.style.visibility = "hidden";
        transpose.style.visibility = "hidden";

        y = 0;
        timer = setInterval(play, 50);
    } else {
        playButton.style.visibility = "visible";
        pauseButton.style.visibility = "hidden";
        range.style.visibility = "visible";
        rangeValue.style.visibility = "visible";
        transpose.style.visibility = "visible";

        clearInterval(timer);
    }
}

function play() {
    window.scroll(-100, y);
    y += 0.5 * rangeValue.value;
}

function updateRangeInput(val) {
    rangeValue.value = val;
}

function changeKey(value) {

    transposeValue.value = String(Number(transposeValue.value)+value);

    let songChords = document.getElementsByTagName('chord')
    for (let i = 0; i < songChords.length; i++) {

        let chord = songChords[i].innerHTML;

        if (diesisChords.indexOf(chord) === 0 && value < 0) {
            songChords[i].innerHTML = diesisChords[diesisChords.length - 1]
        } else if(diesisChords.indexOf(chord) === diesisChords.length - value && value > 0) {
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