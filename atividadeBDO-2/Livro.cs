namespace atividadeBDO_2
{
    public class Livro
    {
        public int codigo;
        public string nome;
        public Autor autor;
        public Editora editora;
        public int ano;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Nome { get => nome; set => nome = value; }
        public Autor Autor { get => autor; set => autor = value; }
        public Editora Editora { get => editora; set => editora = value; }
        public int Ano { get => ano; set => ano = value; }
       

        public Livro(int codigo, string nome, Autor autor, Editora editora, int ano)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Autor = autor;
            this.Editora = editora;
            this.Ano = ano;
        }

    }
}
