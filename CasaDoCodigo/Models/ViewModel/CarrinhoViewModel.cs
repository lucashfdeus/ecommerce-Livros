using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Models.ViewModel
{
	public class CarrinhoViewModel
	{
		public CarrinhoViewModel(IList<ItemPedido> itens )
		{
			Itens = itens;
		}

		public IList<ItemPedido> Itens { get; }

		public decimal Total => Itens.Sum( i => i.Quantidade * i.PrecoUnitario);
	}
}
