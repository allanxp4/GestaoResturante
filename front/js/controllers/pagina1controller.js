app.controller('Pagina1Controller', function($scope, $http){
    $scope.msg = "aro pexoal";
    $scope.palavra_mascula = "daibduiabfiabfu";

    $scope.campo = "";
    $scope.mostrar = true;

    $scope.dados = [
        'dado1', 'dado2', 'dado3'
    ]

    $scope.funcao = function(){
        $scope.palavra_mascula = "Botão clicado!";       
    }

    $scope.fazerRequisicao = function(url){
        $http.get(url)
        .then(function(dados){
            $scope.campo = dados;            
        },
        function(error){
            console.log(error);
        })
    }


})