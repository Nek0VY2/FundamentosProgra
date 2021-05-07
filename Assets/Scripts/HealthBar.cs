using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Image imgPortrait;
    public Image imgHPBar;

    private Ruby ruby;
    // Start is called before the first frame update
    void Start()
    {
        ruby = GameObject.FindGameObjectWithTag("Player").GetComponent<Ruby>();  //esto no es viable si hay más tags de "Player" | esto nos trae un game object, pero con el punto buscamos su componente 
    }

    void Update()
    {
        imgHPBar.fillAmount = (float)ruby.currentHP/(float)ruby.maxHP;
    }
}
