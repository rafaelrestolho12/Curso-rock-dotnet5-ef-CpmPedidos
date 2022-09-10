using CpmPedidos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpmPedidos.Interface
{
    public interface IProdutoRepository
    {
        List<Produto> GetProdutos();

        List<Produto> GetProdutosByNameDescription(string search, int page);

        Produto GetProdutoById(int id);
    }
}
