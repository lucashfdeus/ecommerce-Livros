using CasaDoCodigo.Models;
using System.Collections.Generic;

namespace CasaDoCodigo.Contratos.Interfaces
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro> livros);
        IList<Produto> GetProdutos();
    }
}
