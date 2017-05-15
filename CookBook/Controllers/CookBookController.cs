using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CookBook.Interfaces;
using CookBook.Services;

namespace CookBook.Controllers
{
    public class CookBookController : Controller
    {
        private IRecipeService _recipeService;

        public CookBookController()
        {
            _recipeService = new RecipeService();
        }

        public CookBookController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        // GET: CookBook
        public async Task<ActionResult> Index()
        {
            var recipes =  await _recipeService.GetAllRecipes();

            return View(recipes);
        }
    }
}