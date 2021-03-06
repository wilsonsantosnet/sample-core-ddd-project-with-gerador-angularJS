﻿(function () {
    'use strict';

    angular.module("Sample.Controllers")
        .controller("MainController", MainController);

    MainController.$inject = ['$state', '$timeout', '$location', 'AccountService']

    function MainController($state, $timeout, $location, AccountService) {

        var vm = this;
        vm.randomDefault = Math.random();

        vm.Logout = function () {
            AccountService.logout();
        };

        vm.HideShowMenu = function () {

        };

        vm.LoadMenu = function () {

            AccountService.menu(function (result) {

                if (result.data != null)
                {
                    if (result.data.name != null) {
                        vm.userName = result.data.name
                    }

                    if (result.data.role != null) {
                        vm.userRole = result.data.role
                    }

                    if (result.data.tools != null) {
                        vm.menu = JSON.parse(result.data.tools)
                    }

                    vm.userInfo = "Usuário logado: " + vm.userName + " [" + vm.userRole + "]"
                }

                //for (var i = 0; i < result.dataList.length; i++) {


                //    if (result.dataList[i].clamsType == "name") {

                //        vm.userName = result.dataList[i].value
                //    }

                //    if (result.dataList[i].clamsType == "role") {

                //        vm.userRole = result.dataList[i].value
                //    }

                //    if (result.dataList[i].clamsType == "tools") {
                //        vm.menu = JSON.parse(result.dataList[i].value);
                //    }
                //}
                

            });
        };

    };
})();