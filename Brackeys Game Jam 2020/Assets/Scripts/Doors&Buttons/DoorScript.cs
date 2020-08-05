using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private bool inverted;
    [SerializeField]
    GameObject linkedButton;

    [SerializeField]
    Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        if(linkedButton.name == "floorButton")
        {
            if (!inverted)
            {
                linkedButton.GetComponent<floorButtonScript>().buttonActive += ActivateDoor;
                linkedButton.GetComponent<floorButtonScript>().buttonInactive += DeactivateDoor;
            }
            else
            {
                linkedButton.GetComponent<floorButtonScript>().buttonActive += DeactivateDoor;
                linkedButton.GetComponent<floorButtonScript>().buttonInactive += ActivateDoor;
            }
        }
        else
        {
            if (!inverted)
            {
                linkedButton.GetComponent<WallButtonScript>().buttonActive += ActivateDoor;
                linkedButton.GetComponent<WallButtonScript>().buttonInactive += DeactivateDoor;
            }
            else
            {
                linkedButton.GetComponent<WallButtonScript>().buttonActive += DeactivateDoor;
                linkedButton.GetComponent<WallButtonScript>().buttonInactive += ActivateDoor;
            }
        }
        
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
