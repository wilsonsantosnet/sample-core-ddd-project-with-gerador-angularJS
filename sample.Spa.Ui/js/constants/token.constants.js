(function () {
    'use strict';

    angular
        .module("Sample.Config")
        .constant("TokenConstants", {
            TOKEN: window.localStorage.getItem("TOKEN_AUTH"),
            ISAUTH: ["$q", function ($q) {
                var token = window.localStorage.getItem("TOKEN_AUTH");
                if (token == null) {
                    return $q.reject({ authenticated: false });
                } else {
                    return $q.when({ authenticated: true });
                }
            }]
        });
})();

