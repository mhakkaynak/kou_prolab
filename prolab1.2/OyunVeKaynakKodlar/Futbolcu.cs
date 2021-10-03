using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Futbolcu : Sporcu
{
   public int penalti;
    public int serbestAtis;
    public int kaleciKarsiKarsiya;
    public bool isused = false;

    public string futbolcuAdi;
    public string futbolcuTakim;

    public GameObject gameobject;

   
    public Futbolcu(string sporcuIsim,string sporcuTakim,int penalti,int serbestAtis,int kaleciKarsiKarsiya,bool isused, GameObject Gameobject) : base(sporcuIsim,sporcuTakim)
    {
        this.futbolcuAdi = sporcuIsim;
        this.futbolcuTakim = sporcuTakim;
        this.penalti = penalti;
        this.serbestAtis = serbestAtis;
        this.kaleciKarsiKarsiya = kaleciKarsiKarsiya;
        this.isused = isused;
        this.gameobject = Gameobject;
    }

    public override void sporcuPuaniGoster()
    {
        base.sporcuPuaniGoster();
        Debug.Log("Penalti: " + this.penalti);
        Debug.Log("Serbest Atis: " + this.serbestAtis);
        Debug.Log("Kaleci Karsi Karsiya: " + this.kaleciKarsiKarsiya);
    }
    public string FutbolcuAdi
    {
        get
        {
            return futbolcuAdi;
        }
        set
        {
            futbolcuAdi = value;
        }
    }
    public string FutbolcuTakim
    {
        get
        {
            return futbolcuTakim;
        }
        set
        {
            futbolcuTakim = value;
        }
    }
    public int Penalti
    {
        get
        {
            return penalti;
        }
        set
        {
            penalti = value;
        }
    }
    public int SerbestAtis
    {
        get
        {
            return serbestAtis;
        }
        set
        {
            serbestAtis = value;
        }
    }
    public int KaleciKarsiKarsiya
    {
        get
        {
            return kaleciKarsiKarsiya;
        }
        set
        {
            kaleciKarsiKarsiya = value;
        }
    }
    public bool IsUsed
    {
        get
        {
            return isused;
        }
        set
        {
            isused = value;
        }
    }
}
