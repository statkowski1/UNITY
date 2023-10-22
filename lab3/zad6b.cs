using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad6 : MonoBehaviour
{
    //Celem programu jest płynna zmianna między kolorami z czerwonego na niebieski na danym obiekcie
    public Color startColor = Color.red;
    public Color endColor = Color.blue;
    public float duration = 2f;
    public float tmp = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        tmp += Time.deltaTime / duration;
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, tmp);
    }
}
