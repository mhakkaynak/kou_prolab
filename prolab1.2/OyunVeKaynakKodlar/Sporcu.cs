using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sporcu : MonoBehaviour
{
    string sporcuIsim;
    string sporcuTakim;

    public Sporcu(string sporcuIsim, string sporcuTakim)
    {
        this.sporcuIsim = sporcuIsim;
        this.sporcuTakim = sporcuTakim;
    }
    public Sporcu()
    {

    }
    public string SporcuIsim
    {
        get
        {
            return sporcuIsim;
        }
        set
        {
            sporcuIsim = value;
        }
    }
    public string SporcuTakim
    {
        get
        {
            return sporcuTakim;
        }
        set
        {
            sporcuTakim = value;
        }
    }
    public virtual void sporcuPuaniGoster()
    {
        Debug.Log("Sporcu puani gosteriliyor!");

    }




}
