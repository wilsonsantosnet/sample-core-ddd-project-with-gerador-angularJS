(function () {
    'use strict';

    angular.module("Sample.Controllers")
        .controller("LoginController", LoginController);

    LoginController.$inject = ['Api', '$state', 'AccountService']

    function LoginController(Api, $state, AccountService) {

        var vm = this;

        vm.DoLogin = function (model) {
            AccountService.login(model.Email, model.Password);
        };

    };

})();