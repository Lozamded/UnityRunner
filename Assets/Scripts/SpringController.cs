using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour //Controlador de resortes
{
    public int power = 16; //Poder de salto
    public Animator animator; //animador
    public bool active = false; //si ha sido presionado
    public float recoveryTime = 0.24f; //tiempo de recuperacion

     public void OnTriggerEnter(Collider other) //algo toco al resorte
    {
        if ( (other.tag).ToLower() == "player"  && active == false) //Si es el player hacerlo saltar
        {
            animator.SetBool("Activate",true);
            active = true;
            FindObjectOfType<AudioManager>().PlaySfx("spring");
            other.gameObject.GetComponent<PlayerController>().Jump(power);
            StartCoroutine( reset() ); //volverlo activar
        }   
    }

    public IEnumerator reset() //puede volver a utilizarse
    {
        yield return new WaitForSeconds(recoveryTime);
        active = false;
    }
}
