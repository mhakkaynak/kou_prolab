#include <LiquidCrystal.h>
#include <SPI.h>
#include <SD.h>
#include <math.h>
#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#define KIRMIZILED 8
#define YESILLED 9

File dosya;
const int rs = 7, en = 6, d4 = 5, d5 = 4, d6 = 3, d7 = 2;
LiquidCrystal lcd(rs, en, d4, d5, d6, d7);
String para_string;
String hizmet_string[4];
String hizmet_isim[4] = {"Kopukleme","Yikama","Kurulama","Cilalama"};
int kasa_bilgileri[5] = {0, 0, 0, 0, 0};
int paralar[5] = {5, 10, 20, 50, 100};
int hizmetler_kasa[4] = {0, 0, 0, 0};
int hizmetler[4] = {0, 0, 0, 0};
int hizmet_fiyat[4] = {0, 0, 0, 0};
int yuklenen_tutar = 0;
int para_ustu[5] = {0, 0, 0, 0, 0};
int odenecek_tutar = 0;
int secim = 0;
int random_sayi = 0;

void dosya_yazma_baslangic();
void dosya_yazma();
void dosya_okuma();
void kasa_bilgileri_olusturma();
void hizmet_bilgileri_olusturma();
void lcd_satir_temizleme(int i);
void para_yukleme();
void hizmet_secimi();
int odenecek_tutari_bulma();
void para_ustu_bulma();

void setup() {
  pinMode(KIRMIZILED, OUTPUT);
  pinMode(YESILLED, OUTPUT);
  Serial.begin(9600);
  lcd.begin(16, 2);
  while (!Serial) {
    ;
  } 
  lcd.setCursor(0, 0);
  lcd.print("Yukleniyor");
  pinMode(10, OUTPUT);
  digitalWrite(10, HIGH);
  if (!SD.begin(10))
  {
    lcd.clear();
    lcd.print("Hata");
    while (1);
  }
  dosya_okuma();
}

void loop() {
  if (secim == 0)
  {
    lcd.setCursor(0, 0);
    lcd.print("Para Yukleme: ");
    para_yukleme();
    delay(200);
  }
  else if (secim == 1)
  {
    lcd.setCursor(0, 0);
    lcd.print("Hizmet Secimi: ");
    hizmet_secimi();
    delay(200);
  }
  else if (secim == 2)
  {
    if(random_sayi != 2)
    { 
      random_sayi = random(1, 5);
    }
    if (random_sayi == 2)
    {
      lcd.setCursor(0, 0);
      lcd.print("PARA SIKISTI");
      digitalWrite(KIRMIZILED, HIGH);
      random_sayi = 0;
      delay(400);
    } 
    else
    {
      digitalWrite(YESILLED, HIGH);
      lcd.setCursor(0, 0);
      lcd.print("Odenecek Tutar: ");
      odenecek_tutar = odenecek_tutari_bulma();
      lcd.setCursor(0, 1);
      lcd.print(odenecek_tutar);
      lcd.print(" TL");
      lcd.setCursor(0, 0);
      para_ustu_bulma();
    }
  }
  int button = analogRead(A0);
  if(button > 950 && button < 960)
  {
    yuklenen_tutar = 0;
    dosya_okuma();
    lcd.clear();
          for (int i = 0; i < 5; i++)
      {
        if(i != 4)
        {
          hizmetler[i] = 0;
        }
        para_ustu[i] = 0;
      }
    secim = 0;
  }
}

void dosya_yazma_baslangic() {
  dosya = SD.open("hizmet.txt", FILE_WRITE);
  if (dosya)
  {
    dosya.println("0,0,0,0,0");
    dosya.println("1,Kopukleme,30,15 TL");
    dosya.println("2,Yikama,50,10 TL");
    dosya.println("3,Kurulama,100,5 TL");
    dosya.println("4,Cilalama,20,50 TL");
    dosya.close();
    dosya_okuma();
  }
  else
  {
    lcd.clear();
    lcd.setCursor(0 ,0);
    lcd.print("Hata");
  }
}

void dosya_yazma() {
  SD.remove("hizmet.txt");
  dosya = SD.open("hizmet.txt", FILE_WRITE);
  if (dosya)
  {
    for(int i = 0; i < 5; i++)
    {
      dosya.print(kasa_bilgileri[i]);
      dosya.print(",");
    }
    dosya.println();
    for(int  i = 0; i < 4; i++)
    {
     dosya.print(i+1);
     dosya.print(",");
     dosya.print(hizmet_isim[i]);
     dosya.print(",");
     dosya.print(hizmetler_kasa[i]);
     dosya.print(",");
     dosya.print(hizmet_fiyat[i]);
     dosya.print(" TL");
     dosya.println();
    }
    dosya.println("Para ustu:");
    for(int i = 0 ; i < 5; i++)
    {
      dosya.print(para_ustu[i]);
      dosya.print(" adet ");
      dosya.print(paralar[i]);
      dosya.println(" TL");
      Serial.println(String(para_ustu[i]) + " adet " + String(paralar[i]) + " TL");
    }
    dosya.close();
  }
  else
  {
    lcd.setCursor(0,0);
    lcd.print("Hata");
  }
}

void dosya_okuma() {
  dosya = SD.open("hizmet.txt");
  int i = 0;
  if (dosya)
  {
    while (dosya.available())
    {
      if( i < 5)
      {
        if(i == 0)
        {
          para_string = dosya.readStringUntil('\n');
        }
        else 
        {
          hizmet_string[i-1] = dosya.readStringUntil('\n');
        }
        i++;
      }
      else
      {
        break;
      }
    }
    dosya.close();
  }
  else
  {
    dosya_yazma_baslangic();
    lcd.setCursor(0,0);
    lcd.print("Hata");
  }
  kasa_bilgileri_olusturma();
  hizmet_bilgileri_olusturma();
}

void kasa_bilgileri_olusturma(){
  char *delp;
  int i;
  int j = 0; 
  int para = 0;
  int delp_boyut;
  char para_dizi[para_string.length()];
  para_string.toCharArray(para_dizi, para_string.length());
  delp = strtok (para_dizi, ",");
  while (delp != NULL) 
  {
    delp_boyut = strlen(delp);
    para = 0;
    for(i = 0; i < delp_boyut; i++)
    {
      para += ((int)delp[i]-48) * pow(10, (strlen(delp)-i-1));
    }
    kasa_bilgileri[j] = para;
    delp = strtok (NULL, " ,");
    j++;
  }
}

void hizmet_bilgileri_olusturma(){
  char *delp;
  int j = 0; 
  int k = 0; 
  int l = 0;
  for(int i = 0; i < 4; i++)
  {
    char hizmet_dizi[hizmet_string[i].length()];
    hizmet_string[i].toCharArray(hizmet_dizi, hizmet_string[i].length());
    delp = strtok (hizmet_dizi, ","); // buradan id leri alabilsin.
    j = 0;
    while(delp != NULL)
    {
      if(j != 0 && j%3 == 0)
      {
        hizmet_fiyat[k] = (int)atoi(delp);
        k++;
      }
      if(j!=0 &&  (j+1)%3==0)
      {
        hizmetler_kasa[l] = (int)atoi(delp);
        l++;
      }
      delp = strtok(NULL, ",");
      j++;
    }
  }
}

void lcd_satir_temizleme(int i){
  lcd.setCursor(0, i);
  lcd.print("                ");
  lcd.setCursor(0, i);
}

void para_yukleme() {
  int button = analogRead(A0);

  if (button > 1010)
  {
    kasa_bilgileri[0]++;
    yuklenen_tutar += 5;
  }
  else if (button > 1000)
  {
    kasa_bilgileri[1]++;
    yuklenen_tutar += 10;
  }

  else if (button > 990)
  {
    kasa_bilgileri[2]++;
    yuklenen_tutar += 20;
  }
  else if (button > 980)
  {
    kasa_bilgileri[3]++;
    yuklenen_tutar += 50;
  }
  else if (button > 970)
  {
    kasa_bilgileri[4]++;
    yuklenen_tutar += 100;
  }
  else if (button > 960)
  {
    lcd.clear();
    secim = 1;
  }
  if (secim == 0)
  {
    lcd.setCursor(0, 1);
    lcd.print(yuklenen_tutar);
    lcd.print("TL para attiniz.");
  }
}

void hizmet_secimi() {
  int button = analogRead(A0);
  lcd.setCursor(0, 1);
  int i = 5;
  if (button > 1010)
  {
    i = 0;
    lcd_satir_temizleme(1);
    lcd.print("Kopukleme");
  }
  else if (button > 1000)
  {
    i = 1;
    lcd_satir_temizleme(1);
    lcd.print("Yikama");
  }

  else if (button > 990)
  {
    i = 2;
    lcd_satir_temizleme(1);
    lcd.print("Kurulama");
  }
  else if (button > 980)
  {
    i = 3;
    lcd_satir_temizleme(1);
    lcd.print("Cilalama");
  }
  else if (button > 970)
  {
    Serial.println("Secilen hizmetler: ");
    for(int i = 0; i < 4; i++)
    {
      Serial.println(hizmet_isim[i] + ": "+hizmetler[i]);
    }
    lcd.clear();
    secim = 2;
  }
  if(i < 4)
  {
    if(hizmetler_kasa[i] > 0)
    {
      hizmetler[i]++;
      hizmetler_kasa[i]--;
    }
    else{
      lcd_satir_temizleme(1);
      lcd.print("Hizmet tukendi");
    }
  }
}

int odenecek_tutari_bulma() {
  int odenecek_tutar = 0;
  for (int i = 0; i < 4; i++)
  {
    odenecek_tutar += hizmetler[i] * hizmet_fiyat[i];
  }
  return odenecek_tutar;
}

void para_ustu_bulma() {
  lcd.setCursor(0, 1);
  int verilecek_para = 100;
  int toplam_para_ustu = yuklenen_tutar - odenecek_tutar;
  int i = 4;
  Serial.println("Yuklenen tutar: " + String(yuklenen_tutar));
  Serial.println("Odenecek tutar: " + String(odenecek_tutar));
  Serial.println("Para ustu: " + String(toplam_para_ustu));
  if (toplam_para_ustu < 0)
  {
    lcd.print("Eksik odeme");
    delay(1000);
  }
  else
  { 
      while (toplam_para_ustu > 0)
      {
        if(kasa_bilgileri[i] > 0)
        {
          if (toplam_para_ustu >= paralar[i])
          {
            para_ustu[i] = para_ustu[i] + 1;
            toplam_para_ustu -= paralar[i];
            kasa_bilgileri[i]--;
          }
          else
          {
            i--;
          }
        }
        else
        {
          i--;
        }
    }
  if(toplam_para_ustu > 0)
  {
    lcd.print("Kasada para yoktur");
    delay(1000);
  }
  else
  {
    dosya_yazma();
  }
  secim = 4;
  }
}
