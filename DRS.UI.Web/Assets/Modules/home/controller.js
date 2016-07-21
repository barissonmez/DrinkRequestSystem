(function() {
    'use strict';
    
    angular
        .module('DrinkRequestSystemApp')
        .controller('HomeController', HomeController);

    HomeController.$inject = ['Services'];
    
    function HomeController(Services) {
        var vm = this;
        vm.createOrder = createOrder;
        vm.deleteOrder = deleteOrder;
        
        initController();

        function initController() {
            loadAllDrinks();
            loadTodaysOrders();
        }
        
        function loadAllDrinks() {
            Services.GetDrinks()
                .then(function (drinks) {
                    vm.allDrinks = drinks;
                });
        }

        function createOrder(id) {
            Services.CreateOrder(id)
                .then(function () {
                    loadTodaysOrders();
                });
        }
        
        function deleteOrder(id) {
            Services.DeleteOrder(id)
                .then(function () {
                    loadTodaysOrders();
                });
        }
        
        function loadTodaysOrders() {
            Services.TodaysOrders()
                .then(function (orders) {
                    vm.todaysOrders = orders;
                });
        }
    }

})();