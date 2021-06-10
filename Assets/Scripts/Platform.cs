using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Balance variables")]
    public bool isMovingHorizontally = true;
    public bool startsMovingRightUp;
    public int movingDistance = 4;
    public float speed = 2;//valor que tan rapido se mueve
    
    private Vector2 originalPosition; //nuestro punto de partida
    private Vector2 targetPosition; //nuestro punto de llegada
    private Vector2 newPosition; //actualizando su posición actual

    void Start()
    {
        originalPosition = transform.position;
        if(isMovingHorizontally) //se mueve horizontalmente
        {
            if (startsMovingRightUp)
                targetPosition = new Vector2(originalPosition.x + movingDistance, originalPosition.y);
            else
                targetPosition = new Vector2(originalPosition.x - movingDistance, originalPosition.y);
        }
        else
            if(startsMovingRightUp)
                targetPosition = new Vector2(originalPosition.x, originalPosition.y + movingDistance);
            else
                targetPosition = new Vector2(originalPosition.x, originalPosition.y - movingDistance);



    }

    void Update()
    {
        if (isMovingHorizontally) //izquierda derecha
        {
            if (startsMovingRightUp) // inicia moviendose a la derecha
            {
                if (transform.position.x >= targetPosition.x)
                {
                    newPosition = originalPosition;
                }
                else if (transform.position.x <= originalPosition.x)
                {
                    newPosition = targetPosition;
                }
            }
            else //inicia moviendose a la izquierda
            {
                if (transform.position.x <= targetPosition.x)
                {
                    newPosition = originalPosition;
                }
                else if (transform.position.x >= originalPosition.x)
                {
                    newPosition = targetPosition;
                }
            }
        }
       else //arriba o abajo
        {
            if (startsMovingRightUp) // inicia moviendose a la derecha
            {
                if (transform.position.y >= targetPosition.y)
                {
                    newPosition = originalPosition;
                }
                else if (transform.position.y <= originalPosition.y)
                {
                    newPosition = targetPosition;
                }
            }
            else //inicia moviendose a la izquierda
            {
                if (transform.position.y <= targetPosition.y)
                {
                    newPosition = originalPosition;
                }
                else if (transform.position.y >= originalPosition.y)
                {
                    newPosition = targetPosition;
                }
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, newPosition, Time.deltaTime * speed); // donde estamos, a donde vamos, distancia maxima que avanzara, asi que le damos el valor de speed multiplicado por la variable que cambia solito en decimales "time.deltatime" 
    }
}
