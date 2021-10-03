using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kullanici : Oyuncu
{
    
    public int x = 99;
    public Kullanici()
    {

    }
    public Kullanici(int oyuncuID,string oyuncuAdi,int skor) : base(oyuncuID, oyuncuAdi, skor)
    {
        oyuncuID = this.oyuncuID;
        oyuncuAdi = this.oyuncuAdi;
        skor = this.skor;
    }
    
    
    
    public override int kartSec(int a)
    {

        

        return a;
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
