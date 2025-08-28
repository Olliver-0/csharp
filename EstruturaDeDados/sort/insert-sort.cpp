// Insertion Sort

#include <iostream>
#include <string>
#include <vector>

using namespace std;

main() {
	vector<string> nomes;
	int x, y;
	string temp;
	
	nomes.push_back("Catatau");
	nomes.push_back("Ze Colmeia");
	nomes.push_back("Xunda");
	nomes.push_back("Gonzo");
	nomes.push_back("Tiao Gaviao");
	nomes.push_back("Mutley");
	nomes.push_back("Pombo Dudley");
	nomes.push_back("Capitao Caverna");
	
	// mostra os dados originais
	cout << "---=== Dados originais ===---" << endl;
	for (x = 0; x < nomes.size(); x ++) {
		cout << nomes[x] << endl;
	}
	cout << endl;
	
	// ordena os dados coom Insertion Sort
	for (x = 1; x < nomes.size(); x++) {
		temp = nomes[x];
		y = x - 1;
		while (y >= 0 && nomes[y] > temp) {
			nomes[y + 1] = nomes[y];
			y--;
		}
		nomes[y + 1] = temp;
	}
	// mostra os dados ordenados
	cout << "---=== Dados ordenados ===---" << endl;
	for (x = 0; x < nomes.size(); x ++) {
		cout << nomes[x] << endl;
	}
	cout << endl;
}
