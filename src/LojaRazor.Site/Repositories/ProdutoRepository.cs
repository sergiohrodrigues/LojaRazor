using LojaRazor.Site.Models;

namespace LojaRazor.Models;

public static class ProdutoRepositorio
{
    private static readonly List<Produto> _produtos = new()
    {
        new() { Id = 1, Nome = "Notebook Gamer",    Descricao = "i9, 32GB RAM, RTX 4070",          Preco = 8499.90m, Categoria = "Eletrônicos", EmEstoque = true,  Estoque = 5  },
        new() { Id = 2, Nome = "Fone Bluetooth",    Descricao = "Cancelamento de ruído, 30h bat.", Preco =  899.90m, Categoria = "Eletrônicos", EmEstoque = true,  Estoque = 18 },
        new() { Id = 3, Nome = "Cadeira Ergonômica",Descricao = "Lombar ajustável, rodízios",      Preco = 2199.00m, Categoria = "Móveis",      EmEstoque = true,  Estoque = 3  },
        new() { Id = 4, Nome = "Mesa Gamer",        Descricao = "1,60m, passa-cabos integrado",   Preco = 1350.00m, Categoria = "Móveis",      EmEstoque = false, Estoque = 0  },
        new() { Id = 5, Nome = "Mouse sem fio",     Descricao = "25600 DPI, 11 botões",           Preco =  349.90m, Categoria = "Periféricos", EmEstoque = true,  Estoque = 42 },
        new() { Id = 6, Nome = "Teclado Mecânico",  Descricao = "Switch red, RGB, ABNT2",         Preco =  599.90m, Categoria = "Periféricos", EmEstoque = true,  Estoque = 9  },
    };

    // Retorna todos os produtos
    public static List<Produto> GetTodos() => _produtos;

    // Busca um produto pelo Id
    public static Produto? GetPorId(int id) =>
        _produtos.FirstOrDefault(p => p.Id == id);

    // Filtra por categoria
    public static List<Produto> GetPorCategoria(string categoria) =>
        _produtos.Where(p => p.Categoria == categoria).ToList();

    // Retorna categorias únicas (útil para montar filtros)
    public static List<string> GetCategorias() =>
        _produtos.Select(p => p.Categoria).Distinct().ToList();
}