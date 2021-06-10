using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruby : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer ruby;
    public Rigidbody2D rigidbody;

    [Header("Balance variables")]
    //[SerializeField]
    public float moveSpeed = 0.1f;
    [SerializeField]
    private float jumpForce = 1;

    public int maxHP = 30; // mi entero vale 30 de forma inicial. en este caso mi HP
    [HideInInspector] //asi no sale en unity, asi no se puede modificar en el editor.
    public int currentHP = 30; //si la de arriba es incial, esta vera cuando le pegan y asi

    private float horizontal;
    private float vertical;
    private Vector3 direction;  // vector3: x,y,z. vector 2: x,y.

    private bool enPiso;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal"); //con estas obtenemos la dirección en la que se esta moviendo
        vertical = Input.GetAxis("Vertical"); //GetAxis es sobre que eje, de las x o las y, input se maneja con etiquetas.
        direction = new Vector3(horizontal, 0f, vertical); // 0f = "nada" de posición, entre () le estamos diciendo cuales tomara, x,y,z.

        animator.SetBool("RunBack", false);
        animator.SetBool("RunFront", false);
        animator.SetBool("RunSide", false);

        if (Input.GetKeyDown(KeyCode.Space) && enPiso == true)
        {
            rigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  //agrega una fuerza (addforce) hacia arriba, x se queda en 0f.
            animator.SetTrigger("JumpSide");
        }

        if (Input.GetKey(KeyCode.D))
        {
            ruby.flipX = false; //voltea al sprite
            //transform.localScale = new Vector3(1, 1, 1); <- modificar la parte del transform.
            animator.SetBool("RunSide", true);
            transform.position = new Vector2(transform.position.x + moveSpeed, transform.position.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            ruby.flipX = true; //regresa al sprite a su original
            animator.SetBool("RunSide",true);
            transform.position = new Vector2(transform.position.x - moveSpeed,transform.position.y);
        }
        if (enPiso == false)
        {
            animator.SetBool("RunSide", false);
        }
        if (direction.magnitude == 0f)
        {
            animator.SetBool("RunSide", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision) //cuando el trigger entre, es cuando pasa. (cuando entra en colision con el objeto)
    {
        if(collision.CompareTag("Hazard"))
        {
            if ((currentHP - collision.GetComponent<Hazard>().damageAmount) < 0) //comparar con el limite inferior
            {
                currentHP = 0;
                animator.SetTrigger("Dead");
            }

            else
            {
                currentHP -= collision.GetComponent<Hazard>().damageAmount; //"-=" hace una resta automatica de lo que tiene mi variable hp , get component es para que traiga a hazard, y ahi aplica su DamageAmount
                animator.SetTrigger("DamageSide");
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            if ((currentHP - collision.GetComponent<Enemy>().damageAmount) < 0) //comparar con el limite inferior
            {
                currentHP = 0;
                animator.SetTrigger("Dead");
            }

            else
            {
                currentHP -= collision.GetComponent<Enemy>().damageAmount; //"-=" hace una resta automatica de lo que tiene mi variable hp , get component es para que traiga a hazard, y ahi aplica su DamageAmount
                animator.SetTrigger("DamageSide");
            }
        }

        if (collision.CompareTag("Heal"))
        {
            if ((currentHP + collision.GetComponent<Heal>().HealAmount) > maxHP) //ahora con el limite superior
                currentHP = maxHP;
            else
                currentHP += collision.GetComponent<Heal>().HealAmount;


         animator.SetTrigger("TurnToSide");  //esta animación es la de heal (la que se pone verde)
        }

        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            enPiso = true;
          
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            enPiso = false;
        }
    }


}
