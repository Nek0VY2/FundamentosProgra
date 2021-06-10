using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{

    private float jumpForce = 9; //9 para que logre llegar pero no se vaya al espacio :D
    
    private void OnCollisionEnter2D(Collision2D collision) //lo mismo de comparar si colisiono pero en lugar de trigger , collision https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnCollisionEnter2D.html
    {
        if (collision.gameObject.CompareTag("Player")) //si el jugador entra en colision, es cuando pasa esto.
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); //mismo que en el salto  
        }
    }
}
