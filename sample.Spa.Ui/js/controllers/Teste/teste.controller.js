
function TesteControllerBase(vm, Crud, $stateParams, $location, $timeout, TesteConstants, Notification, Api, $filter, customConfig) {

    vm.crud = new Crud.start();
	vm.randomDefault = Math.random();
	vm.mostrarFiltros = false;

    vm.crud.Config = {
        resource: "Teste",
        Create: {
            pathModal: "view/Teste/modalCreate.html",
        },
        Edit: {
            pathModal: "view/Teste/modalEdit.html",
        },
		Details: {
            pathModal: "view/Teste/details.html",
        },
    };

    vm.crud.Config = angular.merge({}, customConfig, vm.crud.Config)
    vm.crud.SetViewModel(vm);
	vm.crud.Filter($location.search());
	vm.crud.ConfigInPage($stateParams, vm, Notification, $timeout)

	vm.ActionTitle = TesteConstants.ActionTitle;
	vm.ActionDescription = TesteConstants.ActionDescription;
	vm.Labels = TesteConstants.Labels;	
	vm.Attributes = TesteConstants.Attributes;	

};