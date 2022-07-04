using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour //Controlador de la camara
{
    public Transform target; //Objetivo de la camara, el player
    public Vector3  offset; //compensación
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position; //compensación respecto a la posición del player
    }

    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x,transform.position.y,offset.z + target.position.z); //posicion respecto al player
        transform.position = Vector3.Lerp(transform.position,newPosition,12*Time.deltaTime); //Movimiento de camara sutil
    }
}
