using CasaDoCodigo.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class UpdateQuantidadeResponse
    {
      
        //Item de pedido que foi alterado
        public ItemPedido itemPedido { get; }
        //Carrinho com os totais
        public CarrinhoViewModel carrinhoViewModel { get; }

        public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            this.itemPedido = itemPedido;
            this.carrinhoViewModel = carrinhoViewModel;
        }

    }
}
