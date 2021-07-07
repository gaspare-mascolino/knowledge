const http = require('http');
const url = process.argv[2];
var text = "";

http.get(url, (res) => {
    res.setEncoding('utf8');
    res.on('data', (data) => text+= data);
    res.on('end', () => {
        console.log(text.length);
        console.log(text);
    });
})

/*
   'use strict'
    const http = require('http')
    const bl = require('bl')
    
    http.get(process.argv[2], function (response) {
      response.pipe(bl(function (err, data) {
        if (err) {
          return console.error(err)
        }
        data = data.toString()
        console.log(data.length)
        console.log(data)
      }))
    })
*/