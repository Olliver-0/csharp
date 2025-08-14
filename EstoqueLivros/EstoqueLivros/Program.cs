const int MAX_BOOKS = 50;

string[] titles = new string[MAX_BOOKS];
int[] qtdBooks = new int[MAX_BOOKS];
float[] prices = new float[MAX_BOOKS];
float[] totalPrices = new float[MAX_BOOKS];

Console.WriteLine("------------------------------------------------------------------------");
int bookCount = Register();

Console.Clear();

CalcTotal(titles, qtdBooks, prices, totalPrices);
ShowReport(titles, qtdBooks, prices, totalPrices);

Console.WriteLine("Pressione qualquer tecla para sair do programa.");
Console.ReadKey(true);
Console.Clear();

int Register()
{
  string title;
  int qtdBook;
  float price;
  string res;
  int counter = 0;

  Console.WriteLine("Bem-vindo ao Registro de Livros! Cadastre os livros do seu estoque aqui!\n");

  do
  {
    Console.WriteLine("Digite o título do livro: ");
    title = Console.ReadLine();

    Console.WriteLine("Digite o a quantidade em estoque do livro: ");
    qtdBook = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o preço do livro: ");
    price = float.Parse(Console.ReadLine());

    if (Validate(title, qtdBook, price))
    {
      titles[counter] = title;
      qtdBooks[counter] = qtdBook;
      prices[counter] = price;

      counter++;
    }
    else
    {
      Console.Write("Dados inválidos. Verifique se:\n1- O título não está vazio\n2- A quantidade é maior ou igual a zero\n3- O preço está entre R$10,00 e R$500,00");
    }

    Console.WriteLine("Deseja cadastrar mais um livro? [s/n]: ");
    res = Console.ReadLine();
  } while (res == "s" && counter < 50);

  return counter;
}

bool Validate(string title, int qtdBook, float price)
{
  if (string.IsNullOrWhiteSpace(title) || qtdBook < 0 || price < 10.00 || price > 500.00)
  {
    return false;
  }

  return true;
}

void CalcTotal(string[] titles, int[] qtdBooks, float[] prices, float[] totalPrices)
{
  for (int i = 0; i < bookCount; i++)
  {
    totalPrices[i] = qtdBooks[i] * prices[i];
  }
}

bool IsAvailable(int qtdBook) {
  if (qtdBook > 0)
  {
    return true;
  }
  else
  {
    return false;
  }
}

void ShowReport(string[] titles, int[] qtdBooks, float[] prices, float[] totalPrices)
{
  Console.WriteLine("------------------------------------------------------------------------");
  Console.WriteLine("Relatório de Livros\n");

  float totalPricesInStock = 0;
  int availabilityCounter = 0;

  for (int i = 0; i < bookCount; i++)
  {
    string avaiable;

    if (IsAvailable(qtdBooks[i]))
    {
      avaiable = "Disponível";
      availabilityCounter += qtdBooks[i];
    }
    else
    {
      avaiable = "Indisponível";
    }

    for (int j = 0; j < bookCount; j++) totalPricesInStock += totalPrices[j];

    Console.WriteLine($"\t\tLivro {i + 1}\n");
    Console.WriteLine($"Título: {titles[i]}");
    Console.WriteLine($"Quantidade: {qtdBooks[i]}");
    Console.WriteLine($"Preço unitário: {prices[i]:C}");
    Console.WriteLine($"Valor total: {totalPrices[i]:C}");
    Console.WriteLine($"Disponibilidade: {avaiable}\n");
  }

  Console.WriteLine("------------------------------------------------------------------------");

  Console.WriteLine("Relatório de Estoque\n\n");
  Console.WriteLine($"Valor total do estoque: {totalPricesInStock:C}");
  Console.WriteLine($"Quantidade de livros disponíveis: {availabilityCounter}");
}
