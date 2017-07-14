(function () {
    'use strict';

    angular.module("Sample.Config")
        .config(routeConfig);

    routeConfig.$inject = ['$stateProvider', '$urlRouterProvider', 'TokenConstants', 'breadcrumbConstants'];

    function routeConfig($stateProvider, $urlRouterProvider, TokenConstants, breadcrumbConstants) {
	
        var _isAuth = TokenConstants.ISAUTH;

        $stateProvider

		
            .state('template', {
                url: '',
                abstract: true,
                views: {
                    'main': {
                        templateUrl: 'template/layout.html'
                    }
                }
            })

                        
            .state('template.Teste', {
                url: '/Teste',
				ncyBreadcrumb: {
                    label: breadcrumbConstants.Teste
                },
                views: {
                    'content': {
                        templateUrl: MakeUrl('view/Teste/index.html'),
                        controller: 'TesteController as vm',
                        resolve: {
                            auth: _isAuth,
                            loadPlugin: function ($ocLazyLoad) {
                                return $ocLazyLoad.load(
                                    [
										'js/constants/Teste.constants.js',
										'js/controllers/Teste/Teste.custom.controller.js',
										'js/controllers/Teste/Teste.controller.js'
									]
                                );
                            }
                        }
                    }
                }
            })


			.state('template.Teste-edit', {
                url: '/Teste/Edit/:Id',
				ncyBreadcrumb: {
                    label: breadcrumbConstants.Teste
                },
                views: {
                    'content': {
                        templateUrl: MakeUrl('view/Teste/edit.html'),
                        controller: 'TesteController as vm',
                        resolve: {
                            auth: _isAuth,
                            loadPlugin: function ($ocLazyLoad) {
                                return $ocLazyLoad.load(
                                    [
										'js/constants/Teste.constants.js',
										'js/controllers/Teste/Teste.custom.controller.js',
										'js/controllers/Teste/Teste.controller.js'
									]
                                );
                            }
                        }
                    }
                }
            })

			.state('Teste-print', {
                url: '/Teste/Print/:Id',
				ncyBreadcrumb: {
                    label: breadcrumbConstants.Teste
                },
                views: {
                    'mainBody': {
                        templateUrl: MakeUrl('view/Teste/details.html'),
                        controller: 'TesteController as vm',
                        resolve: {
                            auth: _isAuth,
                            loadPlugin: function ($ocLazyLoad) {
                                return $ocLazyLoad.load(
                                    [
										'js/constants/Teste.constants.js',
										'js/controllers/Teste/Teste.custom.controller.js',
										'js/controllers/Teste/Teste.controller.js'
									]
                                );
                            }
                        }
                    }
                }
            })


			.state('template.Teste-create', {
                url: '/Teste/Create',
				ncyBreadcrumb: {
                    label: breadcrumbConstants.Teste
                },
                views: {
                    'content': {
                        templateUrl: MakeUrl('view/Teste/create.html'),
                        controller: 'TesteController as vm',
                        resolve: {
                            auth: _isAuth,
                            loadPlugin: function ($ocLazyLoad) {
                                return $ocLazyLoad.load(
                                    [
										'js/constants/Teste.constants.js',
										'js/controllers/Teste/Teste.custom.controller.js',
										'js/controllers/Teste/Teste.controller.js'
									]
                                );
                            }
                        }
                    }
                }
            })


        function MakeUrl(url, noCache) {
            if (noCache)
                return url;

            return url + '?v=' + Math.random();
        }

    };

})();