using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int DamageAmount;
    public Ruby ruby;

   // private void InteractWithPlayer()
    //{
        //ruby.currentHP = ruby.currentHP - DamageAmount;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //InteractWithPlayer();
            //activar animación del hazard en lugar de bajar la vida por que eso ya se paso a ruby
        }
    }
}
