(function () {

    var app = angular.module("test", ["ngRoute"]);

    app.constant("schConfig",
        {
            source: "http://localhost:64247/api/",
        });

    app.config(function ($routeProvider) {

        $routeProvider
            .when("/employee", { templateUrl: "views/employee.html", controller: "EmployeeController" })
            .otherwise({ redirectTo: "/employee" });
    });

}());