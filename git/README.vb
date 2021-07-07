TERMINAL

    - git config --global user.name "Gaspare Mascolino"
    - git config --global user.email EMAIL
    - git config --global --list
    - rm ~/.gitconfig  -> per resettare le credenziali

    - add -> aggiunge un elemento al commit (add * per aggiungere tutto)
    - branch -> mostra su quale branch ti trovi (-D per cancellarlo)
    - checkout -b -> crea un branch e ti sposti su quel branch o se esiste (senza -b) sposti direttamente
    - commit -m "Some meaningful commit comment"
    - clone
    - fetch ->
    - push -> pusha l'ultimo commmit lanciato
    - pull -> si tira gli aggiornamenti del branch
    - pull origin develop -> per pullare develop da remoto
    - pull origin release -> per pullare release da remoto
    - reset -> HEAD <file> per resettare un file modificato
    - stash -> salvare le modifiche da un'altra parte temporaneamente
    - stash list
    - stash apply -> riporta le modifiche dell'ultimo stash sul branch corrente
    - status -> stato rispetto all'origin branch corrente

    Go back to a previous commit

        git reset --hard code
        git push --force
    