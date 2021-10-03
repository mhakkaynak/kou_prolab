using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public Transform[] slots;
    public Transform[] slotspc;

    List<Futbolcu> futlist = new List<Futbolcu>();
    ArrayList liste = new ArrayList();
    List<Basketbolcu> baslist = new List<Basketbolcu>();

    Kullanici kullanici = new Kullanici(1,"Kullanici",0);
    Bilgisayar bilgisayar = new Bilgisayar(2,"Bilgisayar",0);
    

    public bool futbolturu = true;
    Oyuncu oyuncuu = new Oyuncu();
    public int sayac = 0;
    
    public GameObject[] basketkart;
    public GameObject[] futbolkart;
    
    public int buttonsecim;

    public Text kullanicitext;
    public Text pctext;

    public Text k1;
    public Text k2;
    public Text k3;
    public Button buton;
    public Text ozellik;

    public Text p1;
    public Text p2;
    public Text p3;
    public void tekrarOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    void listehazirlaFutbol()
    {

        Futbolcu futbolcu = new Futbolcu("Maradona", "Napoli", 100, 100, 100, false, futbolkart[0]);
        Futbolcu futbolcu2 = new Futbolcu("Drogba", "Chelsea", 87, 55, 92, false, futbolkart[1]);
        Futbolcu futbolcu3 = new Futbolcu("Alex", "Fenerbahce", 93, 85, 69, false, futbolkart[2]);
        Futbolcu futbolcu4 = new Futbolcu("Guiza", "Fenerbahce", 66, 32, 30, false, futbolkart[3]);
        Futbolcu futbolcu5 = new Futbolcu("Burak Yilmaz", "Besiktas", 78, 70, 85, false, futbolkart[4]);
        Futbolcu futbolcu6 = new Futbolcu("Merih Demiral", "Juventus", 66, 31, 29, false, futbolkart[5]);
        Futbolcu futbolcu7 = new Futbolcu("Hakan Calhanoglu", "Milan", 85, 88, 70, false, futbolkart[6]);
        Futbolcu futbolcu8 = new Futbolcu("Ronaldinho", "Barcelona", 90,80, 92, false, futbolkart[7]);
        
        futlist.Add(futbolcu);
        futlist.Add(futbolcu2);
        futlist.Add(futbolcu3);
        futlist.Add(futbolcu4);
        futlist.Add(futbolcu5);
        futlist.Add(futbolcu6);
        futlist.Add(futbolcu7);
        futlist.Add(futbolcu8);
        for (int i = 0; i < futlist.Count; i++)
        {
            oyuncuu.futlist2.Add(futlist.ElementAt(i));
        }


    }
    void listehazirlaBasket()
    {

        Basketbolcu basketbolcu = new Basketbolcu("Kobe Bryant", "L.A Lakers", 100, 100, 100, false,basketkart[0]);
        Basketbolcu basketbolcu2 = new Basketbolcu("Larry Bird", "Celtics", 77, 93, 61, false, basketkart[1]);
        Basketbolcu basketbolcu3 = new Basketbolcu("Isaiah Thomas", "Celtics", 68, 83, 91, false, basketkart[2]);
        Basketbolcu basketbolcu4 = new Basketbolcu("Micheal Jordan", "L.A Lakers", 92, 87, 90, false, basketkart[3]);
        Basketbolcu basketbolcu5 = new Basketbolcu("Bogdan Bogdanovic", "Fenerbahce", 70, 64, 83, false, basketkart[4]);
        Basketbolcu basketbolcu6 = new Basketbolcu("Cedi Osman", "Cleaveland", 66, 54, 83, false, basketkart[5]);
        Basketbolcu basketbolcu7 = new Basketbolcu("Toni Kukoc", "Chicago Bulls", 67, 60, 70, false, basketkart[6]);
        Basketbolcu basketbolcu8 = new Basketbolcu("Lebron James", "L.A Lakers", 84, 90, 87, false, basketkart[7]);

        baslist.Add(basketbolcu);
        baslist.Add(basketbolcu2);
        baslist.Add(basketbolcu3);
        baslist.Add(basketbolcu4);
        baslist.Add(basketbolcu5);
        baslist.Add(basketbolcu6);
        baslist.Add(basketbolcu7);
        baslist.Add(basketbolcu8);
        for (int i = 0; i < futlist.Count; i++)
        {
            oyuncuu.baslist2.Add(baslist.ElementAt(i));
        }


    }
    void Start()
    {
        OyunHazirla();             
    }
    public void OyunHazirla()
    {
        listehazirlaFutbol();
        listehazirlaBasket();
        oyuncuu.listeKaristir();
        listeDiz();                      
    }
    public void listeDiz()
    {
        for (int i = 0; i < 4; i++)
        {
            oyuncuu.playerbasketbolcu.ElementAt(i).gameobject.transform.position = slots[i+4].position;
        }
        for (int i = 0; i < 4; i++)
        {
            oyuncuu.playerfutbolcu.ElementAt(i).gameobject.transform.position = slots[i].position;
        }
        for (int i = 0; i < 4; i++)
        {
            oyuncuu.pcbasketbolcu.ElementAt(i).gameobject.transform.position = slotspc[i + 4].position;
            oyuncuu.pcbasketbolcu.ElementAt(i).gameobject.transform.rotation = slotspc[i + 4].rotation;
        }
        for (int i = 0; i < 4; i++)
        {
            oyuncuu.pcfutbolcu.ElementAt(i).gameobject.transform.position = slotspc[i].position;
            
            oyuncuu.pcfutbolcu.ElementAt(i).gameobject.transform.rotation = slotspc[i].rotation;
        }
    }
    
    #region set
    public void setx1()
    {
        buttonsecim = 0;
    }
    public void setx2()
    {
        buttonsecim = 1;
    }

    public void setx3()
    {
        buttonsecim = 2;
    }

    public void setx4()
    {
        buttonsecim = 3;
    }

    public void setx5()
    {
        buttonsecim = 4;
    }

    public void setx6()
    {
        buttonsecim = 5;
    }

    public void setx7()
    {
        buttonsecim = 6;
    }

    public void setx8()
    {
        buttonsecim =7;
    }
    #endregion


    public void KartOyna()
    {
        Debug.Log(bilgisayar.oyuncuAdi);
        
        int secim = kullanici.kartSec(buttonsecim);
        int secim2 = bilgisayar.kartSec(secim);
        Debug.Log("Bilgisayarin secimi! " + secim2);
        if ((futbolturu == true && secim < 4) || futbolturu == false && secim >= 4)
        {
            
            if (secim >= 4)
            {
                Debug.Log("Basketbolcu Turu!");
                secim -= 4;
                secim2 -= 4;
                if (oyuncuu.playerbasketbolcu.ElementAt(secim).isused)
                {
                    return;
                }
                while (true)
                {
                    if (oyuncuu.pcbasketbolcu.ElementAt(secim2).isused)
                    {
                        secim2 = bilgisayar.kartSec(secim);
                        
                    }
                    else if (!oyuncuu.pcbasketbolcu.ElementAt(secim2).isused)
                    {
                        break;
                    }

                }
               
                futbolturu = !futbolturu;
                int kontrol = HamleAyarla();
                Debug.Log("Hamle numarasi: " + kontrol);
                Debug.Log("Kullanicinin indexi " + secim);
                Debug.Log("Pcnin indexi " + secim2);
                ozellik.text = kontrol.ToString();
                Debug.Log("Kullanicinin sectigi kart: " + oyuncuu.playerbasketbolcu.ElementAt(secim).basketbolcuAdi);
                oyuncuu.playerbasketbolcu.ElementAt(secim).sporcuPuaniGoster();
                Debug.Log("Kullanicinin sectigi kart: " + oyuncuu.pcbasketbolcu.ElementAt(secim).basketbolcuAdi);
                oyuncuu.pcbasketbolcu.ElementAt(secim2).sporcuPuaniGoster();
                if (kontrol == 1)
                {
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).ikilik > oyuncuu.pcbasketbolcu.ElementAt(secim2).ikilik)
                    {
                        kullanici.skor += 1;
                        //UI
                        arayuzGuncelleBasketbolcu(secim, secim2);

                        kullanicitext.text = kullanici.skor.ToString();
                        Debug.Log("Oyuncu puan aldi!");
                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = true;


                        Destroy(oyuncuu.playerbasketbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcbasketbolcu.ElementAt(secim2).gameobject);



                    }
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).ikilik < oyuncuu.pcbasketbolcu.ElementAt(secim2).ikilik)
                    {
                        bilgisayar.skor += 1;
                        arayuzGuncelleBasketbolcu(secim, secim2);
                        pctext.text = bilgisayar.skor.ToString();
                        Debug.Log("Bilgisayar puan aldi");
                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerbasketbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcbasketbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).ikilik == oyuncuu.pcbasketbolcu.ElementAt(secim2).ikilik)
                    {
                       if (sayac == 7)
                        {
                            sonDurumBeraberlik(kontrol,1);
                        }
                        Debug.Log("Berabere");
                        arayuzGuncelleBasketbolcu(secim, secim2);
                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = false;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = false;
                    }



                }
                else if (kontrol == 2)
                {
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).ucluk > oyuncuu.pcbasketbolcu.ElementAt(secim2).ucluk)
                    {
                        kullanici.skor += 1;
                        arayuzGuncelleBasketbolcu(secim, secim2);
                        kullanicitext.text = kullanici.skor.ToString();
                        Debug.Log("Oyuncu puan aldi!");
                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerbasketbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcbasketbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).ucluk < oyuncuu.pcbasketbolcu.ElementAt(secim2).ucluk)
                    {
                        bilgisayar.skor += 1;
                        arayuzGuncelleBasketbolcu(secim, secim2);
                        pctext.text = bilgisayar.skor.ToString();
                        Debug.Log("Bilgisayar puan aldi");
                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerbasketbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcbasketbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).ucluk == oyuncuu.pcbasketbolcu.ElementAt(secim2).ucluk)
                    {
                        Debug.Log("Berabere");
                        if (sayac == 7)
                        {
                            sonDurumBeraberlik(kontrol, 2);
                        }
                        arayuzGuncelleBasketbolcu(secim, secim2);

                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = false;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = false;
                    }
                }
                else
                {
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).serbestatis > oyuncuu.pcbasketbolcu.ElementAt(secim2).serbestatis)
                    {
                        kullanici.skor += 1;
                        arayuzGuncelleBasketbolcu(secim, secim2);
                        kullanicitext.text = kullanici.skor.ToString();
                        Debug.Log("Oyuncu puan aldi!");
                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerbasketbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcbasketbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).serbestatis < oyuncuu.pcbasketbolcu.ElementAt(secim2).serbestatis)
                    {
                        bilgisayar.skor += 1;
                        arayuzGuncelleBasketbolcu(secim, secim2);
                        pctext.text = bilgisayar.skor.ToString();
                        Debug.Log("Bilgisayar puan aldi");
                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerbasketbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcbasketbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerbasketbolcu.ElementAt(secim).serbestatis == oyuncuu.pcbasketbolcu.ElementAt(secim2).serbestatis)
                    {
                        Debug.Log("Berabere");
                        if (sayac == 7)
                        {
                            sonDurumBeraberlik(kontrol, 3);
                        }
                        arayuzGuncelleBasketbolcu(secim, secim2);

                        oyuncuu.playerbasketbolcu.ElementAt(secim).isused = false;
                        oyuncuu.pcbasketbolcu.ElementAt(secim2).isused = false;
                    }
                }
            }


            //F
            else
            {
                Debug.Log("Futbolcu Turu!");

                if (oyuncuu.playerfutbolcu.ElementAt(secim).isused)
                {
                    return;
                }
                while (true)
                {
                    if (oyuncuu.pcfutbolcu.ElementAt(secim2).isused)
                    {
                        secim2 = bilgisayar.kartSec(secim);

                    }
                    else if (!oyuncuu.pcfutbolcu.ElementAt(secim2).isused)
                    {
                        break;
                    }

                }
                futbolturu = !futbolturu;
                int kontrol = HamleAyarla();
                Debug.Log("Hamle numarasi: " + kontrol);
                Debug.Log("Kullanicinin indexi " + secim);
                Debug.Log("Pcnin indexi " + secim2);
                ozellik.text = kontrol.ToString();
                if (kontrol == 1)
                {
                    if (oyuncuu.playerfutbolcu.ElementAt(secim).penalti > oyuncuu.pcfutbolcu.ElementAt(secim2).penalti)
                    {
                        kullanici.skor += 1;
                        //UI
                        arayuzGuncelleFutbolcu(secim, secim2);

                        kullanicitext.text = kullanici.skor.ToString();
                        Debug.Log("Oyuncu puan aldi!");
                        oyuncuu.playerfutbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerfutbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcfutbolcu.ElementAt(secim2).gameobject);

                    }
                    if (oyuncuu.playerfutbolcu.ElementAt(secim).penalti < oyuncuu.pcfutbolcu.ElementAt(secim2).penalti)
                    {
                        bilgisayar.skor += 1;
                        arayuzGuncelleFutbolcu(secim, secim2);
                        pctext.text = bilgisayar.skor.ToString();
                        Debug.Log("Bilgisayar puan aldi");
                        oyuncuu.playerfutbolcu.ElementAt(secim).IsUsed = true;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerfutbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcfutbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerfutbolcu.ElementAt(secim).penalti == oyuncuu.pcfutbolcu.ElementAt(secim2).penalti)
                    {
                        Debug.Log("Berabere");
                        if (sayac == 7)
                        {
                            sonDurumBeraberlik(kontrol, 1);
                        }
                        arayuzGuncelleFutbolcu(secim, secim2);

                        oyuncuu.playerfutbolcu.ElementAt(secim).isused = false;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = false;
                    }

                }
                else if (kontrol == 2)
                {
                    if (oyuncuu.playerfutbolcu.ElementAt(secim).serbestAtis > oyuncuu.pcfutbolcu.ElementAt(secim2).serbestAtis)
                    {
                        kullanici.skor += 1;
                        arayuzGuncelleFutbolcu(secim, secim2);
                        kullanicitext.text = kullanici.skor.ToString();
                        Debug.Log("Oyuncu puan aldi!");
                        oyuncuu.playerfutbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerfutbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcfutbolcu.ElementAt(secim2).gameobject);
                    }

                    if (oyuncuu.playerfutbolcu.ElementAt(secim).serbestAtis < oyuncuu.pcfutbolcu.ElementAt(secim2).serbestAtis)
                    {
                        bilgisayar.skor += 1;
                        arayuzGuncelleFutbolcu(secim, secim2);
                        pctext.text = bilgisayar.skor.ToString();
                        Debug.Log("Bilgisayar puan aldi");
                        oyuncuu.playerfutbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerfutbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcfutbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerfutbolcu.ElementAt(secim).serbestAtis == oyuncuu.pcfutbolcu.ElementAt(secim2).serbestAtis)
                    {
                        Debug.Log("Berabere");
                        if (sayac == 7)
                        {
                            sonDurumBeraberlik(kontrol, 2);
                        }
                        arayuzGuncelleFutbolcu(secim, secim2);

                        oyuncuu.playerfutbolcu.ElementAt(secim).isused = false;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = false;
                    }
                }
                else
                {
                    if (oyuncuu.playerfutbolcu.ElementAt(secim).kaleciKarsiKarsiya > oyuncuu.pcfutbolcu.ElementAt(secim2).kaleciKarsiKarsiya)
                    {
                        kullanici.skor += 1;
                        arayuzGuncelleFutbolcu(secim, secim2);
                        kullanicitext.text = kullanici.skor.ToString();
                        Debug.Log("Oyuncu puan aldi!");
                        oyuncuu.playerfutbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerfutbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcfutbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerfutbolcu.ElementAt(secim).kaleciKarsiKarsiya < oyuncuu.pcfutbolcu.ElementAt(secim2).kaleciKarsiKarsiya)
                    {
                        bilgisayar.skor += 1;
                        arayuzGuncelleFutbolcu(secim, secim2);
                        pctext.text = bilgisayar.skor.ToString();
                        Debug.Log("Bilgisayar puan aldi");
                        oyuncuu.playerfutbolcu.ElementAt(secim).isused = true;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = true;

                        Destroy(oyuncuu.playerfutbolcu.ElementAt(secim).gameobject);
                        Destroy(oyuncuu.pcfutbolcu.ElementAt(secim2).gameobject);
                    }
                    if (oyuncuu.playerfutbolcu.ElementAt(secim).kaleciKarsiKarsiya == oyuncuu.pcfutbolcu.ElementAt(secim2).kaleciKarsiKarsiya)
                    {
                        if (sayac == 7)
                        {
                            sonDurumBeraberlik(kontrol, 3);
                        }
                        Debug.Log("Berabere");
                        arayuzGuncelleFutbolcu(secim, secim2);
                        oyuncuu.playerfutbolcu.ElementAt(secim).isused = false;
                        oyuncuu.pcfutbolcu.ElementAt(secim2).isused = false;
                    }
                }

            }
        }

        sayac++;


    }
    public void arayuzGuncelleBasketbolcu(int secim,int secim2)
    {
        k1.text = oyuncuu.playerbasketbolcu.ElementAt(secim).ikilik.ToString();
        k2.text = oyuncuu.playerbasketbolcu.ElementAt(secim).ucluk.ToString();
        k3.text = oyuncuu.playerbasketbolcu.ElementAt(secim).serbestatis.ToString();

        p1.text = oyuncuu.pcbasketbolcu.ElementAt(secim2).ikilik.ToString();
        p2.text = oyuncuu.pcbasketbolcu.ElementAt(secim2).ucluk.ToString();
        p3.text = oyuncuu.pcbasketbolcu.ElementAt(secim2).serbestatis.ToString();
    }
    public void arayuzGuncelleFutbolcu(int secim,int secim2)
    {
        k1.text = oyuncuu.playerfutbolcu.ElementAt(secim).penalti.ToString();
        k2.text = oyuncuu.playerfutbolcu.ElementAt(secim).serbestAtis.ToString();
        k3.text = oyuncuu.playerfutbolcu.ElementAt(secim).kaleciKarsiKarsiya.ToString();

        p1.text = oyuncuu.pcfutbolcu.ElementAt(secim2).penalti.ToString();
        p2.text = oyuncuu.pcfutbolcu.ElementAt(secim2).serbestAtis.ToString();
        p3.text = oyuncuu.pcfutbolcu.ElementAt(secim2).kaleciKarsiKarsiya.ToString();
    }
    public void sonDurumBeraberlik(int kontrol1,int kontrol2)
    {
       
            while (true)
            {
                KartOyna();
                if (kontrol1 != kontrol2)
                {

                    break;
                }
            }
        
    }
   
    int HamleAyarla()
    {
        int hamle = Random.Range(1, 4);
        return hamle;
    }
    

    // Update is called once per frame

}
