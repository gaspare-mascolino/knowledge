const fs = require('fs');
const path = require('path');

const dirpath = process.argv[2];
const ext = `.${process.argv[3]}`;

fs.readdir(dirpath, (err, files) => {
 /*   
    files.forEach((file) => {
        if(path.extname(file) === ext) {
            console.log(file);
        }
    });
*/
    
const filtered = files.filter((file) => path.extname(file) === ext);
filtered.forEach((file) => console.log(file));
});