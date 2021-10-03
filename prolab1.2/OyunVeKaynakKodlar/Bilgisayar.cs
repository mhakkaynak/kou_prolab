using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bilgisayar : Oyuncu
{
    
    
    public Bilgisayar()
    {

    }
   public Bilgisayar(int oyuncuID,string oyuncuAdi,int skor): base(oyuncuID,oyuncuAdi,skor)
    {
;       oyuncuID = this.oyuncuID;
        oyuncuAdi = this.oyuncuAdi;
        skor = this.skor;

    }
    public override int kartSec(int a)
    {
        int x = 111;
        if (a >= 4)
        {
            x = Random.Range(4, 8);
        }
        else
        {
            x = Random.Range(0, 4);
        }

        return x;
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
}
