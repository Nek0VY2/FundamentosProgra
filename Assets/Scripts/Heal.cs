using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int HealAmount;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // private void InteractWithPlayer()
    //{
    //    ruby.currentHP = ruby.currentHP + HealAmount;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("MedkitAnimation");
            //InteractWithPlayer();
            //activar animación del heal en lugar de bajar la vida por que eso ya se paso a ruby
        }
    }
}
