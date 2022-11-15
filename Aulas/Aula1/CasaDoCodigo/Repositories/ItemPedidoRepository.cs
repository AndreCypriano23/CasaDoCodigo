using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        void UpdateQuantidade(ItemPedido itemPedido);
       
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {

        }

        public void UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = dbSet.
                Where(ip => ip.Id == itemPedido.Id).FirstOrDefault();
        
            if(itemPedidoDB != null)
            {
                /* Aqui estava dando erro de não poder modificar a quantidade pq o set dele é privado, então fiz um método para poder alterar isso 
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade) = itemPedido.Quantidade;*/
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);

                contexto.SaveChanges();
            }
        }
    }
}
