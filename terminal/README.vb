COMANDI 
    ls -> mostra il contenuto della directory (-l -la type)
    cd -> si sposta nella directory
    find -> cerca i file per un determinato nome (find . -name <name> -print0 | xargs -0 git rm --ignore-unmatch)
    vi -> scrive in un file 
EXPORT
    
    su mac .zshrc o .bash_profile nella home folder

    • conda
        export PATH="/usr/local/anaconda3/bin:$PATH"

    • nvm
        export NVM_DIR=~/.nvm
        source $(brew --prefix nvm)/nvm.sh
    
    • sdkman
        export SDKMAN_DIR="/Users/c333797/.sdkman"
        [[ -s "/Users/c333797/.sdkman/bin/sdkman-init.sh" ]] && source "/Users/c333797/.sdkman/bin/sdkman-init.sh"
    
