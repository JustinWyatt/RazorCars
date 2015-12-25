var app = angular.module("app", ['ngRoute', 'ngResource']).
    config(function ($routeProvider) {
        $routeProvider.
            when('/index', { controller: 'InventoryController', templateUrl: 'account.html' }).
            when('/useraccounts', { controller: 'UsersController', templateUrl: 'useraccounts.html' }).
            when('/cars', { controller: 'CarsController', templateUrl: 'cars.html' }).
            when('/messages', { controller: 'MessagesController', templateUrl: 'messages.html' }).

            otherwise({ redirectTo: '/index' });
    });
app.factory('inventory', function ($resource) {
    return $resource('/api/inventoriesapi/index/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

app.controller('InventoryController', ['$scope', 'inventory', function ($scope, inventory) {
    $scope.inventories = inventory.query();
}]);