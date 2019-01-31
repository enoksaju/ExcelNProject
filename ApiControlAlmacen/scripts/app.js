// Define module
var App = angular.module('apiTestApp', []);

App.controller('ApiTestController', ['$scope', '$http', function ApiTestController($scope, $http) {
  $scope.values = ['first', 'second'];
  $scope.url = 'http://localhost:51129/api';
  $scope.control = 'default';
  $scope.metodo = 'GET';
  $scope.toSendData = '{}';
  $scope.SendData = function () {
    $http({ method: $scope.metodo, url: $scope.url + '/' + $scope.control, data: JSON.parse($scope.toSendData) }).
    then(function (response) {
      $scope.status = response.status;
      $scope.data = response.data;
    }, function (response) {
      $scope.data = response.data || 'Request failed';
      $scope.status = response.status;
    })
  }
}]);