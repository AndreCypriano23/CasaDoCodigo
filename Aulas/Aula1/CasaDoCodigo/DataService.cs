using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
//using static CasaDoCodigo.Repositories.ProdutoRepository;

namespace CasaDoCodigo
{
    class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            //Ele vai criar o BD se necessário
            contexto.Database.EnsureCreated();

            List<Livro> livros = GetLivros();

            produtoRepository.SaveProdutos(livros);

            //agora vai salvar
            contexto.SaveChanges();
        }



        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");//lendo os dados do arquivo Json
            //Vou chamar a classe da biblioteca Newtonsoft.Json para converter um arquivo em objeto
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);   //transformando texto em objeto
            
            //retorna uma lista de livros
            return livros;
        }
    }


}
