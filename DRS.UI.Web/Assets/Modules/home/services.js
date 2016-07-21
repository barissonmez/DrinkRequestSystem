(function() {
    'use strict';
    
    angular
        .module('DrinkRequestSystemApp')
        .factory('Services', Services);

    Services.$inject = ['$http'];
    
    function Services($http) {
        
        var service = {};

        service.GetDrinks = GetDrinks;
        service.CreateOrder = CreateOrder;
        service.TodaysOrders = TodaysOrders;
        service.DeleteOrder = DeleteOrder;
        
        return service;
        
        function GetDrinks() {
            return $http.get('/Drink/GetAll').then(handleSuccess, handleError('Error getting all drinks'));
        }

        function CreateOrder(id) {
            return $http.get('/Order/Create/' + id).then(handleSuccess, handleError('Error creating order'));
        }
        
        function DeleteOrder(id) {
            return $http.get('/Order/Delete/' + id).then(handleSuccess, handleError('Error deleting order'));
        }
        
        function TodaysOrders() {
            return $http.get('/Order/Today').then(handleSuccess, handleError('Error getting todays orders'));
        }

        // private functions
        function handleSuccess(res) {
            return res.data;
        }

        function handleError(error) {
            return function () {
                return { success: false, message: error };
            };
        }
    }

})();