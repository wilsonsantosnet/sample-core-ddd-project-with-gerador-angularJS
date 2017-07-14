(function () {
    'use strict';
  
    angular
        .module('Sample.Services', [
            'ui.bootstrap',
            'common.utils',
            'ui-notification',
			'ngclipboard'
        ]);

    angular
        .module('Sample.Config', [
            'ui.router',
            'common.utils',
            'oc.lazyLoad',
        ]);

    angular
        .module('Sample.Controllers', [
            'ui.bootstrap',
            'common.utils',
            'ui-notification',
            'ui.mask',
            'ui.utils.masks',
            'ui.bootstrap.datetimepicker'
        ]);

    angular
       .module('Seed', [
           'Sample.Services',
           'Sample.Config',
           'Sample.Controllers',
       ]);
    
})();