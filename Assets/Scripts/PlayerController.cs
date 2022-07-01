using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 direction;
    public float forwardSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
    }

    void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);   
    }
}
