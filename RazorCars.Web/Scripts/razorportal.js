var RazorPortal = angular.module("RazorPortal", ["ngResource"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: AccountCtrl, templateUrl: 'account.html' }).
            when('/inventories', { controller: AccountCtrl, templateUrl: 'inventories.html' }).
            when('/cars', { controller: AccountCtrl, templateUrl: 'listcars.html' }).
            otherwise({ redirectTo: '/' });
    });

RazorPortal.factory('Todo', function ($resource) {
    return $resource('/api/inventoriesapi/:id', { id: '@id' }, { update: { method: 'PUT' } });
});

var AccountCtrl = function ($scope, $location) {

    $scope.test = "testing";
}

