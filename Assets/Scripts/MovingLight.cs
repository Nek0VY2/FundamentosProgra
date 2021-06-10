using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLight : MonoBehaviour
{
    public float rotationTreshold; //variable del "rango/umbral"
    public float speed; //variable de la velocidad del movimiento
    public float maxOffset = 0.2f;
    [SerializeField]
    Quaternion maxLeft;
    [SerializeField]
    Quaternion maxRight;
    Coroutine currentCoroutine;
    //NOTA: LERP procesos que tiene unity para hacer varianzas entre un dato y otro en un tiempo determinado.
    //necesitan estar en un segundo plano, osea que se les genere su propio proceso extra, para que puedan.
    //basicamente: interpolarse de un punto A a un punto B en cierta cantidad de tiempo.

    // Start is called before the first frame update
    void Start()
    {
        maxLeft.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold);
        maxRight.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold * -1);
        currentCoroutine = StartCoroutine(MoveLeft());
    }

    void Update()
    {
    
    }
    //quaternion por que nos lo pide el ".rotation", 
        //transform.rotation = Quaternion.Lerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + rotationTreshold, transform.rotation.w), Time.deltaTime * speed); //modificamos el segundo valor, por que es el que nos dira a donde se movera.

    IEnumerator MoveLeft() //IEnumerator implica otro tipo de procesos extra más complejos, requiere que se ejecuten frame by frame, se les conoce como "cortinas".
    {
        while(transform.localEulerAngles.z > maxLeft.eulerAngles.z + maxOffset)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxLeft, Time.deltaTime * speed); //modificamos el segundo valor, por que es el que nos dira a donde se movera.
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        StopCoroutine(currentCoroutine); //metodo para detener corutinas
        currentCoroutine = StartCoroutine(MoveRight()); //iniciar la corutina tal.
    }

    IEnumerator MoveRight()
    {
        while(transform.localEulerAngles.z < maxRight.eulerAngles.z - maxOffset)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, maxRight, Time.deltaTime * speed);
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(MoveLeft());
    }

}
