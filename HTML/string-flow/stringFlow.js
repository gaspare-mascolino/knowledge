let int;
function scorriStringa(azione) {

    if(azione === 'scorri') {
        let val = document.getElementById('inputStringa').value;
        int = setInterval(() => {
            document.getElementById('stringaScorrevole').innerHTML = val;
            const primoCar = val[0];
            val = val.substring(1) + primoCar
        }, 150)
    } else {
        clearInterval(int);
    }
}