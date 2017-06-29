using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CookBook.Interfaces;
using CookBook.Models;
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
            var recipes = await _recipeService.GetAllRecipes();

            return View(recipes);
        }

        public async Task<ActionResult> RecipeListView()
        {
            var recipes = await _recipeService.GetAllRecipes();

            return PartialView("Index", recipes);
        }

        public async Task<ActionResult> RecipeView()
        {
            return PartialView();
        }

        public async Task<ActionResult> EditRecipeView()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> AllRecipes()
        {
            var recipes = await _recipeService.GetAllRecipes();

            return Json(recipes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> Recipe(int recipeId)
        {
            var recipe = await _recipeService.GetRecipe(recipeId);

            return Json(recipe, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> LastVersion(int versionId)
        {
            var recipe = await _recipeService.GetRecipeVersion(versionId);

            return Json(recipe, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> AddUpdateRecipe(RecipeVM recipeVm)
        {
            recipeVm = await _recipeService.SaveRecipe(recipeVm);

            return Json(recipeVm);
        }
    }
}