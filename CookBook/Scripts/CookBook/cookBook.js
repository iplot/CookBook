(function() {
    var app = angular
        .module('cookBook', ['ngRoute'])
        .config(['$routeProvider', function ($routeProvider) {
            debugger;
            $routeProvider
                .when('/', {
                    templateUrl: '/CookBook/RecipeListView'
                    //controller: 'recipe'
                })
                .when('/Recipe', {
                    templateUrl: '/CookBook/RecipeView',
                    controller: 'recipe'
                });
            //.otherwise({redirecTo: '/'});
        }]);
})();