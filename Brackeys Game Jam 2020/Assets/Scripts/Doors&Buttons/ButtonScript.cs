using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    Animator animator;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            animator.SetBool("TriggerButtonAnimation", true);
            print("Contact");
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
        yield return new WaitForSeconds(2);

        animator.SetBool("TriggerButtonAnimation",false);
    }
}
