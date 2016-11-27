app.controller('PedidoController', function($scope, $http){
    
    $scope.pedido = {}

    $scope.qtd = 0;

    $scope.aumentaQtd = function(){
        $scope.qtd++;
    }

    $scope.diminuiQtd = function(){
        $scope.qtd--;
    }

    $scope.pedido.produtos = [
        {
            id: "1",
            descricao: "Burgão",
            quantidade: 2,
            preco: 12.98
        },
        {
            id: "2",
            descricao: "Coisa",
            quantidade: 5,
            preco: 5.10
        }
    ]

    //produtos de exemplo, na aplicação real eles virão do servidor
    $scope.produtos = [
        {
            id: "1",
            descricao: "Burgão2",
            quantidade: 2,
            preco: 12.98
        },
        {
            id: "2",
            descricao: "Coisa2",
            quantidade: 5,
            preco: 5.10
        }
    ]


})