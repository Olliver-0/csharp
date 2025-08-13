public class Livro
{
  // propriedades
  public string titulo;
  public string autor;
  public string isbn;
  public int anoPublicacao;
  public int paginas;


  // métodos
  public Livro(string cod, string tit, string aut, int ano, int pag)
  {
    isbn = cod;
    titulo = tit;
    autor = aut;
    anoPublicacao = ano;
    paginas = pag;
  }

  public void ImprimirDados()
  {
    Console.WriteLine("Dados do livro1");
    Console.WriteLine($"ISBN : {isbn}");
    Console.WriteLine($"TITULO : {titulo}");
    Console.WriteLine($"AUTOR : {autor}");
    Console.WriteLine($"ANO DE PUB. : {anoPublicacao}");
    Console.WriteLine($"NUM DE PAG. : {paginas}");
  }

}