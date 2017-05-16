(function() {

    angular
        .module('cookBook')
        .controller('recipe', RecipeController);

    RecipeController.$inject = [
        '$scope',
        'recipeStorage'
    ];

    function RecipeController($scope, recipeStorage) {
        $scope.recipes = recipeStorage.getAllRecipes();
    }

})();