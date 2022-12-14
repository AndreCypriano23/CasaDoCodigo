using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int itemPedidoId);
    }

    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {

        }
        //Método para obter somente o item apartir do id 

        public ItemPedido GetItemPedido(int itemPedidoId)
        {
            return dbSet.
              Where(ip => ip.Id == itemPedidoId).FirstOrDefault();
        }

    }
}
