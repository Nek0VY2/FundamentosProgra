using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCamera : MonoBehaviour
{
    public delegate void ParallaxCameraDelegate(float deltaMovement); //delegado que () va a estar utilizando los metodos de las layers,(delta del movimiento)

    public ParallaxCameraDelegate onCameraTranslateX; //translate es la palabra que utiliza unity para movimiento?
    public ParallaxCameraDelegate onCameraTranslateY;

    private float oldPositionX;
    private float oldPositionY;

    private void Start()
    {
        oldPositionX = transform.position.x; //posición actual
        oldPositionY = transform.position.y;
    }

    //private void fixedUpdate() //el fixedupdate a diferencia del update, es que el update se actualiza cuando quiere, y el fixedupdate entra cada 0.1 s o nano segundo, tiene un tiempo ciclico y exacto
    private void LateUpdate() //este entra cada nano segundos despuesito de??
    {
        if (transform.position.x != oldPositionX) //operador para diferente "!="
        {
            if (onCameraTranslateX != null)//revisar primero que nuestro minion existe 
            {
                float deltaX = oldPositionX - transform.position.x;
                onCameraTranslateX(deltaX);
            }
            oldPositionX = transform.position.x;
        }

        if (transform.position.x != oldPositionY)
        {
            if (onCameraTranslateY != null)//revisar primero que nuestro minion existe 
            {
                float deltaY = oldPositionY - transform.position.y;
                onCameraTranslateY(deltaY);
            }
            oldPositionY = transform.position.y;
        }
    }
}
