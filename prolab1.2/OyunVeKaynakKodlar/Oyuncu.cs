using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using System.Linq;
using System;

public class Oyuncu : MonoBehaviour
{
  
    

    
    public int oyuncuID;
    public string oyuncuAdi;
    public int skor = 0;

   public List<Futbolcu> futlist2 = new List<Futbolcu>();
    public List<Basketbolcu> baslist2 = new List<Basketbolcu>();

   public List<Futbolcu> playerfutbolcu = new List<Futbolcu>();
   public List<Basketbolcu> playerbasketbolcu = new List<Basketbolcu>();

   public List<Futbolcu> pcfutbolcu = new List<Futbolcu>();
   public List<Basketbolcu> pcbasketbolcu = new List<Basketbolcu>();

    public Oyuncu(int oyuncuID, string oyuncuAdi, int skor)
    {
        this.oyuncuID = oyuncuID;
        this.oyuncuAdi = oyuncuAdi;
        this.skor = skor;

    }
    public Oyuncu()
    {

    }
   
    public void listeKaristir()
    {
        futlist2 = futlist2.OrderBy(a => Guid.NewGuid()).ToList();
        baslist2 = baslist2.OrderBy(a => Guid.NewGuid()).ToList();

        for (int i = 0; i < 4; i++)
        {
            playerfutbolcu.Add(futlist2.ElementAt(i));
        }
        for (int i = 4; i < 8; i++)
        {
            pcfutbolcu.Add(futlist2.ElementAt(i));
        }
        for (int i = 0; i < 4; i++)
        {
            playerbasketbolcu.Add(baslist2.ElementAt(i));
            
        }
        for (int i = 4; i < 8; i++)
        {
            pcbasketbolcu.Add(baslist2.ElementAt(i));
        }

        

    }
    
    public virtual int kartSec(int a)
    {

        return 1;
    }
    public int OyuncuID
    {
        get
        {
            return oyuncuID;
        }
        set
        {
            oyuncuID = value;
        }
    }
    public string OyuncuAdi
    {
        get
        {
            return oyuncuAdi;
        }
        set
        {
            oyuncuAdi = value;
        }
    }
    public int Skor
    {
        get
        {
            return skor;
        }
        set
        {
            skor = value;
        }
    }
    public void SkorGoster()
    {
        Debug.Log("Oyuncunun skoru: " + skor);
    }

}
