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

    public delegate void ActivateButton();
    public delegate void DeactivateButton();

    public ActivateButton ButtonActivated;
    public DeactivateButton ButtonDeactivated;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player" || collider.tag == "Ghost")
        {
            animator.SetBool("TriggerButtonAnimation", true);
            ButtonActivation();
        }
    }

    void ButtonActivation()
    {
        if(ButtonActivated != null)
        {
            ButtonActivated();
        }
    }

    void ButtonDeactivation()
    {
        if (ButtonDeactivated != null)
        {
            ButtonDeactivated();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.tag == "Player" || collider.tag == "Ghost")
        {
            StartCoroutine(ButtonUp());
        } 
    }
    private IEnumerator ButtonUp()
    {
        yield return new WaitForSeconds(waitTime);

        animator.SetBool("TriggerButtonAnimation",false);

        ButtonDeactivation();
    }
}
