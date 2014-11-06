var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var url = '/api/Faq/';


    function hentAlleFaqs() {
        $http.get(url).
          success(function (alleFaqs) {
              $scope.faqs = alleFaqs;
              $scope.laster = false;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };
    $scope.visFaqs = true;
    //$scope.regKnapp = true;
    $scope.laster = true;
    hentAlleFaqs();

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

});