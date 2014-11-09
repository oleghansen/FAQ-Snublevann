var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var url1 = '/api/Faq/GetAll';
    var url2 = '/api/Faq/GetUbesvarte';
    var url3 = '/api/Category/GetAll';
    var url4 = '/api/Faq/GetCategoryFaqs/';
    var url5 = '/api/Faq/PostFaq/';
    var url6 = '/api/Faq/GetFaq/';
    


    $scope.laster = true;
    hentAlleFaqs();


    function hentAlleFaqs() {
        $http.get(url1).
          success(function (alleFaqs) {
              $scope.faqs = alleFaqs;
              hentAlleCategories();
              $scope.laster = false;
              onLoad();
              $scope.detaljer = true;

              $scope.sendKnapp = true;
              $scope.visFaqKnapp = true;
              $scope.visInnsendteKnapp = true;

          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

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
        $scope.send = true; // dette er knappen for å registrere i form´en.
    };

    $scope.visFaqsFunction = function () {
        hideAll();
        $scope.visKategoriPanel = true;
        $scope.visFaqs = true;
        $scope.detaljer = true;
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
        $scope.visKategoriPanel = true;
    };

    $scope.visDetaljerFunction = function (id) {
        hideAll();
        hentFaq(id);
        $scope.visDetaljer = true;
    };

    $scope.hentUbesvarte = function () {
        hideAll();
        hentUbesvarte();
    }

    $scope.leggTilFaq = function () {
        console.log("Inne i leggTiLFaq");
        var nyfaq = {
        name: $scope.navn,
        epost: $scope.epost,
        question: $scope.sporsmal
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

        $http({
            url: url4,
            params: {id: id }
        }).success(function (katFaqs) {
              $scope.katfaqs = katFaqs;
              $scope.visKategoriFaqs= true;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    function hentFaq(id) {

        $http({url: url6,params: { id: id }}).success(function (faq) {
            $scope.faqdetaljer = faq;
            $scope.visDetaljer = true;
            $scope.visKategoriPanel = true;
            console.log($scope.faqdetaljer);
        }).
          error(function (data, status) {
              console.log(status + data);
          });
    };


    function onLoad() {
        $scope.visFaqs = true;
        $scope.visSkjema = false;
        $scope.visUbesvarte = false;
    };

    function hideAll() {
        $visDetaljer = false;
        $scope.visKategoriPanel = false;
        $scope.visKategoriFaqs = false;
        $scope.visFaqs = false;
        $scope.visSkjema = false;
        $scope.visUbesvarte = false;
    };
});