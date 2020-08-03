using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<ButtonScript>().doorActivation += OpenDoor;
        FindObjectOfType<ButtonScript>().doorDeactivation += CloseDoor;
    }

    private void OpenDoor()
    {
        doorAnimator.SetBool("DoorActive", true);
    }

    private void CloseDoor()
    {
        doorAnimator.SetBool("DoorActive", false);
    }

}
