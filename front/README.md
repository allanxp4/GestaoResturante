#Frontend do sistema
es6 + vue.js + webpack

##Instruções:

###Set-up
Baixe o node.js v6.9 LTS: https://nodejs.org/en/
O node é apenas uma ferramenta que permite rodar js no cliente,
usaremos ele aqui para facilitar o desenvolvimento com o vue.js
e os componentes.

Ele é extremamente fácil de usar e todos os comandos que você precisará saber
do node para esse projeto são:

```
Para restaurar os pacotes (similar ao restore Nuget packages do mvc):
npm install

Para subir o servidor de desenvolvimento e o analizador de código:
npm run dev

Para gerar a aplicação pronta para o deploy, bastando copiar a pasta dist
para o servidor web:
npm run build
```

Sim, isso é tudo de node.

Basta instalar, entrar na pasta front/restaurante, rodar npm install e
npm run dev. Após isso seu browser irá abrir com a sua aplicação.

O ótimo disso é que no caso de acontecer algum erro, ao invés de travar
e cuspir tudo no console, ele vai mostrar na própria aplicação o que deu errado.
O eslint tambêm anializa o código por coisas toscas do tipo "esqueci um ;".

####Estutura das pastas do vue:

build: onde a aplicação pronta será colocada apos o npm run build,
incluindo html, js, css, tudo minificado, obfuscado e compactado.


config:
Algumas configurações do ambiente, não precisaremos mexer nisso.

src:
Onde nossa aplicação ficará.


### Na pasta da nossa aplicação:
Relembrando:
componentes: A pasta onde todos os nossos componentes .vue ficarão.
Só de olhar o arquivo é simples deduzir como funciona,
Temos o template do componente, o js e o css, e podemos usar esse componente
com uma tag própria no HTML. Usando o scoped no style, o css que você colocar lá
só vai servir para o próprio componente, ou seja, se você usar o seletor p,
ele só vai valer para os p do nosso componente.

App.vue: o componente base: perceba que ele declara a utilização do componente
Hello, e usa ele no template com a tag <hello>, como se fosse uma tag padrão.

main.js: O 'entry point' da aplicação, que cria a instância do Vue e
inicia ele na id "app" do index.html.

Perceba que não há nenhuma importação de script no index.html.
O webpack, componente do node, compila tudo e injeta sozinho onde fazer mais lógica,
por exemplo, se um componente depende de outro, ele coloca na ordem certa antes do fechamento do body,
se for um css, ele coloca no header. Inteligente, não?

Uma olhada rápida na documentação do vue mostra certinho como funciona.

Depois que a gente escolher o que vamos usar no css de front-end eu monto o esqueleto
e ai a gente divide os componentes da aplicação por igual.
