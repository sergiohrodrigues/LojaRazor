using LojaRazor.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaRazor.Controllers;

public class ProdutosController : Controller
{
    // GET /Produtos  ou  GET /Produtos?categoria=Eletrônicos
    public IActionResult Index(string? categoria)
    {
        // Parâmetros da query string são recebidos automaticamente
        // Ex: /Produtos?categoria=Móveis  →  categoria = "Móveis"

        var produtos = string.IsNullOrEmpty(categoria)
            ? ProdutoRepositorio.GetTodos()
            : ProdutoRepositorio.GetPorCategoria(categoria);

        // ViewBag é um objeto dinâmico para passar dados extras à View
        // (diferente do Model, que é fortemente tipado)
        ViewBag.Categorias = ProdutoRepositorio.GetCategorias();
        ViewBag.CategoriaAtiva = categoria;

        return View(produtos); // passa List<Produto> como Model
    }

    // GET /Produtos/Detalhes/3
    public IActionResult Detalhes(int id)
    {
        var produto = ProdutoRepositorio.GetPorId(id);

        // NotFound() retorna HTTP 404 se não achar o produto
        if (produto is null) return NotFound();

        return View(produto); // passa um único Produto como Model
    }

    public IActionResult Parcial(string? categoria)
    {
        var produtos = string.IsNullOrEmpty(categoria)
            ? ProdutoRepositorio.GetTodos()
            : ProdutoRepositorio.GetPorCategoria(categoria);

        return PartialView("_ListaProdutos", produtos);
    }
}