using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ParallaxLayers : MonoBehaviour
{
    public float parallaxFactorX;
    public float parallaxFactorY;

    public void MoveX(float deltaX)
    {
        Vector3 newPosition = transform.position;  // partimos de posición original
        newPosition.x -= deltaX * parallaxFactorX; //calculos matematicos
        transform.position = newPosition; //una vez hechos le cambiamos la posición
    }

    public void MoveY(float deltaY)
    {
        Vector3 newPosition = transform.position;  
        newPosition.x -= deltaY * parallaxFactorY; 
        transform.position = newPosition; 
    }
}
