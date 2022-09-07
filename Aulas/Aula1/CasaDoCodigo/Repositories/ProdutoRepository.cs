using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationContext contexto;

        public ProdutoRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
        }

        public IList<Produto> GetProdutos()
        {
            return contexto.Set<Produto>().ToList();//Retorna uma lista a partir do DbSet
        }

        public void SaveProdutos(List<Livro> livros)
        {
            //salvar no banco cada livro
            foreach (var livro in livros)
            {
                //vamos acessar a tabela do banco de dados
                contexto.Set<Produto>().Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                //mas agora ele só add no set de produtos, que é add info em memória, nao foi mandado p o banco
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
