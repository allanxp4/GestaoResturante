var app = angular.module('restaurante', ['ngRoute'])
    .config(function($routeProvider){
        $routeProvider.when('/pagina1', {
            templateUrl: '/views/pagina1.html',
            controller: 'Pagina1Controller'
        });

        $routeProvider.when('/pagina2', {
            templateUrl: '/views/pagina2.html',
            controller: 'Pagina2Controller'
        });

        $routeProvider.otherwise({redirectTo: '/pagina1'});
    })