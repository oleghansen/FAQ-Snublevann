var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var url1 = '/api/Faq/GetAll';
    var url2 = '/api/Faq/GetUbesvarte';
    var url3 = '/api/Category/GetAll';
    var url4 = '/api/Category/GetCategoryFaqs/';
    var url5 = '/api/Faq/Post/';
    
    function hentAlleFaqs() {
        $http.get(url1).
          success(function (alleFaqs) {
              onLoad();
              $scope.faqs = alleFaqs;
              $scope.laster = false;
              
              $scope.sendKnapp = true;
              $scope.visFaqKnapp = true;
              $scope.visInnsendteKnapp = true;
 
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };
    $scope.visSkjema = false;
    $scope.laster = true;
    
    hentAlleFaqs();


    
    function hentUbesvarte() {
        $http.get(url2).
          success(function (ubesvarte) {
              $scope.ubesvarte = ubesvarte,
              $scope.laster = false,
              $scope.visUbesvarte = true
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };
    $scope.laster = true;



    $scope.visSkjema = function () {
        $scope.navn = "";
        $scope.epost = "";
        $scope.kategori = "";
        $scope.sporsmal = "";
        // for å unngå at noen av feltene gir "falske" feilmeldinger 
        $scope.skjema.$setPristine();
        $scope.visSkjema = true;
        $scope.send = true; // dette er knappen for å registrere i form´en.
    };

    $scope.visFaqsFunction = function () {
        hideAll();
        $scope.visFaqs = true;
        $scope.visKategoriPanel = true;
    };

    $scope.visSkjemaFunction = function () {
        hideAll();
        hentAlleCategories();
        $scope.send = true;
        $scope.visSkjema = true;
    };

    $scope.visKategoriFunction = function (id) {
        hideAll();
        hentKategoriFaqs(id);
    };

    $scope.hentUbesvarte = function () {
        hideAll();
        hentUbesvarte();
    }

    $scope.sendFunction = function () {
        $scope.leggTilFaq();
    }

    $scope.leggTilFaq = function() {
        var nyfaq = {
        navn: $scope.navn,
        epost: $scope.epost,
        kategori: $scope.kategori,
        sporsmal: $scope.sporsmal
        };

        $http.post(url5, nyfaq).
          success(function (data) {
              hentAlleFaqs();
              onLoad();
              console.log("Lagre kunder OK!")
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    function hentAlleCategories() {
        $http.get(url3).
          success(function (alleCats) {
              $scope.cats = alleCats;

          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    function hentKategoriFaqs(id) {
        $http.get(url4 + id).
          success(function (katFaqs) {
              $scope.katfaqs = katFaqs;
              $scope.visKategoriFaqs = true;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    
   /* $scope.visRegistrerSkjema = function () {
        $scope.fornavn = "";
        $scope.etternavn = "";
        $scope.adresse = "";
        $scope.postnr = "";
        $scope.poststed = "";
        // for å unngå at noen av feltene gir "falske" feilmeldinger 
        $scope.skjema.$setPristine();
        $scope.regKnapp = false; // dette er knappen fra listen av kunder til reg-skjema
        $scope.visSkjema = true;
        $scope.visKunder = false;
        $scope.registrering = true; // dette er knappen for å registrere i form´en.
        $scope.oppdatering = false; // dette er knappen for å endre i form´en.
    };

    $scope.lagreKunde = function () {
        // lag et object for overføring til server via post
        console.log("Inne i registerKunde");
        var kunde = {
            fornavn: $scope.fornavn,
            etternavn: $scope.etternavn,
            adresse: $scope.adresse,
            postnr: $scope.postnr,
            poststed: $scope.poststed
        };

        $http.post(url, kunde).
          success(function (data) {
              // returner ingen ting, alternativt kan alle kundene returneres, men det er ikke helt "REST"
              hentAlleKunder(); // må gjøre dette inne i post ellers vil hentAlleKunder kjøre før den er ferdig
              $scope.visKunder = true;
              $scope.visSkjema = false;
              $scope.regKnapp = true;
              console.log("Lagre kunder OK!")
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    $scope.sletteKunde = function (id) {

        $http.delete(url + id).
        success(function (data) {
            // returner ingen ting
            hentAlleKunder();
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    $scope.endreKunde = function (id) {
        // hent en kunde og vis denne i skjema

        // ta vekk registreringsknapp 
        $scope.registrering = false;
        $scope.oppdatering = true;
        $scope.postStedReadOnly = true;
        // kan ta vekk kundelistingen med setningen under, men da må også i oppdaterKunde vise visKunder=true
        $scope.visKunder = false;
        // hent kunde
        $http.get(url + id).
            success(function (kunde) {
                // får den oppdaterte kunden tilbake
                $scope.id = kunde.id;
                $scope.fornavn = kunde.fornavn;
                $scope.etternavn = kunde.etternavn;
                $scope.adresse = kunde.adresse;
                $scope.postnr = kunde.postnr;
                $scope.poststed = kunde.poststed;
                // vis skjema med kundedata
                $scope.visSkjema = true;
            }).
            error(function (data, status) {
                console.log(status + data);
            });
    };

    $scope.oppdaterKunde = function () {
        // flytt de endrede dataene fra endre-skjema og oppdater server
        
        // lag kunde
        var kunde = {
            fornavn: $scope.fornavn,
            etternavn: $scope.etternavn,
            adresse: $scope.adresse,
            postnr: $scope.postnr,
            poststed: $scope.poststed
        };

        $scope.visSkjema = false;
        $scope.visKunder = true;
       
        $http.put(url + $scope.id, kunde).
            success(function (data) {
                // returner ingen ting
                hentAlleKunder();
            }).
            error(function (data, status) {
                console.log(status + data);
            });
    }; */

    function onLoad() {
        $scope.visFaqs = true;
        $scope.visSkjema = false;
        $scope.visUbesvarte = false;
    };

    function hideAll() {
        $scope.visKategoriPanel = false;
        $scope.visKategoriFaqs = false;
        $scope.visFaqs = false;
        $scope.visSkjema = false;
        $scope.visUbesvarte = false;
    };
});