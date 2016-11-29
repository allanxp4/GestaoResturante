var appGarcom = angular.module('restaurante.garcom', ['ui.select', 'ngSanitize']);
appGarcom.controller('pedido-controller',
    function ($scope) {
        $scope.pedido = {
            produtos: []
        };

        /* 
        Esturtura do JSON a ser enviado:
         $scope.pedido = {
             mesa: 0,
             produtos: {
                 id: 0,
                 quantidade: 0
             }
         };*/

        //Inicializa o select2/ui-select
        $scope.select2 = { ProdutoAtual: {} };

        $scope.qtd = 0;

        //Adciona produtos ao objeto para ser enviado (e consequentemente a lista pelo 2-way binding)
        $scope.adicionarProduto = function () {
            console.log($scope.select2.ProdutoAtual);
            $scope.select2.ProdutoAtual.quantidade = $scope.qtd;
            $scope.pedido.produtos.push($scope.select2.ProdutoAtual);
        }

        //Lista de produtos do pedido para serem enviados
        $scope.pedido.produtos = [];

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
        ];
    });