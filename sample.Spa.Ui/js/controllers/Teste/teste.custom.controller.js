(function () {
    'use strict';

    angular.module("Sample.Controllers")
        .controller("TesteController", TesteController);

    TesteController.$inject = ['Crud', 'TesteConstants', 'Notification', '$stateParams', '$location', '$timeout', 'Api']

    function TesteController(Crud, TesteConstants, Notification, $stateParams, $location, $timeout, Api, $filter) {

        var vm = this;

        TesteControllerBase(vm, Crud, $stateParams, $location, $timeout, TesteConstants, Notification, Api, $filter, {
            Labels: TesteConstants.Labels,
            Attributes: TesteConstants.Attributes,
			 Create: {
                urlRedirect:"/Teste"
            },
            Edit: {
                urlRedirect:"/Teste"
            },
        });

    };
})();