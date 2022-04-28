using CasaDoCodigo.Contratos.Interfaces;
using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext _contexto;
        private readonly IProdutoRepository _produtoRepository;

        public DataService(ApplicationContext contexto,
            IProdutoRepository produtoRepository)
        {
            _contexto = contexto;
            _produtoRepository = produtoRepository;
        }

        public void InicializaDB()
        {
            _contexto.Database.Migrate();

            List<Livro> livros = GetLivros();

            _produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
