#include <iostream>
#include <string>
#include <vector>

using namespace std;

main() {
	vector<string> dados;
	dados.push_back("Catatau");
	dados.push_back("Ze Colmeia");
	dados.push_back("Xunda");
	dados.push_back("Gonzo");
	dados.push_back("Tiao Gaviao");
	dados.push_back("Mutley");
	dados.push_back("Pombo Dudley");
	dados.push_back("Capitao Caverna");
	
	int x, y;
	string temp;
	
	system("cls");
	
	cout << "Dados originais do vetor" << endl;
	cout << "------------------------" << endl;
	for (x = 0; x < dados.size(); x++) {
		cout << dados[x] << endl;
	}
	
	// bubble sort
	for (x = 0; x < dados.size(); y++) {
		for (y = x + 1; y < dados.size(); y++) {
			if (dados[x] > dados[y]) {
				temp = dados[x];
				dados[x] = dados[y];
				dados[y] = temp;
			}
		}
	}
	
	//mostra os dados ordenados
	cout << endl << "Dados ordenados do vetor" << endl;
	cout << "------------------------" << endl;
	for (x = 0; x < dados.size; x++)
	{
		cout << dados[x] << endl;
	}

	getch();
}
