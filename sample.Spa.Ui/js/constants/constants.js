(function () {
    'use strict';

    angular
        .module("common.utils")
        .constant("endpoints", {
            DEFAULT: "http://localhost:8122/api/",
			AUTH: "http://localhost:4000/api/"
        }); 

    angular
        .module("common.utils")
        .constant("configsConstants", {
            STATE_STATUSCODE_401: "/#Login",
        });

	angular
      .module("common.utils")
      .constant("compatibilityConstants", {
          SuccessHandleAPI: function (data, self) {
			self.ViewModel.FilterResult = data.DataList;
            self.Pagination.TotalItens = data.Summary.Total;
          },
		  GetDataAPI: function (data) {
			return data.Data;	
          },
		  GetErrorsAPI: function(err){
			return err.data !== null ? err.data.Errors : null;
		  }
      });

})();