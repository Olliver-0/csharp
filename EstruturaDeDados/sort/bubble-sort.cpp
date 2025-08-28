#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <conio.h>

#define MAX_STRINGS 8 
#define MAX_TAM_STRING 20

int main()
{
	/*forma 1
	char dados[MAX_STRINGS][MAX_TAM_STRING];

	dados[0] = "Catatau";
	dados[1] = "Zoe Colmeia";
	dados[2] = "Xunda",
	dados[3]	"Gonzo",
	dados[4]	"Tiao Gaviao",
	dados[5]	"Mutley",
	dados[6]	"Pombo Dudley",
	dados[7]	"Capitao Caverna"
	*/
	
	//forma 2
	char dados[MAX_STRINGS][MAX_TAM_STRING] = {
		"Catatau",
		"Ze Colmeia",
		"Xunda",
		"Gonzo",
		"Tiao Gaviao",
		"Mutley",
		"Pombo Dudley",
		"Capitao Caverna"
	};
	
	int x, y;
	char temp[MAX_TAM_STRING];
	
	system("cls");
	printf("Dados originais do vetor\n");
	printf("------------------------\n");
	for (x=0; x<MAX_STRINGS; x++)
	{
		printf("%s \n", dados[x]);
	}
	
	//bubble sort 
	for(x = 0; x < MAX_STRINGS; x++){
		for (y = x+1; y < MAX_STRINGS; y++){
			if (strcmp(dados[x], dados [y]) > 0 ) {
				strcpy(temp    , dados[x]);
				strcpy(dados[x], dados[y]);
				strcpy(dados[y], temp    );
			}
		}
	}
	
	//mostra os dados ordenados
	printf("Dados ordenados do vetor\n");
	printf("------------------------\n");
		for (x=0; x<MAX_STRINGS; x++)
	{
		printf("%s \n", dados[x]);
	}

	getch();
	return 0;
	}

