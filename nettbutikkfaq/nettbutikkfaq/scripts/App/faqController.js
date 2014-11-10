var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var url1 = '/api/Faq/GetAll';
    var url2 = '/api/Faq/GetUbesvarte';
    var url3 = '/api/Category/GetAll';
    var url4 = '/api/Faq/GetCategoryFaqs/';
    var url5 = '/api/Faq/PostFaq/';
    var url6 = '/api/Faq/GetFaq/';
    
    hideAll();
    $scope.laster = true;
    $scope.visSkjema = false;
    hentAlleFaqs();


    function hentAlleFaqs() {
        $http.get(url1).
          success(function (alleFaqs) {
              $scope.faqs = alleFaqs;
              hentAlleCategories();
              $scope.laster = false;
              $scope.headerFaq = true;
              $scope.visFaqsFunction();
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
              $scope.headerUbesvarte = true;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };




    $scope.visSkjema = function () {
        hideAll();
        $scope.headerSpor = true;
        $scope.visSporreSkjema = true;
        $scope.name = "";
        $scope.epost = "";
        $scope.category = "";
        $scope.question = "";
        // for å unngå at noen av feltene gir "falske" feilmeldinger 
        $scope.skjema.$setPristine();
        $scope.send = true; // dette er knappen for å registrere i form´en.
    };

    $scope.visFaqsFunction = function () {
        hideAll();
        $scope.visKategoriPanel = true;
        $scope.headerFaq = true;
        $scope.visFaqs = true;
        $scope.detaljer = true;
    };

    $scope.visSkjemaFunction = function () {
        hideAll();
        hentAlleCategories();
        $scope.send = true;
        $scope.visSkjema();
        $scope.headerSpor = true;
    };

    $scope.visKategoriFunction = function (id) {
        hideAll();
        hentKategoriFaqs(id);
        $scope.visKategoriPanel = true;
    };

    $scope.visDetaljerFunction = function (id) {
        hideAll();
        hentFaq(id);
    };

    $scope.hentUbesvarte = function () {
        hideAll();
        hentUbesvarte();
    }

    $scope.leggTilFaq = function () {
        console.log("Inne i leggTiLFaq");
        var nyfaq = {
        name: $scope.name,
        epost: $scope.epost,
        title: $scope.title,
        question: $scope.question,
        categoryid: $scope.category
        };

        $http.post(url5, nyfaq).
          success(function (data) {
              hideAll();
              $scope.headerTakk = true;
              $scope.visTakk = true;
             
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
              $scope.visKategoriFaqs = true;
              $scope.headerFaq = true;
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
        $scope.visDetaljer = false;
        $scope.visUbesvarte = false;
    };

    function hideAll() {
        $scope.headerFaq = false;
        $scope.headerUbesvarte = false;
        $scope.headerSpor = false;
        $scope.headerTakk = false;
        $scope.visTakk = false;
        $scope.visDetaljer = false;
        $scope.visKategoriPanel = false;
        $scope.visKategoriFaqs = false;
        $scope.visFaqs = false;
        $scope.visSporreSkjema = false;
        $scope.visUbesvarte = false;
    };
});