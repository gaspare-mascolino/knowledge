String.prototype.toJadenCase = function () {
  console.log(this)
    return this.split(" ").map( a => a[0].toUpperCase() + a.slice(1)).join(" ");
  };

var str = "How can mirrors be real if our eyes aren't real";
console.log(str.toJadenCase());