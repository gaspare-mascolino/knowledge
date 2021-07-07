const http = require('http');
const url = process.argv[2];

http.get(url, function callback (response) { 
    response.setEncoding('utf8');
    response.on('data', console.log)
    response.on('error', console.error)
        
    
}).on('error', console.error);