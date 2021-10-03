using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketbolcu : Sporcu
{
    public int ikilik;
    public int ucluk;
    public int serbestatis;
    public bool isused = false;

    public string basketbolcuAdi;
    public string basketbolcuTakim;

    public GameObject gameobject;

    public Basketbolcu(string sporcuIsim, string sporcuTakim, int ikilik, int ucluk, int serbestatis, bool isused, GameObject Gameobject) : base(sporcuIsim, sporcuTakim)
    {
        this.basketbolcuAdi = sporcuIsim;
        this.basketbolcuTakim = sporcuTakim;
        this.ikilik = ikilik;
        this.ucluk = ucluk;
        this.serbestatis = serbestatis;
        this.isused = isused;
        this.gameobject = Gameobject;
        
    }

    public Basketbolcu()
    {

    }

    public override void sporcuPuaniGoster()
    {
        base.sporcuPuaniGoster();
        Debug.Log("Ikilik: " + this.ikilik);
        Debug.Log("Ucluk: " + this.ucluk);
        Debug.Log("Serbest Atis " + this.serbestatis);
    }
    public string BasketbolcuAdi
    {
        get
        {
            return basketbolcuAdi;
        }
        set
        {
            basketbolcuAdi = value;
        }
    }
    public string BasketbolcuTakim
    {
        get
        {
            return basketbolcuTakim;
        }
        set
        {
            basketbolcuTakim = value;
        }
    }
    public int Ikilik
    {
        get
        {
            return ikilik;
        }
        set
        {
            ikilik = value;
        }
    }
    public int SerbestAtis
    {
        get
        {
            return serbestatis;
        }
        set
        {
            serbestatis = value;
        }
    }
    public int Ucluk
    {
        get
        {
            return ucluk;
        }
        set
        {
            ucluk = value;
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
