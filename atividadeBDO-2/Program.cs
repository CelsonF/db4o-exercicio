using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atividadeBDO_2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string livroAutor;
            string livroEditora;
            string livroBor;

            //Registro de autores,livros e editoras
            Autor oda = new Autor(1, "Eiichiro Oda");
            Autor akiraToriyama = new Autor(2, "Akira Toriyama");
            Autor masashiKishimoto = new Autor(3, "Masashi Kishimoto");
            Autor bobKane = new Autor(4, "Bob Kane");
            Autor jerrySiegel = new Autor(5, "Jerry Siegel");
            
            Editora shonenJump = new Editora(1, "Shonen Jump");
            Editora dcComics = new Editora(2, "DC Comics");

            Livro onePiece = new Livro(1, "One Piece", oda, shonenJump, 1997);
            Livro dragonBallClassico = new Livro(2, "Dragon Ball Classico", akiraToriyama, shonenJump, 1986);
            Livro dragonBallZ = new Livro(3, "Dragon Ball Z", akiraToriyama, shonenJump, 1989);
            Livro naruto = new Livro(4, "Naruto", masashiKishimoto, shonenJump, 1999);
            Livro batman = new Livro(5, "Batman", bobKane, dcComics, 1939);
            Livro superman = new Livro(6, "Surperman", jerrySiegel, dcComics, 1938);


            //Criando acesso ao serviço
            Services services = new Services();

            try
            {
                //Salvar no banco Db4o
                services.CriarLivro(onePiece);
                services.CriarLivro(dragonBallClassico);
                services.CriarLivro(dragonBallZ);
                services.CriarLivro(naruto);
                services.CriarLivro(batman);
                services.CriarLivro(superman);
            }
            catch (Exception exc)
            {
                Console.WriteLine("Ocorreu um erro ao Salvar os livros no banco DB4O - log {0}", exc);
            }

            Console.WriteLine("Buscando todos os Livros:");
            services.RetornarLivros();

            Console.WriteLine("\nPressione alguma tecla para ir para próxima parte  do teste da aplicação.\n");
            Console.ReadKey();

            Console.WriteLine("\nAgora digite o nome de uma Editora para verificarmos se iremos encotra-la");
            livroEditora = Console.ReadLine();
            services.RetornarLivrosEditora(livroEditora);

            Console.ReadKey();
        }
    }
}
