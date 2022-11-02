using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
    }

    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public PedidoRepository(ApplicationContext contexto, IHttpContextAccessor contextAccessor)
            : base(contexto)
        {
            this._contextAccessor = contextAccessor;
        }

        public void AddItem(string codigo)
        {
            var produto = contexto.Set<Produto>()
                        .Where(p => p.Codigo == codigo)
                        .FirstOrDefault();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado");
            }

            var pedido = GetPedido();
            var itemPedido = contexto.Set<ItemPedido>()
              .Where(i => i.Produto.Codigo == codigo && i.Pedido.Id == pedido.Id)
              .SingleOrDefault();

            if(itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                contexto.Set<ItemPedido>()
                    .Add(itemPedido);

                contexto.SaveChanges();
            }

        }

        public Pedido GetPedido()
        {
            //Obter o Pedido Atual. Primeiro passo, saber qual é o Id do pedido que está gravado na sessao
            var pedidoId = GetPedidoId();
            var pedido = dbSet.Where(p => p.Id == pedidoId).SingleOrDefault();
            //Igual ao Id da sessao. O SingleOrDefault retorna o valor ou um nulo se nao tiver, sem dar um erro
                
            if(pedido == null)
            {
                pedido = new Pedido();
                //Add essa nova instância ao DbSet de produto
                dbSet.Add(pedido);
                contexto.SaveChanges();//grava no banco e obtém o novo Id p/ o pedido
                //Gravando na sessao 
                SetPedidoId(pedido.Id);//Agora vou aproveitar sempre o mesmo Id a cada navegação
            }

            return pedido; 
        }

        private int? GetPedidoId()
        {
            return _contextAccessor.HttpContext.Session.GetInt32("pedidoId");//lendo => mesmo nome que coloquei no set 'pedidoId'
        }

        private void SetPedidoId(int pedidoId)
        {
            _contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);//Gravando 
        }

    }
}
