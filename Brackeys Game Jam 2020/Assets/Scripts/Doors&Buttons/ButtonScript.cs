using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    private float waitTime = 0;

    public delegate void ActivateDoor();
    public ActivateDoor doorActivation;

    public delegate void DeactivateDoor();
    public DeactivateDoor doorDeactivation;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            animator.SetBool("TriggerButtonAnimation", true);
            activateDoor();
        }
    }

    void activateDoor()
    {
        if(doorActivation != null)
        {
            doorActivation();
        }
    }

    void deactivateDoor()
    {
        if (doorDeactivation != null)
        {
            doorDeactivation();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
       if(collider.tag == "Player")
        {
            StartCoroutine(ButtonUp());
        } 
    }
    private IEnumerator ButtonUp()
    {
        yield return new WaitForSeconds(waitTime);

        animator.SetBool("TriggerButtonAnimation",false);

        deactivateDoor();
    }
}
