using Db4objects.Db4o;
using Db4objects.Db4o.Query;
using Db4objects.Db4o.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace atividadeBDO_2
{
    public class Services
    {
        static string pathName = "C:/Temp/Biblioteca.yap";

        public List<Livro> livros = new List<Livro>();

        public IEnumerable<Livro> RetornarLivrosAutor(Autor autor) {
            return livros.Where(livro => livro.autor.codigo == autor.codigo);
        }

        public IEnumerable<Livro> RetornarLivrosEditora(Editora editora)
        {
            return livros.Where(livro => livro.editora.codigo == editora.codigo);
        }

        public IEnumerable<Livro> OrdenarLivrosData()
        {
            return livros.OrderBy(livro => livro.ano);
        }

        public void RetornarLivros()
        {
            IObjectContainer dataBase = Db4oFactory.OpenFile(pathName);
            try
            {
                var result = from Livro livro in dataBase select livro;
                ListResult(result);
            }
            catch (Exception error)
            {
                Console.WriteLine("Estamos com erro ao Imprimir os livros - {0}", error);
            }
            finally
            {
                dataBase.Close();
            }
        }

        public static void ListResult(IDb4oLinqQuery<Livro> result) 
        {
            foreach (Livro livros in result)
                Console.WriteLine("{0} - {1} - {2} - {3}", livros.codigo, livros.nome, livros.editora.nome, livros.ano);
        }

        public IEnumerable<Autor> RetornarAutores()
        {
            return livros.Select(livro => livro.autor);
        }

        public IEnumerable<Editora> RetornarEditoras()
        {
            return livros.Select(livro => livro.editora);
        }


        public void CriarLivro(Livro livro) {

            IObjectContainer dataBase = Db4oFactory.OpenFile(pathName);
            try
            {
                dataBase.Store(livro);
            }
            catch (Exception error)
            {
                Console.WriteLine("Estamos com erro ao criar um livro - {0}", error);
            }
            finally 
            {
                dataBase.Close();
            }
        }


        public void ApagarLivro(Livro livro)
        {
            livros.Remove(livro);
        }

        public Livro PegarLivro(Livro livro)
        {
          return  livros.Find(x => x.nome == livro.nome);
        }

        public string ImprimirLivros() 
        {
            IObjectContainer dataBase = Db4oFactory.OpenFile(pathName);
            string texto = "";

            try
            {

            }
            catch (Exception error)
            {
                Console.WriteLine("Estamos com erro ao Imprimir os livros - {0}", error);
            }
            finally 
            {
                dataBase.Close();
            }

            for (int i = 0; i < livros.Count; i++)
            {
                texto += $"{livros[i].Nome}\n";
            }

            return texto;
        }

    }
}
