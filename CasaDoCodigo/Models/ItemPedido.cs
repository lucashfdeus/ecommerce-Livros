using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class ItemPedido : BaseModel
    {

        public ItemPedido()
        {

        }
        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        [Required]
        [DataMember]
        public Pedido Pedido { get; private set; }

        [Required]
        [DataMember]
        public Produto Produto { get; private set; }           

        [Required]
        [DataMember]
        public int Quantidade { get; private set; }
        [Required]
        [DataMember]
        public decimal PrecoUnitario { get; private set; }

        internal void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }


    }
}
