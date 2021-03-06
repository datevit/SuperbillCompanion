
# Inizia a sviluppare con SuperBill

[SuperBill](https://www.superbill.it/) è un software di gestione della fatturazione per le piccole e medie imprese prodotto da [Datev Koinos](https://www.datevkoinos.it/). SuperBill offre un interfaccia API per integrare software di terze parti e un sistema di autenticazione e autorizzazione nello standard OpenID Connect.

## SupebillCompanion

SuperbillCompanion é una applicazione ASP.net Core di esempio che ti permette di prendere confidenza con le API di SuperBill. Per semplicità SuperbillCompanion non utilizza un database per memorizzare alcune informazioni necessarie per individure il tenant dell'utente e l'Authorization-Key per il controllo della licenza, pertanto nel caso in cui si voglia simulare l'accesso a diversi contesti, é necessario rimuovere manualmente i cookie API_KEY e TENANT_KEY.


### Prerequisiti
Per utilizzare SuperbillCompanion é necessario aver installato l'SDK di ASP.net Core 3.1 e aver registrato e configurato una applicazione di integrazione sul sito sviluppatori Datev Koinos (maggiori informazioni [qui](https://developer.datev.it/)).
Nella configurazione della applicazione di integrazione riportare l'indirizzo https://localhost:5001/signin-oidc (5001 è la porta di default, utilizzare la propria se diversa) nell'elenco degli **URI di reindirizzamento** e selezionare le autorizzazioni **profile**, **openid**, **config**, **integrasdi** e **efat**.

### Setup del progetto

 1. Eseguire il clone di questo repository
```bash
git clone https://github.com/datevit/SuperbillCompanion.git
``` 

 2. Installare le dipendenze del progetto
```bash
dotnet restore
``` 

 3. Sostituire in ConfigureServices della classe Startup <YOUR_CLIENT_ID> e <YOUR_CLIENT_SECRET> il "Client ID" e il "Client secret" tua applicazione di integrazione.
 4. Eseguire l'applicazione
 ```bash
dotnet run
``` 

