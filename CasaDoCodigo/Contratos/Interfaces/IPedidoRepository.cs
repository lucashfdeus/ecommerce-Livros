using CasaDoCodigo.Models;

namespace CasaDoCodigo.Contratos.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido);
    }
}
