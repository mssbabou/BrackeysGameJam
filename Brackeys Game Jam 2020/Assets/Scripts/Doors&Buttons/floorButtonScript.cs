using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorButtonScript : MonoBehaviour
{
    public delegate void PlayerOnButton();
    public delegate void PlayerOffButton();

    public PlayerOnButton buttonActive;
    public PlayerOffButton buttonInactive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayerOnButton();       
    }

    private void CheckForPlayerOnButton()
    {
        if (Physics2D.Raycast(transform.position, Vector2.up, 2f))
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
}
