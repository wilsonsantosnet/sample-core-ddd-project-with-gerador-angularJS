(function () {
    'use strict';

    angular.module("Sample.Controllers")
        .controller("HomeController", HomeController);

    HomeController.$inject = ['$location', 'AccountService', 'Api', 'Crud', '$uibModal', 'Notification']

    function HomeController($location, AccountService, Api, Crud, $uibModal, Notification) {

        var vm = this;

    };
})();