using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CpmPedidos.Repository
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext dbContext) :  base(dbContext) { }

        public Produto GetProdutoById(int id)
        {
            var produtos = DbContext.Produtos;

            var dado = produtos
                .Include(x => x.Imagens)
                .Include(x => x.Categoria)
                .Where(x => x.Ativo && x.Id == id)
                .FirstOrDefault();
            return dado;
        }

        public List<Produto> GetProdutos()
        {
            var produtos = DbContext.Produtos;
            var dados = (from p in produtos
                         where p.Ativo
                         orderby p.Nome
                         select p).ToList();
            return dados;
        }

        public List<Produto> GetProdutosByNameDescription(string search, int page)
        {
            var produtos = DbContext.Produtos;
            var searchUp = search.ToUpper();

            var dados = (from p in produtos
                         where p.Ativo &&
                               (p.Descricao.ToUpper().Contains(searchUp) || p.Nome.ToUpper().Contains(searchUp))
                         orderby p.Nome
                         select p).Skip(PageSize * (page - 1))
                                  .Take(PageSize)
                                  .ToList();

            return dados;
        }
    }
}
