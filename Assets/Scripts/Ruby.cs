using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer ruby;

    [Header("Balance variables")]
    [SerializeField]
    private float moveSpeed;

    public int maxHP = 30; // mi entero vale 30 de forma inicial. en este caso mi HP
    [HideInInspector] //asi no sale en unity, asi no se puede modificar en el editor.
    public int currentHP = 30; //si la de arriba es incial, esta vera cuando le pegan y asi

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //w - Up/Back
        animator.SetBool("RunBack", false);
        animator.SetBool("RunFront", false);
        animator.SetBool("RunSide", false);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("RunBack",true);
            animator.SetBool("RunFront",false);
            animator.SetBool("RunSide",false);
            transform.position = new Vector2(transform.position.x,transform.position.y + moveSpeed);
        } 
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("RunBack",false);
            animator.SetBool("RunFront",true);
            animator.SetBool("RunSide",false);
            transform.position = new Vector2(transform.position.x,transform.position.y - moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            ruby.flipX = true; //voltea al sprite
            animator.SetBool("RunBack", false);
            animator.SetBool("RunFront", false);
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            ruby.flipX = false; //regresa al sprite a su original
            animator.SetBool("RunBack",false);
            animator.SetBool("RunFront",false);
            animator.SetBool("RunSide",true);
            transform.position = new Vector2(transform.position.x - moveSpeed,transform.position.y);
        }
        
        //s - Down/Front
        //a - Left
        //d - Right
    }

    private void OnTriggerEnter2D(Collider2D collision) //cuando el trigger entre, es cuando pasa. (cuando entra en colision con el objeto)
    {
        if(collision.CompareTag("Hazard"))
        {
            if ((currentHP - collision.GetComponent<Hazard>().DamageAmount) < 0) //comparar con el limite inferior
            {
                currentHP = 0;
                animator.SetTrigger("Dead");
            }

            else
            {
                currentHP -= collision.GetComponent<Hazard>().DamageAmount; //"-=" hace una resta automatica de lo que tiene mi variable hp , get component es para que traiga a hazard, y ahi aplica su DamageAmount
                animator.SetTrigger("DamageSide");
            }
        }

        if (collision.CompareTag("Heal"))
        {
            if ((currentHP + collision.GetComponent<Heal>().HealAmount) > maxHP) //ahora con el limite superior
                currentHP = maxHP;
            else
                currentHP += collision.GetComponent<Heal>().HealAmount;


         animator.SetTrigger("TurnToSide");  //esta animación es la de heal (la que se pone verde)/preguntar por que no me deja espejear
                //active heal particles
        }
    }

}
