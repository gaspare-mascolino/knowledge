function calcolaTabellina() {

    const val = document.getElementById('input').value;
    let tab = '';

    for(let i = 1; i < 11; i++) {
        tab += `${val}x${i} = ${val * i}<br>`;
    }

    document.getElementById('visualizzaTabellina').innerHTML = tab;
}