var app = angular.module('restaurante', ['ngRoute', 'ngSanitize', 'ui.select'])
    .config(function($routeProvider){
        $routeProvider.when('/novopedido', {
            templateUrl: '/views/pedido.html',
            controller: 'PedidoController'
        });

        $routeProvider.when('/pagina2', {
            templateUrl: '/views/pagina2.html',
            controller: 'Pagina2Controller'
        });

        $routeProvider.otherwise({redirectTo: '/novopedido'});
    })