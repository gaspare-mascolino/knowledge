const path = require('path');
const fs = require('fs');

fs.readdir(
    path.resolve(__dirname, 'lyrics'),
    (err, files) => {
        if (err) throw err;

        for (let file of files) {
            fs.readFile( path.resolve(__dirname, 'lyrics/'+file), 'utf8' , (err, data) => {
                if (err) {
                    console.error(err)
                    return
                }
                const list = data.split("\n");

                list[0] = '# '+list[0]                   // Title
                list[1] = '!!! Info'                     // Info box
                list[2] = '    '+'**'+list[2]+'**'       // Capo

                list[3] = '<pre>\n'
                list.push('</pre>')

                for (let i = 4; i < list.length-1; i++) {
                    if(i%2===0) {
                        list[i] = '<b>'+list[i]+'</b>'
                    }
                }

                console.log(list)
                fs.writeFile(path.resolve(__dirname, file+'.md'), list.join('\n'), function(err) {
                    if(err) {
                        return console.log(err);
                    }
                    console.log("The file was saved!");
                });
            })
        }
    }
);