var appGarcom = angular.module('restaurante.garcom', ['ui.select', 'ngSanitize']);
appGarcom.controller('pedido-controller',
    function ($scope, $http) {
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

        $scope.qtd = 1;

        //Adciona produtos ao objeto para ser enviado (e consequentemente a lista pelo 2-way binding)
        $scope.adicionarProduto = function () {
            console.log($scope.select2.ProdutoAtual);
            $scope.select2.ProdutoAtual.quantidade = $scope.qtd;
            $scope.select2.ProdutoAtual.uuid = Math.random();
            $scope.pedido.produtos.push(JSON.parse(JSON.stringify($scope.select2.ProdutoAtual)));
            //gambis pra copiar o objeto
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

        //Modal de opções
        $scope.produtoOpcoes = {};
        $scope.modalOpcoes = {};

        $scope.abrirOpcoes = function (produto) {
            //sdds es6
            if (typeof produto.observacoes != "undefined") {
                $scope.modalOpcoes.observacoes = produto.observacoes;
            }
            $scope.produtoOpcoes.produto = produto;
            $("#modal-opcoes").modal('toggle');
        }

        //necessário para apagar a mensagem de notificações
        $scope.fecharModal = function() {
            $scope.modalOpcoes.observacoes = "";
            $("#modal-opcoes").modal('toggle');
        }

        $scope.salvarObservacoes = function () {
            console.log("aro");
            $scope.produtoOpcoes.produto.observacoes = $scope.modalOpcoes.observacoes;
            console.log($scope.pedido.produtos);
            $scope.modalOpcoes.observacoes = "";
            console.log($scope.pedido.produtos);
            $("#modal-opcoes").modal('toggle');
        }

        $scope.apagarProduto = function() {
            var index = $scope.pedido.produtos.indexOf($scope.produtoOpcoes.produto);
            $scope.pedido.produtos.splice(index, 1);
            $("#modal-opcoes").modal('toggle');
        }


        //Envio do pedido
        $scope.enviarPedido = function () {
            
            $http.post('api/pedido', JSON.stringify($scope.pedido))
            .then(function () {
                //Reseta o pedido
                $scope.pedido = { produtos: [] };
                toastr.success("Pedido enviado!");
            }, function (error) {
                toastr.warning("Erro: " + error);
            })
        }
        
    });



