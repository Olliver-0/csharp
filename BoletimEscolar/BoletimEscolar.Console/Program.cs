// Início do programa

const int MAX_ALUNOS = 30;
const int NUM_NOTAS = 4;

string[] nomes = new string[MAX_ALUNOS];
float[,] notas = new float[MAX_ALUNOS, NUM_NOTAS];
int numAlunos;

numAlunos = LerNumeroAlunos();
LerDadosAlunos(nomes, notas, numAlunos);
ExibirRelatorio(nomes, notas, numAlunos);

Console.ReadKey();
// Fim do programa

/********************************
***    Funções do Programa    ***
********************************/

static int LerNumeroAlunos()
{
  int num;
  do
  {
    Console.Write("Digite o número de alunos (1 a {0}): ", MAX_ALUNOS);
    num = int.Parse(Console.ReadLine() ?? "");
  } while (num < 1 || num > MAX_ALUNOS);
  return num;
}

static void LerDadosAlunos(string[] nomes, float[,] notas, int numAlunos)
{
  for (int i = 0; i < numAlunos; i++)
  {
    Console.WriteLine($"\nAluno {i + 1}: ");
    do
    {
      Console.Write("Digite o nome: ");
      nomes[i] = Console.ReadLine() ?? "";
    } while (string.IsNullOrWhiteSpace(nomes[i]));

    for (int j = 0; j < NUM_NOTAS; j++)
    {
      do
      {
        Console.Write($"Digite a nota {j + 1} (0 a 10): ");
        notas[i, j] = float.Parse(Console.ReadLine() ?? "");
      } while (notas[i, j] < 0 || notas[i, j] > 10);
    }
  }
}

static float CalcularMedia(float[,] notas, int aluno)
{
  float soma = 0;
  for (int j = 0; j < NUM_NOTAS; j++)
  {
    soma += notas[aluno, j];
  }
  return soma / NUM_NOTAS;
}

static string VerificarSituacao(float media)
{
  return media >= 7 ? "Aprovado" : "Reprovado";
}

static void ExibirRelatorio(string[] nomes, float[,] notas, int numAlunos)
{
  Console.WriteLine("\n=== Relatório Final ===");
  Console.WriteLine("Nome\t\tMédia\tSituação");
  Console.WriteLine("----------------------------");

  float somaMedias = 0;
  int aprovados = 0;

  for (int i = 0; i < numAlunos; i++)
  {
    float media = CalcularMedia(notas, i);
    string situacao = VerificarSituacao(media);
    somaMedias += media;
    if (situacao == "Aprovado") aprovados++;

    Console.WriteLine($"{nomes[i],-15}\t{media:F2}\t{situacao}");
  }

  float mediaTurma = somaMedias / numAlunos;
  float percentualAprovados = (float)aprovados / numAlunos * 100;

  Console.WriteLine("\nEstatísticas da turma:");
  Console.WriteLine($"Média geral: {mediaTurma:F2}");
  Console.WriteLine($"Percentual de aprovados: {percentualAprovados:F2}%");
}
