using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtonScript : MonoBehaviour
{
    public delegate void PlayerActivatedButton();
    public delegate void PlayerDeactivatedButton();

    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite inactiveSprite;
    [SerializeField]
    private Sprite activeSprite;
    

    [SerializeField]
    private bool isActive = false;

    public PlayerActivatedButton buttonActive;
    public PlayerDeactivatedButton buttonInactive;
    
    [SerializeField]
    private Transform playerTransform;

    private Vector2 displacmentFromPlayer;
    private float distanceFromPlayer;
    [SerializeField]
    private float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayerProximity();
    }

    private void CheckForPlayerProximity()
    {
        displacmentFromPlayer = playerTransform.position - transform.position;
        distanceFromPlayer = displacmentFromPlayer.magnitude;
        if (distanceFromPlayer < maxDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleState();
            }
        }
    }

    private void ToggleState()
    {
        if (isActive)
        {
            if(buttonInactive != null)
            {
                buttonInactive();
                isActive = false;
                spriteRenderer.sprite = inactiveSprite;
            }
        }

        else
        {
            if(buttonActive != null)
            {
                buttonActive();
                isActive = true;
                spriteRenderer.sprite = activeSprite;
            }   
        }
    }
}
