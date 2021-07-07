const http = require('http');

var text1 = "";
var text2 = "";
var text3= "";

http.get(process.argv[2], (res) => {
    res.setEncoding('utf8');
    res.on('data', (data) => text1+= data);
    res.on('end', () => {
        console.log(text1);
        http.get(process.argv[3], (res) => {
            res.setEncoding('utf8');
            res.on('data', (data) => text2+= data);
            res.on('end', () => {
                console.log(text2);
                http.get(process.argv[4], (res) => {
                    res.setEncoding('utf8');
                    res.on('data', (data) => text3+= data);
                    res.on('end', () => {
                        console.log(text3);
                    });
                })
            });
        })
    });
})

/*  const http = require('http')
    const bl = require('bl')
    const results = []
    let count = 0
    
    function printResults () {
      for (let i = 0; i < 3; i++) {
        console.log(results[i])
      }
    }
    
    function httpGet (index) {
      http.get(process.argv[2 + index], function (response) {
        response.pipe(bl(function (err, data) {
          if (err) {
            return console.error(err)
          }
    
          results[index] = data.toString()
          count++
    
          if (count === 3) {
            printResults()
          }
        }))
      })
    }
    
    for (let i = 0; i < 3; i++) {
      httpGet(i)
    }
*/