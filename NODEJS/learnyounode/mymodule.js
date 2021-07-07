const fs = require('fs');
const path = require('path');

const myModule = (dir, ext, cb) => {
    fs.readdir(dir, (err, list) => {
        return err ? cb(err) : cb(null, list.filter(file => 
        path.extname(file) === `.${ext}`));
    });
};

module.exports = myModule;