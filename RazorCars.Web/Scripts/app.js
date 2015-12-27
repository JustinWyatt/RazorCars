var app = angular.module("app", ['ngRoute', 'ngResource']).
    config(function ($routeProvider) {
        $routeProvider.
            when('/index', { controller: 'InventoryController', templateUrl: 'account.html' }).
            when('/useraccounts', { controller: 'UsersController', templateUrl: 'useraccounts.html' }).
            when('/cars', { controller: 'CarsController', templateUrl: 'cars.html' }).
            when('/messageboard', { controller: 'MessagesController', templateUrl: 'messages.html' }).
            when('/rentals', {controller: 'RentalsController', templateUrl: 'rentals.html'}).
            otherwise({ redirectTo: '/index' });
    });
app.factory('inventory', function ($resource) {
    return $resource('/api/inventoriesapi/index/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

app.factory('rentals', function ($resource){
    return $resource('/api/inventoriesapi/rentals/:id', { id: '@id'}, { update: { method: 'PUT'} });
});

app.controller('InventoryController', ['$scope', 'inventory', function ($scope, inventory) {
    $scope.inventories = inventory.query();
}]);

app.controller('RentalsController', ['$scope', 'rentals', function ($scope, rentals){
    $scope.rentals = rentals.query();
}]);