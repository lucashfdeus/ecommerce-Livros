using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;

namespace CasaDoCodigo.Contratos.Interfaces
{
    public interface IItemPedidoRepository 
    {
        ItemPedido GetItemPedido( int itemPedidoId );
        void RemoveItemPedido( int itemPedidoId );
    }
}
