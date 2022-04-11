using CasaDoCodigo.Contratos.Interfaces;
using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
