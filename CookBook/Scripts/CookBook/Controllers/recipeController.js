(function() {

    angular
        .module('cookBook')
        .controller('recipe', RecipeController);

    RecipeController.$inject = [
        '$scope',
        'recipeStorage'
    ];

    function RecipeController($scope, recipeStorage) {
        recipeStorage.getAllRecipes().then(function(recipes) {
            $scope.recipes = recipes.data;
        });
    }

})();