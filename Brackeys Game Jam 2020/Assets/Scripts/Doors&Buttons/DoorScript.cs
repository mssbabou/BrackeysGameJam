using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    [SerializeField]
    GameObject linkedButton;

    [SerializeField]
    Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        linkedButton.GetComponent<floorButtonScript>().buttonActive += ActivateDoor;
        linkedButton.GetComponent<floorButtonScript>().buttonInactive += DeactivateDoor;
    }

    private void ActivateDoor()
    {
        doorAnimator.SetBool("doorActive", true);
    }

    private void DeactivateDoor()
    {
        doorAnimator.SetBool("doorActive", false);
    }
}
