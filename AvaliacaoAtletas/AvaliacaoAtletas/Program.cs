// Exercício 2: Sistema de Avaliação de Atletas
//  Crie um programa em C# que simule a avaliação de desempenho de até 20
//  atletas em uma competição esportiva. O sistema deve:
// Permitir a entrada do nome do atleta e suas 3 pontuações (valores
//  entre 0 e 100) em uma prova.
//  Validar que o nome não seja vazio e que as pontuações estejam no
//  intervalo permitido.
//  Calcular a média das 3 pontuações de cada atleta.
//  Determinar a classificação (Aprovado se média ≥ 70, Reprovado caso
//  contrário).
//  Exibir um relatório com o nome, as 3 pontuações, a média e a
//  classificação de cada atleta, além da média geral da competição e o
//  percentual de atletas aprovados.
//  Organizar o código em funções para entrada de dados, cálculo de
//  médias, verificação de classificação e geração do relatório.

const int MAX_ATHLETES = 20;
const int MAX_SCORES = 3;
const float MIN_MEDIA_APPROVAL = 70f;

string[] names = new string[MAX_ATHLETES];
int[,] allScores = new int[MAX_ATHLETES, MAX_SCORES];
float[] medias = new float[MAX_ATHLETES];
bool[] approved = new bool[MAX_ATHLETES];
float totalMedia = 0f;
float approvedPercent = 0f;
int athleteCounter = 0;

Console.Clear();
Console.WriteLine("-------------------------------------------------");
Console.WriteLine("Seja muito bem-vindo! Avalie seus atletas aqui!\n");

Rating();

if (athleteCounter > 0)
{
  CalcMedias();
  Classify();
  ShowReport();
}
else
{
  Console.WriteLine("Nenhum atleta foi cadastrado.");
}

Console.WriteLine("\nPressione qualquer tecla para sair do programa.");
Console.ReadKey(true);
Console.Clear();

void Rating()
{
  string continueResponse;

  do
  {
    while (true)
    {
      Console.Write($"\nDigite o nome do {athleteCounter + 1}º atleta: ");
      string currentName = Console.ReadLine();
      if (!string.IsNullOrEmpty(currentName))
      {
        names[athleteCounter] = currentName;
        break;
      }
      Console.WriteLine("Erro: O nome não pode ser vazio. Tente novamente.");
    }

    for (int i = 0; i < MAX_SCORES; i++)
    {
      while (true)
      {
        Console.Write($"Digite a {i + 1}ª pontuação: ");
        int score = int.Parse(Console.ReadLine());

        if (score >= 0 && score <= 100)
        {
          allScores[athleteCounter, i] = score;
          break;
        }
        else
        {
          Console.WriteLine("Erro: A pontuação deve ser um número entre 0 e 100.");
        }
      }
    }

    athleteCounter++;

    if (athleteCounter < MAX_ATHLETES)
    {
      Console.Write("\nDeseja avaliar mais um atleta? [s/n]: ");
      continueResponse = Console.ReadLine();
    }
    else
    {
      Console.WriteLine("\nLimite máximo de atletas atingido.");
      continueResponse = "n";
    }

  } while (continueResponse == "s");
}

void CalcMedias()
{
  float totalSum = 0;
  for (int i = 0; i < athleteCounter; i++)
  {
    int individualSum = 0;
    for (int j = 0; j < MAX_SCORES; j++)
    {
      individualSum += allScores[i, j];
    }
    medias[i] = (float)individualSum / MAX_SCORES;
    totalSum += medias[i];
  }
  totalMedia = totalSum / athleteCounter;
}

void Classify()
{
  int approvedCounter = 0;
  for (int i = 0; i < athleteCounter; i++)
  {
    if (medias[i] >= MIN_MEDIA_APPROVAL)
    {
      approved[i] = true;
      approvedCounter++;
    }
    else
    {
      approved[i] = false;
    }
  }

  if (athleteCounter > 0)
  {
    approvedPercent = (float)approvedCounter / athleteCounter * 100;
  }
}

void ShowReport()
{
  Console.WriteLine("\n-------------------------------------------------");
  Console.WriteLine("Relatório Individual dos Atletas");
  Console.WriteLine("-------------------------------------------------");

  for (int i = 0; i < athleteCounter; i++)
  {
    Console.WriteLine($"\nAtleta #{i + 1}");
    Console.WriteLine($"Nome: {names[i]}");
    Console.Write("Pontuações: ");
    for (int j = 0; j < MAX_SCORES; j++)
    {
      Console.Write($"{allScores[i, j]} ");
    }
    Console.WriteLine($"\nMédia: {medias[i]:F2}");
    Console.WriteLine($"Classificação: {(!approved[i] ? "Reprovado" : "Aprovado")}");
  }

  Console.WriteLine("\n-------------------------------------------------");
  Console.WriteLine("Relatório Geral da Competição");
  Console.WriteLine("-------------------------------------------------");
  Console.WriteLine($"Média Geral: {totalMedia:F2}");
  Console.WriteLine($"Percentual de atletas aprovados: {approvedPercent:F2}%");
}
