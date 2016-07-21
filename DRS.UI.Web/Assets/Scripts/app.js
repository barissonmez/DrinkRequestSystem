(function() {

    'use strict';

    angular
        .module('DrinkRequestSystemApp', ['ngRoute'])
        .config(config);
    
    config.$inject = ['$routeProvider'];
    function config($routeProvider) {
        $routeProvider
            .when('/', {
                controller: 'HomeController',
                templateUrl: 'Assets/Modules/home/home.view.html',
                controllerAs: 'vm'
            })
            .otherwise({ redirectTo: '/' });
    }

})();