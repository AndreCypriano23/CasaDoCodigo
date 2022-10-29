using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {

        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {

        }


        public IList<Produto> GetProdutos()
        {
            return dbSet.ToList();//Retorna uma lista a partir do DbSet
        }

        public void SaveProdutos(List<Livro> livros)
        {
            //salvar no banco cada livro
            foreach (var livro in livros)
            {
                //Filtro para evitar duplicação
                
                if (!dbSet.Where(p => p.Codigo == livro.Codigo).Any())//Se não tiver produto
                {
                    //vamos acessar a tabela do banco de dados
                    dbSet.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                   //mas agora ele só add no set de produtos, que é add info em memória, nao foi mandado p o banco
                }

            }
        }

    }
    public class Livro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
