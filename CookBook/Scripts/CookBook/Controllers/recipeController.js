(function() {

    angular
        .module('cookBook')
        .controller('recipe', RecipeController);

    RecipeController.$inject = [
        '$scope',
        '$location',
        'recipeStorage'
    ];

    function RecipeController($scope, $location, recipeStorage) {
        recipeStorage.getAllRecipes().then(function(recipes) {
            $scope.recipes = recipes;
        });

        $scope.currentRecipe = null;
        $scope.gotoRecipe = function (id) {
            $location.url('/Recipe');
//            recipeStorage.getRecipeById()
        }
    }

})();