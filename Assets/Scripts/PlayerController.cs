using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public GameObject LevelManager; //Administrador del nivel
    public CharacterController controller; //Controlador de personaje
    public Vector3 direction; //direccion  
    public float forwardSpeed; //velocidad hacia adelante
    public float maxSpeed = 24; //Velodcidad maxima
    public float speedIncreaser = 0.024f; //valor de incremento de velovidad

    public int desiredLine = 1; //Linea actual, 0, 1 y 2 para izquierda, centro y derecha respectivamente
    public float laneDistance = 4; //Distancia entre lineas

    public float Gravity = -10; //Gravedad
    public float jumpForce = 6; //Potencia de salto
    public bool canJump = true; //Puede saltar

    public bool sliding = false; //Si se esta deslizando
    public float slideTime = 1.34f; //tiempo que dura el deslizarse

    public Animator animator; //Animador

    public GameObject Audio; //Administrador de audios

    public bool Alive = true; //si esta vivo

    void Start()
    {
       Alive = true;
    }

    void Update()
    {
        direction.z = forwardSpeed; //vector velocidad
        
        if (forwardSpeed <  maxSpeed) //aumenao un poco hasta la velocidad maxima cada frame
        {
            forwardSpeed += speedIncreaser  * Time.deltaTime;
        }
    
        animator.SetBool("isGrounded",controller.isGrounded); //le envia al animador si esta en el suelo o en el aire

        if (controller.isGrounded) //Si esta en el piso
        {
            animator.SetBool("isJumping",false);  //le envia al animador que no esta saltando ni callendo

            //Obtener los inputs  
            if((Input.GetKeyDown(KeyCode.RightArrow) || TouchManager.swipeRight ) && sliding == false) //input derecha
            {
                desiredLine += 1; //ver linea de la derecha
                if (desiredLine > 2)
                {
                    desiredLine = 2;
                } 
            }

            if( (Input.GetKeyDown(KeyCode.LeftArrow)  || TouchManager.swipeLeft)  && sliding == false )//input izquierda
            {
                desiredLine -= 1; //ver linea de la izquierda
                if (desiredLine < 0)
                {
                    desiredLine = 0;
                } 
            }

            if( (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || TouchManager.swipeUp) &&  sliding == false )// input salto
            {
                Jump(jumpForce); //saltar
            }

            if( (Input.GetKeyDown(KeyCode.DownArrow) || TouchManager.swipeDown) &&  sliding == false) // Input deslizar
            {

                StartCoroutine( Slide() );
            }

        }else {
             direction.y += Gravity * Time.deltaTime; //Gravedad 
             if (direction.y > 0) //Si estoy subiendo estoy saltando caso contrario callendo
             {
                animator.SetBool("isJumping",true);
             }else
             {
                animator.SetBool("isJumping",false);
             }
        }


        //Debug.Log("Forward: " + (transform.forward).ToString() + " UP: " + (transform.up).ToString());
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up; //obicación del cambio de linea

        switch(desiredLine) 
        {
            case 0:
                targetPosition += Vector3.left * laneDistance; 
                break;
                           
            case 2:
                targetPosition += Vector3.right * laneDistance; 
                break;

        }

        if (transform.position != targetPosition) //Cambio del linea
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

        if (Alive) //Si esta vivo avanza
        {
            controller.Move(direction * Time.deltaTime);  //Mover al player
        }
           
    }


    public void Jump(float jumpValue) //salto, publico para que los resortes lo hagan saltar
    {
        Audio.GetComponent<AudioManager>().PlaySfx("jump");
        direction.y = jumpValue;
    }

    void OnControllerColliderHit(ControllerColliderHit hit) //Si colisiono con un objeto
    {
        if ( (hit.transform.tag).ToLower() == "obstacles" ) //Si es un obstaculo
        {
            StartCoroutine( callGameOver() );
        }else if( (hit.transform.tag).ToLower() == "obstacleshigh" ){ //Si es un obstaculo esquibable por desliz

            if(sliding)
            {
                Physics.IgnoreCollision(hit.collider,controller);

            }else{
                StartCoroutine( callGameOver() ); //perder
            }
        }
    }

    public IEnumerator Slide() //co-rurina de desizarce en el tiempo designado
    {
         Audio.GetComponent<AudioManager>().PlaySfx("slide");
        animator.SetBool("isSliding",true);
        sliding = true;

        yield return new WaitForSeconds(slideTime);

        sliding = false;
        animator.SetBool("isSliding",false);
    }

     public IEnumerator callGameOver() //Co-rutina para pantalla de game over, debido a que se espera entre un enfecto de sonido y otro
    {
        if (Alive)
        {
            Alive = false;
        }
        Audio.GetComponent<AudioManager>().PlaySfx("hit");
        yield return new WaitForSeconds(0.65f);
        Audio.GetComponent<AudioManager>().PlaySfx("ouch");
        LevelManager.GetComponent<LevelManager>().setGameOver(); //se llama al game over desde el administrador del nivel

    }
}
