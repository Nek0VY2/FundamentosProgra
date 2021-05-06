using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int HealAmount;
    public Ruby ruby;

   // private void InteractWithPlayer()
    //{
    //    ruby.currentHP = ruby.currentHP + HealAmount;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //InteractWithPlayer();
            //activar animación del heal en lugar de bajar la vida por que eso ya se paso a ruby
        }
    }
}
