(function () {

    var app = angular.module("test");

    app.controller("EmployeeController", function ($scope, $rootScope, DataService) {

        var dataSet = "employee";  //we are defining where are we getting our data from
        $scope.selString = "";
        $scope.sortOrder = "";
        fetchData();

        //this function returns all the employee data from our WebApi application
        function fetchData() {
            DataService.list(dataSet, function (data) {
                $scope.employees = data;
                //console.log($scope.employees);
            });
        }

        //with this function we are transfering data to an editor for update
        $scope.transfer = function (item) {
            $scope.employee = item;
        };

        //this function is used to create a new entry in the employee table
        $scope.newEmployee = function () {
            $scope.employee = {
                empId: 0,
                firstName: "",
                age: "",
                activity: "false",
                department:0
            }
        };

        //this function is used to delete a single entry from the database
        $scope.deleteData = function () {
            DataService.delete(dataSet, $scope.employee.empId, function (data) { fetchData() });
        }

        //this function is used to save new data or update existing data in the database
        $scope.saveData = function () {
            if ($scope.employee.empId == 0) {
                DataService.create(dataSet, $scope.employee, function (data) { fetchData(); });
            }
            else {
                DataService.update(dataSet, $scope.employee.empId, $scope.employee, function (data) { fetchData(); });
            }
        }
    });
}());
