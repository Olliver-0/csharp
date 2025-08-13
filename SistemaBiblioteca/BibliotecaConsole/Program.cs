Console.Clear();
Console.WriteLine("---=== Sistema de Biblioteca ===---");

// cria o objetivo livro 1
Livro livro1 = new("123", "O Senhor dos Anéis", "JRR Tolkien", 2015, 1247);

// cria o objetivo livro 2
Livro livro2 = new("437", "Ilíada", "Homero", 2020, 421);

// mostra na tela os dados do objeto 1

livro1.ImprimirDados();
livro2.ImprimirDados();
