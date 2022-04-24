const path = require('path');
const fs = require('fs');

let list = []
const CHORD_REGEX = new RegExp('[CDEFGAB](?:#|b|)', 'g')

fs.readdir(
    path.resolve(__dirname, 'lyrics'),
    (err, files) => {
        if (err) throw err;

        for (let file of files) {
            fs.readFile(path.resolve(__dirname, 'lyrics/' + file), 'utf8', (err, data) => {
                if (err) {
                    console.error(err)
                    return
                }
                list = data.split("\n");

                list[0] = '# ' + list[0]                   // Title
                list[1] = '!!! Info'                     // Info box
                list[2] = '    ' + '**' + list[2] + '**'       // Capo

                list[3] = '<pre>\n'

                for (let i = 4; i < list.length - 1; i++) {

                    if (i % 2 === 0) {
                        let matches = list[i].match(CHORD_REGEX)

                        if (matches) {
                            matches.forEach(match => {
                                list[i] = list[i].replace(match, '<chord>' + match + '</chord>')
                            })
                        }
                        list[i] = '<b>' + list[i] + '</b>'
                    }
                }

                list.push('</pre>')
                list.push('\n')
                list.push('<button id="play" class="md-button-play" onclick="start(true)"></button>')
                list.push('<button id="pause" class="md-button-pause" onclick="start(false)"></button>')

                list.push('<input type="range" id="range" class="md-range" value="10" min="1" max="10" onchange="updateRangeInput(this.value);"/>')
                list.push('<input type="text" id="rangeValue" class="md-range-value" value="10" readonly/>')

                list.push('<div id="transpose">')
                list.push('    <b>Transpose:</b>')
                list.push('    <input type="text" id="transposeValue" value="0" readonly/>')
                list.push('    <button id="keyUp" class="md-buttonKey" onclick="changeKey(1)">+1</button>')
                list.push('    <button id="keyDown" class="md-buttonKey" onclick="changeKey(-1)">-1</button>')
                list.push('    <button id="shuffle" onclick="shuffleSong()"></button>')
                list.push('</div>')

                fs.writeFile(path.resolve(__dirname, file + '.md'), list.join('\n'), function (err) {
                    if (err) {
                        return console.log(err);
                    }
                    console.log("The file was saved!");
                });

                fs.appendFile( '../../music.md', "<a href=/knowledge/repertoire/" + file +"/>" + data.split("\n")[0] + "\n\n", function (err) {
                        if (err) {
                            return console.log(err);
                        } else {
                            console.log("The music.md was updated!");
                            console.log("<a id=songs href=/repertoire/" + file + ".md >" + data.split("\n")[0] + "</a>")
                        }
                    }
                )
            })
        }
    })
