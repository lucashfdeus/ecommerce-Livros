using CasaDoCodigo.Contratos.Interfaces;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public PedidoRepository(ApplicationContext contexto,
            IHttpContextAccessor contextAccessor,
            IItemPedidoRepository itemPedidoRepository) : base(contexto)
        {
            this._contextAccessor = contextAccessor;
            this._itemPedidoRepository = itemPedidoRepository;
        }

        public void AddItem( string codigo )
        {
            var produto = contexto.Set<Produto>()
                            .Where( p => p.Codigo == codigo )
                            .SingleOrDefault();

            if( produto == null )
            {
                throw new ArgumentException( "Produto não encontrado" );
            }

            var pedido = GetPedido();

            var itemPedido = contexto.Set<ItemPedido>()
                                .Where( i => i.Produto.Codigo == codigo
                                         && i.Pedido.Id == pedido.Id )
                                .SingleOrDefault();

            if( itemPedido == null )
            {
                itemPedido = new ItemPedido( pedido, produto, 1, produto.Preco );
                contexto.Set<ItemPedido>()
                    .Add( itemPedido );

                contexto.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbSet
                .Include(p => p.Itens)
                    .ThenInclude(i => i.Produto)
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault();

            if( pedido == null )
            {
                pedido = new Pedido();
                dbSet.Add( pedido );
                contexto.SaveChanges();
                SetPedidoId(pedido.Id); //reaproveitando cada pedido na navegação;
            }

            return pedido;
        }

        private int? GetPedidoId()
        {
            return _contextAccessor.HttpContext.Session.GetInt32( "pedidoId" );
        }

        private void SetPedidoId( int pedidoId )
        {
            _contextAccessor.HttpContext.Session.SetInt32( "pedidoId", pedidoId );
        }

        public UpdateQuantidadeResponse UpdateQuantidade( ItemPedido itemPedido )
        {
            var itemPedidoDB = _itemPedidoRepository.GetItemPedido( itemPedido.Id );

            if( itemPedidoDB != null )
            {
                itemPedidoDB.AtualizaQuantidade( itemPedido.Quantidade );

                if( itemPedido.Quantidade == 0 )
                {
                    _itemPedidoRepository.RemoveItemPedido( itemPedido.Id );
                }

                contexto.SaveChanges();

                var carrinhoViewModel = new CarrinhoViewModel( GetPedido().Itens );

                return new UpdateQuantidadeResponse( itemPedidoDB, carrinhoViewModel );
            }

            throw new ArgumentException( "ItemPedido não encontrado" );
        }

        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = _itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                if (itemPedido.Quantidade == 0)
                {
                    _itemPedidoRepository.RemoveItemPedido(itemPedido.Id);
                }

                contexto.SaveChanges();

                var carrinhoViewModel = new CarrinhoViewModel(GetPedido().Itens);

                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado");
        }
    }
}