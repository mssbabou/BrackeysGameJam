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
    { if(button.name == "Button")
        {
            button.GetComponent<ButtonScript>().ButtonActivated += OpenDoor;
            button.GetComponent<ButtonScript>().ButtonDeactivated += CloseDoor;
        }
        else if(button.name == "Wall Button")
        {
            button.GetComponent<WallButton>().ButtonActivated += OpenDoor;
            button.GetComponent<WallButton>().ButtonDeactivated += CloseDoor;
        }
        
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
