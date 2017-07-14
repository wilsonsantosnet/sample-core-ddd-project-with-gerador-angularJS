(function () {
    'use strict';

    

    angular
        .module('Sample.Config')
        .factory('httpRequestInterceptor', function () {
            return {
                request: function (configs) {
                    var item = localStorage.getItem("TOKEN_AUTH");
                    configs.headers['Authorization'] = "Bearer " + item;
                    return configs;                }
            };
        });

    angular
        .module('Sample.Config')
        .config(function ($httpProvider) {
            $httpProvider.interceptors.push('httpRequestInterceptor');
        });
    
})();