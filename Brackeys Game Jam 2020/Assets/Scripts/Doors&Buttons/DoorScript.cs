using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    [SerializeField]
    private GameObject button;
    [SerializeField]
    Animator doorAnimator;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<ButtonScript>().doorActivation += OpenDoor;
        button.GetComponent<ButtonScript>().doorDeactivation += CloseDoor;
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
