using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Models;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.Identidade;

namespace NSE.Catalogo.API.Controllers
{
    [Authorize]
    public class CatalogoController : MainController
    {
        private readonly IProdutoRepositoy _produtoRepositoy;

        public CatalogoController(IProdutoRepositoy produtoRepositoy)
        {
            _produtoRepositoy = produtoRepositoy;
        }

        [AllowAnonymous]
        [HttpGet("catalogo/produtos")]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepositoy.ObterTodos();
        }

        [ClaimsAuthorize("Catalogo", "Ler")]
        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            return await _produtoRepositoy.ObterPorId(id);
        }
    }
}
