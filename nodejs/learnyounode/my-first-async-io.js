const fs = require('fs');

const filename = process.argv[2];

// console.log('Inizio');      // #1

fs.readFile(filename, 'utf8', (error, data) => {
    // console.log(data);      // #3

    if (error)
        throw error;
        
    const lines = fs.readFileSync(process.argv[2], 'utf8')
        .split('\n').length - 1;
    console.log(lines);
});

// console.log('Fine');        // #2

