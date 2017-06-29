(function() {

    angular
        .module('cookBook')
        .service('recipeStorage', RecipeStorage);

    RecipeStorage.$inject = [
        '$http',
        '$q'
    ];

    function RecipeStorage ($http, $q) {
        var recipesList = [];

        function loadRecipeById(id) {
            return $http({
                method: 'GET',
                url: '/CookBook/GetRecipe',
                data: {id: id}
            });
        }

        function loadRecipes() {
            return $http({
                url: '/CookBook/AllRecipes',
                method: 'GET'
            });
        }

        return {
            setData: function(recipes) {
                recipesList = recipes;
            },
            getAllRecipes: function () {
                var deferred = $q.defer(),
                    loadPromise;

                if (recipesList.length > 0) {
                    setTimeout(function() {
                        deferred.resolve(recipesList);
                    }, 0);
                } else {
                    loadPromise = loadRecipes();
                    loadPromise.then(function (recipes) {
                        recipesList = recipes.data;
                        deferred.resolve(recipesList);
                    });
                }

                return deferred.promise;
            },
            getRecipeById: function (id) {
                var i = 0,
                    temp = null,
                    recipe = null,
                    deferred = $q.defer();

                for (i in recipesList) {
                    temp = recipesList[i];
                    if (temp.id === id) {
                        recipe = temp;
                        break;
                    }
                }
                
                if (recipe == null) {
                    //load recipe
                    loadRecipeById(id).then(function(recipe) {
                        deferred.resolve(recipe.data);
                    });
                } else {
                    setTimeout(function() {
                        deferred.resolve(recipe);
                    }, 0);
                }

                return deferred.promise;
            }
        };
    }

})();