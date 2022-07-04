using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringController : MonoBehaviour
{
    public int power = 16;
    public Animator animator;
    public bool active = false;
    public float recoveryTime = 0.24f;

     public void OnTriggerEnter(Collider other) 
    {
        //Debug.Log("ToqueAlgo");
        if ( (other.tag).ToLower() == "player"  && active == false)
        {
            Debug.Log("Springu");
            animator.SetBool("Activate",true);
            active = true;
            FindObjectOfType<AudioManager>().PlaySfx("spring");
            other.gameObject.GetComponent<PlayerController>().Jump(power);
            StartCoroutine( reset() );
        }   
    }

    public IEnumerator reset()
    {
        yield return new WaitForSeconds(recoveryTime);
        active = false;
    }
}
