# RainbowProject
Repository relativa al progetto di "Realtà Virtuale". Gruppo 02.

## Guida di accesso alla repository
Come prima cosa va installata una versione desktop di Github, se ne possono usare diverse, il funzionamento rimane lo stesso.
https://desktop.github.com/ questa è quella ufficiale di Github, se invece si volesse utilizzare anche un'interfaccia grafica più intuitiva
per la gestione dei branches si può utilizzare ad esempio SourceTree https://www.sourcetreeapp.com/.

In questa guida vengono illustrati i passi per collegare sourcetree al proprio account GitHub: http://modulesunraveled.com/very-basics-git/connecting-sourcetree-your-github-account

Una volta sistemato il proprio ambiente si può già iniziare a lavorare sul progetto collegato alla repository in modo da avere un version control più che adeguato. 

## Repository Management
Per quanto riguarda la gestione della repository l'idea è quella di gestire separatamente i propri sviluppi su branches separati, questo è vero sia per la parte grafica che per la parte di programmazione. 

### Sviluppi sulla parte di programmazione
Per quanto riguarda la parte di programmazione la gestione del codice dovrebbe essere non troppo complicata, possono insorgere dei problemi nel caso in cui si andasse a modificare la stessa porzione di codice, in quel caso il nostro manager delle repository ci segnalerà eventuali conflitti che potremo risolvere con una semplice ispezione del codice, quando e se capiterà conviene confrontarsi con la persona che ha effettuato le modifiche e valutare qualche porzione tenere.

### sviluppi sulla parte grafica
In questo caso le cose sono più delicate, gli asset grafici possono non essere riconosciuti facilmente ed è per questo che il metodo di lavoro ottimale è quello di evitare di fare modifiche allo stesso file grafico su due branches separati. In questo modo si eviteranno conflitti non facilmente risolvibili. Ad esempio se si vuole modificare la geografia di un livello conviene farlo in un solo branch e mergiare quando si concludono gli sviluppi. 
