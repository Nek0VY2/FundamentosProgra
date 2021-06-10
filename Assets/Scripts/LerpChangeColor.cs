using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpChangeColor : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D light1;
    public Color color1;
    public Color color2;
    public float tiempo;

    void Start()
    {
        light1.color = Color.white;
        tiempo = Random.Range(0.4f, 1.5f);
    }

    void Update()
    {
        light1.color = Color.Lerp(color1, color2, Mathf.PingPong(Time.time, tiempo));
    }

 
}
