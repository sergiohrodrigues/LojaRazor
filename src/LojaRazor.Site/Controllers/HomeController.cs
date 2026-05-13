using LojaRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaRazor.Controllers;

public class HomeController : Controller
{
    // GET /  ou  GET /Home/Index
    public IActionResult Index()
    {
        // Busca os 3 primeiros produtos para exibir na home
        var destaques = ProdutoRepositorio.GetTodos().Take(3).ToList();

        // View() renderiza Views/Home/Index.cshtml
        // O segundo argumento ? o MODEL passado para a View
        return View(destaques);
    }
}