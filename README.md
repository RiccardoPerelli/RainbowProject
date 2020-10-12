# RainbowProject
Repository relativa al progetto di "Realtà Virtuale". Gruppo 02.

## Guida di accesso alla repository
Come prima cosa va installata una versione desktop di Github, se ne possono usare diverse, il funzionamento rimane lo stesso.
https://desktop.github.com/ questa è quella ufficiale di Github, se invece si volesse utilizzare anche un'interfaccia grafica più intuitiva
per la gestione dei branches si può utilizzare ad esempio SourceTree https://www.sourcetreeapp.com/.

In questa guida vengono illustrati i passi per collegare sourcetree al proprio account GitHub: http://modulesunraveled.com/very-basics-git/connecting-sourcetree-your-github-account

Una volta sistemato il proprio ambiente si può già iniziare a lavorare sul progetto collegato alla repository in modo da avere un version control più che adeguato. 

## Repository Management
Le repository si dividono in:
- Locale: una copia del progetto su spazio di archiviazione locale utilizzato per sviluppi sul proprio pc.
- Remota: l'effettiva repository contenuta in GitHub alla quale tutti siamo collegati che accoglierà le modifiche di tutti noi.

### Operazioni di base
le operazioni di base di git per la gestione di una repository sono le seguenti:
- Commit: permette di salvare modifiche sulla repository locale in modo permanente (pensarci bene prima di commitare delle modifiche).
- Push: trasferisce tutte le modifiche fatte sul proprio branch locale alla repository remota, rendendo quindi visibile a tutti le proprie modifiche.
- Fetch: permette di sincronizzarsi con la repository remota verificando di fatto se sono state fatte modifiche da altri utenti.
- Pull: scarica delle modifiche di altri utenti sulla repository locale, in pratica se A fa una modifica e B la necessita per proseguire B dovrà fare un pull 
prima di andare avanti.
- Merge: Unisce un branch con un altro, in questo caso possono presentarsi dei conflitti, nel caso accadesse andrà ispezionato con cura il conflitto e deciso come risolverlo.
- Branch: Permette di creare un nuovo branch partendo da un già esistente (solitamente partendo da master).

### Gestione degli sviluppi
Per quanto riguarda la gestione della repository l'idea è quella di gestire separatamente i propri sviluppi su branches separati, questo è vero sia per la parte grafica che per la parte di programmazione. 

### Sviluppi sulla parte di programmazione
Per quanto riguarda la parte di programmazione la gestione del codice dovrebbe essere non troppo complicata, possono insorgere dei problemi nel caso in cui si andasse a modificare la stessa porzione di codice, in quel caso il nostro manager delle repository ci segnalerà eventuali conflitti che potremo risolvere con una semplice ispezione del codice, quando e se capiterà conviene confrontarsi con la persona che ha effettuato le modifiche e valutare qualche porzione tenere.

### sviluppi sulla parte grafica
In questo caso le cose sono più delicate, gli asset grafici possono non essere riconosciuti facilmente ed è per questo che il metodo di lavoro ottimale è quello di evitare di fare modifiche allo stesso file grafico su due branches separati. In questo modo si eviteranno conflitti non facilmente risolvibili. Ad esempio se si vuole modificare la geografia di un livello conviene farlo in un solo branch e mergiare quando si concludono gli sviluppi. 
