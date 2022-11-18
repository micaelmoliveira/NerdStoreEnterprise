using NSE.Core.Data;

namespace NSE.Catalogo.API.Models
{
    public interface IProdutoRepositoy : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
    }
}
