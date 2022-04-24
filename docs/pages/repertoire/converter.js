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

                for (let i = 4; i < list.length-1; i++) {
                    if(i%2===0) {
                        list[i] = '<b>'+list[i]+'</b>'
                    }
                }

                list.push('</pre>')
                list.push('\n')
                list.push('<button id="play" class="md-button-play" onclick="start(true)">![](../assets/images/site/play.png){: style="height:50px;width:50px"}</button>')
                list.push('<button id="pause" class="md-button-pause" onclick="start(false)">![](../assets/images/site/pause.png){: style="height:50px;width:50px"}</button>')

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