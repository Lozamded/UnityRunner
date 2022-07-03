using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameObject LevelManager;
    public CharacterController controller;
    public Vector3 direction;
    public float forwardSpeed; 
    public float maxSpeed = 24;

    public int desiredLine = 1; //Linea actual, 0, 1 y 2 para izquierda, centro y derecha respectivamente
    public float laneDistance = 4; //Distancia entre lineas

    public float Gravity = -10;
    public float jumpForce = 6;
    public bool canJump = true;

    public bool sliding = false;
    public float slideTime = 1.34f;

    public Animator animator;


    void Start()
    {
        // animator.set
    }

    // Update is called once per frame
    void Update()
    {
        direction.z = forwardSpeed;
        


        if (forwardSpeed <  maxSpeed)
        {
            forwardSpeed += 0.024f  * Time.deltaTime;
        }
    


        //Obtener los inputs  
        if(Input.GetKeyDown(KeyCode.RightArrow) || TouchManager.swipeRight)
        {
            desiredLine += 1;
            if (desiredLine > 2)
            {
                desiredLine = 2;
            } 
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)  || TouchManager.swipeLeft )
        {
            desiredLine -= 1;
            if (desiredLine < 0)
            {
                desiredLine = 0;
            } 
        }

        animator.SetBool("isGrounded",controller.isGrounded);

        if (controller.isGrounded)
        {
            animator.SetBool("isJumping",false);
            if( (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || TouchManager.swipeUp) &&  sliding == false )
            {
                Jump(jumpForce);
            }

            if( (Input.GetKeyDown(KeyCode.DownArrow) || TouchManager.swipeDown) &&  sliding == false)
            {

                StartCoroutine( Slide());
            }

        }else {
             direction.y += Gravity * Time.deltaTime;
             if (direction.y > 0)
             {
                animator.SetBool("isJumping",true);
             }else
             {
                animator.SetBool("isJumping",false);
             }
        }


        //Debug.Log("Forward: " + (transform.forward).ToString() + " UP: " + (transform.up).ToString());
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;


        switch(desiredLine)
        {
            case 0:
                targetPosition += Vector3.left * laneDistance; 
                break;
                           
            case 2:
                targetPosition += Vector3.right * laneDistance; 
                break;

        }

        //transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);
        //controller.center = controller.center;
 

        if (transform.position != targetPosition)
        {
            Vector3 diff = targetPosition - transform.position;
            Vector3 moveDir = diff.normalized * 25 * Time.deltaTime; 
            if(moveDir.sqrMagnitude < diff.sqrMagnitude)
            {
                controller.Move(moveDir);
            }else {
                controller.Move(diff);
            }
        }

        controller.Move(direction * Time.deltaTime);  //Mover al player

    }


    public void Jump(float jumpValue)
    {
        direction.y = jumpValue;
    }

    public void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        if ( (hit.transform.tag).ToLower() == "obstacles")
        {
            Debug.Log("choque un Obstaculo");
            if(sliding)
            {
                Physics.IgnoreCollision(hit.collider,controller);

            }else
            {
                LevelManager.GetComponent<LevelManager>().setGameOver();
            }
        }   
    }

    public IEnumerator Slide()
    {
        //inicio Slide
        Debug.Log("InicioSlide");
        animator.SetBool("isSliding",true);
        sliding = true;

        yield return new WaitForSeconds(slideTime);

        sliding = false;
        animator.SetBool("isSliding",false);
        Debug.Log("TerminoSlide");
        //Fin Slide
    }
}
