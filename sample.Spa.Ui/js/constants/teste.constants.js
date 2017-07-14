(function () {
    'use strict';

    angular
        .module("Sample.Config")
        .constant("TesteConstants", {

			ActionTitle : "Teste",
			ActionDescription : "Essa tela é um exemplo de CRUD , gerado pelo gerador",

			Labels : {
                testeId : 'testeId',
                nome : 'nome',
			
			},
			Attributes : {
                testeId : '',
                nome : '',
				
			}
        });
})();

