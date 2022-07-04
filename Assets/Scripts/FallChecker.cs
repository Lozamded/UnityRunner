using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallChecker : MonoBehaviour //Verificador de caidas
{

    public GameObject player; //Player
    public MeshRenderer Renderer; //malla

    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false; //ocultar malla
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z);  //Seguir al player en el eje z
    }
}
