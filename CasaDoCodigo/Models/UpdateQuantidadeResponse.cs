using CasaDoCodigo.Models.ViewModel;

namespace CasaDoCodigo.Models
{
	public class UpdateQuantidadeResponse
	{
		public UpdateQuantidadeResponse( ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel )
		{
			ItemPedido = itemPedido;
			CarrinhoViewModel = carrinhoViewModel;
		}

		public ItemPedido ItemPedido { get; }
		public CarrinhoViewModel CarrinhoViewModel { get; }
	}
}
