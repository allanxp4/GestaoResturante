var appGarcom = angular.module('restaurante.garcom', ['ui.select', 'ngSanitize']);
appGarcom.controller('pedido-controller',
    function ($scope, $http) {
        $scope.pedido = {
            Produtos: []
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
            $scope.select2.ProdutoAtual.Quantidade = $scope.qtd;
            $scope.select2.ProdutoAtual.uuid = Math.random();
            $scope.select2.ProdutoAtual.ProdutoId = $scope.select2.ProdutoAtual.Id;
            $scope.pedido.Produtos.push(JSON.parse(JSON.stringify($scope.select2.ProdutoAtual)));
            //gambis pra copiar o objeto
        }

        //Lista de produtos do pedido para serem enviados
        $scope.pedido.Produtos = [];

     
        //produtos de exemplo, na aplicação real eles virão do servidor
        $scope.produtos = [
            {
                Id: "1",
                Nome: "Burgão2",
                Valor: 12.98
            },
            {
                Id: "2",
                Nome: "Coisa2",
                Valor: 5.10
            }
        ];

        $scope.atualizarSelect = function (termo) {
            $http({
                method: 'GET',
                url: 'api/Produto?termo=' + termo,
            }).then(function (dados) {
                console.log(dados);
                $scope.produtos = dados.data;
            }, function (erro) {
                toastr.warning("Erro!");
                console.log(erro);
            })
        }


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
            var index = $scope.pedido.Produtos.indexOf($scope.produtoOpcoes.produto);
            $scope.pedido.Produtos.splice(index, 1);
            $("#modal-opcoes").modal('toggle');
        }


        //Envio do pedido
        $scope.enviarPedido = function () {
            console.log($scope.pedido);
            $http.post('api/pedido', JSON.stringify($scope.pedido))
            .then(function () {
                //Reseta o pedido
                $scope.pedido = { Produtos: [] };
                toastr.success("Pedido enviado!");
            }, function (error) {
                toastr.warning("Erro: " + error);
            })
        }
        
    });



