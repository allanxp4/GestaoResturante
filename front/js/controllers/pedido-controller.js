app.controller('PedidoController', function($scope, $http){

    $scope.pedido = {
        produtos: []
    };

   /* 
    $scope.pedido = {
        mesa: 0,
        produtos: {
            id: 0,
            quantidade: 0
        }
    };*/

    /*
    $scope.produtoAtual = {
        quantidade: 0
    };*/

    $scope.qtd = 0;

    $scope.adicionarProduto = function(){
        console.log($scope.produtoAtual)
        $scope.produtoAtual.quantidade = $scope.qtd;
        $scope.pedido.produtos.push($scope.produtoAtual);
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
            preco: 12.98
        },
        {
            id: "2",
            descricao: "Coisa2",
            preco: 5.10
        }
    ]


})