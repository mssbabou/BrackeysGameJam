using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorButtonScript : MonoBehaviour
{
    public delegate void PlayerOnButton();
    public delegate void PlayerOffButton();

    public PlayerOnButton buttonActive;
    public PlayerOffButton buttonInactive;

    private bool playerOnButton = false;

    [SerializeField]
    private Animator buttonAnimator;
    // Start is called before the first frame update
    void Start()
    {
        buttonActive += buttonDown;
        buttonInactive += buttonUp;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayerOnButton();       
    }

    private void CheckForPlayerOnButton()
    {
        
        
        if (playerOnButton)
        { 
            if(buttonActive != null)
            {
                buttonActive();
            }
        }
        else
        {
            if(buttonInactive != null)
            {
                buttonInactive();
            }          
        }
    }

    private void buttonDown()
    {
        buttonAnimator.SetBool("buttonActive", true);
    }

    private void buttonUp()
    {
        buttonAnimator.SetBool("buttonActive", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerOnButton = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerOnButton = false;
    }


}
