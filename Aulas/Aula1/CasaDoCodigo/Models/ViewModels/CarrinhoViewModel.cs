using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public CarrinhoViewModel(IList<ItemPedido> itens)
        {
            this.Itens = itens;
        }

        public IList<ItemPedido> Itens { get; }//nao vou colocar set pq ela é somente leitura

        public decimal Total => Itens.Sum(i => i.Quantidade * i.PrecoUnitario);


    }
}
