#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdarg.h>
// Bu proje Erce Uslu-190202083 ve Muhammed Halil Akkaynak-190202075 tarafindan yapilmýstir.
typedef struct Struct {
	char* kelime;
	int kelimeSayisi;
	struct Struct* sonraki;
}Dugum;

int sayac(Dugum* dugum, char kelime[]);
Dugum* ekle(Dugum* dugum, char kelime[]);
void EkranaBas(Dugum* dugum);
Dugum* sil(Dugum* dugum, char kelime[]);

int main()
{
	Dugum* dugum;
	dugum = (Dugum*)malloc(sizeof(Dugum));
	dugum->kelime = ""; 
	dugum->kelimeSayisi = 1;
	dugum->sonraki = NULL;
	FILE* dosya;
	dosya = fopen("metin.txt", "r");
	char kelime[100];
	if (dosya != NULL)
	{
		while (!feof(dosya))
		{
			fscanf(dosya, "%s", &kelime);
			ekle(dugum, kelime);
		}
		EkranaBas(dugum);
	}
	else
	{
		printf("Hata");
	}
	fclose(dosya);
	free(dugum);
}

Dugum* ekle(Dugum* dugum, char kelime[]) {
	int kelimeSayisi = sayac(dugum, kelime);
	if (kelimeSayisi != 1) 
	{
		sil(dugum, kelime);
	}
	if (dugum == NULL) 
	{
		dugum = (Dugum*)malloc(sizeof(Dugum));
		dugum->sonraki = NULL;
		dugum->kelime = malloc(strlen(kelime) + 1);
		strcpy(dugum->kelime, kelime);
		dugum->kelimeSayisi = 1;
		return dugum;
	}
	if (dugum->kelimeSayisi > kelimeSayisi) 
	{
		Dugum* gecici = (Dugum*)malloc(sizeof(Dugum));
		gecici->kelimeSayisi = kelimeSayisi;
		gecici->kelime = malloc(strlen(kelime) + 1);
		strcpy(gecici->kelime, kelime);
		gecici->sonraki = dugum;
		return gecici;
	}
	Dugum* iter = dugum;
	while (iter->sonraki != NULL && iter->sonraki->kelimeSayisi < kelimeSayisi)
	{
		iter = iter->sonraki;
	}
	Dugum* gecici = (Dugum*)malloc(sizeof(Dugum));
	gecici->sonraki = iter->sonraki;
	iter->sonraki = gecici;
	gecici->kelimeSayisi = kelimeSayisi;
	gecici->kelime = malloc(strlen(kelime) + 1);
	strcpy(gecici->kelime, kelime);
	return dugum;
}

int sayac(Dugum* dugum, char kelime[]) {
	Dugum* iter = dugum;
	int kelimeSayisi = 1;
	if (strncmp(iter->kelime, kelime, 100) == 0) {
		kelimeSayisi = iter->sonraki->kelimeSayisi;
		kelimeSayisi++;
	}
	while (iter->sonraki != NULL) {
		if (strncmp(iter->sonraki->kelime, kelime, 100) == 0) 
		{
			kelimeSayisi = iter->sonraki->kelimeSayisi;
			kelimeSayisi++;
		}
		iter = iter->sonraki;
	}
	return kelimeSayisi;
}

Dugum* sil(Dugum* dugum, char kelime[]) {
	Dugum* gecici;
	Dugum* iter = dugum;
	if (strncmp(dugum->kelime, kelime, 100) == 0) 
	{
		gecici = dugum;
		dugum = dugum->sonraki;
		free(gecici);
		return dugum;
	}
	while (iter->sonraki != NULL)
	{
		if (strncmp(iter->sonraki->kelime, kelime, 100) == 0)
		{
			gecici = iter->sonraki;
			iter->sonraki = iter->sonraki->sonraki;
			free(gecici);
			return dugum;
		}
		iter = iter->sonraki;
	}
}

void EkranaBas(Dugum* dugum) {
	Dugum* iter = dugum;
	int i=1;
	while (iter)
	{
		if (iter->kelime != "") 
		{
			printf("%d : %s : %d\n", i, iter->kelime, iter->kelimeSayisi);
			i++;
		}
		iter = iter->sonraki;
	}
}
