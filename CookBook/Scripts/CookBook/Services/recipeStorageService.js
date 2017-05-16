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
            return $http.send({
                method: 'GET',
                url: '/CookBook/GetRecipe',
                data: {id: id}
            });
        }

        return {
            setData: function(recipes) {
                recipesList = recipes;
            },
            getAllRecipes: function() {
                return recipesList;
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
                    return loadRecipeById(id);
                }

                deferred.resolve(recipe);
                return deferred.promise;
            }
        };
    }

})();