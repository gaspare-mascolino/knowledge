// console.log(process.argv); 
/*
const total = process.argv
    .map(val => +val)
    .filter(val => Number.isInteger(val))
    .reduce((sum, val) => sum + val);

console.log(total);
*/

var total = 0;

for (let i = 2; i < process.argv.length; i += 1){
    total += Number(process.argv[i]);
}


console.log(total);
