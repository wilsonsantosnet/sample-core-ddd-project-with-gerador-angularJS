(function () {
    'use strict';

    angular
        .module('Seed')
        .run(OnRun);

    OnRun.$inject = ['$rootScope', '$state']
  
    function OnRun($rootScope, $state) {

        $rootScope.$on("$stateChangeError", function (event, toState, toParams, fromState, fromParams, error) {

        });

        $rootScope.$on("$stateChangeSuccess", function (event, toState, toParams, fromState, fromParams) {

        });
    }

})();