function visualizzaStringa() {
    const stringa = document.getElementById('inputStringa').value;
    document.getElementById('mostraStringa').innerHTML = stringa;
}

function invertiStringa() {
    var newstr = "";
    var stringa = new String(document.getElementById('inputStringa').value);
    // stringa.split(''); -> Trasforma la stringa in un array
    for(var i = stringa.length - 1; i >= 0; i--) {
        newstr += stringa[i];
    }
    document.getElementById('mostraStringa').innerHTML = newstr;

}