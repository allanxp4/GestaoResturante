app.controller('PedidoController', function($scope, $http){
    
    $scope.qtd = 0;

    $scope.aumentaQtd = function(){
        $scope.qtd++;
    }

    $scope.diminuiQtd = function(){
        $scope.qtd--;
    }
})