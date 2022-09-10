using CpmPedidos.Domain;
using CpmPedidos.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CpmPedidos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : AppBaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoController(IServiceProvider serviceProvider, IProdutoRepository produtoRepository) : base(serviceProvider)
        {
            _produtoRepository = (IProdutoRepository)serviceProvider.GetService(typeof(IProdutoRepository));
        }

        [HttpGet]
        public List<Produto> GetProdutos()
        {
            return _produtoRepository.GetProdutos();
        }

        [HttpGet]
        [Route("search/{text}/{page?}")]
        public List<Produto> GetProdutosByNameDescription(string text, int page = 1)
        {
            return _produtoRepository.GetProdutosByNameDescription(text, page);
        }

        [HttpGet]
        [Route("{id}")]
        public Produto GetProdutoById(int? id)
        {
            if ((id ?? 0) > 0)
                return _produtoRepository.GetProdutoById(id.Value);
            else
                return null;
        }
    }
}
