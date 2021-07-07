n = 1234;

console.log(n.toString(2));
console.log(n.toString(2).split('0'));
console.log(n.toString(2).split('0').join(''))

n = n.toString(2).split('0').join('').length;
console.log(n);