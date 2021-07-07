/*function HighAndLow(numbers) {
    let array = numbers.split(" ").sort(compare);
    return `${array[array.length - 1]} ${array[0]}`;
   
}

function compare(a, b) {
    return a-b;
}
*/

function HighAndLow(numbers) {
   
    numbers = numbers.split(' ');
    return `${Math.max(...numbers)} ${Math.min(...numbers)}`;
}

console.log(HighAndLow("4 5 29 54 4 0 -214 542 -64 1 -3 6 -6"))
