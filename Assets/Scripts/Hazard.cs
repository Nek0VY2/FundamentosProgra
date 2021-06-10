using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public int damageAmount;
    private Animator animator;
    public ParticleSystem particlesHa;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // private void InteractWithPlayer()  // asdsdv
    //{
    //ruby.currentHP = ruby.currentHP - DamageAmount; // adaf
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("HazardActive");
            particlesHa.Play();
            
            //InteractWithPlayer();
            //activar animación del hazard en lugar de bajar la vida por que eso ya se paso a ruby
        }
    }
}
